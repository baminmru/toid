Imports gPic

Public Class frmMyTask
    Private Sub frmMyTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadGalery()

        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size


    End Sub


    Private lgi As List(Of gPic.GaleryItem)

    Private Sub ReloadGalery()
        Try


            Dim sPath As String
            sPath = GetMyStorePath()
            Dim dt As DataTable, dt2 As DataTable
            Dim opid As Guid
            opid = GetOper().ID

            Dim q As String

            q = "select st.*,b2g(to_taskinfo.instanceid) tid from  v_autotod_st st "
            q += " join  to_scheditems on  b2g(to_scheditems.themachine) =st.id"
            q += " join to_taskinfo On to_scheditems.to_scheditemsid =to_taskinfo.themachine  where (to_taskinfo.taskFinished=0 or to_taskinfo.taskFinished is null) and to_taskinfo.oper =" & Manager.ID2Const(opid)

            ImageGallery1.TextColor = Color.Orange

            dt = Manager.GetData(q)
            Dim i As Integer
            Dim gi As gPic.GaleryItem


            lgi = New List(Of gPic.GaleryItem)



            For i = 0 To dt.Rows.Count - 1
                gi = New gPic.GaleryItem
                gi.ID = New Guid(dt.Rows(i)("id").ToString)
                gi.Tag = New Guid(dt.Rows(i)("tid").ToString)

                dt2 = Manager.GetData("select fname from  toimg_data  where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and toimg_data.link2id ='" & LATIR2.Utils.GUID2String(gi.ID) & "' And toimg_data.link2part='tod_st' And (toimg_data.link1part is null or toimg_data.link1part='')  order by changestamp desc ")
                If dt2.Rows.Count > 0 Then
                    If IO.File.Exists(sPath & "\" & dt2.Rows(0)("fname")) Then
                        gi.FilePath = sPath & "\" & dt2.Rows(0)("fname")
                    Else
                        gi.FilePath = sPath & "\nophoto.jpg"
                    End If
                Else
                    gi.FilePath = sPath & "\nophoto.jpg"
                End If

                gi.Name = dt.Rows(i)("tod_st_invn") & " " & dt.Rows(i)("tod_st_name")

                gi.PrcVisible = False
                gi.PrcValue = 0

                lgi.Add(gi)


            Next
            Dim rect As Rectangle
            rect = Screen.PrimaryScreen.WorkingArea

            Me.ImageGallery1.PGap = 10

            If lgi.Count > 12 Then
                Me.ImageGallery1.PicHeight = (rect.Height - 120) / 3
                Me.ImageGallery1.PicWidth = (rect.Width - 120) / 4
            Else
                Me.ImageGallery1.PicHeight = (rect.Height - 90) / 3
                Me.ImageGallery1.PicWidth = (rect.Width - 55) / 4
            End If
            ImageGallery1.DrawItems(lgi)

        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub


    Private Sub ImageGallery1_ImageClick(ByRef Item As GaleryItem) Handles ImageGallery1.ImageClick
        Dim oID As System.Guid


        Try
            Dim f As frmTaskSystem
            f = New frmTaskSystem

            oID = Item.Tag
            f.TaskInstID = oID
            f.StID = Item.ID
            f.StName = Item.Name
            If f.ShowDialog() = DialogResult.OK Then
                ReloadGalery()
            End If


        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try



    End Sub

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Dim op As toop.toop.to_oper
        op = GetOper()
        If Not op Is Nothing Then
            lblText.Text = "Мои задачи " & " (" & op.Brief & ")"
        End If

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
End Class