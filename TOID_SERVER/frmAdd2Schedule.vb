Imports System.Collections.Generic

Public Class frmAdd2Schedule

    Public lid As List(Of String)


    Private Sub frmAdd2Schedule_Load(sender As Object, e As EventArgs) Handles Me.Load

        dtStart.Value = DateTime.Today.AddDays(5)

        Dim dt As DataTable

        dt = Manager.Session.GetData("SELECT DISTINCT instanceid id , to_cardinfo_the_machine name FROM v_autoTO_CARDINFO WHERE to_cardinfo_card_archived_val=0 order by to_cardinfo_the_machine")
        Dim o As cbItem
        lstCard.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            On Error Resume Next
            o = New cbItem
            o.ID = dt.Rows(i)("ID")
            o.Name = dt.Rows(i)("Name")

            lstCard.Items.Add(o)


        Next




    End Sub

    Private Sub Cancell_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        lid = New List(Of String)


        For Each li As cbItem In lstCard.CheckedItems
            lid.Add(li.ID)
        Next


        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetAll.Click
        Dim i As Integer
        For i = 0 To lstCard.Items.Count - 1
            lstCard.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Dim i As Integer
        For i = 0 To lstCard.Items.Count - 1
            lstCard.SetItemChecked(i, False)
        Next
    End Sub
End Class