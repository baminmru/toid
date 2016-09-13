Imports Braincase.GanttChart
Public Class frmGant

    Private _mManager As ProjectManager
    Private Sub frmGant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _mManager = New ProjectManager()
        Dim work As Task
        Dim prev As Task
        Dim i As Integer
        For i = 1 To 60
            work = New Task()
            work.Name = "станок " + i.ToString()
            _mManager.Add(work)

            _mManager.SetDuration(work, 3)
            _mManager.SetStart(work, (i - 1) \ 3 * 3)

            prev = work
            If i > 1 Then
                _mManager.Relate(prev, work)
            End If
        Next



        Chart1.Init(_mManager)
    End Sub

    Private Sub Chart1_TaskMouseClick(sender As Object, e As TaskMouseEventArgs) Handles Chart1.TaskMouseClick
        MsgBox(e.Task.Name)
    End Sub
End Class