
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Тип измерения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittod_valtype
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
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbledizm  as  System.Windows.Forms.Label
Friend WithEvents txtedizm As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdedizm As System.Windows.Forms.Button
Friend WithEvents cmdedizmClear As System.Windows.Forms.Button

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
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lbledizm = New System.Windows.Forms.Label
Me.txtedizm = New LATIR2GuiManager.TouchTextBox
Me.cmdedizm = New System.Windows.Forms.Button
Me.cmdedizmClear = New System.Windows.Forms.Button

Me.lblName.Location = New System.Drawing.Point(20,5)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 1
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,27)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 2
Me.txtName.Text = "" 
Me.lbledizm.Location = New System.Drawing.Point(20,52)
Me.lbledizm.name = "lbledizm"
Me.lbledizm.Size = New System.Drawing.Size(200, 20)
Me.lbledizm.TabIndex = 3
Me.lbledizm.Text = "Ед. изм."
Me.lbledizm.ForeColor = System.Drawing.Color.Blue
Me.txtedizm.Location = New System.Drawing.Point(20,74)
Me.txtedizm.name = "txtedizm"
Me.txtedizm.ReadOnly = True
Me.txtedizm.Size = New System.Drawing.Size(155, 20)
Me.txtedizm.TabIndex = 4
Me.txtedizm.Text = "" 
Me.cmdedizm.Location = New System.Drawing.Point(176,74)
Me.cmdedizm.name = "cmdedizm"
Me.cmdedizm.Size = New System.Drawing.Size(22, 20)
Me.cmdedizm.TabIndex = 5
Me.cmdedizm.Text = "..." 
Me.cmdedizmClear.Location = New System.Drawing.Point(198,74)
Me.cmdedizmClear.name = "cmdedizmClear"
Me.cmdedizmClear.Size = New System.Drawing.Size(22, 20)
Me.cmdedizmClear.TabIndex = 6
Me.cmdedizmClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbledizm)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtedizm)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdedizm)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdedizmClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittod_valtype"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtedizm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtedizm.TextChanged
  Changing

end sub
private sub cmdedizm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedizm.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_edizm","",System.guid.Empty, id, brief) Then
          txtedizm.Tag = id
          txtedizm.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdedizmClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedizmClear.Click
  try
          txtedizm.Tag = Guid.Empty
          txtedizm.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As tod.tod.tod_valtype
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tod.tod.tod_valtype)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
If Not item.edizm Is Nothing Then
  txtedizm.Tag = item.edizm.id
  txtedizm.text = item.edizm.brief
else
  txtedizm.Tag = System.Guid.Empty 
  txtedizm.text = "" 
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

item.Name = txtName.text
If not txtedizm.Tag.Equals(System.Guid.Empty) Then
  item.edizm = Item.Application.FindRowObject("tod_edizm",txtedizm.Tag)
Else
   item.edizm = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
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
