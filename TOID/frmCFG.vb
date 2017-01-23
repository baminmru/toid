Public Class frmCFG
    Private myresizer As New LATIR2GuiManager.Resizer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If fb.ShowDialog = DialogResult.OK Then
            txtPath2IMG.Text = fb.SelectedPath
            SaveSetting("TOID", "CFG", "TEMPPATH", txtPath2IMG.Text)
        End If
    End Sub

    Private Sub txtPath2IMG_TextChanged(sender As Object, e As EventArgs) Handles txtPath2IMG.TextChanged
        Try
            Dim idef As toimg.toimg.toimg_def
            idef = GetMyStore().toimg_def.Item(1)
            idef.imagestore = txtPath2IMG.Text
            idef.Save()
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub frmCFG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myresizer = New LATIR2GuiManager.Resizer
        txtPath2IMG.Text = GetMyStorePath()
        txtServerSite.Text = GetSetting("TOID", "CFG", "SERVERSITE", "")
        txtTempPath.Text = GetSetting("TOID", "CFG", "TEMPPATH", "")
        Dim tabtip As String
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")
        If tabtip = "true" Then
            chkTabTip.Checked = True
        Else
            chkTabTip.Checked = False
        End If
        Dim tools As String
        tools = GetSetting("LATIR4", "CFG", "TOOLS", "false")
        If tools = "true" Then
            chkTools.Checked = True
        Else
            chkTools.Checked = False
        End If

        Dim totrn As String
        totrn = GetSetting("LATIR4", "CFG", "LOADTOTRN", "false")
        If totrn = "true" Then
            chkTOTRN.Checked = True
        Else
            chkTOTRN.Checked = False
        End If
        myresizer.FindAllControls(Me)

        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub

    Private Sub chkTabTip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTabTip.CheckedChanged
        If chkTabTip.Checked = True Then
            SaveSetting("LATIR4", "CFG", "TABTIP", "true")
        Else
            SaveSetting("LATIR4", "CFG", "TABTIP", "false")
        End If
    End Sub



    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.Close()
    End Sub

    Private Sub chkTools_CheckedChanged(sender As Object, e As EventArgs) Handles chkTools.CheckedChanged
        If chkTools.Checked = True Then
            SaveSetting("LATIR4", "CFG", "TOOLS", "true")
        Else
            SaveSetting("LATIR4", "CFG", "TOOLS", "false")
        End If
    End Sub

    Private Sub frmCFG_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub cmdTempPath_Click(sender As Object, e As EventArgs) Handles cmdTempPath.Click
        If fb.ShowDialog = DialogResult.OK Then
            txtTempPath.Text = fb.SelectedPath
        End If
    End Sub

    Private Sub txtTempPath_TextChanged(sender As Object, e As EventArgs) Handles txtTempPath.TextChanged
        SaveSetting("TOID", "CFG", "TEMPPATH", txtTempPath.Text)
    End Sub

    Private Sub txtServerSite_TextChanged_1(sender As Object, e As EventArgs) Handles txtServerSite.TextChanged
        SaveSetting("TOID", "CFG", "SERVERSITE", txtServerSite.Text)
    End Sub

    Private Sub chkTOTRN_CheckedChanged(sender As Object, e As EventArgs) Handles chkTOTRN.CheckedChanged
        If chkTOTRN.Checked = True Then
            SaveSetting("LATIR4", "CFG", "LOADTOTRN", "true")
        Else
            SaveSetting("LATIR4", "CFG", "LOADTOTRN", "false")
        End If
    End Sub
End Class