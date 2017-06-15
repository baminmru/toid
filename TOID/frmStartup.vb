Imports System.Collections.Generic
Imports System.ComponentModel
Imports gPic

Public Class frmStartup

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        fStart = Me
    End Sub

    Private tools As String = ""

    Private Sub loadlist()

        If tools <> GetSetting("LATIR4", "CFG", "TOOLS", "false") Then
            ImageGallery1.Visible = False
            Dim li As List(Of gPic.GaleryItem)
            li = New List(Of gPic.GaleryItem)

            AddItem(li, "IMAGES\check.jpg", "")
            AddItem(li, "IMAGES\danger.jpg", "")

            AddItem(li, "IMAGES\diag2.jpg", "")
            AddItem(li, "IMAGES\diag3.jpg", "")
            AddItem(li, "IMAGES\diagcomp.jpg", "")


            AddItem(li, "IMAGES\gantt1.jpg", "")
            ' AddItem(li, "IMAGES\gantt2.jpg", "Расписание")
            AddItem(li, "IMAGES\graph.jpg", "")
            AddItem(li, "IMAGES\graph2.jpg", "")
            AddItem(li, "IMAGES\graph3.jpg", "Активные работы")
            AddItem(li, "IMAGES\group.jpg", "")

            AddItem(li, "IMAGES\learning.jpg", "")
            AddItem(li, "IMAGES\list.jpg", "")
            AddItem(li, "IMAGES\list2.jpg", "")

            AddItem(li, "IMAGES\oper2.jpg", "")
            AddItem(li, "IMAGES\oper3.jpg", "")
            AddItem(li, "IMAGES\oper4.jpg", "")
            AddItem(li, "IMAGES\oper5.jpg", "")

            AddItem(li, "IMAGES\report.jpg", "")
            AddItem(li, "IMAGES\report2.jpg", "")
            AddItem(li, "IMAGES\report3.jpg", "")

            AddItem(li, "IMAGES\todo.jpg", "")
            AddItem(li, "IMAGES\tools.jpg", "")



            AddItem(li, "IMAGES\oper.jpg", "Мои задания")
            AddItem(li, "IMAGES\operrest.jpg", "Настройки")




            tools = GetSetting("LATIR4", "CFG", "TOOLS", "false")
            If tools = "true" Then
                '  AddItem(li, "IMAGES\instructage.jpg", "Карты диагностики")
                '  AddItem(li, "IMAGES\instruction.jpg", "Справочники")

                '   AddItem(li, "IMAGES\to1.jpg", "Операторы")
                'AddItem(li, "IMAGES\diag1.jpg", "Размер шрифта")
                'AddItem(li, "IMAGES\zoom_ok.jpg", "Размер шрифта")
                AddItem(li, "IMAGES\NFC2.jpg", "Инициализация NFC меток")
                AddItem(li, "IMAGES\list.jpg", "Протокол работы")
                AddItem(li, "IMAGES\password.jpg", "Смена пароля")

                ' AddItem(li, "IMAGES\image1.jpg", "Привязка изображений станков")
                'AddItem(li, "IMAGES\manager.jpg", "Привязка изображений узлов")
                ' AddItem(li, "IMAGES\images.jpg", "Привязка изображений узлов")
            End If
            ' AddItem(li, "IMAGES\exit.jpg", "Выход из системы")


            Dim rect As Rectangle
            rect = Screen.PrimaryScreen.WorkingArea

            Me.ImageGallery1.PGap = 10

            If li.Count > 12 Then
                Me.ImageGallery1.PicHeight = (rect.Height - 120) / 3
                Me.ImageGallery1.PicWidth = (rect.Width - 120) / 4
            Else
                Me.ImageGallery1.PicHeight = (rect.Height - 90) / 3
                Me.ImageGallery1.PicWidth = (rect.Width - 55) / 4
            End If


            ImageGallery1.DrawItems(li)
            ImageGallery1.Visible = True
        End If


    End Sub

    Private Sub frmStartup_Load(sender As Object, e As EventArgs) Handles Me.Load


        Me.lblText.Text = Application.ProductName & " :: " & sitename

        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size



        GetMyStore()  '  подготовить хранилище фотографий

        Timer1.Enabled = True

        Replicator.DisableNewReplica = False

    End Sub


    Public Sub AddItem(li As List(Of gPic.GaleryItem), Path As String, _Name As String)
        If _Name <> "" Then
            Dim gi As gPic.GaleryItem
            gi = New gPic.GaleryItem()
            Dim FileName As String
            FileName = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\" & Path
            gi.ID = Guid.NewGuid
            gi.FilePath = FileName
            gi.Name = _Name
            gi.PrcVisible = False
            gi.PrcValue = 0
            li.Add(gi)
        End If

    End Sub





    Private Sub ImageGallery1_ImageClick(ByRef gi As GaleryItem) Handles ImageGallery1.ImageClick
        Dim OK As Boolean = False
        Try

            Select Case gi.Name



                Case "Протокол работы"
                    Try
                        Dim f As frmLog
                        f = New frmLog
                        f.StartPosition = FormStartPosition.Manual
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                    Catch ex As Exception

                    End Try


                Case "Настройки"
                    Try
                        Dim f As frmCFG
                        f = New frmCFG
                        f.StartPosition = FormStartPosition.Manual
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                    Catch ex As Exception

                    End Try


                Case "Смена пароля"
                    Try
                        Dim f As frmNewPass
                        f = New frmNewPass
                        f.StartPosition = FormStartPosition.Manual
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                    Catch ex As Exception

                    End Try


                Case "Мои задания"

                    Try
                        Dim f As frmMyTask
                        f = New frmMyTask
                        f.StartPosition = FormStartPosition.Manual
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                    Catch ex As Exception

                    End Try



                Case "Инициализация NFC меток"
                    Try
                        Dim f As frmNFC
                        f = New frmNFC
                        f.StartPosition = FormStartPosition.Manual
                        f.WindowState = FormWindowState.Normal

                        f.ShowDialog()
                    Catch ex As Exception

                    End Try






                Case "Активные работы"
                    Try
                        Dim f As frmJob
                        f = New frmJob
                        f.StartPosition = FormStartPosition.Manual
                        f.WindowState = FormWindowState.Normal
                        f.ShowDialog()
                    Catch ex As Exception
                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try


            End Select


        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub



    Private InTimer As Boolean = False
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If InTimer Then
            Log("*")
            Return
        End If
        If Manager Is Nothing Then
            Return
        End If

        If Manager.Session Is Nothing Then
            Return
        End If
        InTimer = True
        Try
            Dim r As Replicator
            Dim rdef As tor.tor.tor_info
            Dim ri As Integer
            Dim rok As Boolean
            If RObj Is Nothing Then
                Dim id As Guid
                Dim dt As DataTable
                dt = Manager.GetData("select " & Manager.Provider.InstanceFieldList & " from instance where objtype='tor'")
                If dt.Rows.Count > 0 Then
                    id = New Guid(dt.Rows(0)("instanceid").ToString)
                    RObj = Manager.GetInstanceObject(id)
                    rok = False
                    For ri = 1 To RObj.tor_info.Count
                        rdef = RObj.tor_info.Item(ri)
                        If rdef.name.ToLower = Environment.MachineName.ToLower Then
                            rok = True
                            Exit For
                        End If
                    Next
                    If Not rok Then
                        rdef = RObj.tor_info.Add
                        rdef.clientdata = DateSerial(2000, 1, 1)
                        rdef.serverdata = DateSerial(2000, 1, 1)

                        rdef.name = Environment.MachineName
                        rdef.Save()
                    End If

                End If

                If RObj Is Nothing Then
                    id = Guid.NewGuid
                    RObj = Manager.NewInstance(id, "tor", "Репликация для компьютера " & Environment.MachineName)
                    rdef = RObj.tor_info.Add
                    rdef.clientdata = DateSerial(2000, 1, 1)
                    rdef.serverdata = DateSerial(2000, 1, 1)
                    rdef.name = Environment.MachineName
                    rdef.Save()
                End If
            End If

            If RObj Is Nothing Then
                Log("Объект описание репликации не получен. Процесс репликации невозможен.")
                InTimer = False
                Return
            End If

            Dim i As Integer
            Dim ti As tor.tor.tor_info

            RObj.tor_info.Refresh()

            For i = 1 To RObj.tor_info.Count
                ti = RObj.tor_info.Item(i)
                If ti.name.ToLower() = Environment.MachineName.ToLower() Then
                    r = New Replicator(GetSetting("TOID", "CFG", "SERVERSITE", ""), ti.serverdata, ti.clientdata)
                    If r.DoReplica() = False Then
                        Timer1.Interval = 60000
                    Else
                        Timer1.Interval = 60000
                    End If

                    RObj.tor_info.Refresh()
                    Exit For
                End If
            Next

        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

        InTimer = False
    End Sub

    Private Sub frmStartup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If e.CloseReason = CloseReason.WindowsShutDown Or e.CloseReason = CloseReason.TaskManagerClosing Then
        Timer1.Enabled = False
        Log("Остановка процесса репликации")
        Replicator.DisableNewReplica = True

        While InTimer = True
            Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
        End While

        Log("Ожидаем завершения репликации")
        Dim fw As frmWait
        fw = New frmWait
        fw.Show()

        While Replicator.ReplicaInProgress()
            fw.pb.Value = DateTime.Now.Second
            Application.DoEvents()
        End While
        fw.Close()


        Log("Завершение сессии на клиенте")
        SyncLock Manager
            Manager.Session.Logout()
            Manager.Close()
            ClearOnLogOut()
        End SyncLock
        Log("Сессия завершена. Ждем следующего входа.")
    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        If MsgBox("Хотите завершить работу текущего оператора с программой?", vbQuestion + vbYesNo, "Подтвердите завершение") = vbYes Then
            Timer1.Enabled = False
            Me.Close()
        End If


    End Sub

    Private Sub frmStartup_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        loadlist()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        Timer1.Interval = 30000
        Timer1.Enabled = True
        Dim op As toop.toop.to_oper
        op = GetOper()
        If Not op Is Nothing Then
            lblText.Text = Application.ProductName & " (" & op.Brief & ") :: " & sitename
        End If
        If RegistedTags Is Nothing Then
            RegistedTags = New List(Of SystemComment)
            Dim stag As DataTable
            Dim sc As SystemComment
            Try
                stag = Manager.GetData("select count(*) cnt from savedtags")
            Catch ex As Exception
                Manager.GetData("create table savedtags (st_id varchar(64),tagid varchar(64))")
            End Try

            stag = Manager.GetData("select * cnt from savedtags")
            Dim si As Integer
            For si = 0 To stag.Rows.Count - 1
                sc = New SystemComment
                sc.SystemID = New Guid(stag.Rows(si)("st_id").ToString())
                sc.Comment = stag.Rows(si)("tagid").ToString()
                SyncLock RegistedTags
                    RegistedTags.Add(sc)
                End SyncLock
            Next

        End If
    End Sub

    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub CloseButton1_Load(sender As Object, e As EventArgs) Handles CloseButton1.Load

    End Sub
End Class