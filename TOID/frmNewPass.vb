Public Class frmNewPass

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
            lblText.Text = "Смена пароля " & " (" & op.Brief & ")"
        End If
    End Sub

    Private Sub frmReject_Load(sender As Object, e As EventArgs) Handles Me.Load
        myresizer = New LATIR2GuiManager.Resizer

        myresizer.FindAllControls(Me)

    End Sub



    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub


    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        If txtPassword.Text <> txtPassword2.Text Then
            MsgBox("Новый пароль и подтверждение пароля не совпадают")
            Return
        End If

        If txtOldPassword.Text.ToLower <> password.ToLower Then
            MsgBox("Текущий пароль неверен")
            Return
        End If
        cmdOK.Enabled = False
        cmdCancel.Enabled = False

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

        Log("Начинаем смену пароля")
        Dim r As Replicator
        r = New Replicator(GetSetting("TOID", "CFG", "SERVERSITE", ""), Date.MinValue, Date.MinValue)
        If r.ChangePassword(username, txtPassword.Text) Then
            password = txtPassword.Text.ToLower
            Replicator.DisableNewReplica = False
            cmdOK.Enabled = True
            cmdCancel.Enabled = True
            MsgBox("Пароль изменен", vbExclamation & vbOKOnly, "Статус")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Не удалось сменить пароль", vbExclamation & vbOKOnly, "Ошибка")
            Replicator.DisableNewReplica = False
            cmdOK.Enabled = True
            cmdCancel.Enabled = True
        End If
    End Sub
End Class