Imports Braincase.GanttChart

Public Class frmGant

    Public SchedID As Guid

    Private _mManager As ProjectManager
    Private Sub frmGant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim dd As Date
        dt = Manager.Session.GetData("SELECT * FROM v_autoto_schedinfo  where instanceid='" & LATIR2.Utils.GUID2String(SchedID) & "' ")
        If dt.Rows.Count > 0 Then
            Try
                dtpFrom.Value = dt.Rows(0)("to_schedinfo_dfrom")
            Catch ex As Exception
                dtpFrom.Value = New Date(DateAndTime.Today().Year, 1, 1)
            End Try

            Try
                dtpTo.Value = dt.Rows(0)("to_schedinfo_dto")
            Catch ex As Exception
                dtpTo.Value = New Date(dtpFrom.Value.Year + 1, 1, 1)
            End Try

        End If

        Reload()
    End Sub


    Private Sub Reload()
        Dim UseInit As Boolean = False


        _mManager = New ProjectManager()



        Dim work As Task
        Dim i As Integer
        Dim dt As DataTable
        Dim dd As Date


        Dim delay As Integer
        dt = Manager.Session.GetData("SELECT * FROM v_autoto_scheditems  where to_scheditems_todate>=" & Manager.Date2Const(dtpFrom.Value) & " and to_scheditems_todate<=" & Manager.Date2Const(dtpTo.Value) & " and instanceid='" & LATIR2.Utils.GUID2String(SchedID) & "' order by to_scheditems_todate")
        'If dt.Rows.Count > 0 Then
        '    dd = dt.Rows(i)("to_scheditems_todate")
        'End If
        'dd = DateSerial(dd.Year, dd.Month, dd.Day).AddDays(-10)
        dd = dtpFrom.Value
        _mManager.Start = dd
        _mManager.TimeScale = TimeScale.Day

        Chart1.TimeScaleDisplay = TimeScaleDisplay.DayOfMonth
        Chart1.AllowTaskDragDrop = True
        Chart1.AllowDragDropModifications = False

        For i = 0 To dt.Rows.Count - 1
            work = New Task()
            work.Name = dt.Rows(i)("to_scheditems_themachine").ToString
            If dt.Rows(i)("to_scheditems_oper").ToString.Trim <> "" Then
                work.Name += "->" + dt.Rows(i)("to_scheditems_oper").ToString()
                If dt.Rows(i)("to_scheditems_isdone").ToString.ToLower <> "нет" Then
                    work.Complete = 1.0
                Else
                    work.Complete = 0.5
                End If

            Else
                work.Complete = 0
            End If


            work.Tag = dt.Rows(i)("to_scheditems_oper").ToString()
            work.ID = New Guid(dt.Rows(i)("id").ToString())

            _mManager.Add(work)

            _mManager.SetDuration(work, 1)
            delay = DateDiff(DateInterval.Day, dd, dt.Rows(i)("to_scheditems_todate"))
            _mManager.SetStart(work, delay)

        Next

        Chart1.Init(_mManager)
        Chart1.Invalidate()

    End Sub

    Private ClickTask As Task

    Private Sub Chart1_TaskMouseClick(sender As Object, e As TaskMouseEventArgs) Handles Chart1.TaskMouseClick
        clickTask = e.Task
        If e.Button = MouseButtons.Right Then
            Dim lc As Point
            lc = e.Location
            lc.X += Chart1.Left
            lc.Y += Chart1.Top + 30

            mnuContext.Show(lc)
        End If
    End Sub



    Private Sub ProcessTask(ByRef _Task As Task)
        Dim R As Guid
        R = _Task.ID

        Dim dt As DataTable
        Dim tsk As totask.totask.Application

        dt = Manager.Session.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(New Guid(R.ToString())) & "'")

        If dt.Rows.Count = 1 Then

            Dim tsched As tosched.tosched.Application
            Dim tsi As tosched.tosched.to_scheditems
            tsched = Manager.GetInstanceObject(SchedID)
            tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(New Guid(R.ToString())))

            If tsi.oper Is Nothing Then
                If MsgBox("Взять задачу на исполнение ?", MsgBoxStyle.YesNo) = DialogResult.Yes Then


                    tsk = BuildNewTask(Manager, R.ToString())
                    If Not tsk Is Nothing Then
                        Try

                            Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
                            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
                            Doc_GUIBase = GuiManager.GetTypeGUI(tsk.TypeName, RootDllPath)
                            If (Not Doc_GUIBase Is Nothing) Then
                                Dim obj As Object = Doc_GUIBase.GetObjectControl("adm", tsk.TypeName)
                                Dim f As frmChild
                                f = New frmChild
                                f.AppendControl(obj)
                                f.MdiParent = Me.MdiParent
                                f.Attach(GuiManager, tsk)
                                f.Show()
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                    End If

                Else
                    Return
                End If

            End If



            tsk = BuildNewTask(Manager, R.ToString())
            If Not tsk Is Nothing Then
                Try

                    Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
                    Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
                    Doc_GUIBase = GuiManager.GetTypeGUI(tsk.TypeName, RootDllPath)
                    If (Not Doc_GUIBase Is Nothing) Then
                        Dim obj As Object = Doc_GUIBase.GetObjectControl("adm", tsk.TypeName)
                        Dim f As frmChild
                        f = New frmChild
                        f.AppendControl(obj)
                        f.MdiParent = Me.MdiParent
                        f.Attach(GuiManager, tsk)
                        f.Show()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
    End Sub



    Private Sub Chart1_TaskMouseDoubleClick(sender As Object, e As TaskMouseEventArgs) Handles Chart1.TaskMouseDoubleClick
        ProcessTask(e.Task)
    End Sub



    Private Sub mnuSched_Click(sender As Object, e As EventArgs) Handles mnuSched.Click

        Dim dt As DataTable

        dt = Manager.Session.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(ClickTask.ID) & "'")

        If dt.Rows.Count = 1 Then

            Dim tsched As tosched.tosched.Application
            Dim tsi As tosched.tosched.to_scheditems
            tsched = Manager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
            tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(ClickTask.ID))
            Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = GuiManager.GetTypeGUI(tsched.TypeName, RootDllPath)
            If (Not Doc_GUIBase Is Nothing) Then
                If Doc_GUIBase.ShowPartEditForm(DocMode, tsi) Then
                    tsi.Save()
                    Dim ts As Long
                    ts = DateDiff(DateInterval.Day, _mManager.Start, tsi.todate)
                    _mManager.SetStart(ClickTask, ts)
                End If
            End If
        End If


    End Sub

    Private Sub mnuCard_Click(sender As Object, e As EventArgs) Handles mnuCard.Click
        ProcessTask(ClickTask)
    End Sub

    Private Sub Chart1_TaskMouseDrop(sender As Object, e As TaskDragDropEventArgs) Handles Chart1.TaskMouseDrop
        If e.Source.Complete > 0.0 Then
            e.Cancel = True
        End If



    End Sub

    Private Sub Chart1_TaskChanged(sender As Object, e As TaskChangedEventArgs) Handles Chart1.TaskChanged


        Dim dt As DataTable

        dt = Manager.Session.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(e.Task.ID) & "'")

        If dt.Rows.Count = 1 Then
            Dim tsched As tosched.tosched.Application
            Dim tsi As tosched.tosched.to_scheditems
            tsched = Manager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
            tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(e.Task.ID))
            tsi.todate = _mManager.Start.AddDays(e.Task.Start)
            tsi.Save()
        End If


    End Sub

    Private Sub cmdAddAll_Click(sender As Object, e As EventArgs) Handles cmdAddAll.Click


        Dim f As frmAdd2Schedule
        f = New frmAdd2Schedule
        If f.ShowDialog = DialogResult.OK Then

            Dim ls As List(Of String)
            Dim i As Integer

            Dim tsched As tosched.tosched.Application = Nothing
            Dim tsi As tosched.tosched.to_scheditems

            ls = f.lid

            Try
                tsched = Manager.GetInstanceObject(SchedID)
            Catch
            End Try

            If tsched Is Nothing Then
                Exit Sub
            End If

            i = 0
            For Each s As String In ls

                Dim tc As tocard.tocard.Application
                Dim tci As tocard.tocard.to_cardinfo
                Dim nxtdate As DateTime
                tc = Manager.GetInstanceObject(New Guid(s))
                tci = tc.to_cardinfo.Item(1)
                If tci.card_archived = tocard.tocard.enumBoolean.Boolean_Net Then
                    tsi = tsched.to_scheditems.Add

                    nxtdate = f.dtStart.Value.AddDays(i)
                    If nxtdate.DayOfWeek = DayOfWeek.Saturday Then
                        i = i + 1
                    End If
                    nxtdate = f.dtStart.Value.AddDays(i)
                    If nxtdate.DayOfWeek = DayOfWeek.Sunday Then
                        i = i + 1
                    End If
                    nxtdate = f.dtStart.Value.AddDays(i)

                    tsi.todate = nxtdate
                    tsi.TheMachine = tci.the_machine
                    tsi.isdone = tosched.tosched.enumBoolean.Boolean_Net
                    tsi.Save()
                    i += 1
                End If

            Next
            Reload()
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Reload()
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click

        Dim pDoc As System.Drawing.Printing.PrintDocument

        pDoc = New System.Drawing.Printing.PrintDocument()

        PrintDialog1.Document = pDoc
        pDoc.DefaultPageSettings.Landscape = True

        If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' tell Chart to print to the document at the specified scale
            Chart1.Print(pDoc, 0.5)
        End If


        'Dim printDialog As  = New PrintPreviewDialog

        'pDoc.DefaultPageSettings.Landscape = True
        'pDoc.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize()
        'Chart1.Print(pDoc, 1)

        'PrintPreviewDialog1.WindowState = FormWindowState.Maximized

        'PrintPreviewDialog1.Document = pDoc
        'PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Dim f As frmCopySched
        f = New frmCopySched
        If f.ShowDialog = DialogResult.OK Then
            Dim dt As DataTable
            Dim i As Integer
            Dim j As Integer
            Dim dst As Date
            Dim dd As Date
            Dim id As Guid
            Dim lag As Integer
            Dim q As String
            q = "SELECT * FROM v_autoto_scheditems  where instanceid=" & Manager.ID2Const(SchedID) & " and to_scheditems_todate >=" & Manager.Date2Const(f.dtpStart.Value) & " and to_scheditems_todate <=" & Manager.Date2Const(f.dtpEnd.Value) & "  order by to_scheditems_todate"
            dt = Manager.Session.GetData(q)

            dst = f.dtpStart.Value

            If dt.Rows.Count > 0 Then

                Dim tsched As tosched.tosched.Application = Nothing
                Dim tsi As tosched.tosched.to_scheditems
                Dim tsi2 As tosched.tosched.to_scheditems


                Try
                    tsched = Manager.GetInstanceObject(SchedID)
                Catch
                End Try

                If tsched Is Nothing Then
                    Exit Sub
                End If

                For j = 0 To dt.Rows.Count - 1
                    dd = dt.Rows(j)("to_scheditems_todate")
                    id = New Guid(dt.Rows(j)("id").ToString())


                    tsi = tsched.to_scheditems.Item(id)
                    lag = Math.Abs(DateDiff(DateInterval.Day, dst, dd))
                    Dim nxtdate As DateTime

                    tsi2 = tsched.to_scheditems.Add

                    nxtdate = f.dtpCopyTo.Value.AddDays(lag)
                    If nxtdate.DayOfWeek = DayOfWeek.Saturday Then
                        lag = lag + 1
                    End If
                    nxtdate = f.dtpCopyTo.Value.AddDays(lag)
                    If nxtdate.DayOfWeek = DayOfWeek.Sunday Then
                        lag = lag + 1
                    End If
                    nxtdate = f.dtpCopyTo.Value.AddDays(lag)

                    tsi2.todate = nxtdate
                    tsi2.TheMachine = tsi.TheMachine
                    tsi2.isdone = tosched.tosched.enumBoolean.Boolean_Net
                    tsi2.Save()
                    'i += 1
                Next
                Reload()
            End If

        End If
    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click
        Dim f As frmRPT_SHED
        f = New frmRPT_SHED
        f.tID = SchedID
        f.dtpFrom.Value = dtpFrom.Value
        f.dtpTo.Value = dtpTo.Value
        f.chkUseDates.Checked = True


        f.ShowDialog()
        f = Nothing
    End Sub
End Class