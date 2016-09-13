
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Оператор режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_oper
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
Friend WithEvents lblFamilyName  as  System.Windows.Forms.Label
Friend WithEvents txtFamilyName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSurName  as  System.Windows.Forms.Label
Friend WithEvents txtSurName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltnum  as  System.Windows.Forms.Label
Friend WithEvents txttnum As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllogin  as  System.Windows.Forms.Label
Friend WithEvents txtlogin As LATIR2GuiManager.TouchTextBox

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
Me.lblFamilyName = New System.Windows.Forms.Label
Me.txtFamilyName = New LATIR2GuiManager.TouchTextBox
Me.lblSurName = New System.Windows.Forms.Label
Me.txtSurName = New LATIR2GuiManager.TouchTextBox
Me.lbltnum = New System.Windows.Forms.Label
Me.txttnum = New LATIR2GuiManager.TouchTextBox
Me.lbllogin = New System.Windows.Forms.Label
Me.txtlogin = New LATIR2GuiManager.TouchTextBox

Me.lblName.Location = New System.Drawing.Point(20,5)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 1
Me.lblName.Text = "Имя"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,27)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 2
Me.txtName.Text = "" 
Me.lblFamilyName.Location = New System.Drawing.Point(20,52)
Me.lblFamilyName.name = "lblFamilyName"
Me.lblFamilyName.Size = New System.Drawing.Size(200, 20)
Me.lblFamilyName.TabIndex = 3
Me.lblFamilyName.Text = "Фамилия"
Me.lblFamilyName.ForeColor = System.Drawing.Color.Black
Me.txtFamilyName.Location = New System.Drawing.Point(20,74)
Me.txtFamilyName.name = "txtFamilyName"
Me.txtFamilyName.Size = New System.Drawing.Size(200, 20)
Me.txtFamilyName.TabIndex = 4
Me.txtFamilyName.Text = "" 
Me.lblSurName.Location = New System.Drawing.Point(20,99)
Me.lblSurName.name = "lblSurName"
Me.lblSurName.Size = New System.Drawing.Size(200, 20)
Me.lblSurName.TabIndex = 5
Me.lblSurName.Text = "Отчество"
Me.lblSurName.ForeColor = System.Drawing.Color.Black
Me.txtSurName.Location = New System.Drawing.Point(20,121)
Me.txtSurName.name = "txtSurName"
Me.txtSurName.Size = New System.Drawing.Size(200, 20)
Me.txtSurName.TabIndex = 6
Me.txtSurName.Text = "" 
Me.lbltnum.Location = New System.Drawing.Point(20,146)
Me.lbltnum.name = "lbltnum"
Me.lbltnum.Size = New System.Drawing.Size(200, 20)
Me.lbltnum.TabIndex = 7
Me.lbltnum.Text = "Табельный номер"
Me.lbltnum.ForeColor = System.Drawing.Color.Blue
Me.txttnum.Location = New System.Drawing.Point(20,168)
Me.txttnum.name = "txttnum"
Me.txttnum.Size = New System.Drawing.Size(200, 20)
Me.txttnum.TabIndex = 8
Me.txttnum.Text = "" 
Me.lbllogin.Location = New System.Drawing.Point(20,193)
Me.lbllogin.name = "lbllogin"
Me.lbllogin.Size = New System.Drawing.Size(200, 20)
Me.lbllogin.TabIndex = 9
Me.lbllogin.Text = "Логин"
Me.lbllogin.ForeColor = System.Drawing.Color.Blue
Me.txtlogin.Location = New System.Drawing.Point(20,215)
Me.txtlogin.name = "txtlogin"
Me.txtlogin.Size = New System.Drawing.Size(200, 20)
Me.txtlogin.TabIndex = 10
Me.txtlogin.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFamilyName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFamilyName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSurName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSurName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltnum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttnum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlogin)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_oper"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtFamilyName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFamilyName.TextChanged
  Changing

end sub
private sub txtSurName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurName.TextChanged
  Changing

end sub
private sub txttnum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttnum.TextChanged
  Changing

end sub
private sub txtlogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlogin.TextChanged
  Changing

end sub

Public Item As toop.toop.to_oper
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,toop.toop.to_oper)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtFamilyName.text = item.FamilyName
txtSurName.text = item.SurName
txttnum.text = item.tnum
txtlogin.text = item.login
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
item.FamilyName = txtFamilyName.text
item.SurName = txtSurName.text
item.tnum = txttnum.text
item.login = txtlogin.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtFamilyName.text <> "" ) 
if mIsOK then mIsOK =( txtSurName.text <> "" ) 
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
