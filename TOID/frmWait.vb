Imports System.IO
Public Class frmWait
    Private Sub frmWait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Timer1.Enabled = True
        pb.Value = DateTime.Now.Second
        RefreshLog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If inrefresh Then Exit Sub
        inrefresh = True
        pb.Value = DateTime.Now.Second
        Application.DoEvents()
        RefreshLog()
        inrefresh = False
    End Sub

    Private inrefresh As Boolean = False
    Private Sub RefreshLog()

        Dim sTemp As String
        Dim s1 As String = ""
        Dim ss() As String
        sTemp = GetSetting("TOID", "CFG", "TEMPPATH", "c:\temp")
        Try
            s1 = File.ReadAllText(sTemp & "\log_" & DateTime.Now.ToString("yyyyMMdd") & ".txt")
        Catch ex As Exception

        End Try
        ss = s1.Split(vbCrLf)
        Dim i As Integer, j As Integer
        j = 0
        s1 = ""
        For i = UBound(ss) To 0 Step -1
            If j >= 20 Then Exit For
            j = j + 1
            s1 = s1 & ss(i) & vbCrLf
        Next
        lblLog.Text = s1
        Application.DoEvents()

    End Sub

    Private Sub frmWait_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
    End Sub
End Class