Public Class frmJournalView
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Dim dt As DataTable
    Dim jID As System.Guid
    Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal jName As String, ByVal Caption As String)
        GuiManager = gm
        Me.Text = Caption
        dt = Manager.Session.GetRowsExDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='mtzjrnl' and  Name='" + jName + "'")
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        If dt.Rows.Count > 0 Then
            jID = New Guid(dt.Rows(0)("INSTANCEID").ToString())
            Dim jdef As MTZJrnl.MTZJrnl.Application
            jdef = CType(GuiManager.Manager.GetInstanceObject(jID), MTZJrnl.MTZJrnl.Application)
            jv.Attach(GuiManager, jdef, Me)

        Else
            jID = Guid.Empty
        End If

    End Sub







    Private Sub jv_JVOnEdit(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refresh As Boolean) Handles jv.JVOnEdit
        Dim obj As LATIR2.Document.Doc_Base
        Dim dg As LATIR2GuiManager.Doc_GUIBase
        If InstanceID.Equals(System.Guid.Empty) Then Exit Sub
        obj = GuiManager.Manager.GetInstanceObject(InstanceID)
        If obj Is Nothing Then
            MsgBox("Не удалось получить доступ к объекту")
            Exit Sub
        End If
        dg = GuiManager.GetTypeGUI(obj.TypeName)
        If dg Is Nothing Then
            MsgBox("Не удалось получить доступ к интерфейсной части объекта")
            Exit Sub
        End If

        dg.ShowForm(DocMode, obj, False)
        Refresh = False
        UseDefault = False
    End Sub



    Private Sub jv_JVOnDel(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refresh As Boolean) Handles jv.JVOnDel
        If DocMode <> "" Then
            Dim obj As LATIR2.Document.Doc_Base
            If InstanceID.Equals(System.Guid.Empty) Then Exit Sub
            obj = GuiManager.Manager.GetInstanceObject(InstanceID)
            If obj Is Nothing Then
                MsgBox("Не удалось получить доступ к объекту")
                Exit Sub
            End If
            If MsgBox("Удалить документ: <" & obj.Brief & "> ?", vbYesNo + vbQuestion, "Удаление документа") = vbYes Then
                GuiManager.Manager.DeleteInstance(obj)
            End If
        Else
            MsgBox("Операция доступна только администратору")
        End If
        UseDefault = False
    End Sub




End Class