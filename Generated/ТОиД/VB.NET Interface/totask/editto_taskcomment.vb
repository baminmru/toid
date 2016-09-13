
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Примечания режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_taskcomment
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
Friend WithEvents lblcodetocomment  as  System.Windows.Forms.Label
Friend WithEvents txtcodetocomment As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdcodetocomment As System.Windows.Forms.Button
Friend WithEvents cmdcodetocommentClear As System.Windows.Forms.Button
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
Me.lblcodetocomment = New System.Windows.Forms.Label
Me.txtcodetocomment = New LATIR2GuiManager.TouchTextBox
Me.cmdcodetocomment = New System.Windows.Forms.Button
Me.cmdcodetocommentClear = New System.Windows.Forms.Button
Me.lbltheComment = New System.Windows.Forms.Label
Me.txttheComment = New LATIR2GuiManager.TouchTextBox

Me.lblcodetocomment.Location = New System.Drawing.Point(20,5)
Me.lblcodetocomment.name = "lblcodetocomment"
Me.lblcodetocomment.Size = New System.Drawing.Size(200, 20)
Me.lblcodetocomment.TabIndex = 1
Me.lblcodetocomment.Text = "Узел"
Me.lblcodetocomment.ForeColor = System.Drawing.Color.Blue
Me.txtcodetocomment.Location = New System.Drawing.Point(20,27)
Me.txtcodetocomment.name = "txtcodetocomment"
Me.txtcodetocomment.ReadOnly = True
Me.txtcodetocomment.Size = New System.Drawing.Size(155, 20)
Me.txtcodetocomment.TabIndex = 2
Me.txtcodetocomment.Text = "" 
Me.cmdcodetocomment.Location = New System.Drawing.Point(176,27)
Me.cmdcodetocomment.name = "cmdcodetocomment"
Me.cmdcodetocomment.Size = New System.Drawing.Size(22, 20)
Me.cmdcodetocomment.TabIndex = 3
Me.cmdcodetocomment.Text = "..." 
Me.cmdcodetocommentClear.Location = New System.Drawing.Point(198,27)
Me.cmdcodetocommentClear.name = "cmdcodetocommentClear"
Me.cmdcodetocommentClear.Size = New System.Drawing.Size(22, 20)
Me.cmdcodetocommentClear.TabIndex = 4
Me.cmdcodetocommentClear.Text = "X" 
Me.lbltheComment.Location = New System.Drawing.Point(20,52)
Me.lbltheComment.name = "lbltheComment"
Me.lbltheComment.Size = New System.Drawing.Size(200, 20)
Me.lbltheComment.TabIndex = 5
Me.lbltheComment.Text = "Примечание"
Me.lbltheComment.ForeColor = System.Drawing.Color.Black
Me.txttheComment.Location = New System.Drawing.Point(20,74)
Me.txttheComment.name = "txttheComment"
Me.txttheComment.MultiLine = True
Me.txttheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txttheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txttheComment.TabIndex = 6
Me.txttheComment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcodetocomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcodetocomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcodetocomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcodetocommentClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheComment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_taskcomment"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtcodetocomment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodetocomment.TextChanged
  Changing

end sub
private sub cmdcodetocomment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcodetocomment.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_system","",System.guid.Empty, id, brief) Then
          txtcodetocomment.Tag = id
          txtcodetocomment.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdcodetocommentClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcodetocommentClear.Click
  try
          txtcodetocomment.Tag = Guid.Empty
          txtcodetocomment.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txttheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheComment.TextChanged
  Changing

end sub

Public Item As totask.totask.to_taskcomment
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totask.totask.to_taskcomment)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.codetocomment Is Nothing Then
  txtcodetocomment.Tag = item.codetocomment.id
  txtcodetocomment.text = item.codetocomment.brief
else
  txtcodetocomment.Tag = System.Guid.Empty 
  txtcodetocomment.text = "" 
End If
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

If not txtcodetocomment.Tag.Equals(System.Guid.Empty) Then
  item.codetocomment = Item.Application.FindRowObject("tod_system",txtcodetocomment.Tag)
Else
   item.codetocomment = Nothing
End If
item.theComment = txttheComment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txttheComment.text <> "" ) 
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
