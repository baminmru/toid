Imports System.IO

Public Class frmLog

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.Close()
    End Sub
    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Dim inrefresh As Boolean = False

    Private Sub RefreshLog()
        If inrefresh Then Exit Sub
        inrefresh = True
        Dim sTemp As String
        sTemp = GetSetting("TOID", "CFG", "TEMPPATH", "c:\temp")
        Try
            txtLog.Text = File.ReadAllText(sTemp & "\log_" & DateTime.Now.ToString("yyyyMMdd") & ".txt")
        Catch ex As Exception

        End Try
        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.ScrollToCaret()
        inrefresh = False
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshLog()
    End Sub

    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshLog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RefreshLog()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim sTemp As String
        sTemp = GetSetting("TOID", "CFG", "TEMPPATH", "c:\temp")
        Try
            File.WriteAllText(sTemp & "\log_" & DateTime.Now.ToString("yyyyMMdd") & ".txt", "")
        Catch ex As Exception

        End Try
    End Sub
End Class