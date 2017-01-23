Public Class frmAddComment


    Private myresizer As New LATIR2GuiManager.Resizer
    Public SysName As String
    Public SysID As Guid
    Public StName As String
    Public chk As totask.totask.to_taskchecks

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAddComment_Load(sender As Object, e As EventArgs) Handles Me.Load
        myresizer = New LATIR2GuiManager.Resizer
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Dim dt As DataTable
        dt = Manager.GetData("SELECT * FROM v_autotod_bug where tod_bug_the_system_id='" & LATIR2.Utils.GUID2String(SysID) & "' order by tod_bug_name")
        lstStd.DisplayMember = "tod_bug_name"
        lstStd.ValueMember = "tod_bug_name"
        lstStd.DataSource = dt
        lstStd.SelectedIndex = -1
        txtMy.Text = ""
        myresizer.FindAllControls(Me)

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtMy.Text <> "" Then
            Dim cc As totask.totask.to_taskcheckcomment
            cc = chk.to_taskcheckcomment.Add
            cc.the_date = DateTime.Now
            cc.the_operator = GetOper()
            cc.Info = txtMy.Text
            cc.Save()

            ' добавить в глобальный справочник при репликации
            If chkAddToDict.Checked Then
                If MyGlobalComments Is Nothing Then
                    MyGlobalComments = New List(Of SystemComment)
                End If
                Dim sc As SystemComment
                sc = New SystemComment
                sc.SystemID = SysID
                sc.Comment = txtMy.Text
                MyGlobalComments.Add(sc)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub

    Private Sub cmdToMy_Click(sender As Object, e As EventArgs) Handles cmdToMy.Click
        If lstStd.SelectedIndex >= 0 Then
            txtMy.Text = lstStd.SelectedValue
        End If
    End Sub
End Class