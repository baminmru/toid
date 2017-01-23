Imports LATIR2
Imports LATIR2.Document
Imports LATIR2GuiManager
Imports FastExcel
Imports System.IO

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

    Private Function At(R As FastExcel.Row, colIdx As Integer) As FastExcel.Cell
        Dim s As String
        For Each cell As FastExcel.Cell In R.Cells
            If cell.ColumnNumber = colIdx Then
                s = cell.ColumnName + "::" + "C=" + colIdx.ToString() + " R=" + R.RowNumber.ToString() + " =>" + cell.Value.ToString()
                Debug.Print(s)
                Return cell
            End If
        Next
        Return Nothing

    End Function
    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        If txtFile.Text = "" Then
            Exit Sub
        End If


        Dim wb As FastExcel.FastExcel
        Dim ws As Worksheet
        Dim cell As FastExcel.Cell
        Dim subsys As String = ""

        Dim cell_0 As FastExcel.Cell = Nothing
        Dim cell_A As FastExcel.Cell = Nothing
        Dim cell_B As FastExcel.Cell = Nothing
        Dim cell_C As FastExcel.Cell = Nothing
        Dim cell_D As FastExcel.Cell = Nothing
        Dim cell_E As FastExcel.Cell = Nothing
        Dim cell_Enext As FastExcel.Cell = Nothing
        Dim cell_F As FastExcel.Cell = Nothing
        Dim cell_G As FastExcel.Cell = Nothing
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
        wb = New FastExcel.FastExcel(inputFile, True)
        For Each ws In wb.Worksheets
            i = ws.Index

            txtLog.Text = ws.Name & vbCrLf & txtLog.Text


            tc = FindCard(ws.Name)
            If tc IsNot Nothing Then
                ws.Read()


                Dim rows() As FastExcel.Row = ws.Rows().ToArray()

                Dim Range As FastExcel.Row
                startcell = -1
                For j = 1 To rows.Count
                    Range = rows(j)


                    cell = At(Range, 2) 'ws.Range("B" & j.ToString(), "B" & j.ToString())
                    If cell IsNot Nothing AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString() <> "" Then
                        If cell.Value.ToString.StartsWith("№") Then
                            startcell = j
                            Exit For
                        End If
                    End If
                Next

                If startcell > 0 Then
                    For j = startcell + 1 To rows.Count - 1
                        Range = rows(j)

                        cell_0 = At(Range, 1)  '("A" & j.ToString(), "A" & j.ToString())

                        If cell_0 IsNot Nothing AndAlso cell_0.Value IsNot Nothing AndAlso cell_0.Value.ToString() <> "" Then
                            tsys = FindSys(cell_0.Value.ToString)
                        End If


                        cell = At(Range, 2) 'ws.Range("B" & j.ToString(), "B" & j.ToString())


                        If cell IsNot Nothing AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString() <> "" Then
                            If IsNumeric(cell.Value) Then
                                cell_A = At(Range, 2) 'ws.Range("B" & j.ToString(), "B" & j.ToString())
                                cell_B = At(Range, 3) 'ws.Range("C" & j.ToString(), "C" & j.ToString())
                                cell_C = At(Range, 4) 'ws.Range("D" & j.ToString(), "D" & j.ToString())
                                cell_D = At(Range, 5) 'ws.Range("E" & j.ToString(), "E" & j.ToString())
                                cell_E = At(Range, 6) 'ws.Range("F" & j.ToString(), "F" & j.ToString())
                                cell_F = At(Range, 7) 'ws.Range("G" & j.ToString(), "G" & j.ToString())
                                cell_G = At(Range, 8) 'ws.Range("H" & j.ToString(), "H" & j.ToString())

                                Range = rows(j + 1)

                                cell_Enext = At(Range, 6) 'ws.Range("F" & (j + 1).ToString(), "F" & (j + 1).ToString())

                                If cell_B.Value IsNot Nothing Then
                                    If cell_B.Value.ToString <> "" Then
                                        txtLog.Text = cell_B.Value & vbCrLf & txtLog.Text
                                        Application.DoEvents()

                                        For iii = 1 To tc.to_cardchecks.Count
                                            tcc = tc.to_cardchecks.Item(iii)
                                            If tcc.the_check = cell_B.Value.ToString And tcc.the_system.ID.Equals(tsys.ID) And tcc.thesubsystem = subsys Then
                                                GoTo check_found
                                            End If
                                        Next

                                        tcc = tc.to_cardchecks.Add()

check_found:
                                        tcc.the_system = tsys
                                        tcc.thesubsystem = subsys
                                        tcc.the_check = cell_B.Value.ToString
                                        Try
                                            tcc.normochas = cell_D.Value
                                        Catch ex As Exception

                                        End Try



                                        Try
                                            tcc.the_doc = cell_C.Value.ToString
                                        Catch ex As Exception

                                        End Try

                                        If cell_E IsNot Nothing AndAlso cell_E.Value IsNot Nothing Then
                                            Try
                                                tcc.valuetype = FindValType(cell_E.Value.ToString)
                                            Catch ex As Exception

                                            End Try

                                        End If

                                        If cell_Enext IsNot Nothing AndAlso cell_Enext.Value IsNot Nothing Then
                                            Dim lv As String
                                            lv = cell_Enext.Value.ToString

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



                                        If cell_G IsNot Nothing AndAlso cell_G.Value IsNot Nothing Then
                                            Try
                                                tcc.the_comment = cell_G.Value.ToString
                                            Catch ex As Exception

                                            End Try
                                        End If


                                        tcc.Save()


                                        If cell_C IsNot Nothing AndAlso cell_C.Value IsNot Nothing Then
                                            Dim ss() As String
                                            Dim ms As String
                                            Dim tm As tod.tod.tod_material
                                            Dim dev As tocard.tocard.to_carddevices
                                            ms = cell_C.Value.ToString()
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

                            Else
                                Range = rows(j)

                                ' это название подсистемы , или выход ...
                                cell_A = At(Range, 2) ' ws.Range("B" & j.ToString(), "B" & j.ToString())
                                cell_B = At(Range, 3) 'ws.Range("C" & j.ToString(), "C" & j.ToString())
                                cell_C = At(Range, 4) 'ws.Range("D" & j.ToString(), "D" & j.ToString())
                                If cell_B.Value Is Nothing Then
                                    If cell_A.Value IsNot Nothing Then
                                        subsys = cell.Value.ToString
                                        txtLog.Text = cell.Value & vbCrLf & txtLog.Text
                                        Application.DoEvents()
                                        'End If
                                    End If
                                Else
                                    If cell_B.Value.ToString <> "" Then
                                        If cell_B.Value.ToString.ToLower().StartsWith("итого") Then
                                            Exit For
                                        End If
                                    End If
                                End If
                            End If
                        Else

                            Range = rows(j)


                            ' продолжение блока проверок  с дополнительными  точками контроля (X Y Z  и т.п. )
                            cell_B = At(Range, 3) ' ws.Range("C" & j.ToString(), "C" & j.ToString())
                            cell_C = At(Range, 4) 'ws.Range("D" & j.ToString(), "D" & j.ToString())

                            If cell_B IsNot Nothing AndAlso cell_B.Value IsNot Nothing Then
                                If cell_B.Value.ToString <> "" Then

                                    If cell_B.Value.ToString <> "" Then
                                        If cell_B.Value.ToString.ToLower().StartsWith("итого") Then
                                            Exit For
                                        End If
                                    End If


                                    Application.DoEvents()

                                    For iii = 1 To tc.to_cardchecks.Count
                                        tcc = tc.to_cardchecks.Item(iii)
                                        If tcc.the_check = cell_B.Value.ToString And tcc.the_system.ID.Equals(tsys.ID) And tcc.thesubsystem = subsys Then
                                            GoTo check_found3
                                        End If
                                    Next

                                    tcc = tc.to_cardchecks.Add()

check_found3:
                                    tcc.the_system = tsys
                                    tcc.thesubsystem = subsys
                                    tcc.the_check = cell_B.Value.ToString
                                    Try
                                        tcc.normochas = cell_D.Value
                                    Catch ex As Exception

                                    End Try



                                    Try
                                        tcc.the_doc = cell_C.Value.ToString
                                    Catch ex As Exception

                                    End Try

                                    If cell_E IsNot Nothing AndAlso cell_E.Value IsNot Nothing Then
                                        Try
                                            tcc.valuetype = FindValType(cell_E.Value.ToString)
                                        Catch ex As Exception

                                        End Try

                                    End If

                                    If cell_Enext IsNot Nothing AndAlso cell_Enext.Value IsNot Nothing Then
                                        Dim lv As String
                                        lv = cell_Enext.Value.ToString

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
                                        tcc.the_comment = cell_G.Value.ToString
                                    Catch ex As Exception

                                    End Try


                                    tcc.Save()


                                    If cell_C IsNot Nothing AndAlso cell_C.Value IsNot Nothing Then
                                        Dim ss() As String
                                        Dim ms As String
                                        Dim tm As tod.tod.tod_material
                                        Dim dev As tocard.tocard.to_carddevices
                                        ms = cell_C.Value.ToString()
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
                    txtERR.Text = txtERR.Text & ws.Name & vbCrLf
            End If
        Next

        wb.Dispose()

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
