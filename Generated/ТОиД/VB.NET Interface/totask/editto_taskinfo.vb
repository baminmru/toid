
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_taskinfo
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IRowEditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    private mOnInit as boolean = false
    private mChanged as boolean = false
    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed 
    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved
    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed
    Public Sub Changing()
      if not mOnInit then
        mChanged = true
        raiseevent Changed()
      end if
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

 Dim iii As Integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lbltheMachine  as  System.Windows.Forms.Label
Friend WithEvents txttheMachine As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtheMachine As System.Windows.Forms.Button
Friend WithEvents lbloper  as  System.Windows.Forms.Label
Friend WithEvents txtoper As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdoper As System.Windows.Forms.Button
Friend WithEvents lbltheCard  as  System.Windows.Forms.Label
Friend WithEvents txttheCard As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtheCard As System.Windows.Forms.Button
Friend WithEvents cmdtheCardClear As System.Windows.Forms.Button

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

 Me.HolderPanel = New LATIR2GUIControls.AutoPanel
 Me.HolderPanel.SuspendLayout()
Me.SuspendLayout()
 '
'HolderPanel
'
Me.HolderPanel.AllowDrop = True
Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
Me.HolderPanel.Name = "HolderPanel"
Me.HolderPanel.Size = New System.Drawing.Size(232, 120)
Me.HolderPanel.TabIndex = 0
Me.lbltheMachine = New System.Windows.Forms.Label
Me.txttheMachine = New LATIR2GuiManager.TouchTextBox
Me.cmdtheMachine = New System.Windows.Forms.Button
Me.lbloper = New System.Windows.Forms.Label
Me.txtoper = New LATIR2GuiManager.TouchTextBox
Me.cmdoper = New System.Windows.Forms.Button
Me.lbltheCard = New System.Windows.Forms.Label
Me.txttheCard = New LATIR2GuiManager.TouchTextBox
Me.cmdtheCard = New System.Windows.Forms.Button
Me.cmdtheCardClear = New System.Windows.Forms.Button

Me.lbltheMachine.Location = New System.Drawing.Point(20,5)
Me.lbltheMachine.name = "lbltheMachine"
Me.lbltheMachine.Size = New System.Drawing.Size(200, 20)
Me.lbltheMachine.TabIndex = 1
Me.lbltheMachine.Text = "Станок"
Me.lbltheMachine.ForeColor = System.Drawing.Color.Black
Me.txttheMachine.Location = New System.Drawing.Point(20,27)
Me.txttheMachine.name = "txttheMachine"
Me.txttheMachine.ReadOnly = True
Me.txttheMachine.Size = New System.Drawing.Size(176, 20)
Me.txttheMachine.TabIndex = 2
Me.txttheMachine.Text = "" 
Me.cmdtheMachine.Location = New System.Drawing.Point(198,27)
Me.cmdtheMachine.name = "cmdtheMachine"
Me.cmdtheMachine.Size = New System.Drawing.Size(22, 20)
Me.cmdtheMachine.TabIndex = 3
Me.cmdtheMachine.Text = "..." 
Me.lbloper.Location = New System.Drawing.Point(20,52)
Me.lbloper.name = "lbloper"
Me.lbloper.Size = New System.Drawing.Size(200, 20)
Me.lbloper.TabIndex = 4
Me.lbloper.Text = "Оператор"
Me.lbloper.ForeColor = System.Drawing.Color.Black
Me.txtoper.Location = New System.Drawing.Point(20,74)
Me.txtoper.name = "txtoper"
Me.txtoper.ReadOnly = True
Me.txtoper.Size = New System.Drawing.Size(176, 20)
Me.txtoper.TabIndex = 5
Me.txtoper.Text = "" 
Me.cmdoper.Location = New System.Drawing.Point(198,74)
Me.cmdoper.name = "cmdoper"
Me.cmdoper.Size = New System.Drawing.Size(22, 20)
Me.cmdoper.TabIndex = 6
Me.cmdoper.Text = "..." 
Me.lbltheCard.Location = New System.Drawing.Point(20,99)
Me.lbltheCard.name = "lbltheCard"
Me.lbltheCard.Size = New System.Drawing.Size(200, 20)
Me.lbltheCard.TabIndex = 7
Me.lbltheCard.Text = "Диагностическая карта"
Me.lbltheCard.ForeColor = System.Drawing.Color.Blue
Me.txttheCard.Location = New System.Drawing.Point(20,121)
Me.txttheCard.name = "txttheCard"
Me.txttheCard.ReadOnly = True
Me.txttheCard.Size = New System.Drawing.Size(155, 20)
Me.txttheCard.TabIndex = 8
Me.txttheCard.Text = "" 
Me.cmdtheCard.Location = New System.Drawing.Point(176,121)
Me.cmdtheCard.name = "cmdtheCard"
Me.cmdtheCard.Size = New System.Drawing.Size(22, 20)
Me.cmdtheCard.TabIndex = 9
Me.cmdtheCard.Text = "..." 
Me.cmdtheCardClear.Location = New System.Drawing.Point(198,121)
Me.cmdtheCardClear.name = "cmdtheCardClear"
Me.cmdtheCardClear.Size = New System.Drawing.Size(22, 20)
Me.cmdtheCardClear.TabIndex = 10
Me.cmdtheCardClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheMachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheMachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtheMachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbloper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheCard)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheCard)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtheCard)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtheCardClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_taskinfo"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txttheMachine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheMachine.TextChanged
  Changing

end sub
private sub cmdtheMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtheMachine.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_st","",System.guid.Empty, id, brief) Then
          txttheMachine.Tag = id
          txttheMachine.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtoper_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtoper.TextChanged
  Changing

end sub
private sub cmdoper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoper.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("to_oper","",System.guid.Empty, id, brief) Then
          txtoper.Tag = id
          txtoper.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txttheCard_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheCard.TextChanged
  Changing

end sub
private sub cmdtheCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtheCard.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("to_cardinfo","",System.guid.Empty, id, brief) Then
          txttheCard.Tag = id
          txttheCard.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdtheCardClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtheCardClear.Click
  try
          txttheCard.Tag = Guid.Empty
          txttheCard.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As totask.totask.to_taskinfo
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totask.totask.to_taskinfo)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.theMachine Is Nothing Then
  txttheMachine.Tag = item.theMachine.id
  txttheMachine.text = item.theMachine.brief
else
  txttheMachine.Tag = System.Guid.Empty 
  txttheMachine.text = "" 
End If
If Not item.oper Is Nothing Then
  txtoper.Tag = item.oper.id
  txtoper.text = item.oper.brief
else
  txtoper.Tag = System.Guid.Empty 
  txtoper.text = "" 
End If
If Not item.theCard Is Nothing Then
  txttheCard.Tag = item.theCard.id
  txttheCard.text = item.theCard.brief
else
  txttheCard.Tag = System.Guid.Empty 
  txttheCard.text = "" 
End If
        mOnInit = false
  raiseevent Refreshed()
end sub


''' <summary>
'''Сохранения данных в полях объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save
  if mRowReadOnly =false then

If not txttheMachine.Tag.Equals(System.Guid.Empty) Then
  item.theMachine = Item.Application.FindRowObject("tod_st",txttheMachine.Tag)
Else
   item.theMachine = Nothing
End If
If not txtoper.Tag.Equals(System.Guid.Empty) Then
  item.oper = Item.Application.FindRowObject("to_oper",txtoper.Tag)
Else
   item.oper = Nothing
End If
If not txttheCard.Tag.Equals(System.Guid.Empty) Then
  item.theCard = Item.Application.FindRowObject("to_cardinfo",txttheCard.Tag)
Else
   item.theCard = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txttheMachine.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtoper.Tag.Equals(System.Guid.Empty)
 return mIsOK
end function
Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged
 return mChanged
end function
Public Sub SetupPanel()
    HolderPanel.SetupPanel()
End Sub
Public Overridable Function GetMaxX() As Double
    Return HolderPanel.GetMaxX()
End Function
Public Overridable Function GetMaxY() As Double
    Return HolderPanel.GetMaxY()
End Function
end class
