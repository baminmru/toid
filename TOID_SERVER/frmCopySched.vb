Public Class frmCopySched
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmCopySched_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpCopyTo.Value = Date.Today.AddDays(1)
        dtpStart.Value = DateSerial(DateTime.Today.Year, DateTime.Today.Month, 1)
        dtpEnd.Value = Date.Today
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If dtpStart.Value < dtpEnd.Value And dtpEnd.Value < dtpCopyTo.Value Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Следует выбрать правильные значения параметров")
        End If

    End Sub
End Class