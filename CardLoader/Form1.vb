Imports LATIR2
Imports LATIR2.Document
Imports LATIR2GuiManager
Imports SpreadsheetLight
Imports System.IO
Imports DocumentFormat.OpenXml


Public Class Form1
    Private Manager As LATIR2.Manager
    Private gMan As LATIR2GuiManager.LATIRGuiManager

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Manager = New Manager
        gMan = New LATIRGuiManager
        gMan.Attach(Manager)
        If Not gMan.Login("supervisor", "toid_ORA") Then
            End
        End If
    End Sub

    Private Sub cmdFile_Click(sender As Object, e As EventArgs) Handles cmdFile.Click
        opf.Multiselect = False
        opf.CheckFileExists = True
        opf.CheckPathExists = True
        opf.ReadOnlyChecked = True
        opf.InitialDirectory = "C:\bami\projects\CM_2016\"
        opf.Filter = "All files|*.*"
        opf.Title = "Файл для загрузки"

        If opf.ShowDialog = DialogResult.OK Then
            txtFile.Text = opf.FileName
        End If
    End Sub

    Private tod As tod.tod.Application
    Private tc As tocard.tocard.Application

    Private Function At(R As Integer, colIdx As Integer) As SpreadsheetLight.SLCell
        Dim s As String
        Dim slp As New SLCellPoint(R, colIdx)
        Dim slc As SLCell
        Try
            slc = Cells(slp)
            If slc.IsEmpty = False Then
                If slc.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString Then
                    s = wb.GetCellTrueValue(slc)
                    slc.CellText = s
                Else

                    If slc.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number Then
                        If slc.NumericValue = 0.0 Then
                            slc.CellText = ""
                        Else
                            slc.CellText = slc.NumericValue.ToString()
                        End If

                    End If

                End If


            End If
        Catch ex As Exception
            slc = Nothing
        End Try



        Return slc

    End Function
    Public wb As SpreadsheetLight.SLDocument
    Public Cells As Dictionary(Of SpreadsheetLight.SLCellPoint, SpreadsheetLight.SLCell)

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        If txtFile.Text = "" Then
            Exit Sub
        End If



        Dim cell As SpreadsheetLight.SLCell
        Dim subsys As String = ""
        Dim gname As String = ""

        Dim cell_0 As SpreadsheetLight.SLCell = Nothing
        Dim cell_A As SpreadsheetLight.SLCell = Nothing
        Dim cell_B As SpreadsheetLight.SLCell = Nothing
        Dim cell_C As SpreadsheetLight.SLCell = Nothing
        Dim cell_D As SpreadsheetLight.SLCell = Nothing
        Dim cell_E As SpreadsheetLight.SLCell = Nothing
        Dim cell_Enext As SpreadsheetLight.SLCell = Nothing
        Dim cell_F As SpreadsheetLight.SLCell = Nothing
        Dim cell_G As SpreadsheetLight.SLCell = Nothing
        Dim iii As Integer

        Dim tsys As tod.tod.tod_system = Nothing
        Dim tcc As tocard.tocard.to_cardchecks = Nothing

        Dim id As Guid
        Dim dt As DataTable

        dt = Manager.GetData("select * from v_instance where objtype='tod'")
        id = New Guid(dt.Rows(0)("instanceid").ToString)
        tod = Manager.GetInstanceObject(id)



        Dim i As Integer, j As Integer, startcell As Integer
        Dim inputFile As FileInfo = New FileInfo(txtFile.Text)
        wb = New SpreadsheetLight.SLDocument(txtFile.Text)
        Dim worksheets As List(Of String)
        worksheets = wb.GetSheetNames()
        wb.CloseWithoutSaving()
        Dim sName As String

        For Each sName In worksheets
            wb = New SpreadsheetLight.SLDocument(txtFile.Text, sName)
            ' i = ws.Index

            txtLog.Text = sName & vbCrLf & txtLog.Text
            Application.DoEvents 

            tc = FindCard(sName)
            If tc IsNot Nothing Then
                Cells = wb.GetCells()


                Dim RowCount As Integer
                RowCount = wb.GetWorksheetStatistics().NumberOfRows


                startcell = -1
                For j = 1 To RowCount



                    cell = At(j, 2) 'ws.Range("B" & j.ToString(), "B" & j.ToString())
                    If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                        If cell.CellText.StartsWith("№") Then
                            startcell = j
                            Exit For
                        End If
                    End If
                Next

                If startcell > 0 Then
                    For j = startcell + 1 To RowCount


                        cell_0 = At(j, 1)  '("A" & j.ToString(), "A" & j.ToString())

                        If cell_0 IsNot Nothing AndAlso Not cell_0.IsEmpty AndAlso cell_0.CellText <> "" Then
                            tsys = FindSys(cell_0.CellText)
                            gname = cell_0.CellText
                        End If


                        cell = At(j, 2) 'ws.Range("B" & j.ToString(), "B" & j.ToString())


                        If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                            If IsNumeric(cell.CellText) Then
                                cell_A = At(j, 2) 'ws.Range("B" & j.ToString(), "B" & j.ToString())
                                cell_B = At(j, 3) 'ws.Range("C" & j.ToString(), "C" & j.ToString())
                                cell_C = At(j, 4) 'ws.Range("D" & j.ToString(), "D" & j.ToString())
                                cell_D = At(j, 5) 'ws.Range("E" & j.ToString(), "E" & j.ToString())
                                cell_E = At(j, 6) 'ws.Range("F" & j.ToString(), "F" & j.ToString())
                                cell_F = At(j, 7) 'ws.Range("G" & j.ToString(), "G" & j.ToString())
                                cell_G = At(j, 8) 'ws.Range("H" & j.ToString(), "H" & j.ToString())



                                cell_Enext = At(j + 1, 6) 'ws.Range("F" & (j + 1).ToString(), "F" & (j + 1).ToString())

                                If Not cell_B.IsEmpty Then

                                    If cell_B.CellText <> "" Then
                                        txtLog.Text = gname & " " & subsys & " " & cell_B.CellText & vbCrLf & txtLog.Text
                                        Application.DoEvents()
                                        If tsys IsNot Nothing Then
                                            For iii = 1 To tc.to_cardchecks.Count
                                                tcc = tc.to_cardchecks.Item(iii)
                                                Try
                                                    If tcc.the_check = cell_B.CellText And tcc.the_system.ID.Equals(tsys.ID) And tcc.thesubsystem = subsys Then
                                                        GoTo check_found
                                                    End If
                                                Catch ex As Exception

                                                End Try

                                            Next

                                            tcc = tc.to_cardchecks.Add()

check_found:
                                            tcc.the_system = tsys
                                            tcc.thesubsystem = subsys
                                            tcc.the_check = cell_B.CellText
                                            Try
                                                tcc.normochas = cell_D.CellText
                                            Catch ex As Exception

                                            End Try



                                            Try
                                                tcc.the_doc = cell_C.CellText
                                            Catch ex As Exception

                                            End Try

                                            If cell_E IsNot Nothing AndAlso Not cell_E.IsEmpty Then

                                                Try
                                                    tcc.valuetype = FindValType(cell_E.CellText)
                                                Catch ex As Exception

                                                End Try

                                            End If

                                            If cell_Enext IsNot Nothing AndAlso Not cell_Enext.IsEmpty Then
                                                Dim lv As String
                                                lv = cell_Enext.CellText

                                                If lv.IndexOf("≤") >= 0 Then
                                                    lv = lv.Replace("≤", "")
                                                    Try

                                                        tcc.hivalue = lv
                                                    Catch ex As Exception

                                                    End Try
                                                ElseIf lv.IndexOf("≥") >= 0 Then
                                                    lv = lv.Replace("≥", "")
                                                    Try

                                                        tcc.lowvalue = lv
                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        tcc.hivalue = lv
                                                        'tcc.lowvalue = lv
                                                    Catch ex As Exception

                                                    End Try
                                                End If

                                            End If



                                            If cell_G IsNot Nothing AndAlso Not cell_G.IsEmpty Then

                                                Try
                                                    tcc.the_comment = cell_G.CellText
                                                Catch ex As Exception

                                                End Try
                                            End If


                                            tcc.Save()



                                            If cell_C IsNot Nothing AndAlso Not cell_C.IsEmpty Then
                                                Dim ss() As String
                                                Dim ms As String
                                                Dim tm As tod.tod.tod_material
                                                Dim dev As tocard.tocard.to_carddevices
                                                ms = cell_C.CellText
                                                ms = ms.Replace(vbCr, ".")
                                                ms = ms.Replace(vbLf, ".")
                                                ms = ms.Replace(",", ".")
                                                ms = ms.Replace("-", " ")
                                                ms = ms.Replace("  ", " ")
                                                ms = ms.Replace("  ", " ")
                                                ms = ms.Replace("  ", " ")
                                                ms = ms.Replace("  ", " ")
                                                ss = ms.Split(".")
                                                Dim ii As Integer
                                                For ii = LBound(ss) To UBound(ss)
                                                    If ss(ii) <> "" Then
                                                        tm = FindMaterial(ss(ii))
                                                        If Not tm Is Nothing Then
                                                            dev = tcc.to_carddevices.Add()
                                                            dev.mat = tm
                                                            dev.Save()

                                                        End If
                                                    End If

                                                Next


                                            End If
                                        End If
                                    End If
                                End If

                            Else


                                ' это название подсистемы , или выход ...
                                cell_A = At(j, 2) ' ws.Range("B" & j.ToString(), "B" & j.ToString())
                                cell_B = At(j, 3) 'ws.Range("C" & j.ToString(), "C" & j.ToString())
                                cell_C = At(j, 4) 'ws.Range("D" & j.ToString(), "D" & j.ToString())
                                If cell_B.CellText = "" Then
                                    If Not cell_A.IsEmpty Then
                                        subsys = cell.CellText
                                        txtLog.Text = gname & " " & subsys & " " & cell.CellText & vbCrLf & txtLog.Text
                                        Application.DoEvents()
                                        'End If
                                    End If
                                Else
                                    If cell_B.CellText <> "" Then
                                        If cell_B.CellText.ToLower().StartsWith("итого") Then
                                            Exit For
                                        End If
                                    End If
                                End If
                            End If
                        Else




                            ' продолжение блока проверок  с дополнительными  точками контроля (X Y Z  и т.п. )
                            cell_B = At(j, 3) ' ws.Range("C" & j.ToString(), "C" & j.ToString())
                            cell_C = At(j, 4) 'ws.Range("D" & j.ToString(), "D" & j.ToString())

                            If cell_B IsNot Nothing AndAlso Not cell_B.IsEmpty Then

                                If cell_B.CellText <> "" Then

                                    If cell_B.CellText <> "" Then
                                        If cell_B.CellText.ToLower().StartsWith("итого") Then
                                            Exit For
                                        End If
                                    End If


                                    Application.DoEvents()

                                    For iii = 1 To tc.to_cardchecks.Count
                                        tcc = tc.to_cardchecks.Item(iii)
                                        Try
                                            If tcc.the_check = cell_B.CellText And tcc.the_system.ID.Equals(tsys.ID) And tcc.thesubsystem = subsys Then
                                                GoTo check_found3
                                            End If
                                        Catch ex As Exception

                                        End Try

                                    Next

                                    tcc = tc.to_cardchecks.Add()

check_found3:
                                    tcc.the_system = tsys
                                    tcc.thesubsystem = subsys
                                    tcc.the_check = cell_B.CellText
                                    Try
                                        tcc.normochas = cell_D.CellText
                                    Catch ex As Exception

                                    End Try



                                    Try
                                        tcc.the_doc = cell_C.CellText
                                    Catch ex As Exception

                                    End Try

                                    If cell_E IsNot Nothing AndAlso Not cell_E.IsEmpty Then

                                        Try
                                            tcc.valuetype = FindValType(cell_E.CellText)
                                        Catch ex As Exception

                                        End Try

                                    End If

                                    If cell_Enext IsNot Nothing AndAlso Not cell_Enext.IsEmpty Then
                                        Dim lv As String
                                        lv = cell_Enext.CellText

                                        If lv.IndexOf("≤") >= 0 Then
                                            lv = lv.Replace("≤", "")
                                            Try

                                                tcc.hivalue = lv
                                            Catch ex As Exception

                                            End Try
                                        ElseIf lv.IndexOf("≥") >= 0 Then
                                            lv = lv.Replace("≥", "")
                                            Try

                                                tcc.lowvalue = lv
                                            Catch ex As Exception

                                            End Try
                                        Else
                                            Try
                                                tcc.hivalue = lv
                                                'tcc.lowvalue = lv
                                            Catch ex As Exception

                                            End Try
                                        End If

                                    End If




                                    Try
                                        tcc.the_comment = cell_G.CellText
                                    Catch ex As Exception

                                    End Try


                                    tcc.Save()


                                    If cell_C IsNot Nothing AndAlso Not cell_C.IsEmpty Then
                                        Dim ss() As String
                                        Dim ms As String
                                        Dim tm As tod.tod.tod_material
                                        Dim dev As tocard.tocard.to_carddevices
                                        ms = cell_C.CellText
                                        ms = ms.Replace(vbCr, ".")
                                        ms = ms.Replace(vbLf, ".")
                                        ms = ms.Replace(",", ".")
                                        ms = ms.Replace("-", " ")
                                        ms = ms.Replace("  ", " ")
                                        ms = ms.Replace("  ", " ")
                                        ms = ms.Replace("  ", " ")
                                        ms = ms.Replace("  ", " ")
                                        ss = ms.Split(".")
                                        Dim ii As Integer
                                        For ii = LBound(ss) To UBound(ss)
                                            If ss(ii) <> "" Then
                                                tm = FindMaterial(ss(ii))
                                                If Not tm Is Nothing Then
                                                    dev = tcc.to_carddevices.Add()
                                                    dev.mat = tm
                                                    dev.Save()

                                                End If
                                            End If

                                        Next


                                    End If
                                End If
                            End If



                        End If
                    Next
                End If

            Else
                txtERR.Text = txtERR.Text & sName & vbCrLf
            End If
            wb.CloseWithoutSaving()
            wb.Dispose()
        Next



        txtLog.Text = "Загрузка завершена" & vbCrLf & txtLog.Text


    End Sub


    Private Function FindCard(ByVal invn As String) As tocard.tocard.Application
        Dim dt As DataTable
        Dim id As Guid
        Dim inv As String
        Dim tc As tocard.tocard.Application = Nothing
        Dim tst As tod.tod.tod_st = Nothing
        Dim tcinfo As tocard.tocard.to_cardinfo

        inv = invn.Replace("-", "")
        dt = Manager.GetData("select TO_CARDINFO.instanceid from TO_CARDINFO join TOD_ST ON TO_CARDINFO.THE_MACHINE=TOD_STID  where invn='" & inv & "'")

        If dt.Rows.Count = 0 Then
            id = Guid.NewGuid
            tst = FindSt(inv)
            If tst IsNot Nothing Then
                tc = Manager.NewInstance(id, "tocard", invn)
                tcinfo = tc.to_cardinfo.Add
                tcinfo.the_machine = tst
                tcinfo.card_archived = tocard.tocard.enumBoolean.Boolean_Net
                tcinfo.card_date = Date.Now
                tcinfo.Save()

            End If



        Else
            id = New Guid(dt.Rows(0)("instanceid").ToString)
            tc = Manager.GetInstanceObject(id)
        End If
        Return tc


    End Function



    Private Function FindSt(ByVal invn As String) As tod.tod.tod_st
        Dim dt As DataTable
        Dim id As Guid
        Dim inv As String
        Dim tst As tod.tod.tod_st
        inv = invn.Replace("-", "")
        dt = Manager.GetData("select TOD_STID from  TOD_ST  where invn='" & inv & "'")

        If dt.Rows.Count = 0 Then
            Return Nothing

        Else
            id = New Guid(dt.Rows(0)("TOD_STID").ToString)
            tst = tod.tod_st.Item(id)
        End If
        Return tst


    End Function


    Private Function FindSys(ByVal sname As String) As tod.tod.tod_system
        Dim dt As DataTable
        Dim id As Guid
        Dim tst As tod.tod.tod_system
        Dim name As String
        name = sname.TrimEnd.TrimStart
        name = name.Replace("ё", "е")
        name = name.Replace(".", "")
        name = name.ToLower


        If name = "" Then
            Return Nothing
        End If

        dt = Manager.GetData("select tod_systemid from  tod_system   where name='" & Name & "'")

        If dt.Rows.Count = 0 Then

            tst = tod.tod_system.Add
            tst.Name = Name
            tst.Save()
        Else
            id = New Guid(dt.Rows(0)("tod_systemid").ToString)
            tst = tod.tod_system.Item(id)
        End If
        Return tst


    End Function



    Private Function FindValType(ByVal vtname As String) As tod.tod.tod_valtype

        Dim dt As DataTable
        Dim id As Guid
        Dim tst As tod.tod.tod_valtype
        Dim name As String

        name = vtname.Replace("Номинал", "")
        name = name.Replace(" ", "")
        name = name.Replace(",", "")

        If name.Trim = "" Then
            Return Nothing
        End If

        If name.ToLower = "да" Then
            id = New Guid("{CBD5D56B-72B6-4071-AEF3-42244A092DAC}")
            tst = tod.tod_valtype.Item(id)
            Return tst
        End If


        dt = Manager.GetData("select tod_valtypeid from  tod_valtype where name='" & name & "'")

        If dt.Rows.Count = 0 Then
            tst = tod.tod_valtype.Add
            tst.Name = Name
            tst.Save()
        Else
            id = New Guid(dt.Rows(0)("tod_valtypeid").ToString)
            tst = tod.tod_valtype.Item(id)
        End If

        Return tst


    End Function




    Private Function FindMaterial(ByVal vtname As String) As tod.tod.tod_material

        Dim dt As DataTable
        Dim id As Guid
        Dim tst As tod.tod.tod_material
        Dim name As String

        name = vtname.Replace(".", "")
        name = name.Replace("  ", " ")
        name = name.Replace("  ", " ")
        name = name.Replace("  ", " ")
        name = name.Replace("ё", "е")
        name = name.Trim
        name = name.TrimEnd
        name = name.TrimStart
        name = name.ToLower

        If name.Trim = "" Then
            Return Nothing
        End If



        dt = Manager.GetData("select tod_materialid from  tod_material where name='" & name & "'")

        If dt.Rows.Count = 0 Then
            tst = tod.tod_material.Add
            tst.Name = name
            tst.Save()
        Else
            id = New Guid(dt.Rows(0)("tod_materialid").ToString)
            tst = tod.tod_material.Item(id)
        End If

        Return tst


    End Function

End Class
