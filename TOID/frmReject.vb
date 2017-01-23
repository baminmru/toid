Public Class frmReject

    Public tsk As totask.totask.Application
    Public TaskInstID As Guid
    Private myresizer As New LATIR2GuiManager.Resizer

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub
    Private Sub frmReject_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        Dim op As toop.toop.to_oper
        op = GetOper()
        If Not op Is Nothing Then
            lblText.Text = "Передать другому оператору " & " (" & op.Brief & ")"
        End If
    End Sub

    Private Sub frmReject_Load(sender As Object, e As EventArgs) Handles Me.Load
        myresizer = New LATIR2GuiManager.Resizer
        Dim dt As DataTable
        Try
            dt = Manager.GetData("select id, concat(to_oper_name,' ',to_oper_familyname,' ',to_oper_surname) name from v_autoto_oper where to_oper_login is not null and id<>'" & LATIR2.Utils.GUID2String(GetOper().ID) & "'")
            lstOP.DisplayMember = "name"
            lstOP.ValueMember = "id"
            lstOP.DataSource = dt
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
        myresizer.FindAllControls(Me)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lstOP.SelectedIndex >= 0 Then


            Replicator.DisableNewReplica = True
            If Replicator.ReplicaInProgress() Then
                Log("Ожидаем завершения репликации")
                Dim fw As frmWait
                fw = New frmWait
                fw.Show()

                While Replicator.ReplicaInProgress()

                    Application.DoEvents()
                End While
                fw.Close()

            End If


            Log("Начинаем создание передачу задачи другому оператору")
            Dim ti As totask.totask.to_taskinfo
            ti = tsk.to_taskinfo.Item(1)

            Dim r As Replicator
            r = New Replicator(GetSetting("TOID", "CFG", "SERVERSITE", ""), Date.MinValue, Date.MinValue)
            If r.DelegateTask(tsk, lstOP.SelectedValue.ToString) Then
                Replicator.DisableNewReplica = False

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else

                Replicator.DisableNewReplica = False
            End If


        End If
    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub
End Class