Imports System.IO

Public Class frmImageTool
    Private Sub cmdPath_Click(sender As Object, e As EventArgs) Handles cmdPath.Click
        If FDlg.ShowDialog() = DialogResult.OK Then
            txtPath.Text = FDlg.SelectedPath

        End If
    End Sub



    Private Sub txtPath_TextChanged(sender As Object, e As EventArgs) Handles txtPath.TextChanged
        ImageGallery1.CreateGallery(txtPath.Text, True)

    End Sub

    Private ti As toimg.toimg.Application

    Private Sub ImageGallery1_ImageClick(ByRef Item As gPic.GaleryItem) Handles ImageGallery1.ImageClick
        If cmbMachine.SelectedValue Is Nothing Then Exit Sub
        If cmbUzel.SelectedValue Is Nothing Then Exit Sub


        Dim sSrc As String
        Dim ID As Guid = Guid.NewGuid


        sSrc = Guid.NewGuid.ToString().Replace("{", "").Replace("}", "") + IO.Path.GetExtension(Item.FilePath)

        Manager.GetData("INSERT INTO rawimage(rawimageid,changestamp,computername,fname,filetype,link1part,link1id,link2part,link2id,oper) values (" +
                    Manager.ID2Const(ID) + "," & Manager.DateFunc() & ",'" + Environment.MachineName.ToLower + "','" + sSrc + "','" + IO.Path.GetExtension(Item.FilePath) + "','tod_system','" + cmbUzel.SelectedValue.ToString() + "','tod_st','" + cmbMachine.SelectedValue.ToString() + "'," + Manager.ID2Const(GetOper().ID) + ")")

        Manager.Provider.LoadFileToField(Manager.Connection, Item.FilePath, "rawimage", "image", ID)

        Item.PrcValue = 100
        Item.Name = cmbMachine.Text & ":" & cmbUzel.Text





    End Sub

    Private Sub frmImageTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = Nothing
        dt = Manager.GetData("SELECT DISTINCT to_cardinfo_the_machine_id id , to_cardinfo_the_machine name FROM v_autoTO_CARDINFO WHERE to_cardinfo_card_archived_val=0 order by to_cardinfo_the_machine")
        cmbMachine.DataSource = dt
        cmbMachine.DisplayMember = "name"
        cmbMachine.ValueMember = "id"
        cmbMachine_SelectedIndexChanged(Me, Nothing)
    End Sub

    Private Sub ImageGallery1_Load(sender As Object, e As EventArgs) Handles ImageGallery1.Load

    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged
        If cmbMachine.SelectedValue Is Nothing Then Exit Sub
        Dim dt2 As DataTable
        dt2 = Manager.GetData("SELECT DISTINCT tc.TO_CARDCHECKS_THE_SYSTEM_ID ID,tc.TO_CARDCHECKS_THE_SYSTEM NAME FROM v_autoTO_CARDCHECKS tc JOIN v_autoTO_CARDINFO ti ON tc.instanceid=ti.instanceid WHERE to_cardinfo_card_archived_val=0 AND  to_cardinfo_the_machine_id='" & cmbMachine.SelectedValue.ToString & "' order by TO_CARDCHECKS_THE_SYSTEM")

        cmbUzel.DataSource = dt2
        cmbUzel.DisplayMember = "name"
        cmbUzel.ValueMember = "id"
    End Sub

    Private Sub cmbUzel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUzel.SelectedIndexChanged
        Dim dt As DataTable
        dt = Manager.GetData("SELECT distinct thesubsystem name FROM TO_CARDCHECKS JOIN TO_CARDINFO  ON  TO_CARDCHECKS.instanceid=TO_CARDINFO.instanceid  WHERE TO_CARDINFO.THE_MACHINE='" + cmbMachine.SelectedValue.ToString() + "' AND TO_CARDCHECKS.THE_SYSTEM='" + cmbUzel.SelectedValue.ToString() + "' ")
        If dt.Rows.Count > 0 Then
            Dim i As Integer
            Dim s As String = ""
            For i = 0 To dt.Rows.Count - 1
                If s <> "" Then
                    s = s & vbCrLf
                End If
                s = s & dt.Rows(i)("name")
            Next
            If s <> "" Then
                txtSubsystems.Text = s
            End If
        End If



        dt = Manager.GetData("select * from  rawimage  where link1part='tod_system' and link1id='" + cmbUzel.SelectedValue.ToString() + "' and link2part='tod_st' and link2id='" + cmbMachine.SelectedValue.ToString() + "'  order by changestamp desc")

        Dim spath As String
        spath = GetSetting("TOID", "CFG", "PATH2IMG", "")
        If dt.Rows.Count > 0 Then
            If Not File.Exists(spath & "\" & dt.Rows(0)("fname")) Then
                Manager.Provider.SaveFileFromField(Manager.Connection, spath & "\" & dt.Rows(0)("fname"), "rawimage", "image", New Guid(dt.Rows(0)("rawimageid").ToString))
            End If

            picImage.Image = Image.FromFile(spath & "\" & dt.Rows(0)("fname"))
            Else
                Try
                picImage.Image = Image.FromFile(spath & "\nophoto.png")
            Catch ex As Exception

            End Try

        End If



    End Sub
End Class