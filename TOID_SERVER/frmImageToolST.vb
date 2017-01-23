Imports System.IO

Public Class frmImageToolST
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

        'If ti Is Nothing Then
        '    ti = GetMyStore()

        'End If

        'If ti Is Nothing Then
        '    MsgBox("нет списка изображений в базе данных")
        '    Exit Sub
        'End If

        'Dim tPic As toimg.toimg.toimg_data
        'tPic = ti.toimg_data.Add
        'Dim sPath As String
        'sPath = GetMyStorePath()
        'Dim sSrc As String


        'With tPic
        '    .link2part = "tod_st"
        '    .link2id = LATIR2.Utils.GUID2String(New Guid(cmbMachine.SelectedValue.ToString()))
        '    .filetype = IO.Path.GetExtension(Item.FilePath)
        '    sSrc = Guid.NewGuid.ToString().Replace("{", "").Replace("}", "")  +.filetype
        '    .fname = sSrc
        '    FileCopy(Item.FilePath, sPath & "\" & sSrc)
        '    .Save()
        'End With


        If cmbMachine.SelectedValue Is Nothing Then Exit Sub



        Dim sSrc As String
        Dim ID As Guid = Guid.NewGuid


        sSrc = Guid.NewGuid.ToString().Replace("{", "").Replace("}", "") + IO.Path.GetExtension(Item.FilePath)

        Manager.GetData("INSERT INTO rawimage(rawimageid,changestamp,computername,fname,filetype,link1part,link1id,link2part,link2id,oper) values (" +
                    Manager.ID2Const(ID) + "," & Manager.DateFunc() & ",'" + Environment.MachineName.ToLower + "','" + sSrc + "','" + IO.Path.GetExtension(Item.FilePath) + "',null,null,'tod_st','" + cmbMachine.SelectedValue.ToString() + "'," + Manager.ID2Const(GetOper().ID) + ")")

        Manager.Provider.LoadFileToField(Manager.Connection, Item.FilePath, "rawimage", "image", ID)

        Item.PrcValue = 100
        Item.Name = cmbMachine.Text







    End Sub

    Private Sub frmImageTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = Nothing
        'If Manager.Provider.ProviderType = LATIR2.DBProvider.DBProviderType.ORACLE Then
        '    dt = Manager.GetData("SELECT id, (tod_st_invn||' '||tod_st_name) name FROM v_autotod_st order by tod_st_invn")
        'End If
        'If Manager.Provider.ProviderType = LATIR2.DBProvider.DBProviderType.MYSQL Then
        '    dt = Manager.GetData("SELECT id, concat(tod_st_invn,' ',tod_st_name) name FROM v_autotod_st order by tod_st_invn")
        'End If

        dt = Manager.GetData("SELECT DISTINCT to_cardinfo_the_machine_id id , to_cardinfo_the_machine name FROM v_autoTO_CARDINFO WHERE to_cardinfo_card_archived_val=0  order by to_cardinfo_the_machine")

        cmbMachine.DataSource = dt
        cmbMachine.DisplayMember = "name"
        cmbMachine.ValueMember = "id"
        cmbMachine_SelectedIndexChanged(Me, Nothing)
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)


    End Sub

    Private Sub ImageGallery1_Load(sender As Object, e As EventArgs) Handles ImageGallery1.Load

    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged
        Dim dt As DataTable
        dt = Manager.GetData("select * from  rawimage  where link1part is null and link2part='tod_st' and link2id='" + cmbMachine.SelectedValue.ToString() + "'  order by changestamp desc")

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