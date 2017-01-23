Public Class frmChart

    Public StID As Guid
    Public StName As String
    Private myresizer As New LATIR2GuiManager.Resizer

    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New Date(DateTime.Today.Year, DateTime.Today.Month, 1)
        dtpTo.Value = DateTime.Today

        myresizer = New LATIR2GuiManager.Resizer

        myresizer.FindAllControls(Me)
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        lblText.Text = StName

    End Sub
    Private Sub Reload()
        Dim pointIndex As Integer
        Dim dt As DataTable = Nothing
        Dim sname As String
        Dim q As String
        q = "select instanceid  from v_autototrn_def where totrn_def_topvalue=" & DateTime.Today.Year.ToString & " and totrn_def_trandtype_id='" & LATIR2.Utils.GUID2String(New Guid(cmbChartType.SelectedValue.ToString)) & "' and totrn_def_themachine_id='" & LATIR2.Utils.GUID2String(StID) & "'"
        Try
            dt = Manager.GetData(q)
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

        sname = cmbChartType.Text

        chrt.Text = StName & " : " & cmbChartType.Text
        chrt.Series.Clear()

        chrt.Series.Add(sname)
        chrt.Series(sname).IsXValueIndexed = False

        If dt.Rows.Count > 0 Then








            If dt.Rows.Count > 0 Then

                Dim dt2 As DataTable = Nothing

                q = "select * from totrn_data where time_label>=" & Manager.Date2Const(dtpFrom.Value) & " and time_label<=" & Manager.Date2Const(dtpTo.Value) & " and  instanceid='" & LATIR2.Utils.GUID2String(New Guid(dt.Rows(0)("instanceid").ToString)) & "' order by time_label"

                Try
                    dt2 = Manager.GetData(q)
                Catch ex As Exception
                    Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                End Try
                For pointIndex = 0 To dt2.Rows.Count - 1
                    Try
                        chrt.Series("Значения").Points.AddXY(dt2.Rows(pointIndex)("time_label"), dt2.Rows(pointIndex)("thevalue"))
                    Catch ex As Exception
                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try

                Next


            End If


        End If




    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs)
        Reload()
    End Sub

    Private Sub cmbChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChartType.SelectedIndexChanged
        Reload()
    End Sub

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.Close()
    End Sub

    Private Sub frmChart_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim dtTr As DataTable

        dtTr = Manager.GetData("select id,tod_trand_name from v_autotod_trand order by tod_trand_name")




        cmbChartType.DisplayMember = "tod_trand_name"
        cmbChartType.ValueMember = "id"
        cmbChartType.DataSource = dtTr
        cmbChartType.SelectedIndex = 0
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        Reload()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        Reload()
    End Sub
End Class