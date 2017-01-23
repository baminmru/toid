Imports System.Collections.Generic
Imports System.Xml
Imports System.Threading






Public Class Replicator

    Private SiteName As String
    Private LastReplicaDate As Date
    Private LastClientDate As Date

    Public Sub New(ByVal serverSite As String, lastsrvdate As Date, lastclidate As Date)
        SiteName = serverSite
        LastReplicaDate = lastsrvdate
        LastClientDate = lastclidate

    End Sub

    Public Shared rthread As Thread = Nothing
    Public Shared m_DisableNewReplica As Boolean = False
    Public Shared Property DisableNewReplica As Boolean
        Get
            Return m_DisableNewReplica
        End Get
        Set(value As Boolean)
            m_DisableNewReplica = value
            If m_DisableNewReplica = False Then
                Log("Новая репликация разрешена")
            Else
                Log("Новая репликация  заблокирована")
            End If
        End Set
    End Property


    Public Function DoReplica() As Boolean
        If rthread IsNot Nothing Then

            If rthread.IsAlive Then
                Log("Нитка репликатора активна")
                Return False
            End If

            rthread = Nothing
        End If
        If m_DisableNewReplica Then
            Log("Запуск репликации временно заблокирован")
            Return False
        End If
        rthread = New Thread(AddressOf ReplicaThread)
        'rthread.IsBackground = True
        rthread.Start()
        Return True
    End Function

    Public Shared Function ReplicaInProgress() As Boolean
        If rthread IsNot Nothing Then
            If rthread.IsAlive Then Return True
        End If
        Return False
    End Function


    Public Function ReplicaThread() As Boolean
        If Manager Is Nothing Then
            Log("Локальная база уже отключена.")
            Return False
        End If


        If Manager.Site.ToLower() = SiteName.ToLower Then
            Log("Серверная база не может совпадать с текущей. Репликация отключена.")
            Return False
        End If

        If Manager.Connected = False Then
            Log("Локальная база уже отключена.")
            Return False
        End If

        Log("Репликация")

        Dim ReplicaStartTime As DateTime
        Dim srvdt1 As DataTable
        Dim srvdt2 As DataTable
        Dim clidt2 As DataTable
        Dim iCol As Dictionary(Of String, String)
        Dim i As Integer, j As Integer
        Dim iid As String
        Dim sobj As LATIR2.Document.Doc_Base
        Dim drs As LATIR2.Document.Doc_Base
        Dim typename As String, id As System.Guid, name As String
        Dim xdom As System.Xml.XmlDocument
        Dim ServerManager As LATIR2.Manager

        ServerManager = New LATIR2.Manager
        ServerManager.Site = SiteName
        If ServerManager.Session Is Nothing Then
            Log("Сайт сервера  указан неверно, или нет соединения  " & SiteName)
            Return False
        End If

        If ServerManager.Session.Login(username, password) Then

            Log("Вошли на сервер")
            '''''''''''''''''''''''''
            'проводим шаг репликации

            ReplicaStartTime = DateTime.Now




#Region "From client"

            ' на сервер

            Dim lParts As List(Of String)
            Dim spart As String
            iCol = New Dictionary(Of String, String)

            lParts = New List(Of String)
            lParts.Add("to_taskchecks")
            lParts.Add("to_taskcomment")
            lParts.Add("to_taskinfo")

            Try
                SyncLock Manager
                    For Each spart In lParts
                        Dim qry As String
                        qry = "select distinct " & Manager.Base2ID("instanceid") & " from " & spart & " where changestamp >= " & Manager.Date2Const(LastClientDate)
                        clidt2 = Manager.GetData(qry)
                        If clidt2 IsNot Nothing Then


                            For j = 0 To clidt2.Rows.Count - 1
                                iid = clidt2.Rows(j)("instanceid").ToString
                                Try
                                    iCol.Add(iid, iid)
                                Catch ex As Exception
                                    'Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                                End Try

                            Next
                        Else
                            Log(qry)
                        End If
                    Next
                End SyncLock



                SyncLock Manager
                    ' add level 2 part
                    clidt2 = Manager.GetData("select distinct " & Manager.Base2ID("instanceid") & " from to_taskchecks join to_taskcheckcomment on to_taskchecks.to_taskchecksid=to_taskcheckcomment.parentstructrowid  where to_taskcheckcomment.changestamp >= " & Manager.Date2Const(LastClientDate))
                    For j = 0 To clidt2.Rows.Count - 1
                        iid = clidt2.Rows(j)("instanceid").ToString
                        Try
                            iCol.Add(iid, iid)
                        Catch ex As Exception

                        End Try

                    Next
                End SyncLock

            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try

            If iCol.Keys.Count > 0 Then
                Log("Собрано " & iCol.Keys.Count.ToString & " объектов для передачи на сервер")
            End If

            Try

                For Each iid In iCol.Keys
                    If Manager.Connected And ServerManager.Connected Then
                        SyncLock Manager
                            sobj = Manager.GetInstanceObject(New Guid(iid))
                            If Not sobj Is Nothing Then
                                sobj.LockResource(True)
                                xdom = New System.Xml.XmlDocument
                                xdom.LoadXml("<root></root>")
                                sobj.XMLSave(xdom.LastChild, xdom)
                                sobj.UnLockResource()


                                ' save to local database
                                id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)
                                typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
                                name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

                                Log("Client to Server: " + typename + " " + id.ToString + " " + name)

                                drs = ServerManager.GetInstanceObject(id)
                                If drs Is Nothing Then
                                    ServerManager.NewInstance(id, typename, name)
                                End If
                                drs = ServerManager.GetInstanceObject(id)
                                If Not drs Is Nothing Then
                                    drs.LockResource(True)
                                    drs.AutoLoadPart = True
                                    drs.XMLLoad(xdom.LastChild, 0)
                                    drs.BatchUpdate()
                                    drs.UnLockResource()
                                End If
                                ServerManager.FreeInstanceObject(id)
                                xdom = Nothing
                            End If
                        End SyncLock
                    Else
                        GoTo rstop
                    End If


                Next
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try



            Try
                If Manager.Connected And ServerManager.Connected Then

                    ' отсылаем новые картинки
                    Dim qry As String
                    qry = "select fname,filetype,link1part,link1id,link2part,link2id," + Manager.Base2ID("toimg_dataid", "id") + "," + Manager.Base2ID("oper") + " from toimg_data where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and changestamp >= " & Manager.Date2Const(LastClientDate)
                    SyncLock Manager
                        clidt2 = Manager.GetData(qry)
                    End SyncLock
                    If clidt2 IsNot Nothing Then
                        If clidt2.Rows.Count > 0 Then
                            Log("Отсылаем новые картинки на сервер " & clidt2.Rows.Count.ToString)
                        End If
                        For i = 0 To clidt2.Rows.Count - 1
                            srvdt1 = ServerManager.GetData("select * from rawimage where fname='" & clidt2.Rows(i)("fname") & "'  and computername='" & Environment.MachineName.ToLower & "'")
                            If srvdt1.Rows.Count = 0 Then
                                Dim pid As Guid
                                pid = New Guid(clidt2.Rows(i)("id").ToString)
                                ServerManager.GetData("INSERT INTO rawimage(rawimageid,changestamp,computername,fname,filetype,link1part,link1id,link2part,link2id,oper) values (" +
                                ServerManager.ID2Const(pid) + "," & ServerManager.DateFunc() & ",'" + Environment.MachineName.ToLower + "','" + clidt2.Rows(i)("fname").ToString + "','" + clidt2.Rows(i)("filetype").ToString + "','" + clidt2.Rows(i)("link1part").ToString + "','" + clidt2.Rows(i)("link1id").ToString + "','" + clidt2.Rows(i)("link2part").ToString + "','" + clidt2.Rows(i)("link2id").ToString + "'," + ServerManager.ID2Const(New Guid(clidt2.Rows(i)("oper").ToString)) + ")")
                                ServerManager.Provider.LoadFileToField(ServerManager.Connection, GetMyStorePath() & "\" & clidt2.Rows(i)("fname").ToString, "rawimage", "image", pid)
                            End If
                        Next
                    Else
                        Log(qry)
                    End If



                    ' фиксируем удаление картинки
                    clidt2 = Manager.GetData("select fname,filerowid from toimg_todelete where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and changestamp >= " & Manager.Date2Const(LastClientDate))
                    If clidt2.Rows.Count > 0 Then
                        Log("Удаление картинки на сервере " & clidt2.Rows.Count.ToString)
                    End If
                    For i = 0 To clidt2.Rows.Count - 1
                        ServerManager.GetData("delete from rawimage where fname='" & clidt2.Rows(i)("fname") & "' and rawimageid=" & ServerManager.ID2Const(New Guid(clidt2.Rows(i)("filerowid").ToString)))
                    Next
                Else
                    GoTo rstop
                End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try


            Try
                '  посылаем системные комментарии в общий справочник

                If MyGlobalComments IsNot Nothing Then
                    If MyGlobalComments.Count > 0 Then
                        If Manager.Connected And ServerManager.Connected Then
                            Log("Отсылка комментариев на сервер " & MyGlobalComments.Count.ToString)
                            Dim dict As tod.tod.Application
                            Dim bug As tod.tod.tod_bug
                            Dim sc As SystemComment
                            Dim pc As List(Of SystemComment)
                            pc = New List(Of SystemComment)
                            srvdt1 = ServerManager.GetData("SELECT distinct instanceid FROM v_autotod_bug")
                            dict = ServerManager.GetInstanceObject(New Guid(srvdt1.Rows(0)("instanceid").ToString))
                            For i = 0 To MyGlobalComments.Count - 1
                                sc = MyGlobalComments(i)
                                srvdt1 = ServerManager.GetData("SELECT * FROM v_autotod_bug where tod_bug_the_system_id='" & LATIR2.Utils.GUID2String(sc.SystemID) & "' and by tod_bug_name='" & sc.Comment & "'")
                                If srvdt1.Rows.Count = 0 Then
                                    bug = dict.tod_bug.Add
                                    bug.the_comment = sc.Comment
                                    bug.name = sc.Comment
                                    bug.the_system = dict.tod_system.Item(sc.SystemID)
                                    bug.Save()
                                End If
                                pc.Add(sc)
                            Next
                            For i = 0 To pc.Count - 1
                                MyGlobalComments.Remove(pc(i))
                            Next
                            pc.Clear()
                            pc = Nothing
                            If MyGlobalComments.Count > 0 Then
                                Log("Отсылка комментариев на сервер, осталось: " & MyGlobalComments.Count.ToString)
                            Else
                                Log("Все отосланы")
                            End If
                        Else
                            GoTo rstop
                        End If
                    End If
                End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try



            Try
                '  посылаем данные о зарегистрированных метках

                If RegistedTags IsNot Nothing Then
                    If RegistedTags.Count > 0 Then
                        If Manager.Connected And ServerManager.Connected Then
                            SyncLock RegistedTags
                                Log("Отсылка меток на сервер " & RegistedTags.Count.ToString)


                                Dim sc As SystemComment
                                Dim pc As List(Of SystemComment)
                                pc = New List(Of SystemComment)
                                For Each sc In RegistedTags
                                    Try
                                        Log("Отсылка метки " & sc.Comment)
                                        ServerManager.GetData("update to_cardchecks set changestamp =" & ServerManager.Provider.DateFunc() & ", tagid='" & LATIR2.Utils.GUID2String(New Guid(sc.Comment)) & "' where to_cardchecksid=" & Manager.ID2Const(sc.SystemID))
                                        pc.Add(sc)
                                    Catch ex As Exception
                                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                                    End Try

                                Next
                                For i = 0 To pc.Count - 1
                                    RegistedTags.Remove(pc(i))
                                Next
                                pc.Clear()
                                pc = Nothing

                                If RegistedTags.Count > 0 Then
                                    Log("Отсылка меток на сервер, осталось: " & RegistedTags.Count.ToString)
                                Else
                                    Log("Все отосланы")
                                End If
                            End SyncLock
                        Else
                            GoTo rstop
                        End If
                    End If
                    End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try
#End Region



#Region "From server"


            iCol.Clear()

            iCol = New Dictionary(Of String, String)
            ' 'mtzusers','toimg','tod','tosched','totrn','totask','tocard','toop','tor'

            Try

                If Manager.Connected And ServerManager.Connected Then
                    If GetSetting("LATIR4", "CFG", "LOADTOTRN", "false") = "false" Then
                        srvdt1 = ServerManager.GetData("select part.name pname, objecttype.name tname from part join objecttype On objecttype.objecttypeid=part.parentstructrowid  where  part.parentrowid is null and objecttype.name  in ('mtzusers','tod','tosched','tocard','toop')")
                    Else
                        srvdt1 = ServerManager.GetData("select part.name pname, objecttype.name tname from part join objecttype On objecttype.objecttypeid=part.parentstructrowid  where  part.parentrowid is null and objecttype.name  in ('mtzusers','tod','tosched','totrn','tocard','toop')")
                    End If
                Else
                    GoTo rstop
                End If


                ' удаление из структур
                For i = 0 To srvdt1.Rows.Count - 1
                    If Manager.Connected And ServerManager.Connected Then
                        srvdt2 = ServerManager.GetData("select * from syslog where verb like 'DELTEROW' and logstructid='" & srvdt1.Rows(i)("pname") & "' and  changestamp >= " & ServerManager.Date2Const(LastReplicaDate) & " order by changestamp")
                        If srvdt2.Rows.Count > 0 Then
                            Log("Удаление строк по команде с сервера. Раздел: " & srvdt1.Rows(i)("pname").ToString)
                        End If
                        For j = 0 To srvdt2.Rows.Count - 1
                            iid = srvdt2.Rows(j)("the_resource").ToString
                            Try
                                Manager.GetData("delete from " & srvdt1.Rows(i)("pname").ToString & " where " & srvdt1.Rows(i)("pname").ToString() & "id=" & Manager.ID2Const(New Guid(iid)))
                            Catch ex As Exception
                                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                            End Try

                        Next
                    Else
                        GoTo rstop
                    End If
                Next

                If Manager.Connected And ServerManager.Connected Then
                    srvdt2 = ServerManager.GetData("select * from syslog where verb like 'DELETE' and logstructid in ('tod','tosched','totrn','tocard','toop') and  changestamp >= " & ServerManager.Date2Const(LastReplicaDate) & " order by changestamp")
                    If srvdt2.Rows.Count > 0 Then
                        Log("Удаление документов по команде с сервера. Тип: " & srvdt2.Rows(j)("logstructid").ToString)
                    End If
                    For j = 0 To srvdt2.Rows.Count - 1
                        iid = srvdt2.Rows(j)("the_resource").ToString
                        Try
                            Manager.GetData(" Call instance_delete('" & LATIR2.Utils.GUID2String(Manager.Session.SessionID) & "','" & LATIR2.Utils.GUID2String(New Guid(iid)) & "');")

                        Catch ex As Exception
                            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                        End Try

                        Try
                            Manager.GetData("delete from instance where instanceid=" & Manager.ID2Const(New Guid(iid)))
                        Catch ex As Exception
                            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                        End Try


                    Next
                Else
                    GoTo rstop
                End If


                If Manager.Connected And ServerManager.Connected Then
                    ' сборка измененных объектов
                    For i = 0 To srvdt1.Rows.Count - 1
                        srvdt2 = ServerManager.GetData("select distinct " & ServerManager.Base2ID("instanceid") & " from " & srvdt1.Rows(i)("pname") & " where changestamp >= " & ServerManager.Date2Const(LastReplicaDate))
                        For j = 0 To srvdt2.Rows.Count - 1
                            iid = srvdt2.Rows(j)("instanceid").ToString
                            Try
                                iCol.Add(iid, iid)
                            Catch ex As Exception
                                ' Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                            End Try

                        Next
                    Next
                Else
                    GoTo rstop
                End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try

            If iCol.Keys.Count > 0 Then
                Log("Изменено объектов на сервере: " & iCol.Keys.Count.ToString())


            End If


            Try

                For Each iid In iCol.Keys
                    If Manager.Connected And ServerManager.Connected Then
                        sobj = ServerManager.GetInstanceObject(New Guid(iid))
                        If Not sobj Is Nothing Then
                            sobj.LockResource(True)
                            xdom = New System.Xml.XmlDocument
                            xdom.LoadXml("<root></root>")
                            sobj.XMLSave(xdom.LastChild, xdom)
                            sobj.UnLockResource()
                            ServerManager.FreeInstanceObject(sobj.ID)

                            ' save to local database
                            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)
                            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
                            name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

                            Log("Server to client: " + typename + " " + id.ToString + " " + name)

                            SyncLock Manager
                                drs = Manager.GetInstanceObject(id)
                                If drs Is Nothing Then
                                    drs = Manager.NewInstance(id, typename, name)
                                End If


                                If Not drs Is Nothing Then
                                    drs.LockResource(True)
                                    drs.AutoLoadPart = True
                                    drs.XMLLoad(xdom.LastChild, 0)
                                    drs.BatchUpdate()
                                    drs.UnLockResource()
                                End If
                                xdom = Nothing
                            End SyncLock
                        End If
                    Else
                        GoTo rstop
                    End If
                Next

            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try




            ' проверяем нет ли "потеряных" задач

            iCol = New Dictionary(Of String, String)
            ' собираем список всех задач
            Try
                If Manager.Connected And ServerManager.Connected Then
                    srvdt2 = ServerManager.GetData("select distinct " & ServerManager.Base2ID("instanceid") & " from to_taskinfo where oper=" & ServerManager.ID2Const(SrvGetOper(ServerManager).ID))
                    For j = 0 To srvdt2.Rows.Count - 1
                        iid = New Guid(srvdt2.Rows(j)("instanceid").ToString).ToString()
                        Try
                            iCol.Add(iid, iid)
                        Catch ex As Exception

                        End Try

                    Next
                Else
                    GoTo rstop
                End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try



            Try
                If Manager.Connected And ServerManager.Connected Then
                    SyncLock Manager
                        srvdt1 = Manager.GetData("select distinct " & Manager.Base2ID("instanceid") & " from to_taskinfo where oper=" & Manager.ID2Const(GetOper().ID))
                    End SyncLock

                    For j = 0 To srvdt1.Rows.Count - 1
                        iid = New Guid(srvdt1.Rows(j)("instanceid").ToString).ToString()
                        If iCol.ContainsKey(iid) Then
                            Try
                                iCol.Remove(iid)
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                Else
                    GoTo rstop
                End If

            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try


            Try
                If iCol.Keys.Count > 0 Then
                    Log("отсылаем задачи с сервера на планшет " & iCol.Keys.Count.ToString)
                End If
                ' отсылаем задачи с сервера на планшет, если их нет для нашего оператора

                For Each iid In iCol.Keys
                    If Manager.Connected And ServerManager.Connected Then
                        sobj = ServerManager.GetInstanceObject(New Guid(iid))
                        If Not sobj Is Nothing Then
                            sobj.LockResource(True)
                            xdom = New System.Xml.XmlDocument
                            xdom.LoadXml("<root></root>")
                            sobj.XMLSave(xdom.LastChild, xdom)
                            sobj.UnLockResource()
                            ServerManager.FreeInstanceObject(sobj.ID)

                            ' save to local database
                            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)
                            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
                            name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

                            Log("Server to client (lost task): " + typename + " " + id.ToString + " " + name)
                            SyncLock Manager
                                drs = Manager.GetInstanceObject(id)
                                If drs Is Nothing Then
                                    Manager.NewInstance(id, typename, name)
                                End If

                                drs = Manager.GetInstanceObject(id)
                                If Not drs Is Nothing Then
                                    drs.LockResource(True)
                                    drs.AutoLoadPart = True
                                    drs.XMLLoad(xdom.LastChild, 0)
                                    drs.BatchUpdate()
                                    drs.UnLockResource()
                                End If
                            End SyncLock
                            xdom = Nothing
                        End If
                    Else
                        GoTo rstop
                    End If
                Next

            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try


            Try

                If Manager.Connected And ServerManager.Connected Then
                    ' подгружаем картинки с сервера обратно к себе
                    'srvdt1 = ServerManager.GetData("select " & ServerManager.Base2ID("rawimageid", "id") & ",fname,filetype,link1part,link1id,link2part,link2id," & ServerManager.Base2ID("oper") & " from rawimage where computername <> '" & Environment.MachineName.ToLower & "' and changestamp >= " & ServerManager.Date2Const(LastReplicaDate))
                    srvdt1 = ServerManager.GetData("select " & ServerManager.Base2ID("rawimageid", "id") & ",fname,filetype,link1part,link1id,link2part,link2id," & ServerManager.Base2ID("oper") & " from rawimage where changestamp >= " & ServerManager.Date2Const(LastReplicaDate))

                    If srvdt1.Rows.Count > 0 Then
                        Log("подгружаем картинки с сервера " & srvdt1.Rows.Count.ToString)
                    End If

                    For i = 0 To srvdt1.Rows.Count - 1
                        Dim pid As Guid
                        pid = New Guid(srvdt1.Rows(i)("id").ToString)
                        clidt2 = ServerManager.GetData("select * from toimg_data where fname='" & srvdt1.Rows(i)("fname") & "'  and toimg_dataid=" & Manager.ID2Const(pid))

                        SyncLock Manager

                            ' если нет записи о файле в хранилище, создаем запись в  локальной базе данных
                            If clidt2.Rows.Count = 0 Then
                                Manager.GetData("INSERT INTO toimg_data(instanceid,toimg_dataid,changestamp,fname,filetype,link1part,link1id,link2part,link2id,oper) values (" +
                                Manager.ID2Const(GetMyStore().ID) & "," & Manager.ID2Const(pid) & "," & Manager.Date2Const(LastClientDate.AddHours(-1)) & ",'" + srvdt1.Rows(i)("fname").ToString + "','" + srvdt1.Rows(i)("filetype").ToString + "','" + srvdt1.Rows(i)("link1part").ToString + "','" + srvdt1.Rows(i)("link1id").ToString + "','" + srvdt1.Rows(i)("link2part").ToString + "','" + srvdt1.Rows(i)("link2id").ToString + "'," + Manager.ID2Const(New Guid(srvdt1.Rows(i)("oper").ToString)) + ")")
                            End If
                        End SyncLock

                        ' если файла нет в хранилище допихиваем его
                        If IO.File.Exists(GetMyStorePath() & "\" & srvdt1.Rows(i)("fname").ToString) = False Then
                            ' получаем файл с сервера и кладем его в локальное хранилище
                            ServerManager.Provider.SaveFileFromField(ServerManager.Connection, GetMyStorePath() & "\" & srvdt1.Rows(i)("fname").ToString, "rawimage", "image", pid)
                        End If
                    Next
                Else
                    GoTo rstop
                End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try






#End Region

            Log("Регистрация дат: " & ReplicaStartTime.ToString())
            Try
                If Manager.Connected And ServerManager.Connected Then
                    SyncLock Manager
                        Manager.GetData("update tor_info set serverdata =" & Manager.Date2Const(ReplicaStartTime) & " where name='" & Environment.MachineName.ToLower() & "'")
                        Manager.GetData("update tor_info set clientdata = " & Manager.Date2Const(ReplicaStartTime) & " where name='" & Environment.MachineName.ToLower() & "'")
                    End SyncLock
                Else
                    GoTo rstop
                End If
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try
rstop:
            Log("Отключение от сервера")
            Try
                ServerManager.Session.Logout()
                ServerManager.Close()
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try


            Log("Репликация завершена успешно ")
            Return True
        End If

        Try
            ServerManager.Close()
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

        Log("Репликация завершена с ошибкой")
        Return False

    End Function



    Private Function Pass2LocalBase(sobj As LATIR2.Document.Doc_Base) As Boolean
        Dim drs As LATIR2.Document.Doc_Base
        Dim typename As String, id As System.Guid, name As String
        Dim xdom As System.Xml.XmlDocument
        If Not sobj Is Nothing Then
            Log("Собираем XML  задачи")
            sobj.LockResource(True)
            xdom = New System.Xml.XmlDocument
            xdom.LoadXml("<root></root>")
            sobj.XMLSave(xdom.LastChild, xdom)
            sobj.UnLockResource()


            Log("Переносим в локальную базу XML задачи")
            ' save to local database
            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)
            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
            name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

            If Manager IsNot Nothing Then
                drs = Manager.GetInstanceObject(id)
                If drs Is Nothing Then
                    Manager.NewInstance(id, typename, name)
                End If
                drs = Manager.GetInstanceObject(id)
                If Not drs Is Nothing Then
                    drs.LockResource(True)
                    drs.AutoLoadPart = True
                    drs.XMLLoad(xdom.LastChild, 0)
                    drs.BatchUpdate()
                    drs.UnLockResource()
                    Log("Перенос завершен")
                    Return True
                End If
                xdom = Nothing
            Else
                Log("Соединение с локальной базой закрыто ... невозможно перенести задачу")
            End If
        End If

        Return False
    End Function


    Public Function DelegateTask(tsk As totask.totask.Application, ByVal NewOper As String) As Boolean

        Dim ServerManager As LATIR2.Manager
        Log("Создание задачи на сервере " & SiteName)
        ServerManager = New LATIR2.Manager
        ServerManager.Site = SiteName
        If ServerManager.Session Is Nothing Then
            Log("Неверное имя  базы сервера " & SiteName)
            Return False
        End If
        If ServerManager.Session.Login(username, password) Then
            Log("Вход на сервер как " & username)



            Dim ti As totask.totask.to_taskinfo = Nothing
            If Manager.Connected And ServerManager.Connected Then
                Try

                    ti = tsk.to_taskinfo.Item(1)
                    ti.oper = tsk.FindRowObject("to_oper", New Guid(NewOper))
                    ti.Save()
                    Log("Сохранение задачи в локальной базе")
                Catch ex As Exception
                    Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                End Try

                Dim tsched As tosched.tosched.Application
                Dim tsi As tosched.tosched.to_scheditems
                Dim dt As DataTable

                dt = ServerManager.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(ti.themachine.ID) & "'")
                If dt.Rows.Count = 1 Then
                    Try
                        tsched = ServerManager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
                        tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(ti.themachine.ID))
                        tsi.oper = tsched.FindRowObject("to_oper", New Guid(NewOper))
                        tsi.Save()
                        Log("Сохранение пункта расписания на сервере")
                    Catch ex As Exception
                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try
                    ServerManager.Close()
                    Return True
                End If
            End If


        End If
        ServerManager.Close()
        Return False

    End Function



    Public Function ChangePassword(ByVal MyLogin As String, ByVal NewPass As String) As Boolean

        Dim ServerManager As LATIR2.Manager
        ServerManager = New LATIR2.Manager
        ServerManager.Site = SiteName
        If ServerManager.Session Is Nothing Then
            Log("Неверное имя  базы сервера " & SiteName)
            Return False
        End If
        If ServerManager.Session.Login(username, password) Then
            Log("Вход на сервер как " & username)



            Dim ti As totask.totask.to_taskinfo = Nothing
            If Manager.Connected And ServerManager.Connected Then
                Log("Смена пароля для логина: " & MyLogin)
                ServerManager.GetData("update users set changestamp=" & ServerManager.DateFunc() & ",password='" & NewPass & "' where login='" & MyLogin & "'")
                Manager.GetData("update users set  changestamp=" & Manager.DateFunc() & ", password='" & NewPass & "' where login='" & MyLogin & "'")
                ServerManager.Close()
                Return True
            End If


        End If
        ServerManager.Close()
        Return False

    End Function

    'Private NtShedID As String
    'Private NtResult As Boolean

    'Private Sub CreateNewTask()
    '    Dim ServerManager As LATIR2.Manager
    '    Log("Создание задачи на сервере " & SiteName)
    '    ServerManager = New LATIR2.Manager
    '    ServerManager.Site = SiteName
    '    If ServerManager.Session Is Nothing Then
    '        Log("Неверное имя  базы сервера " & SiteName)
    '        NtResult = False
    '        Return
    '    End If
    '    If ServerManager.Session.Login(username, password) Then
    '        Log("Вход на сеервер как " & username)
    '        Dim dt As DataTable
    '        Dim dtcard As DataTable
    '        dt = ServerManager.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(New Guid(ShedID)) & "'")
    '        If dt.Rows.Count = 1 Then

    '            Dim tsched As tosched.tosched.Application
    '            Dim tsi As tosched.tosched.to_scheditems
    '            tsched = ServerManager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
    '            tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(New Guid(NtShedID)))
    '            If Not tsi Is Nothing Then
    '                Log("Найден пункт расписания ")
    '                Dim nid As Guid
    '                Dim tsk As totask.totask.Application
    '                Dim tcard As tocard.tocard.Application

    '                If Not tsi.oper Is Nothing Then
    '                    Log("Задача свободна ")
    '                    dtcard = ServerManager.GetData("select instanceid from v_autoto_taskinfo where to_taskinfo_themachine_id='" & dt.Rows(0)("id") & "'")
    '                    If dtcard.Rows.Count > 0 Then
    '                        tsk = ServerManager.GetInstanceObject(New Guid(dtcard.Rows(0)("instanceid").ToString()))
    '                        If tsk.to_taskinfo.Item(1).oper Is GetOper() Then
    '                            ServerManager.Close()
    '                            Log("Задача уже взята в работу текущим оператором")
    '                            NtResult = True
    '                            Return
    '                        Else
    '                            NtResult = False
    '                            Return
    '                        End If

    '                    End If
    '                    ServerManager.Close()
    '                    Log("Задача закреплена за другим оператором")
    '                    NtResult = False
    '                    Return
    '                End If

    '                tsi.oper = GetOper()

    '                tsi.checkin = DateTime.Now
    '                tsi.Save()
    '                Log("Оператор задачи зафиксирован в расписании")


    '                nid = Guid.NewGuid

    '                Log("Создаем задачу на сервере")
    '                tsk = ServerManager.NewInstance(nid, "totask", dt.Rows(0)("to_scheditems_themachine").ToString)
    '                If Not tsk Is Nothing Then

    '                    Dim mid As String
    '                    mid = dt.Rows(0)("to_scheditems_themachine_id")

    '                    Log("Ищем карту диагностики на сервере")
    '                    dtcard = ServerManager.GetData("select instanceid from v_autoto_cardinfo where to_cardinfo_the_machine_id='" & mid & "' and to_cardinfo_card_archived_val=0")
    '                    If dtcard.Rows.Count >= 0 Then

    '                        tcard = ServerManager.GetInstanceObject(New Guid(dtcard.Rows(0)("instanceid").ToString()))

    '                        If Not tcard Is Nothing Then
    '                            Log("Нашли карту диагностики на сервере")
    '                            Dim ti As totask.totask.to_taskinfo
    '                            ti = tsk.to_taskinfo.Add()
    '                            ti.themachine = tsi
    '                            ti.thecard = tcard.to_cardinfo.Item(1)
    '                            ti.crdate = Date.Now
    '                            ti.taskfinished = totask.totask.enumBoolean.Boolean_Net
    '                            'ti.finishtime = Date.MinValue
    '                            ti.oper = GetOper()
    '                            ti.Save()
    '                            Log("Заголовок задачи создан на сервере")


    '                            Dim i As Integer
    '                            Dim tchk As totask.totask.to_taskchecks
    '                            'Dim cardcheck As tocard.tocard.to_cardchecks
    '                            For i = 1 To tcard.to_cardchecks.Count
    '                                Log("Проверка №" & i.ToString & " создана на сервере")
    '                                tchk = tsk.to_taskchecks.Add()
    '                                tchk.checkref = tcard.to_cardchecks.Item(i)
    '                                tchk.the_check = tcard.to_cardchecks.Item(i).the_check
    '                                tchk.the_system = tcard.to_cardchecks.Item(i).the_system
    '                                tchk.thesubsystem = tcard.to_cardchecks.Item(i).thesubsystem
    '                                tchk.valuetype = tcard.to_cardchecks.Item(i).valuetype
    '                                tchk.lowvalue = tcard.to_cardchecks.Item(i).lowvalue
    '                                tchk.hivalue = tcard.to_cardchecks.Item(i).hivalue
    '                                tchk.the_comment = tcard.to_cardchecks.Item(i).the_comment
    '                                tchk.the_doc = tcard.to_cardchecks.Item(i).the_doc
    '                                tchk.Save()
    '                            Next

    '                            Log("Строки проверок созданы на сервере (" & tsk.to_taskchecks.Count.ToString & ")")
    '                            Log("Задача создана")
    '                            Log("Копируем в локальную базу")
    '                            Pass2LocalBase(tsk)

    '                            ServerManager.Close()

    '                            NtResult = True
    '                            Return

    '                        End If
    '                    End If

    '                End If

    '            End If
    '        Else
    '            Manager.GetData("delete from to_scheditems where to_scheditemsid=" & Manager.ID2Const(New Guid(ShedID)))
    '            Log("На сервере нет такой задачи.")

    '            NtResult = False
    '            Return
    '        End If
    '    End If
    '    ServerManager.Close()
    '    NtResult = False
    '    Return
    'End Sub

    Public Function BuildNewTask(ByVal ShedID As String) As Boolean
        Dim ServerManager As LATIR2.Manager
        Log("Создание задачи на сервере " & SiteName)
        ServerManager = New LATIR2.Manager
        ServerManager.Site = SiteName
        If ServerManager.Session Is Nothing Then
            Log("Неверное имя  базы сервера " & SiteName)
            Return False
        End If
        If ServerManager.Session.Login(username, password) Then
            Log("Вход на сеервер как " & username)
            Dim dt As DataTable
            Dim dtcard As DataTable
            dt = ServerManager.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(New Guid(ShedID)) & "'")
            If dt.Rows.Count = 1 Then

                Dim tsched As tosched.tosched.Application
                Dim tsi As tosched.tosched.to_scheditems
                tsched = ServerManager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
                tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(New Guid(ShedID)))
                If Not tsi Is Nothing Then
                    Log("Найден пункт расписания ")
                    Dim nid As Guid
                    Dim tsk As totask.totask.Application
                    Dim tcard As tocard.tocard.Application

                    If Not tsi.oper Is Nothing Then
                        Log("Задача свободна ")
                        dtcard = ServerManager.GetData("select instanceid from v_autoto_taskinfo where to_taskinfo_themachine_id='" & dt.Rows(0)("id") & "'")
                        If dtcard.Rows.Count > 0 Then
                            tsk = ServerManager.GetInstanceObject(New Guid(dtcard.Rows(0)("instanceid").ToString()))
                            If tsk.to_taskinfo.Item(1).oper Is GetOper() Then
                                ServerManager.Close()
                                Log("Задача уже взята в работу текущим оператором")
                                Return True
                            Else
                                MsgBox("Задача закреплена за другим оператором")
                            End If

                        End If
                        ServerManager.Close()
                        Log("Задача закреплена за другим оператором")
                        Return False
                    End If

                    tsi.oper = GetOper()

                    tsi.checkin = DateTime.Now
                    tsi.Save()
                    Log("Оператор задачи зафиксирован в расписании")


                    nid = Guid.NewGuid

                    Log("Создаем задачу на сервере")
                    tsk = ServerManager.NewInstance(nid, "totask", dt.Rows(0)("to_scheditems_themachine").ToString)
                    If Not tsk Is Nothing Then

                        Dim mid As String
                        mid = dt.Rows(0)("to_scheditems_themachine_id")

                        Log("Ищем карту диагностики на сервере")
                        dtcard = ServerManager.GetData("select instanceid from v_autoto_cardinfo where to_cardinfo_the_machine_id='" & mid & "' and to_cardinfo_card_archived_val=0")
                        If dtcard.Rows.Count >= 0 Then

                            tcard = ServerManager.GetInstanceObject(New Guid(dtcard.Rows(0)("instanceid").ToString()))

                            If Not tcard Is Nothing Then
                                Log("Нашли карту диагностики на сервере")
                                Dim ti As totask.totask.to_taskinfo
                                ti = tsk.to_taskinfo.Add()
                                ti.themachine = tsi
                                ti.thecard = tcard.to_cardinfo.Item(1)
                                ti.crdate = Date.Now
                                ti.taskfinished = totask.totask.enumBoolean.Boolean_Net
                                'ti.finishtime = Date.MinValue
                                ti.oper = GetOper()
                                ti.Save()
                                Log("Заголовок задачи создан на сервере")


                                Dim i As Integer
                                Dim tchk As totask.totask.to_taskchecks
                                'Dim cardcheck As tocard.tocard.to_cardchecks
                                For i = 1 To tcard.to_cardchecks.Count
                                    Log("Проверка №" & i.ToString & " из (" & tcard.to_cardchecks.Count.ToString() & ") создана на сервере")
                                    tchk = tsk.to_taskchecks.Add()
                                    tchk.checkref = tcard.to_cardchecks.Item(i)
                                    tchk.the_check = tcard.to_cardchecks.Item(i).the_check
                                    tchk.the_system = tcard.to_cardchecks.Item(i).the_system
                                    tchk.thesubsystem = tcard.to_cardchecks.Item(i).thesubsystem
                                    tchk.valuetype = tcard.to_cardchecks.Item(i).valuetype
                                    tchk.lowvalue = tcard.to_cardchecks.Item(i).lowvalue
                                    tchk.hivalue = tcard.to_cardchecks.Item(i).hivalue
                                    tchk.the_comment = tcard.to_cardchecks.Item(i).the_comment
                                    tchk.the_doc = tcard.to_cardchecks.Item(i).the_doc
                                    tchk.Save()
                                Next

                                Log("Строки проверок созданы на сервере (" & tsk.to_taskchecks.Count.ToString & ")")
                                Log("Задача создана")
                                Log("Копируем в локальную базу")
                                Pass2LocalBase(tsk)

                                ServerManager.Close()

                                Return True

                            End If
                        End If

                    End If

                End If
            Else
                Manager.GetData("delete from to_scheditems where to_scheditemsid=" & Manager.ID2Const(New Guid(ShedID)))
                Log("На сервере нет такой задачи.")
                MsgBox("Ошибка. На сервере нет такой задачи.")
                Return False
            End If
        End If
        ServerManager.Close()
        Log("Нет связи с сервером. Невозможно взять задачу на исполнение.")
        MsgBox("Нет связи с сервером. Невозможно взять задачу на исполнение.")
        Return False
    End Function




    Public Function CloseTask(ByVal ShedID As String) As Boolean
        Dim ServerManager As LATIR2.Manager
        Log("Завершение задачи")
        ServerManager = New LATIR2.Manager
        ServerManager.Site = SiteName
        If ServerManager.Session Is Nothing Then
            Log("Неверное имя  базы сервера " & SiteName)
            Return False
        End If
        If ServerManager.Session.Login(username, password) Then
            Dim dt As DataTable
            dt = ServerManager.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(New Guid(ShedID)) & "'")
            If dt.Rows.Count = 1 Then

                Dim tsched As tosched.tosched.Application
                Dim tsi As tosched.tosched.to_scheditems
                tsched = ServerManager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
                tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(New Guid(ShedID)))
                If Not tsi Is Nothing Then

                    tsi.finishdate = DateTime.Now
                    tsi.isdone = tosched.tosched.enumBoolean.Boolean_Da
                    tsi.Save()
                    ServerManager.Close()
                    Log("Задача на сервере завершена")
                    Return True

                End If
            End If
            Log("Задача на сервере не найдена")
            ServerManager.Close()
        End If
        Log("Нет связи с сервером. Невозможно закрыть задачу.")
        MsgBox("Нет связи с сервером. Невозможно закрыть задачу.")
        Return False
    End Function




    Private Function SrvGetOper(ByRef ServerManager As LATIR2.Manager) As toop.toop.to_oper

        Dim dt As DataTable
        Dim id As String
        Dim op As toop.toop.Application
        dt = ServerManager.GetData("select distinct " & ServerManager.Base2ID("to_oper.instanceid", "ID") & "  from to_oper join users on to_oper.login =users.login join the_session on the_session.usersid =users.usersid where the_session.the_sessionid=" & ServerManager.ID2Const(ServerManager.Session.SessionID))

        If dt.Rows.Count > 0 Then
            id = dt.Rows(0)("ID").ToString
            op = ServerManager.GetInstanceObject(New Guid(id))
            Return op.to_oper.Item(1)
        End If
        Return Nothing
    End Function


End Class
