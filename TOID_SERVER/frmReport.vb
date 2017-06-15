Imports System.IO
Imports System.Text

Public Class frmReport


    Public tsk As totask.totask.Application
    Public TaskInstID As Guid
    Public StID As Guid
    Public StName As String


    Private wh As StringBuilder
    Private H As Integer = 1

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub WebContextMenuShowing(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        'displays your contextmenustrip - you could leave it out to
        ' just disable the browsers context menu
        'Me.wb.ContextMenuStrip.Show(Cursor.Position)

        'suppresses the display of the browsers context menu
        e.ReturnValue = False
    End Sub

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        'Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Timer1.Enabled = True
        'AddHandler wb.Document.ContextMenuShowing, AddressOf WebContextMenuShowing
    End Sub


    Public Sub BuildReport()
        If StName Is Nothing Then Exit Sub

        wh = New StringBuilder


        Dim sTemp As String
        sTemp = GetSetting("TOID", "CFG", "PATH2IMG", "")
        wh.AppendLine("<!DOCTYPE html><html > <head>  <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"" /></head><body>")
        H = H + 1
        wh.AppendLine("<h" + H.ToString + ">")
        wh.Append("Станок: " & StName)
        wh.AppendLine("</h" + H.ToString + ">")


        Dim sPath As String
        sPath = GetSetting("TOID", "CFG", "PATH2IMG", "")
        Dim dtImg As DataTable
        Dim q As String
        q = "select " & Manager.Base2ID("rawimageid", "id") & ", fname from  rawimage where  link2id ='" & LATIR2.Utils.GUID2String(StID) & "' And link2part='tod_st' and (link1part is null or link1part='')  order by changestamp"

        dtImg = Manager.GetData(q)

        If dtImg.Rows.Count > 0 Then
            wh.AppendLine("<table  border=""1"" style=""word-break:break-all;"">")
            wh.AppendLine("<tr>")
            For l = 0 To dtImg.Rows.Count - 1

                If Not File.Exists(sPath & "\" & dtImg.Rows(l)("fname")) Then
                    Manager.Provider.SaveFileFromField(Manager.Connection, sPath & "\" & dtImg.Rows(l)("fname"), "rawimage", "image", New Guid(dtImg.Rows(l)("id").ToString))
                End If

                wh.AppendLine("<td><img src='" & dtImg.Rows(l)("fname") & "' width='320' height='240' border='0'></td>")

            Next

            wh.AppendLine("</tr></table>")
        End If


        ChecksToHTML()


        wh.AppendLine("</body></html>")
        'Dim rid As Guid
        'rid = Guid.NewGuid
        File.WriteAllText(sTemp & "\report.html", wh.ToString)

        wb.Navigate(sTemp & "\report.html", True)
        'wb.Refresh()


    End Sub


    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        'BuildReport()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        'BuildReport()
    End Sub

    Private Sub chkUseDates_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDates.CheckedChanged
        Dim en As Boolean = False
        If chkUseDates.Checked Then
            en = True
        Else
            en = False
        End If
        dtpFrom.Enabled = en
        dtpTo.Enabled = en
        Label3.Enabled = en
        Label2.Enabled = en
        'BuildReport()
    End Sub
    Private Function LoadData(tid As Guid) As DataTable
        Dim w As String = ""
        Dim dtRows As DataTable
        Dim dt As DataTable

        Dim q1 As String
        Dim sPath As String
        sPath = GetSetting("TOID", "CFG", "PATH2IMG", "")


        q1 = "SELECT distinct invn, thesubsystem,the_check,STID FROM
          (
              SELECT   invn, thesubsystem,the_check,STID FROM v_report_task WHERE STID='" + LATIR2.Utils.GUID2String(tid) + "' 
              union ALL 
              SELECT  invn, thesubsystem,the_check,STID FROM v_report_card  WHERE STID='" + LATIR2.Utils.GUID2String(tid) + "' 
        )  U
          order BY thesubsystem,the_check        "





        If chkUseDates.Checked Then

            w = w + " and crDATE>=" + Manager.Date2Const(dtpFrom.Value)
            w = w + " and crDATE<=" + Manager.Date2Const(dtpTo.Value)

        End If



        dtRows = Manager.GetData(q1)
        pb.Minimum = 0
        pb.Maximum = dtRows.Rows.Count
        pb.Visible = True
        pb.Value = 0


        Dim r As Integer
        Dim c As Integer
        Dim dtCols As DataTable

        dtCols = Manager.GetData("select distinct tinst,crdate from v_report_task where stid='" + LATIR2.Utils.GUID2String(tid) + "' " + w + "  order by crdate")


        Dim dtGr As DataTable


        dtGr = New DataTable

        dtGr.Columns.Add("ceh")
        dtGr.Columns.Add("stname")
        dtGr.Columns.Add("invn")
        dtGr.Columns.Add("thesubsystem")
        dtGr.Columns.Add("the_check")
        dtGr.Columns.Add("vtname")
        dtGr.Columns.Add("lowvalue")
        dtGr.Columns.Add("hivalue")
        For c = 0 To dtCols.Rows.Count - 1
            dtGr.Columns.Add(dtCols.Rows(c)("tinst").ToString())
            dtGr.Columns.Add(dtCols.Rows(c)("tinst").ToString() + "_COMMENTS")
            dtGr.Columns.Add(dtCols.Rows(c)("tinst").ToString() + "_IMAGES")
        Next

        Dim dr As DataRow
        For r = 0 To dtRows.Rows.Count - 1
            pb.Value = r
            dt = Manager.GetData("select * from v_report_card where the_check='" & dtRows.Rows(r)("the_check") & "' and thesubsystem='" & dtRows.Rows(r)("thesubsystem") & "' and stid='" & dtRows.Rows(r)("stid") & "'")
            If dt.Rows.Count = 0 Then
                dt = Manager.GetData("select * from v_report_task where the_check='" & dtRows.Rows(r)("the_check") & "' and thesubsystem='" & dtRows.Rows(r)("thesubsystem") & "' and stid='" & dtRows.Rows(r)("stid") & "' order by crdate")
            End If

            If dt.Rows.Count > 0 Then
                dr = dtGr.NewRow
                dr("ceh") = dt.Rows(0)("ceh")
                dr("stname") = dt.Rows(0)("stname")
                dr("invn") = dt.Rows(0)("invn")
                dr("thesubsystem") = dt.Rows(0)("thesubsystem")
                dr("the_check") = dt.Rows(0)("the_check")
                dr("vtname") = dt.Rows(0)("vtname")
                dr("lowvalue") = dt.Rows(0)("lowvalue")
                dr("hivalue") = dt.Rows(0)("hivalue")

                For c = 0 To dtCols.Rows.Count - 1
                    dt = Manager.GetData("select * from v_report_task where the_check='" & dtRows.Rows(r)("the_check") & "' and thesubsystem='" & dtRows.Rows(r)("thesubsystem") & "' and tinst='" & dtCols.Rows(c)("tinst").ToString() & "' ")

                    If dt.Rows.Count > 0 Then
                        Dim dtImg As DataTable
                        dtImg = Manager.GetData("select " & Manager.Base2ID("rawimageid", "id") & ",fname from rawimage where link1id ='" & LATIR2.Utils.GUID2String(New Guid(dt.Rows(0)("TO_TASKCHECKSID").ToString())) & "' And link1part='to_taskchecks' order by changestamp")

                        Dim imgString As StringBuilder
                        imgString = New StringBuilder()
                        If dtImg.Rows.Count > 0 Then
                            imgString.AppendLine("<table  border=""1"" style=""word-break:break-all;"">")
                            imgString.AppendLine("<tr><td colspan=""2"">Прикрепленные фото</td></tr>")

                            For l = 0 To dtImg.Rows.Count - 1
                                imgString.AppendLine("<tr><td>" & (l + 1).ToString & "</td><td><img src=""" & dtImg.Rows(l)("fname") & """ width=""320"" height=""240"" border=""0""></td></tr>")
                                If Not File.Exists(sPath & "\" & dtImg.Rows(l)("fname")) Then
                                    Manager.Provider.SaveFileFromField(Manager.Connection, sPath & "\" & dtImg.Rows(l)("fname"), "rawimage", "image", New Guid(dtImg.Rows(l)("id").ToString))
                                End If

                            Next

                            imgString.AppendLine("</table>")
                        End If
                        dr(dtCols.Rows(c)("tinst").ToString() + "_IMAGES") = imgString.ToString()
                    End If


                    Dim sComments As String
                    sComments = ""
                    For i = 0 To dt.Rows.Count - 1
                        If i = 0 Then
                            dr(dtCols.Rows(c)("tinst").ToString()) = dt.Rows(i)("thevalue")
                        End If
                        If dt.Rows(i)("info") & "" <> "" Then
                            If sComments <> "" Then
                                sComments += ("; " & vbCrLf)
                            End If

                            sComments += dt.Rows(i)("info")

                            sComments += (" (" & dt.Rows(i)("cname") & " " & dt.Rows(i)("cfamilyname") & ") ")
                        End If

                    Next


                    dr(dtCols.Rows(c)("tinst").ToString() + "_COMMENTS") = sComments







                Next

                dtGr.Rows.Add(dr)
            End If
        Next


        pb.Visible = False

        gv.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        gv.Columns.Clear()

        gv.DataSource = dtGr

        Dim dc As DataGridViewColumn
        For Each dc In gv.Columns
            Select Case dc.DataPropertyName.ToLower
                'Case "commentator"
                '    dc.HeaderText = "Комментировал"
                '    dc.Width = 200

                'Case "thecomment"
                '    dc.HeaderText = "Комментарий"
                '    dc.Width = 200
                'Case "tagtime"
                '    dc.HeaderText = "Зарегистрировано"
                '    dc.Width = 200
                Case "hivalue"
                    dc.HeaderText = "Верхняя<br/>граница"
                Case "thevalue"
                    dc.HeaderText = "Значение"
                    dc.Width = 50
                Case "lowvalue"
                    dc.HeaderText = "Нижняя<br/>граница"
                    dc.Width = 50
                Case "vtname"
                    dc.HeaderText = "Измеряемый<br/>параметр"
                    dc.Width = 200
                Case "the_check"
                    dc.HeaderText = "Проверка"
                    dc.Width = 200
                Case "ceh"
                    dc.HeaderText = "ЦЕХ"
                    dc.Width = 50
                Case "invn"
                    dc.HeaderText = "№"
                    dc.Width = 50
                Case "stname"
                    dc.HeaderText = "Станок"
                    dc.Width = 200
                Case "todate"
                    dc.HeaderText = "Плановая<br/>дата"

                Case "opname"
                    dc.HeaderText = "Оператор"
                Case "thesubsystem"
                    dc.HeaderText = "Cистема"
                    dc.Width = 200
                Case "stname"
                    dc.HeaderText = "Станок"
                    dc.Width = 200
                Case Else
                    For r = 0 To dtCols.Rows.Count - 1
                        If dc.DataPropertyName.ToLower = dtCols.Rows(r)("tinst").ToString().ToLower() Then
                            dc.HeaderText = CType(dtCols.Rows(r)("crdate"), Date).ToString("dd/MM/yyyy") & "<br/>результаты"
                            dc.Width = 100
                        End If

                        If dc.DataPropertyName.ToLower = dtCols.Rows(r)("tinst").ToString().ToLower() & "_comments" Then
                            dc.HeaderText = CType(dtCols.Rows(r)("crdate"), Date).ToString("dd/MM/yyyy") & "<br/>комментарии"
                            dc.Width = 250
                        End If

                        If dc.DataPropertyName.ToLower = dtCols.Rows(r)("tinst").ToString().ToLower() & "_images" Then
                            dc.HeaderText = CType(dtCols.Rows(r)("crdate"), Date).ToString("dd/MM/yyyy") & "<br/>фото"
                            dc.Width = 300
                        End If
                    Next
            End Select



            dc.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Return dtGr
    End Function


    Private Sub ChecksToHTML()


        Dim i As Integer, j As Integer, k As Integer
        Dim sPath As String
        sPath = GetSetting("TOID", "CFG", "PATH2IMG", "")

        Dim dtgr As DataTable


        dtgr = LoadData(StID)
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = dtgr.Rows.Count


        Try



            wh.AppendLine("<table border=""1"" style=""word-break:break-all;""><tr>")


            Dim dc As DataGridViewColumn
            For Each dc In gv.Columns
                If dc.Width > 0 Then
                    wh.AppendLine("<th width='" + (dc.Width * 25).ToString() + "px'>" + dc.HeaderText + "</th>") ' узел
                Else
                    wh.AppendLine("<th >" + dc.HeaderText + "</th>") ' узел
                End If

            Next

            wh.AppendLine("</tr>")

            For i = 0 To dtgr.Rows.Count - 1
                pb.Value = i
                wh.AppendLine("<tr>")
                For Each dc In gv.Columns
                    If dtgr.Rows(i)(dc.DataPropertyName) & "" = "" Then
                        wh.AppendLine("<td>&nbsp;</td>") ' узел
                    Else
                        wh.AppendLine("<td>" + dtgr.Rows(i)(dc.DataPropertyName) + "</td>") ' узел
                    End If

                Next
                wh.AppendLine("</tr>")
            Next




            wh.AppendLine("</table>")

        Catch ex As Exception
            Debug.Print(ex.Message)
            Debug.Print(ex.StackTrace)
        End Try



    End Sub




    Private Function Notabs(ByVal s As String) As String
        Notabs = Replace(Replace(Replace(Replace(Replace(s, "</td><td>", " "), vbCrLf, " "), vbCr, " "), vbLf, " "), "  ", " ")
    End Function



    Private Sub cmdPrint_Click(sender As Object, e As EventArgs)
        wb.ShowPrintPreviewDialog()
    End Sub



    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdBuildReport_Click(sender As Object, e As EventArgs) Handles cmdBuildReport.Click
        BuildReport()
    End Sub
End Class