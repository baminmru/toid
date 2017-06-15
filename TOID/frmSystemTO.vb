Imports System.ComponentModel
Imports System.IO

Public Class frmSystemTO

    Public tsk As totask.totask.Application
    Public SysName As String
    Public StID As Guid
    Public SysID As Guid
    Public TagID As Guid
    Public StName As String
    Private chk As totask.totask.to_taskchecks
    Public GaleryForm As frmTaskSystem
    Private hasSave As Boolean = False
    Private myresizer As New LATIR2GuiManager.Resizer

    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub
    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.Hide()
        If (hasSave) Then
            If Not GaleryForm Is Nothing Then  ' форма может быть вызвана явна при обработке NFC метки
                GaleryForm.ReloadGalery()
            End If
        End If
        Me.Close()

    End Sub


    Private Sub ReloadListView()
        Try
            lstMeasure.Items.Clear()
            Dim li As ListViewItem

            Dim j As Integer
            For j = 1 To tsk.to_taskchecks.Count
                chk = tsk.to_taskchecks.Item(j)
                If chk.the_system.ID.Equals(SysID) Then

                    If chk.thevalue <> "" Then
                        If chk.thevalue = "не проверен" Then
                            li = New ListViewItem(chk.thesubsystem & ". " & chk.the_check, 2)
                        Else
                            li = New ListViewItem(chk.thesubsystem & ". " & chk.the_check, 0)
                        End If

                    Else
                        li = New ListViewItem(chk.thesubsystem & ". " & chk.the_check, 1)
                    End If
                    If Not TagID.Equals(Guid.Empty) Then
                        If chk.tagid <> LATIR2.Utils.GUID2String(TagID) Then
                            chk.tagid = LATIR2.Utils.GUID2String(TagID)
                            chk.tagtime = DateTime.Now()
                            chk.Save()
                        End If

                    End If
                    li.Tag = chk.ID
                    li.ToolTipText = chk.the_comment
                    lstMeasure.Items.Add(li)

                End If
            Next




            If lstMeasure.Items.Count > 0 Then
                lstMeasure.Items(0).Selected = True
                lstMeasure.SelectedItems.Item(0).EnsureVisible()
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub
    Private Sub frmSystemTO_Load(sender As Object, e As EventArgs) Handles Me.Load
        'myresizer = New LATIR2GuiManager.Resizer
        lblText.Text = StName + " Узел: " + SysName


        ReloadListView()
        ' myresizer.FindAllControls(Me)

        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private curcomment As Integer = 0

    Private Sub LoadComments(ByVal Idx As Integer)
        Try
            chk.to_taskcheckcomment.Sort = "the_date"
            txtComment.Text = ""
            If chk.to_taskcheckcomment.Count = 0 Then
                curcomment = 0
            Else
                curcomment = 1
            End If
            If Idx > 0 Then
                If Idx <= chk.to_taskcheckcomment.Count Then
                    txtComment.Text = chk.to_taskcheckcomment.Item(Idx).the_operator.Brief + ":" + vbCrLf + chk.to_taskcheckcomment.Item(Idx).Info
                    curcomment = Idx
                End If
            End If
            lblCommentHeader.Text = "Комментарии (" + curcomment.ToString() + "  из " + chk.to_taskcheckcomment.Count.ToString + ")"
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub


    Private curPhoto As Integer = 0
    Private maxPhotos As Integer = 0

    Private Sub LoadPhotos(ByVal idx As Integer)
        Try
            Dim sPath As String
            sPath = GetMyStorePath()
            Dim dt As DataTable




            dt = Manager.GetData("select fname," & Manager.Base2ID("toimg_dataid", "id") & "  from  toimg_data where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and toimg_data.link1id ='" & LATIR2.Utils.GUID2String(chk.ID) & "' And toimg_data.link1part='to_taskchecks' order by changestamp")

            maxPhotos = dt.Rows.Count
            If maxPhotos = 0 Then
                curPhoto = 0
                Try
                    picPhoto.Image = Image.FromFile(sPath & "\" & "nophoto.jpg")
                Catch ex As Exception
                    Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                End Try

                picPhoto.Tag = ""
            Else
                curPhoto = 1

                If idx <= 0 Then idx = 1
                If idx > maxPhotos Then idx = maxPhotos


                If Not picPhoto.Image Is Nothing Then
                    picPhoto.Image.Dispose()
                End If
                Try
                    picPhoto.Image = Image.FromFile(sPath & "\" & dt.Rows(idx - 1)("fname"))
                Catch ex As Exception
                    Try
                        picPhoto.Image = Image.FromFile(sPath & "\" & "nophoto.jpg")
                    Catch ex2 As Exception
                        Log(ex2.Message & vbCrLf & ex2.StackTrace)
                    End Try

                End Try

                picPhoto.Tag = dt.Rows(idx - 1)("id").ToString
                curPhoto = idx

            End If

            lblPhotoHeader.Text = "Фото (" + curPhoto.ToString() + "  из " + maxPhotos.ToString + ")"
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub

    Private Sub reloadItem(ByVal id As Guid)
        Try
            Dim vt As tod.tod.tod_valtype = Nothing
            chk = tsk.to_taskchecks.Item(id)
            If chk IsNot Nothing Then
                lblCheck.Text = chk.the_check
                lblSubsystem.Text = chk.thesubsystem

                If chk.ValueType Is Nothing Then
                    txtValue.InputMode = gPic.touchInput.iMode.Text
                Else
                    vt = chk.ValueType
                    If vt.ID.Equals(New Guid("{CBD5D56B-72B6-4071-AEF3-42244A092DAC}")) Then
                        txtValue.InputMode = gPic.touchInput.iMode.YesNo
                    Else
                        txtValue.InputMode = gPic.touchInput.iMode.Number
                    End If

                End If

                txtValue.InputValue = chk.theValue
                txtValue.BringToFront()
                lblComment.Text = chk.the_comment
                lblMin.Text = chk.lowvalue
                lblMax.Text = chk.hivalue


                If vt IsNot Nothing Then
                    lblValueType.Text = vt.Name
                Else
                    lblValueType.Text = ""
                End If



                Dim dt As DataTable
                'dt = Manager.GetData("select * from  rawimage  where link1part='tod_system' and link1id='" + chk.the_system.ID.ToString() + "' and link2part='tod_st' and link2id='" + STid.ToString() + "'")
                Dim q As String
                q = "select " & Manager.Base2ID("toimg_dataid", "id") & ", fname from  toimg_data  where instanceid=" & Manager.ID2Const(GetMyStore().ID) & " and toimg_data.link2id ='" & LATIR2.Utils.GUID2String(StID) & "' And toimg_data.link2part='tod_st' And toimg_data.link1part ='tod_system' and toimg_data.link1id='" & LATIR2.Utils.GUID2String(chk.the_system.ID) & "'"
                dt = Manager.GetData(q)
                Dim spath As String
                spath = GetMyStorePath()
                If dt.Rows.Count > 0 Then
                    If Not File.Exists(spath & "\" & dt.Rows(0)("fname")) Then
                        Manager.Provider.SaveFileFromField(Manager.Connection, spath & "\" & dt.Rows(0)("fname"), "toimg_data", "image", New Guid(dt.Rows(0)("id").ToString))
                    End If
                    Try
                        picIMAGE.Image = Image.FromFile(spath & "\" & dt.Rows(0)("fname"))
                    Catch ex As Exception
                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try

                Else
                    Try
                        picIMAGE.Image = Image.FromFile(spath & "\nophoto.jpg")
                    Catch ex As Exception

                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try

                End If

                LoadComments(1)
                LoadPhotos(1)
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub


    Private Sub lstMeasure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMeasure.SelectedIndexChanged
        Try
            Dim li As ListViewItem
            If lstMeasure.SelectedItems.Count > 0 Then
                li = lstMeasure.SelectedItems.Item(0)
                reloadItem(li.Tag)
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblMin_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblMax_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmSystemTO_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try

            If Not chk Is Nothing Then
                chk.thevalue = txtValue.InputValue.ToString
                If Not TagID.Equals(Guid.Empty) Then
                    If chk.tagid <> LATIR2.Utils.GUID2String(TagID) Then
                        chk.tagid = LATIR2.Utils.GUID2String(TagID)
                        chk.tagtime = DateTime.Now()
                    End If
                End If


                For Each l As ListViewItem In lstMeasure.Items
                    If l.Tag.Equals(chk.ID) Then
                        If chk.thevalue <> "" Then
                            If chk.thevalue = "не проверен" Then
                                l.ImageIndex = 2
                            Else
                                l.ImageIndex = 0
                            End If
                        Else
                            l.ImageIndex = 1
                        End If
                        Exit For
                    End If
                Next
                chk.Save()
                hasSave = True
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub btnAddComment_Click(sender As Object, e As EventArgs) Handles btnAddComment.Click
        Try


            Dim f As frmAddComment
            f = New frmAddComment
            f.SysName = Me.SysName
            f.SysID = Me.SysID

            f.chk = Me.chk
            If f.ShowDialog() = DialogResult.OK Then
                LoadComments(chk.to_taskcheckcomment.Count)
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub btnCommentNext_Click(sender As Object, e As EventArgs) Handles btnCommentNext.Click
        If curcomment < chk.to_taskcheckcomment.Count Then
            LoadComments(curcomment + 1)
        End If
    End Sub

    Private Sub btnCommentPrev_Click(sender As Object, e As EventArgs) Handles btnCommentPrev.Click
        If curcomment > 1 Then
            LoadComments(curcomment - 1)
        End If
    End Sub

    Private Sub btnAddPhoto_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        Try


            Dim f As frmAddPhoto
            f = New frmAddPhoto


            f.SysName = Me.SysName
            f.SysID = Me.SysID
            f.chk = Me.chk
            If f.ShowDialog() = DialogResult.OK Then
                LoadPhotos(Integer.MaxValue)
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If curPhoto > 1 Then
            LoadPhotos(curPhoto - 1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If curPhoto < maxPhotos Then
            LoadPhotos(curPhoto + 1)
        End If
    End Sub

    Private Sub btnDelComment_Click(sender As Object, e As EventArgs) Handles btnDelComment.Click
        If chk.to_taskcheckcomment.Item(curcomment).the_operator.ID.Equals(GetOper().ID) Then
            If MsgBox("Удалить комментарий?", vbQuestion + vbYesNo, "Подтвердите") = DialogResult.Yes Then
                Try
                    chk.to_taskcheckcomment.Delete(chk.to_taskcheckcomment.Item(curcomment).ID)
                    LoadComments(curcomment - 1)
                Catch ex As Exception
                    Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                End Try
            End If
        End If
    End Sub

    Private Sub btnDelPhoto_Click(sender As Object, e As EventArgs) Handles btnDelPhoto.Click
        Try


            Dim ti As toimg.toimg.Application
            Dim td As toimg.toimg.toimg_data
            Dim tdel As toimg.toimg.toimg_todelete
            Dim sPath As String
            sPath = GetMyStorePath()
            ti = GetMyStore()

            If picPhoto.Tag <> "" Then
                td = ti.toimg_data.Item(New Guid(picPhoto.Tag.ToString))

                If Not td.oper Is Nothing Then
                    If td.oper.ID.Equals(GetOper().ID) Then
                        If MsgBox("Удалить фото?", vbQuestion + vbYesNo, "Подтвердите") = DialogResult.Yes Then
                            If IO.File.Exists(GetMyStorePath() & "\" & td.fname) Then
                                Try
                                    picPhoto.Image.Dispose()
                                    picPhoto.Image = Image.FromFile(sPath & "\" & "nophoto.jpg")
                                    ' удаление физического файла
                                    IO.File.Delete(sPath & "\" & td.fname)
                                    tdel = ti.toimg_todelete.Add()
                                    tdel.filerowid = picPhoto.Tag.ToString
                                    tdel.fname = td.fname
                                    tdel.Save()
                                    ti.toimg_data.Delete(New Guid(picPhoto.Tag.ToString))
                                    LoadPhotos(0)
                                Catch ex As Exception
                                    MsgBox("Недостаточно прав для удаления файла: " & vbCrLf & ex.Message, vbExclamation + vbOKOnly, "Ошибка")
                                End Try

                            End If



                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

    End Sub



    Private Sub frmSystemTO_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not picPhoto.Image Is Nothing Then
            picPhoto.Image.Dispose()
        End If
        If Not picIMAGE.Image Is Nothing Then
            picIMAGE.Image.Dispose()
        End If
    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'myresizer.ResizeAllControls(Me)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            If Not chk Is Nothing Then
                If chk.to_taskcheckcomment.Count > 0 Then
                    chk.thevalue = "не проверен"
                    If Not TagID.Equals(Guid.Empty) Then
                        If chk.tagid <> LATIR2.Utils.GUID2String(TagID) Then
                            chk.tagid = LATIR2.Utils.GUID2String(TagID)
                            chk.tagtime = DateTime.Now()
                        End If
                    End If


                    For Each l As ListViewItem In lstMeasure.Items
                        If l.Tag.Equals(chk.ID) Then
                            If chk.thevalue <> "" Then
                                If chk.thevalue = "не проверен" Then
                                    l.ImageIndex = 2
                                Else
                                    l.ImageIndex = 0
                                End If

                            Else
                                l.ImageIndex = 1
                            End If
                            Exit For
                        End If
                    Next
                    chk.Save()
                    hasSave = True

                Else
                    MsgBox("Сначала введите комментарий", vbInformation & vbOKOnly, "Отметить как непроверенный")

                End If
            End If

        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim cInf As String
        Dim chk2 As totask.totask.to_taskchecks
        Try

            If Not chk Is Nothing Then
                If chk.to_taskcheckcomment.Count > 0 Then
                    chk.thevalue = "не проверен"

                    cinf = chk.to_taskcheckcomment.Item(1).info
                    chk.Save()

                    For Each l As ListViewItem In lstMeasure.Items
                        chk2 = tsk.to_taskchecks.Item(l.Tag)

                        If chk2.thevalue = "" Then
                            chk2.thevalue = "не проверен"
                            If Not TagID.Equals(Guid.Empty) Then
                                If chk2.tagid <> LATIR2.Utils.GUID2String(TagID) Then
                                    chk2.tagid = LATIR2.Utils.GUID2String(TagID)
                                    chk2.tagtime = DateTime.Now()
                                End If
                            End If
                            chk2.Save()
                            l.ImageIndex = 2
                            With CType(chk2.to_taskcheckcomment.Add, totask.totask.to_taskcheckcomment)
                                .the_operator = GetOper()
                                .info = cInf
                                .Save()
                            End With

                        End If
                    Next

                    hasSave = True

                Else
                    MsgBox("Сначала введите комментарий", vbInformation & vbOKOnly, "Отметить как непроверенный")

                End If
            End If

        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub
End Class