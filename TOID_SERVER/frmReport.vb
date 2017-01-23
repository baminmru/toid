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
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size


    End Sub


    Private Sub BuildReport()
        wh = New StringBuilder
        pb.Maximum = 100
        pb.Minimum = 0
        pb.Value = 0
        pb.Visible = True
        Label1.Visible = True
        Dim sTemp As String
        sTemp = GetSetting("TOID", "CFG", "PATH2IMG", "")
        wh.AppendLine("<!DOCTYPE html><html > <head>  <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"" /></head><body>")
        H = H + 1
        wh.AppendLine("<h" + H.ToString + ">")
        wh.Append("Станок: " & StName)
        wh.AppendLine("</h" + H.ToString + ">")
        pb.Value += 10

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
        pb.Value += 10

        ChecksToHTML()


        wh.AppendLine("</body></html>")
        File.WriteAllText(sTemp & "\report.html", wh.ToString)
        pb.Value += 10
        wb.Navigate(sTemp & "\report.html")
        AddHandler wb.Document.ContextMenuShowing, AddressOf WebContextMenuShowing
        pb.Value = 100
        pb.Visible = False
        Label1.Visible = False
    End Sub


    Private Sub ChecksToHTML()

        Dim dt As DataTable, dt2 As DataTable, dt3 As DataTable
        Dim _tcard As tocard.tocard.Application = Nothing
        Dim _tcc As tocard.tocard.to_cardchecks
        Dim _tsched As tosched.tosched.Application
        Dim _tsi As tosched.tosched.to_scheditems
        Dim _ttask As totask.totask.Application
        Dim _tchk As totask.totask.to_taskchecks
        Dim i As Integer, j As Integer, k As Integer
        Dim sPath As String
        sPath = GetSetting("TOID", "CFG", "PATH2IMG", "")
        Dim dtImg As DataTable

        Try



            dt = Manager.GetData("select * from v_autoto_scheditems  where  to_scheditems_themachine_id='" & LATIR2.Utils.GUID2String(StID) & "' order by to_scheditems_todate")
            dt2 = Manager.GetData("select * from v_autoto_cardinfo where  to_cardinfo_card_archived_val=0 and to_cardinfo_the_machine_id='" & LATIR2.Utils.GUID2String(StID) & "'")


            wh.AppendLine("<table border=""1"" style=""word-break:break-all;""><tr>")

            pb.Value += 10

            wh.AppendLine("<th>Узел</th>") ' узел
            wh.AppendLine("<th>Показатель</th>")
            wh.AppendLine("<th>нормочас</th>") ' нормочас
            wh.AppendLine("<th>минимальное значение </th>") ' минимальное значение 
            wh.AppendLine("<th>максимальное значение</th>") ' максимальное значение
            wh.AppendLine("<th>тип значения</th>") ' тип значения
            wh.AppendLine("</tr><tr>")

            pb.Value += 10

            wh.AppendLine("<td>&nbsp;</td>") ' узел
            wh.AppendLine("<td><strong>Плановая дата</strong></td>")
            wh.AppendLine("<td>&nbsp;</td>") ' нормочас
            wh.AppendLine("<td>&nbsp;</td>") ' минимальное значение 
            wh.AppendLine("<td>&nbsp;</td>") ' максимальное значение
            wh.AppendLine("<td>&nbsp;</td>") ' тип значения

            For i = 0 To dt.Rows.Count - 1
                _tsched = Manager.GetInstanceObject(New Guid(dt.Rows(i)("instanceid").ToString))
                _tsi = _tsched.to_scheditems.Item(New Guid(dt.Rows(i)("id").ToString))
                wh.Append("<td>" & _tsi.todate.ToString("yyyy/MM/dd") & "</td>")
            Next

            pb.Value += 10

            wh.AppendLine("</tr><tr>")
            wh.AppendLine("<td>&nbsp;</td>") ' узел
            wh.AppendLine("<td><strong>Фактическая дата</strong></td>")
            wh.AppendLine("<td>&nbsp;</td>") ' нормочас
            wh.AppendLine("<td>&nbsp;</td>") ' минимальное значение 
            wh.AppendLine("<td>&nbsp;</td>") ' максимальное значение
            wh.AppendLine("<td>&nbsp;</td>") ' тип значения

            For i = 0 To dt.Rows.Count - 1
                _tsched = Manager.GetInstanceObject(New Guid(dt.Rows(i)("instanceid").ToString))
                _tsi = _tsched.to_scheditems.Item(New Guid(dt.Rows(i)("id").ToString))
                wh.Append("<td>" & _tsi.finishdate.ToString("yyyy/MM/dd") & "</td>")
            Next

            pb.Value += 10

            wh.AppendLine("</tr><tr>")
            wh.AppendLine("<td>&nbsp;</td>") ' узел
            wh.AppendLine("<td><strong>Оператор</strong></td>")
            wh.AppendLine("<td>&nbsp;</td>") ' нормочас
            wh.AppendLine("<td>&nbsp;</td>") ' минимальное значение 
            wh.AppendLine("<td>&nbsp;</td>") ' максимальное значение
            wh.AppendLine("<td>&nbsp;</td>") ' тип значения

            For i = 0 To dt.Rows.Count - 1
                _tsched = Manager.GetInstanceObject(New Guid(dt.Rows(i)("instanceid").ToString))
                _tsi = _tsched.to_scheditems.Item(New Guid(dt.Rows(i)("id").ToString))
                If _tsi.oper IsNot Nothing Then
                    wh.Append("<td>" & _tsi.oper.Brief & "</td>")
                Else
                    wh.Append("<td></td>")
                End If

            Next

            wh.AppendLine("</tr>")

            pb.Value += 10

            For j = 0 To dt2.Rows.Count - 1
                _tcard = Manager.GetInstanceObject(New Guid(dt2.Rows(j)("instanceid").ToString))
                Exit For
            Next

            Dim prevsystem As String = ""
            _tcard.to_cardchecks.Sort = "thesubsystem"
            For k = 1 To _tcard.to_cardchecks.Count

                _tcc = _tcard.to_cardchecks.Item(k)
                wh.AppendLine("<tr>")
                If _tcc.thesubsystem <> "" Then
                    'wh.AppendLine("<td><strong>" & _tcc.the_system.Brief & "&nbsp;</strong>") ' узел
                    wh.AppendLine("<td><strong>" & _tcc.thesubsystem & "&nbsp;</strong>") ' узел

                    If prevsystem <> _tcc.thesubsystem Then
                        prevsystem = _tcc.thesubsystem
                        'Dim q As String

                        'q = "select " & Manager.Base2ID("rawimageid", "id") & ", fname from  rawimage where  link2id ='" & LATIR2.Utils.GUID2String(StID) & "' And link2part='tod_st' and  link1part='tod_system' and  link1id ='" & LATIR2.Utils.GUID2String(_tcc.the_system.ID) & "'  order by changestamp"

                        'dtImg = Manager.GetData(q)

                        'If dtImg.Rows.Count > 0 Then
                        '    wh.AppendLine("<table  border=""1"" style=""word-break:break-all;"">")
                        '    wh.AppendLine("<tr>")
                        '    For l = 0 To dtImg.Rows.Count - 1
                        '        wh.AppendLine("<td><img src=""" & dtImg.Rows(l)("fname") & """ width=""320"" height=""240"" border=""0""></td>")
                        '        If Not File.Exists(sPath & "\" & dtImg.Rows(l)("fname")) Then
                        '            Manager.Provider.SaveFileFromField(Manager.Connection, sPath & "\" & dtImg.Rows(l)("fname"), "rawimage", "image", New Guid(dtImg.Rows(l)("id").ToString))
                        '        End If

                        '    Next

                        '    wh.AppendLine("</tr></table>")
                        'End If

                    End If
                    wh.AppendLine("</td>")
                Else
                    wh.AppendLine("<td><strong>&nbsp;</strong></td>") ' узел
                End If

                wh.AppendLine("<td><strong>" & _tcc.the_check & "&nbsp;</strong></td>")
                wh.AppendLine("<td>" & _tcc.normochas.ToString & "&nbsp;</td>") ' нормочас
                wh.AppendLine("<td>" & _tcc.lowvalue & "&nbsp;</td>") ' минимальное значение 
                wh.AppendLine("<td>" & _tcc.hivalue & "&nbsp;</td>") ' максимальное значение
                If _tcc.ValueType IsNot Nothing Then
                    wh.AppendLine("<td>" & _tcc.ValueType.Brief & "&nbsp;</td>") ' тип значения
                Else
                    wh.AppendLine("<td>&nbsp;</td>")
                End If


                For i = 0 To dt.Rows.Count - 1
                    _tsched = Manager.GetInstanceObject(New Guid(dt.Rows(i)("instanceid").ToString))
                    _tsi = _tsched.to_scheditems.Item(New Guid(dt.Rows(i)("id").ToString))



                    dt3 = Manager.GetData("select v_autoto_taskchecks.*,v_autoto_taskinfo.to_taskinfo_themachine_id shedid " +
                        " From v_autoto_taskchecks Join v_autoto_taskinfo On v_autoto_taskchecks.instanceid=v_autoto_taskinfo.instanceid " +
                        " where  v_autoto_taskinfo.to_taskinfo_themachine_id='" & LATIR2.Utils.GUID2String(_tsi.ID) & "' and v_autoto_taskchecks.to_taskchecks_checkref_id='" & LATIR2.Utils.GUID2String(_tcc.ID) & "'")

                    If dt3.Rows.Count > 0 Then
                        Dim l As Integer
                        _ttask = Manager.GetInstanceObject(New Guid(dt3.Rows(0)("instanceid").ToString))

                        _tchk = _ttask.to_taskchecks.Item(New Guid(dt3.Rows(0)("id").ToString))
                        If Not _tchk Is Nothing Then
                            wh.AppendLine("<td>" & _tchk.theValue)

                            If _tchk.to_taskcheckcomment.Count > 0 Then

                                wh.AppendLine("<table  border=""1"" style=""word-break:break-all;"">")
                                wh.AppendLine("<tr><td colspan=""2"">Коментарии оператора</td></tr>")
                                Dim _tcm As totask.totask.to_taskcheckcomment

                                _tchk.to_taskcheckcomment.Sort = "the_date"
                                For l = 1 To _tchk.to_taskcheckcomment.Count
                                    _tcm = _tchk.to_taskcheckcomment.Item(l)
                                    wh.AppendLine("<tr><td>" & l.ToString & "</td><td>" & _tcm.Info & "</td></tr>")
                                Next

                                wh.AppendLine("</table>")

                            End If




                            dtImg = Manager.GetData("select " & Manager.Base2ID("rawimageid", "id") & ",fname from rawimage where link1id ='" & LATIR2.Utils.GUID2String(_tchk.ID) & "' And link1part='to_taskchecks' order by changestamp")

                            If dtImg.Rows.Count > 0 Then
                                wh.AppendLine("<table  border=""1"" style=""word-break:break-all;"">")
                                wh.AppendLine("<tr><td colspan=""2"">Прикрепленные фото</td></tr>")

                                For l = 0 To dtImg.Rows.Count - 1
                                    wh.AppendLine("<tr><td>" & (l + 1).ToString & "</td><td><img src=""" & dtImg.Rows(l)("fname") & """ width=""320"" height=""240"" border=""0""></td></tr>")
                                    If Not File.Exists(sPath & "\" & dtImg.Rows(l)("fname")) Then
                                        Manager.Provider.SaveFileFromField(Manager.Connection, sPath & "\" & dtImg.Rows(l)("fname"), "rawimage", "image", New Guid(dtImg.Rows(l)("id").ToString))
                                    End If

                                Next

                                wh.AppendLine("</table>")
                            End If



                            wh.AppendLine("</td>")


                        Else
                            wh.AppendLine("<td>&nbsp;</td>")
                        End If



                    End If





                Next
                wh.AppendLine("</tr>")

            Next

            pb.Value += 10


            wh.AppendLine("</tr></table>")

        Catch ex As Exception
            Debug.Print(ex.Message)
            Debug.Print(ex.StackTrace)
        End Try



    End Sub








    Private Function Notabs(ByVal s As String) As String
        Notabs = Replace(Replace(Replace(Replace(Replace(s, "</td><td>", " "), vbCrLf, " "), vbCr, " "), vbLf, " "), "  ", " ")
    End Function

    Private Sub frmReport_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        BuildReport()
        cmdPrint.Enabled = True
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        wb.ShowPrintPreviewDialog()
    End Sub
End Class