Imports LATIR2
Imports LATIR2.Document
Imports Oracle.ManagedDataAccess.Client
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Private tod As tod.tod.Application

    Private Manager As LATIR2.Manager

    Private cm As CMConnector


    Sub Main()
        Manager = New LATIR2.Manager


        cm = New CMConnector()

        Manager.Site = cm.toid_site

        If Manager.Session.Login(cm.toid_usr, cm.toid_pwd) Then
            Dim dt As DataTable
            Dim dts As DataTable
            Dim dttr As DataTable
            Dim id As Guid
            Dim stid As Guid
            Dim i As Integer
            Dim j As Integer
            Dim invn As String
            Dim tst As tod.tod.tod_st
            Dim tr As totrn.totrn.Application
            Dim trh As totrn.totrn.totrn_def
            Dim trd As totrn.totrn.totrn_data
            Dim ttype As tod.tod.tod_trand


            dt = Manager.GetData("select * from v_instance where objtype='tod'")
            id = New Guid(dt.Rows(0)("instanceid").ToString)
            tod = Manager.GetInstanceObject(id)

#Region "Get Monitoring Trand"
            ' load  monitoring data

            dt = Manager.GetData("select  tod_stid, invn from to_cardinfo JOIN tod_st ON to_cardinfo.THE_MACHINE=tod_st.tod_stid")
            For i = 0 To dt.Rows.Count - 1
                stid = New Guid(dt.Rows(i)("tod_stid").ToString)
                invn = dt.Rows(i)("invn").ToString
                tst = tod.tod_st.Item(stid)
                Console.WriteLine(invn)
                If Not tst Is Nothing Then
                    dts = cm.QuerySelect("select * from stat where invn='" & invn & "' and YMD >=" & cm.OracleDate(DateSerial(Date.Today.Year, 1, 1)))
                    If dts.Rows.Count > 0 Then
                        ' найти ( или создать тренд )
                        ttype = Nothing
                        ttype = FindTrand("Ремонты")
                        dttr = Manager.GetData("select instanceid from totrn_def where  trandtype=" & Manager.ID2Const(ttype.ID) & " and  topvalue=" & DateTime.Today.Year.ToString & "  And themachine=" & Manager.ID2Const(stid))
                        If dttr.Rows.Count = 0 Then
                            id = Guid.NewGuid
                            tr = Manager.NewInstance(id, "totrn", tst.name & "-" & DateTime.Today.Year.ToString & ". Ремонты.")
                            trh = tr.totrn_def.Add
                            trh.themachine = tst
                            trh.trandtype = ttype
                            trh.topvalue = DateTime.Today.Year
                            trh.Save()
                            tr.AutoLoadPart = False
                        Else
                            id = New Guid(dttr.Rows(0)("instanceid").ToString)
                            tr = Manager.GetInstanceObject(id)
                            tr.AutoLoadPart = False
                        End If

                        For j = 0 To dts.Rows.Count - 1
                            dttr = Manager.GetData("select instanceid from totrn_data where time_label=" & Manager.Date2Const(dts.Rows(j)("ymd")) & "  And instanceid=" & Manager.ID2Const(id))
                            If dttr.Rows.Count = 0 Then
                                trd = tr.totrn_data.Add
                                Try
                                    trd.thevalue = dts.Rows(j)("rtime")
                                Catch ex As Exception
                                    trd.thevalue = 0
                                End Try
                                If trd.thevalue < 0 Then trd.thevalue = 0

                                trd.time_label = dts.Rows(j)("ymd")
                                trd.Save()
                            End If
                        Next




                        ' найти ( или создать тренд )
                        ttype = Nothing
                        ttype = FindTrand("работа")
                        id = New Guid(dt.Rows(i)("tod_stid").ToString)
                        dttr = Manager.GetData("select instanceid from totrn_def where  trandtype=" & Manager.ID2Const(ttype.ID) & " and  topvalue=" & DateTime.Today.Year.ToString & "  And themachine=" & Manager.ID2Const(stid))
                        If dttr.Rows.Count = 0 Then
                            id = Guid.NewGuid
                            tr = Manager.NewInstance(id, "totrn", tst.name & "-" & DateTime.Today.Year.ToString & ". Работа.")
                            trh = tr.totrn_def.Add
                            trh.themachine = tst
                            trh.trandtype = ttype
                            trh.topvalue = DateTime.Today.Year
                            trh.Save()
                            tr.AutoLoadPart = False
                        Else
                            id = New Guid(dttr.Rows(0)("instanceid").ToString)
                            tr = Manager.GetInstanceObject(id)
                            tr.AutoLoadPart = False
                        End If

                        For j = 0 To dts.Rows.Count - 1
                            dttr = Manager.GetData("select instanceid from totrn_data where time_label=" & Manager.Date2Const(dts.Rows(j)("ymd")) & "  And instanceid=" & Manager.ID2Const(id))
                            If dttr.Rows.Count = 0 Then
                                trd = tr.totrn_data.Add
                                Try
                                    trd.thevalue = dts.Rows(j)("wtime")
                                Catch ex As Exception
                                    trd.thevalue = 0
                                End Try
                                If trd.thevalue < 0 Then trd.thevalue = 0
                                trd.time_label = dts.Rows(j)("ymd")
                                trd.Save()
                            End If
                        Next


                    End If
                End If



            Next
#End Region

#Region "Omative trand load"

            Dim msConnect As SqlClient.SqlConnection
            Dim cb As SqlConnectionStringBuilder
            Dim msda As SqlDataAdapter
            Dim mscmd As SqlCommand
            Dim oname As String
            Dim v As Short
            Dim vout As Short

            cb = New SqlConnectionStringBuilder
            cb.DataSource = cm.ms_site
            cb.UserID = cm.ms_usr
            cb.Password = cm.ms_pwd
            cb.IntegratedSecurity = False
            cb.InitialCatalog = cm.ms_base
            msConnect = New SqlConnection(cb.ToString)
            msConnect.Open()
            If msConnect.State = ConnectionState.Open Then

                dt = Manager.GetData("select  tod_stid, tod_st.invn,omative2invn.omname,omative2invn.thecomment from to_cardinfo JOIN tod_st  ON to_cardinfo.THE_MACHINE=tod_st.tod_stid join omative2invn on omative2invn.invn=tod_st.invn order by omative2invn.invn,omative2invn.omname ")
                For i = 0 To dt.Rows.Count - 1
                    stid = New Guid(dt.Rows(i)("tod_stid").ToString)
                    invn = dt.Rows(i)("invn").ToString
                    tst = tod.tod_st.Item(stid)
                    oname = dt.Rows(i)("omname").ToString
                    Console.WriteLine(invn & " " & oname)
                    msda = New SqlDataAdapter
                    mscmd = New SqlCommand
                    mscmd.CommandType = CommandType.Text
                    mscmd.CommandText = "select [time],[status] from Status where substring( [Time],8,2) =" & (DateTime.Today.Year Mod 100).ToString & "  and machineName ='" & oname & "' order by [time]"
                    mscmd.Connection = msConnect


                    msda.SelectCommand = mscmd
                    dts = New DataTable
                    msda.Fill(dts)

                    If dts.Rows.Count > 0 Then
                        ttype = Nothing
                        ttype = FindTrand(dt.Rows(i)("thecomment").ToString)
                        dttr = Manager.GetData("select instanceid from totrn_def where  trandtype=" & Manager.ID2Const(ttype.ID) & " and  topvalue=" & DateTime.Today.Year.ToString & "  And themachine=" & Manager.ID2Const(stid))
                        If dttr.Rows.Count = 0 Then
                            id = Guid.NewGuid
                            tr = Manager.NewInstance(id, "totrn", tst.name & "-" & DateTime.Today.Year.ToString & ". " & dt.Rows(i)("thecomment").ToString)
                            trh = tr.totrn_def.Add
                            trh.themachine = tst
                            trh.trandtype = ttype
                            trh.topvalue = DateTime.Today.Year
                            trh.Save()
                            tr.AutoLoadPart = False
                        Else
                            id = New Guid(dttr.Rows(0)("instanceid").ToString)
                            tr = Manager.GetInstanceObject(id)
                            tr.AutoLoadPart = False
                        End If

                        For j = 0 To dts.Rows.Count - 1
                            dttr = Manager.GetData("select instanceid from totrn_data where time_label=" & Manager.Date2Const(dts.Rows(j)("Time")) & "  And instanceid=" & Manager.ID2Const(id))
                            If dttr.Rows.Count = 0 Then
                                trd = tr.totrn_data.Add
                                v = dts(j)("Status")
                                If oname.ToLower.StartsWith("vcm") Then
                                    If (v And 512) = 512 Then
                                        vout = 1
                                        If (v And 8) = 8 Then
                                            vout = 2
                                        End If
                                        If (v And 2) = 2 Then
                                            vout = 3
                                        End If

                                        If (v And 4) = 4 Then
                                            vout = 10
                                        End If

                                    Else
                                        vout = 0
                                    End If

                                Else
                                    If (v And 512) = 512 Then
                                        vout = 1

                                        If (v And 128) = 128 Then
                                            vout = 2
                                        End If
                                        If (v And 8) = 8 Then
                                            vout = 3
                                        End If

                                        If (v And 16) = 16 Then
                                            vout = 10
                                        End If

                                    Else
                                        vout = 0
                                    End If

                                End If
                                Try
                                    trd.thevalue = vout
                                Catch ex As Exception
                                    trd.thevalue = 0
                                End Try
                                If trd.thevalue < 0 Then trd.thevalue = 0

                                trd.time_label = dts.Rows(j)("Time")
                                trd.Save()
                            End If
                        Next
                    End If


                Next
                msConnect.Close()
            End If


#End Region





        End If
    End Sub

    Private Function FindTrand(ByVal vtname As String) As tod.tod.tod_trand

        Dim dt As DataTable
        Dim id As Guid
        Dim tst As tod.tod.tod_trand
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



        dt = Manager.GetData("select tod_trandid from  tod_trand where name='" & name & "'")

        If dt.Rows.Count = 0 Then
            tst = tod.tod_trand.Add
            tst.Name = name
            tst.Save()
        Else
            id = New Guid(dt.Rows(0)("tod_trandid").ToString)
            tst = tod.tod_trand.Item(id)
        End If

        Return tst


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




End Module
