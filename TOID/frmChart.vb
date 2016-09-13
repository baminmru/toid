Public Class frmChart
    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim random As New Random()
        Dim [date] As DateTime = DateTime.Now.Date
        Dim pointIndex As Integer
        chrt.Series("Series1").IsXValueIndexed = False
        For pointIndex = 0 To 7
            chrt.Series("Series1").Points.AddXY([date], random.Next(5, 95))
            [date] = [date].AddDays(random.Next(1, 5))
        Next

        '' Use point index instead of the X value
        'If UseIndex.Checked Then
        '    chrt.Series("Series1").IsXValueIndexed = True

        '    ' Show labels every day
        '    chrt.ChartAreas("Default").AxisX.LabelStyle.Interval = 1
        '    chrt.ChartAreas("Default").AxisX.MajorGrid.Interval = 1
        '    chrt.ChartAreas("Default").AxisX.MajorTickMark.Interval = 1
        'End If

    End Sub
End Class