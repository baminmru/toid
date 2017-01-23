Public Class frmChart
    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New Date(DateTime.Today.Year, DateTime.Today.Month, 1)
        dtpTo.Value = DateTime.Today

    End Sub
    Private Sub Reload()

        If cmbMachine.SelectedIndex < 0 Or cmbChartType.SelectedIndex < 0 Then
            chrt.Series.Clear()
            Exit Sub
        End If

        Dim pointIndex As Integer
        Dim dt As DataTable = Nothing
        Dim q As String
        q = "select instanceid  from v_autototrn_def where totrn_def_topvalue=" & dtpFrom.Value.Year.ToString & " and  totrn_def_trandtype_id='" & LATIR2.Utils.GUID2String(New Guid(cmbChartType.SelectedValue.ToString)) & "' and totrn_def_themachine_id='" & LATIR2.Utils.GUID2String(New Guid(cmbMachine.SelectedValue.ToString)) & "'"

        Try
            dt = Manager.GetData(q)
        Catch ex As Exception

        End Try


        chrt.Text = cmbMachine.SelectedText & " : " & cmbChartType.SelectedText
        chrt.Series.Clear()
        chrt.Series.Add("Значения")
        chrt.Series("Значения").IsXValueIndexed = False
        If chkLine.Checked Then
            chrt.Series("Значения").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Else
            chrt.Series("Значения").ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If


        If dt.Rows.Count > 0 Then

            Dim dt2 As DataTable = Nothing

            q = "select * from totrn_data where time_label>=" & Manager.Date2Const(dtpFrom.Value) & " and time_label<=" & Manager.Date2Const(dtpTo.Value) & " and  instanceid='" & LATIR2.Utils.GUID2String(New Guid(dt.Rows(0)("instanceid").ToString)) & "' order by time_label"

            Try
                dt2 = Manager.GetData(q)
            Catch ex As Exception

            End Try
            For pointIndex = 0 To dt2.Rows.Count - 1
                chrt.Series("Значения").Points.AddXY(dt2.Rows(pointIndex)("time_label"), dt2.Rows(pointIndex)("thevalue"))
            Next


        End If




    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged
        Reload()
    End Sub

    Private Sub cmbChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChartType.SelectedIndexChanged
        Reload()
    End Sub

    Private Sub frmChart_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim dtSt As DataTable = Nothing
        Dim dtTr As DataTable

        dtSt = Manager.GetData("SELECT DISTINCT to_cardinfo_the_machine_id id , to_cardinfo_the_machine name FROM v_autoTO_CARDINFO WHERE to_cardinfo_card_archived_val=0 order by to_cardinfo_the_machine")


        dtTr = Manager.Session.GetData("select tod_trandid,tod_trand_name from v_autotod_trand order by tod_trand_name")


        cmbMachine.DisplayMember = "name"
        cmbMachine.ValueMember = "id"
        cmbMachine.DataSource = dtSt


        cmbChartType.DisplayMember = "tod_trand_name"
        cmbChartType.ValueMember = "tod_trandid"
        cmbChartType.DataSource = dtTr
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkLine.CheckedChanged
        Reload()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        Reload()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        Reload()
    End Sub
End Class