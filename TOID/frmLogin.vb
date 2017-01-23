Imports System.IO
Public Class frmLogin
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        username = GetSetting("TOID", "SETTING", "UID", "")
        sitename = GetSetting("TOID", "SETTING", "SITECLI", "")
        If sitename = "" Then
            pnlSite.Visible = True
        End If
        txtUser.Text = username
        txtSite.Text = sitename


    End Sub
    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Manager = New LATIR2.Manager
        GuiManager = New LATIR2GuiManager.LATIRGuiManager
        GuiManager.Attach(Manager)

        Manager.Site = txtSite.Text
        lblOut.Text = ""
        If Manager.Session Is Nothing Then
            Me.DialogResult = DialogResult.Abort
            Me.Close()
        ElseIf Manager.Session.Login(txtUser.Text, txtPassword.Text) Then
            SaveSetting("TOID", "SETTING", "UID", txtUser.Text)
            SaveSetting("TOID", "SETTING", "SITECLI", txtSite.Text)
            password = txtPassword.Text
            username = txtUser.Text
            Log("Вход на клиенте " & sitename & "  как " & username)

            Dim spath As String
            spath = GetMyStorePath()
            Try
                If Not File.Exists(spath & "\nophoto.jpg") Then
                    FileCopy(System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\images\nophoto.jpg", spath & "\nophoto.jpg")
                End If
            Catch ex As Exception

            End Try

            Me.DialogResult = DialogResult.OK
            Dim f As frmStartup
            f = New frmStartup
            f.ShowDialog()
        Else
            lblOut.Text = "Неверный пароль или пользователь"
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub



    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.WindowsShutDown Or e.CloseReason = CloseReason.TaskManagerClosing Then

        Else

            Dim f As frmExit
            f = New frmExit
            If f.ShowDialog = DialogResult.OK Then
                If Manager IsNot Nothing Then
                    Try
                        Log("Сессия на клиенте завершена")
                        Manager.Close()
                    Catch ex As Exception
                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try

                End If

            Else
                MsgBox("Неверный код выхода", vbInformation + vbOKOnly, "Ошибка")
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub CloseButton1_Load(sender As Object, e As EventArgs) Handles CloseButton1.Load

    End Sub

    Private Sub btnSite_Click(sender As Object, e As EventArgs) Handles btnSite.Click
        If pnlSite.Visible = True Then
            pnlSite.Visible = False
        Else
            pnlSite.Visible = True
        End If

    End Sub

    Private Sub frmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtPassword.Text = ""
    End Sub
End Class