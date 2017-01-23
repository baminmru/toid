Public Class frmCFG
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If fb.ShowDialog = DialogResult.OK Then
            txtPath2IMG.Text = fb.SelectedPath
        End If
    End Sub

    Private Sub txtPath2IMG_TextChanged(sender As Object, e As EventArgs) Handles txtPath2IMG.TextChanged
        SaveSetting("TOID", "CFG", "PATH2IMG", txtPath2IMG.Text)
    End Sub

    Private Sub frmCFG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPath2IMG.Text = GetSetting("TOID", "CFG", "PATH2IMG", "")
        Dim tabtip As String
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")
        If tabtip = "true" Then
            chkTabTip.Checked = True
        Else
            chkTabTip.Checked = False
        End If
        Dim sTemp As String
        sTemp = GetSetting("TOID", "CFG", "TEMPPATH", "")
        txtTemp.Text = sTemp
    End Sub

    Private Sub chkTabTip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTabTip.CheckedChanged
        If chkTabTip.Checked = True Then
            SaveSetting("LATIR4", "CFG", "TABTIP", "true")
        Else
            SaveSetting("LATIR4", "CFG", "TABTIP", "false")
        End If
    End Sub

    Private Sub cmdtemp_Click(sender As Object, e As EventArgs) Handles cmdtemp.Click
        If fb.ShowDialog = DialogResult.OK Then
            txtTemp.Text = fb.SelectedPath
        End If
    End Sub

    Private Sub txtTemp_TextChanged(sender As Object, e As EventArgs) Handles txtTemp.TextChanged
        SaveSetting("TOID", "CFG", "TEMPPATH", txtTemp.Text)
    End Sub
End Class