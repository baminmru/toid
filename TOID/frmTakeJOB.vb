
Public Class frmTakeJOB
    Public ID As Guid
    Private ShedID As Guid
    Private myresizer As New LATIR2GuiManager.Resizer


    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub frmTakeJOB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myresizer = New LATIR2GuiManager.Resizer
        Dim dt As DataTable, dt1 As DataTable
        Try

            dt = Manager.GetData("select  distinct tod_material.name from to_carddevices join tod_material On to_carddevices.mat=tod_materialid join to_cardchecks On to_carddevices.parentstructrowid=to_cardchecks.to_cardchecksid join to_cardinfo On to_cardchecks.instanceid=to_cardinfo.instanceid where to_cardinfo.the_machine=" & Manager.ID2Const(ID))
            Me.lstTools.DisplayMember = "name"
            Me.lstTools.DataSource = dt

            dt1 = Manager.GetData("select b2g(to_scheditemsid) id, todate from to_scheditems where oper is null  and todate <=curdate() and themachine  =" & Manager.ID2Const(ID))
            If dt1.Rows.Count > 0 Then
                txtDate.Text = dt1.Rows(0)("todate").ToString()
                ShedID = New Guid(dt1.Rows(0)("id").ToString())
            End If



            dt1 = Manager.GetData("select concat(invn,' ', name) name from tod_st where tod_stid =" & Manager.ID2Const(ID))
            If dt1.Rows.Count > 0 Then
                txtST.Text = dt1.Rows(0)("name").ToString()
            End If


        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        myresizer.FindAllControls(Me)

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        cmdOK.Enabled = False
        cmdCancel.Enabled = False
        Dim fw As frmWait
        Replicator.DisableNewReplica = True
        If Replicator.ReplicaInProgress() Then
            Log("Ожидаем завершения репликации")

            fw = New frmWait
            fw.Show()

            While Replicator.ReplicaInProgress()

                Application.DoEvents()
            End While
            fw.Close()

        End If

        Log("Начинаем создание новой задачи")
        Dim r As Replicator
        r = New Replicator(GetSetting("TOID", "CFG", "SERVERSITE", ""), Date.MinValue, Date.MinValue)

        fw = New frmWait
        fw.Show()
        Application.DoEvents()
        If r.BuildNewTask(ShedID.ToString()) Then
            fw.Close()
            Replicator.DisableNewReplica = False
            cmdOK.Enabled = True
            cmdCancel.Enabled = True

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            fw.Close()
            Replicator.DisableNewReplica = False
            cmdOK.Enabled = True
            cmdCancel.Enabled = True
        End If


    End Sub

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        Dim op As toop.toop.to_oper
        op = GetOper()
        If Not op Is Nothing Then
            lblText.Text = "Взять в работу " & " (" & op.Brief & ")"
        End If
    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub
End Class