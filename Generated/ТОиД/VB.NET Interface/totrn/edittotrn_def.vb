
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание тренда режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittotrn_def
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
Friend WithEvents lblthemachine  as  System.Windows.Forms.Label
Friend WithEvents txtthemachine As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthemachine As System.Windows.Forms.Button
Friend WithEvents lbltrandtype  as  System.Windows.Forms.Label
Friend WithEvents txttrandtype As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtrandtype As System.Windows.Forms.Button
Friend WithEvents lbltopvalue  as  System.Windows.Forms.Label
Friend WithEvents txttopvalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblbottomval  as  System.Windows.Forms.Label
Friend WithEvents txtbottomval As LATIR2GuiManager.TouchTextBox

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
Me.lblthemachine = New System.Windows.Forms.Label
Me.txtthemachine = New LATIR2GuiManager.TouchTextBox
Me.cmdthemachine = New System.Windows.Forms.Button
Me.lbltrandtype = New System.Windows.Forms.Label
Me.txttrandtype = New LATIR2GuiManager.TouchTextBox
Me.cmdtrandtype = New System.Windows.Forms.Button
Me.lbltopvalue = New System.Windows.Forms.Label
Me.txttopvalue = New LATIR2GuiManager.TouchTextBox
Me.lblbottomval = New System.Windows.Forms.Label
Me.txtbottomval = New LATIR2GuiManager.TouchTextBox

Me.lblthemachine.Location = New System.Drawing.Point(20,5)
Me.lblthemachine.name = "lblthemachine"
Me.lblthemachine.Size = New System.Drawing.Size(200, 20)
Me.lblthemachine.TabIndex = 1
Me.lblthemachine.Text = "Станок"
Me.lblthemachine.ForeColor = System.Drawing.Color.Black
Me.txtthemachine.Location = New System.Drawing.Point(20,27)
Me.txtthemachine.name = "txtthemachine"
Me.txtthemachine.ReadOnly = True
Me.txtthemachine.Size = New System.Drawing.Size(176, 20)
Me.txtthemachine.TabIndex = 2
Me.txtthemachine.Text = "" 
Me.cmdthemachine.Location = New System.Drawing.Point(198,27)
Me.cmdthemachine.name = "cmdthemachine"
Me.cmdthemachine.Size = New System.Drawing.Size(22, 20)
Me.cmdthemachine.TabIndex = 3
Me.cmdthemachine.Text = "..." 
Me.lbltrandtype.Location = New System.Drawing.Point(20,52)
Me.lbltrandtype.name = "lbltrandtype"
Me.lbltrandtype.Size = New System.Drawing.Size(200, 20)
Me.lbltrandtype.TabIndex = 4
Me.lbltrandtype.Text = "Тип тренда"
Me.lbltrandtype.ForeColor = System.Drawing.Color.Black
Me.txttrandtype.Location = New System.Drawing.Point(20,74)
Me.txttrandtype.name = "txttrandtype"
Me.txttrandtype.ReadOnly = True
Me.txttrandtype.Size = New System.Drawing.Size(176, 20)
Me.txttrandtype.TabIndex = 5
Me.txttrandtype.Text = "" 
Me.cmdtrandtype.Location = New System.Drawing.Point(198,74)
Me.cmdtrandtype.name = "cmdtrandtype"
Me.cmdtrandtype.Size = New System.Drawing.Size(22, 20)
Me.cmdtrandtype.TabIndex = 6
Me.cmdtrandtype.Text = "..." 
Me.lbltopvalue.Location = New System.Drawing.Point(20,99)
Me.lbltopvalue.name = "lbltopvalue"
Me.lbltopvalue.Size = New System.Drawing.Size(200, 20)
Me.lbltopvalue.TabIndex = 7
Me.lbltopvalue.Text = "Верхняя граница"
Me.lbltopvalue.ForeColor = System.Drawing.Color.Blue
Me.txttopvalue.Location = New System.Drawing.Point(20,121)
Me.txttopvalue.name = "txttopvalue"
Me.txttopvalue.MultiLine = false
Me.txttopvalue.Size = New System.Drawing.Size(200,  20)
Me.txttopvalue.TabIndex = 8
Me.txttopvalue.Text = "" 
Me.txttopvalue.MaxLength = 27
Me.txttopvalue.ReadOnly = True
Me.lblbottomval.Location = New System.Drawing.Point(20,146)
Me.lblbottomval.name = "lblbottomval"
Me.lblbottomval.Size = New System.Drawing.Size(200, 20)
Me.lblbottomval.TabIndex = 9
Me.lblbottomval.Text = "Нижняя граница"
Me.lblbottomval.ForeColor = System.Drawing.Color.Blue
Me.txtbottomval.Location = New System.Drawing.Point(20,168)
Me.txtbottomval.name = "txtbottomval"
Me.txtbottomval.MultiLine = false
Me.txtbottomval.Size = New System.Drawing.Size(200,  20)
Me.txtbottomval.TabIndex = 10
Me.txtbottomval.Text = "" 
Me.txtbottomval.MaxLength = 27
Me.txtbottomval.ReadOnly = True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltrandtype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttrandtype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtrandtype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltopvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttopvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblbottomval)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtbottomval)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittotrn_def"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtthemachine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthemachine.TextChanged
  Changing

end sub
private sub cmdthemachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthemachine.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txttrandtype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttrandtype.TextChanged
  Changing

end sub
private sub cmdtrandtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtrandtype.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txttopvalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttopvalue.TextChanged
  Changing

end sub
private sub txtbottomval_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbottomval.TextChanged
  Changing

end sub

Public Item As totrn.totrn.totrn_def
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totrn.totrn.totrn_def)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.themachine Is Nothing Then
  txtthemachine.Tag = item.themachine.id
  txtthemachine.text = item.themachine.brief
else
  txtthemachine.Tag = System.Guid.Empty 
  txtthemachine.text = "" 
End If
If Not item.trandtype Is Nothing Then
  txttrandtype.Tag = item.trandtype.id
  txttrandtype.text = item.trandtype.brief
else
  txttrandtype.Tag = System.Guid.Empty 
  txttrandtype.text = "" 
End If
txttopvalue.text = item.topvalue.toString()
txtbottomval.text = item.bottomval.toString()
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

if mIsOK then mIsOK = not txtthemachine.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txttrandtype.Tag.Equals(System.Guid.Empty)
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
