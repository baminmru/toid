
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Измеренные значения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_taskvalues
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
Friend WithEvents lblcheckvalue  as  System.Windows.Forms.Label
Friend WithEvents txtcheckvalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdcheckvalue As System.Windows.Forms.Button
Friend WithEvents lbltheValue  as  System.Windows.Forms.Label
Friend WithEvents txttheValue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltheComment  as  System.Windows.Forms.Label
Friend WithEvents txttheComment As LATIR2GuiManager.TouchTextBox

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
Me.lblcheckvalue = New System.Windows.Forms.Label
Me.txtcheckvalue = New LATIR2GuiManager.TouchTextBox
Me.cmdcheckvalue = New System.Windows.Forms.Button
Me.lbltheValue = New System.Windows.Forms.Label
Me.txttheValue = New LATIR2GuiManager.TouchTextBox
Me.lbltheComment = New System.Windows.Forms.Label
Me.txttheComment = New LATIR2GuiManager.TouchTextBox

Me.lblcheckvalue.Location = New System.Drawing.Point(20,5)
Me.lblcheckvalue.name = "lblcheckvalue"
Me.lblcheckvalue.Size = New System.Drawing.Size(200, 20)
Me.lblcheckvalue.TabIndex = 1
Me.lblcheckvalue.Text = "Значение для проверки"
Me.lblcheckvalue.ForeColor = System.Drawing.Color.Black
Me.txtcheckvalue.Location = New System.Drawing.Point(20,27)
Me.txtcheckvalue.name = "txtcheckvalue"
Me.txtcheckvalue.ReadOnly = True
Me.txtcheckvalue.Size = New System.Drawing.Size(176, 20)
Me.txtcheckvalue.TabIndex = 2
Me.txtcheckvalue.Text = "" 
Me.cmdcheckvalue.Location = New System.Drawing.Point(198,27)
Me.cmdcheckvalue.name = "cmdcheckvalue"
Me.cmdcheckvalue.Size = New System.Drawing.Size(22, 20)
Me.cmdcheckvalue.TabIndex = 3
Me.cmdcheckvalue.Text = "..." 
Me.lbltheValue.Location = New System.Drawing.Point(20,52)
Me.lbltheValue.name = "lbltheValue"
Me.lbltheValue.Size = New System.Drawing.Size(200, 20)
Me.lbltheValue.TabIndex = 4
Me.lbltheValue.Text = "Значение"
Me.lbltheValue.ForeColor = System.Drawing.Color.Blue
Me.txttheValue.Location = New System.Drawing.Point(20,74)
Me.txttheValue.name = "txttheValue"
Me.txttheValue.Size = New System.Drawing.Size(200, 20)
Me.txttheValue.TabIndex = 5
Me.txttheValue.Text = "" 
Me.lbltheComment.Location = New System.Drawing.Point(20,99)
Me.lbltheComment.name = "lbltheComment"
Me.lbltheComment.Size = New System.Drawing.Size(200, 20)
Me.lbltheComment.TabIndex = 6
Me.lbltheComment.Text = "Прмечание"
Me.lbltheComment.ForeColor = System.Drawing.Color.Blue
Me.txttheComment.Location = New System.Drawing.Point(20,121)
Me.txttheComment.name = "txttheComment"
Me.txttheComment.MultiLine = True
Me.txttheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txttheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txttheComment.TabIndex = 7
Me.txttheComment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcheckvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcheckvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcheckvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheValue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheValue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheComment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_taskvalues"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtcheckvalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcheckvalue.TextChanged
  Changing

end sub
private sub cmdcheckvalue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcheckvalue.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("to_taskchecks","",System.guid.Empty, id, brief) Then
          txtcheckvalue.Tag = id
          txtcheckvalue.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txttheValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheValue.TextChanged
  Changing

end sub
private sub txttheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheComment.TextChanged
  Changing

end sub

Public Item As totask.totask.to_taskvalues
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totask.totask.to_taskvalues)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.checkvalue Is Nothing Then
  txtcheckvalue.Tag = item.checkvalue.id
  txtcheckvalue.text = item.checkvalue.brief
else
  txtcheckvalue.Tag = System.Guid.Empty 
  txtcheckvalue.text = "" 
End If
txttheValue.text = item.theValue
txttheComment.text = item.theComment
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

If not txtcheckvalue.Tag.Equals(System.Guid.Empty) Then
  item.checkvalue = Item.Application.FindRowObject("to_taskchecks",txtcheckvalue.Tag)
Else
   item.checkvalue = Nothing
End If
item.theValue = txttheValue.text
item.theComment = txttheComment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtcheckvalue.Tag.Equals(System.Guid.Empty)
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
