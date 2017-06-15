Imports gPic

Public Class frmTaskSystem

    Private WithEvents mynfc As NFC
    Public tsk As totask.totask.Application
    Public TaskInstID As Guid
    Public StID As Guid
    Public SysID As Guid
    Public StName As String
    Private myresizer As New LATIR2GuiManager.Resizer

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Timer1.Enabled = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private lgi As List(Of gPic.GaleryItem)
    Public Sub ReloadGalery()
        Try


            ImageGallery1.TextColor = Color.Orange
            Dim sPath As String
            sPath = GetMyStorePath()
            Dim dt As DataTable, dt2 As DataTable
            lblText.Text = "ТО:" + StName

            dt = Manager.GetData("select tod_system_name, v_autotod_system.id, to_taskchecks_thesubsystem, v_autoto_taskchecks.id cid, ifnull(to_taskchecks_thevalue,'') val from v_autotod_system  " +
            " Join v_autoto_taskchecks on v_autotod_system.id=v_autoto_taskchecks.to_taskchecks_the_system_id  " +
            " where v_autoto_taskchecks.instanceid ='" + LATIR2.Utils.GUID2String(TaskInstID) + "' order by tod_system_name,to_taskchecks_thesubsystem ")



            Dim i As Integer
            Dim gi As gPic.GaleryItem = Nothing

            tsk = Manager.GetInstanceObject(TaskInstID)
            lgi = New List(Of gPic.GaleryItem)

            Dim prevSys As String = ""
            Dim vCnt As Integer = 0
            Dim j As Integer
            Dim lastStid As String = ""
            Dim s As String = ""
            Dim gcnt As Integer = 0

            For i = 0 To dt.Rows.Count - 1
                If prevSys <> dt.Rows(i)("tod_system_name") Then
                    If Not gi Is Nothing Then


                        gi.Name = s
                        If vCnt > 0 Then
                            gi.PrcValue = 100 * gcnt / vCnt
                        End If
                        gcnt = 0
                        vCnt = 0
                        s = ""
                    End If


                    prevSys = dt.Rows(i)("tod_system_name")
                    gi = New gPic.GaleryItem
                    gi.ID = New Guid(dt.Rows(i)("id").ToString)
                    s = dt.Rows(i)("tod_system_name").ToString() & "\" & dt.Rows(i)("to_taskchecks_thesubsystem")

                    Dim q As String
                    q = "select fname from  toimg_data  where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and toimg_data.link2id ='" & LATIR2.Utils.GUID2String(StID) & "' And toimg_data.link2part='tod_st' And toimg_data.link1part ='tod_system' and toimg_data.link1id='" & LATIR2.Utils.GUID2String(gi.ID) & "' order by changestamp desc"
                    dt2 = Manager.GetData(q)
                    If dt2.Rows.Count > 0 Then
                        If IO.File.Exists(sPath & "\" & dt2.Rows(0)("fname")) Then
                            gi.FilePath = sPath & "\" & dt2.Rows(0)("fname")
                        Else
                            gi.FilePath = sPath & "\nophoto.jpg"
                        End If
                    Else
                        gi.FilePath = sPath & "\nophoto.jpg"
                    End If


                    gi.Name = s
                    gi.PrcVisible = True
                    gi.PrcValue = 0
                    gi.CustomInfo = LATIR2.Utils.GUID2String(StID) & "|" & LATIR2.Utils.GUID2String(gi.ID)
                    gi.Tag = dt.Rows(i)("tod_system_name").ToString()
                    lgi.Add(gi)

                    If dt.Rows(i)("val") <> "" Then
                        gcnt += 1
                    End If
                    vCnt += 1
                Else
                    If dt.Rows(i)("val") <> "" Then
                        gcnt += 1
                    End If
                    vCnt += 1
                    If s.IndexOf(dt.Rows(i)("to_taskchecks_thesubsystem")) < 0 Then
                        If s <> "" Then
                            s = s & "; "
                        End If
                        s = s & dt.Rows(i)("to_taskchecks_thesubsystem")
                    End If

                End If
            Next

            If Not gi Is Nothing Then
                gi.Name = s
                If vCnt > 0 Then
                    gi.PrcValue = 100 * gcnt / vCnt
                End If

            End If

            Dim rect As Rectangle
            rect = Screen.PrimaryScreen.WorkingArea

            Me.ImageGallery1.PGap = 10

            If lgi.Count > 12 Then
                Me.ImageGallery1.PicHeight = (rect.Height - 120) / 3
                Me.ImageGallery1.PicWidth = (rect.Width - 120) / 4
            Else
                Me.ImageGallery1.PicHeight = (rect.Height - 90) / 3
                Me.ImageGallery1.PicWidth = (rect.Width - 55) / 4
            End If
            ImageGallery1.DrawItems(lgi)
            Timer1.Enabled = True

        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub frmTaskSystem_Load(sender As Object, e As EventArgs) Handles Me.Load
        myresizer = New LATIR2GuiManager.Resizer
        myresizer.FindAllControls(Me)
        InitNFC()
        mynfc = NFCReader
        ReloadGalery()

        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)


    End Sub

    Private Sub ImageGallery1_ImageClick(ByRef Item As GaleryItem) Handles ImageGallery1.ImageClick
        Try
            Dim f As frmSystemTO
            f = New frmSystemTO
            f.tsk = tsk
            f.SysName = "Группа: " & Item.Tag.ToString
            f.StName = StName
            f.StID = StID
            f.SysID = Item.ID
            f.TagID = TagID
            f.GaleryForm = Me
            Timer1.Enabled = False
            f.ShowDialog()
            Timer1.Enabled = True
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub

    Private Sub cmdDone_Click(sender As Object, e As EventArgs) Handles cmdDone.Click
        Dim tdef As totask.totask.to_taskinfo
        tdef = tsk.to_taskinfo.Item(1)
        Dim chk As totask.totask.to_taskchecks
        Dim tsys As tod.tod.tod_system
        Dim i As Integer
        Dim ok As Boolean
        Dim msg As String = "Не доделано:" & vbCrLf
        ok = True
        For i = 1 To tsk.to_taskchecks.Count
            chk = tsk.to_taskchecks.Item(i)
            If chk.theValue = "" Then
                msg += vbCrLf + chk.the_check & "(" & chk.thesubsystem & ")"
                ok = False
            End If
            If chk.tagid = "" Then
                tsys = chk.the_system

                If tsys IsNot Nothing Then
                    msg += vbCrLf & "Метка " & tsys.name & " для: " & chk.the_check & "(" & chk.thesubsystem & ")"
                Else
                    msg += vbCrLf & "Метка  для: " & chk.the_check & "(" & chk.thesubsystem & ")"
                End If

                ok = False
            End If
        Next

        If ok Then
            Dim r As Replicator
            r = New Replicator(GetSetting("TOID", "CFG", "SERVERSITE", ""), Date.MinValue, Date.MinValue)
            If r.CloseTask(tdef.theMachine.ID.ToString) = True Then

                tdef.taskFinished = totask.totask.enumBoolean.Boolean_Da
                tdef.finishtime = Date.Now
                Try
                    tdef.Save()
                    Log("Зафиксировано завершение задачи в базе планшета")
                Catch ex As Exception
                    Log("Ошибка при завершении задачи в базе планшета. " + ex.Message)
                End Try


                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MsgBox("Не удалось зафиксировать закрытие задачи на сервере", vbExclamation + vbOKOnly, "Попробуйте позже")
            End If

        Else
            Dim ss As String
            ss = msg
            If Len(ss) > 300 Then
                ss = ss.Substring(0, 300) & " ..."
            End If
            Log(msg)
            MsgBox(ss, vbExclamation + vbOKOnly, "Проверки не завершены")
        End If


    End Sub

    Private inTimer As Boolean = False
    Private TagID As Guid = Guid.Empty
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If inTimer Then Return
        inTimer = True
        Dim myCap As String
        myCap = lblText.Text
        If HasTag Then
            HasTag = False
            TagID = Guid.Empty
            If NFCReader IsNot Nothing Then
                If NFCReader.GetLastTagInfoCount > 0 Then
                    lblText.Text = "Обнаружена NFC метка"
                    Dim ltag As List(Of TOIDTAG)
                    Dim tag As TOIDTAG
                    ltag = NFCReader.GetLastTagInfo()


                    If GetSetting("LATIR4", "CFG", "UpdateCardTags", "false") = "true" Then
                        For Each tag In ltag

                            Application.DoEvents()

                            If Not tag.ID.Equals(Guid.Empty) And tag.Part = "TOID" Then

                                lblText.Text = "Обнаружена NFC метка ТОИД"
                                Application.DoEvents()
                                Dim dt As DataTable
                                Dim ii As Integer
                                If Manager.Provider.ProviderType = LATIR2.DBProvider.DBProviderType.MYSQL Then
                                    dt = Manager.GetData("select c.id,s.to_cardinfo_the_machine,c.to_cardchecks_the_system  from v_autoto_cardchecks c join v_autoto_cardinfo s on  s.instanceid=c.instanceid and s.to_cardinfo_card_archived_val<>-1 where concat(s.to_cardinfo_the_machine_id,'|',c.to_cardchecks_the_system_id) ='" & tag.Data & "' ")
                                ElseIf Manager.Provider.ProviderType = LATIR2.DBProvider.DBProviderType.ORACLE Then
                                    dt = Manager.GetData("select c.id,s.to_cardinfo_the_machine,c.to_cardchecks_the_system  from v_autoto_cardchecks c join v_autoto_cardinfo s on  s.instanceid=c.instanceid and s.to_cardinfo_card_archived_val<>-1 where (s.to_cardinfo_the_machine_id || '|' || c.to_cardchecks_the_system_id) ='" & tag.Data.ToUpper & "' ")
                                Else
                                    dt = New DataTable
                                End If


                                Dim cid As Guid
                                Dim sc As SystemComment
                                lblText.Text = "Обновление привязки метки к карточке диагностики"
                                Application.DoEvents()
                                For ii = 0 To dt.Rows.Count - 1
                                    cid = New Guid(dt.Rows(ii)("id").ToString())
                                    Manager.GetData("update to_cardchecks set changestamp =" & Manager.Provider.DateFunc() & ", tagid='" & LATIR2.Utils.GUID2String(tag.ID) & "' where to_cardchecksid=" & Manager.ID2Const(cid))
                                    sc = New SystemComment
                                    sc.SystemID = cid
                                    sc.Comment = tag.ID.ToString
                                    SyncLock RegistedTags
                                        RegistedTags.Add(sc)
                                        Manager.GetData("insert into savedtags (st_id ,tagid ) values('" & LATIR2.Utils.GUID2String(cid) & "','" & LATIR2.Utils.GUID2String(tag.ID) & "'")
                                    End SyncLock
                                Next
                            End If

                        Next
                    End If



                    Dim gi As gPic.GaleryItem
                    For Each tag In ltag

                        Log("Метка " & tag.ID.ToString)
                        lblText.Text = "Поиск группы для считанной метки:" & tag.ID.ToString
                        Application.DoEvents()

                        For Each gi In lgi
                            If gi.CustomInfo.ToUpper = tag.Data.ToUpper Then
                                TagID = tag.ID

                                Beep()
                                ImageGallery1_ImageClick(gi)
                                ltag.Clear()
                                inTimer = False
                                NFCReader.ClearLastTagInfo()
                                HasTag = False
                                lblText.Text = myCap
                                Application.DoEvents()
                                Return
                            End If
                        Next
                    Next
                    NFCReader.ClearLastTagInfo()
                    HasTag = False
                    ltag.Clear()
                    lblText.Text = "Группа для метки не найдена."
                    Application.DoEvents()
                End If


            End If
        End If
        lblText.Text = myCap
        Application.DoEvents()
        inTimer = False
    End Sub

    Private Sub frmTaskSystem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
        mynfc = Nothing
        If NFCReader IsNot Nothing Then
            NFCReader.CloseDevice()
            NFCReader = Nothing
            Log("Завершение сбора меток. Разузловка.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim f As frmReport
            f = New frmReport
            f.tsk = tsk
            f.TaskInstID = TaskInstID
            f.StID = StID
            f.StName = StName
            f.ShowDialog()
            f.Dispose()
            f = Nothing
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim f As frmChart
            f = New frmChart
            f.StID = StID
            f.StName = StName
            f.ShowDialog()
            f.Dispose()
            f = Nothing
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub btnDelegate_Click(sender As Object, e As EventArgs) Handles btnDelegate.Click
        Try


            Dim f As frmReject
            f = New frmReject
            f.tsk = tsk
            f.TaskInstID = TaskInstID
            If f.ShowDialog = DialogResult.OK Then
                f.Dispose()
                f = Nothing
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                f.Dispose()
                f = Nothing
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub

    Private HasTag As Boolean
    Private Sub mynfc_TagDetected() Handles mynfc.TagDetected
        HasTag = True
    End Sub

    Private Sub cmdDeleteTask_Click(sender As Object, e As EventArgs) Handles cmdDeleteTask.Click
        If MsgBox("Переполучить данные для задачи ?", vbYesNo + vbQuestion, "Переполучение данных с сервера") = vbYes Then
            Manager.DeleteInstance(tsk)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class