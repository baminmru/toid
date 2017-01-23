
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Типичные проблемы режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittod_bugmain
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
Friend WithEvents lblthe_system  as  System.Windows.Forms.Label
Friend WithEvents txtthe_system As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_system As System.Windows.Forms.Button
Friend WithEvents cmdthe_systemClear As System.Windows.Forms.Button
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_comment As LATIR2GuiManager.TouchTextBox

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
Me.lblthe_system = New System.Windows.Forms.Label
Me.txtthe_system = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_system = New System.Windows.Forms.Button
Me.cmdthe_systemClear = New System.Windows.Forms.Button
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblthe_comment = New System.Windows.Forms.Label
Me.txtthe_comment = New LATIR2GuiManager.TouchTextBox

Me.lblthe_system.Location = New System.Drawing.Point(20,5)
Me.lblthe_system.name = "lblthe_system"
Me.lblthe_system.Size = New System.Drawing.Size(200, 20)
Me.lblthe_system.TabIndex = 1
Me.lblthe_system.Text = "Узел"
Me.lblthe_system.ForeColor = System.Drawing.Color.Blue
Me.txtthe_system.Location = New System.Drawing.Point(20,27)
Me.txtthe_system.name = "txtthe_system"
Me.txtthe_system.ReadOnly = True
Me.txtthe_system.Size = New System.Drawing.Size(155, 20)
Me.txtthe_system.TabIndex = 2
Me.txtthe_system.Text = "" 
Me.cmdthe_system.Location = New System.Drawing.Point(176,27)
Me.cmdthe_system.name = "cmdthe_system"
Me.cmdthe_system.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_system.TabIndex = 3
Me.cmdthe_system.Text = "..." 
Me.cmdthe_systemClear.Location = New System.Drawing.Point(198,27)
Me.cmdthe_systemClear.name = "cmdthe_systemClear"
Me.cmdthe_systemClear.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_systemClear.TabIndex = 4
Me.cmdthe_systemClear.Text = "X" 
Me.lblname.Location = New System.Drawing.Point(20,52)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 5
Me.lblname.Text = "Название "
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,74)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 6
Me.txtname.Text = "" 
Me.txtname.ReadOnly = True
Me.lblthe_comment.Location = New System.Drawing.Point(20,99)
Me.lblthe_comment.name = "lblthe_comment"
Me.lblthe_comment.Size = New System.Drawing.Size(200, 20)
Me.lblthe_comment.TabIndex = 7
Me.lblthe_comment.Text = "Примечание"
Me.lblthe_comment.ForeColor = System.Drawing.Color.Blue
Me.txtthe_comment.Location = New System.Drawing.Point(20,121)
Me.txtthe_comment.name = "txtthe_comment"
Me.txtthe_comment.MultiLine = True
Me.txtthe_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthe_comment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthe_comment.TabIndex = 8
Me.txtthe_comment.Text = "" 
Me.txtthe_comment.ReadOnly = True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_systemClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_comment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittod_bug"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtthe_system_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_system.TextChanged
  Changing

end sub
private sub cmdthe_system_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_system.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdthe_systemClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_systemClear.Click
  try
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtthe_comment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_comment.TextChanged
  Changing

end sub

Public Item As tod.tod.tod_bug
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tod.tod.tod_bug)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.the_system Is Nothing Then
  txtthe_system.Tag = item.the_system.id
  txtthe_system.text = item.the_system.brief
else
  txtthe_system.Tag = System.Guid.Empty 
  txtthe_system.text = "" 
End If
txtname.text = item.name
txtthe_comment.text = item.the_comment
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

  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtname.text <> "" ) 
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
