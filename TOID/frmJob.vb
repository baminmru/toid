Imports System.IO
Imports gPic

Public Class frmJob

    Private Sub ReloadGalery()
        Try


            Dim sPath As String
            sPath = GetMyStorePath()
            Dim dt As DataTable, dt2 As DataTable


            ImageGallery1.TextColor = Color.Orange


            dt = Manager.GetData("select st.* from  v_autotod_st st  where st.id in (select b2g(themachine) from to_scheditems where  oper Is null And todate <=curdate())")
            Dim i As Integer
            Dim gi As gPic.GaleryItem
            Dim lgi As List(Of gPic.GaleryItem)

            lgi = New List(Of gPic.GaleryItem)

            For i = 0 To dt.Rows.Count - 1
                gi = New gPic.GaleryItem
                gi.ID = New Guid(dt.Rows(i)("id").ToString)

                Dim q As String
                q = "select fname from  toimg_data  where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and toimg_data.link2id ='" & LATIR2.Utils.GUID2String(gi.ID) & "' And toimg_data.link2part='tod_st' And (toimg_data.link1part is null  or toimg_data.link1part='')  order by changestamp desc"
                dt2 = Manager.GetData(q)
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

    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub frmJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReloadGalery()
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub ImageGallery1_ImageClick(ByRef Item As GaleryItem) Handles ImageGallery1.ImageClick
        Try
            Dim f As frmTakeJOB
            f = New frmTakeJOB
            f.ID = Item.ID
            f.ShowDialog()
            Timer1.Enabled = True
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub



    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        ReloadGalery()
    End Sub
End Class