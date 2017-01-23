
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Оператор режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_opermain
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
Friend WithEvents lblfamilyname  as  System.Windows.Forms.Label
Friend WithEvents txtfamilyname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblsurname  as  System.Windows.Forms.Label
Friend WithEvents txtsurname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltnum  as  System.Windows.Forms.Label
Friend WithEvents txttnum As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltherole  as  System.Windows.Forms.Label
Friend WithEvents txttherole As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtherole As System.Windows.Forms.Button
Friend WithEvents cmdtheroleClear As System.Windows.Forms.Button
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
Me.lblfamilyname = New System.Windows.Forms.Label
Me.txtfamilyname = New LATIR2GuiManager.TouchTextBox
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblsurname = New System.Windows.Forms.Label
Me.txtsurname = New LATIR2GuiManager.TouchTextBox
Me.lbltnum = New System.Windows.Forms.Label
Me.txttnum = New LATIR2GuiManager.TouchTextBox
Me.lbltherole = New System.Windows.Forms.Label
Me.txttherole = New LATIR2GuiManager.TouchTextBox
Me.cmdtherole = New System.Windows.Forms.Button
Me.cmdtheroleClear = New System.Windows.Forms.Button
Me.lbllogin = New System.Windows.Forms.Label
Me.txtlogin = New LATIR2GuiManager.TouchTextBox

Me.lblfamilyname.Location = New System.Drawing.Point(20,5)
Me.lblfamilyname.name = "lblfamilyname"
Me.lblfamilyname.Size = New System.Drawing.Size(200, 20)
Me.lblfamilyname.TabIndex = 1
Me.lblfamilyname.Text = "Фамилия"
Me.lblfamilyname.ForeColor = System.Drawing.Color.Black
Me.txtfamilyname.Location = New System.Drawing.Point(20,27)
Me.txtfamilyname.name = "txtfamilyname"
Me.txtfamilyname.Size = New System.Drawing.Size(200, 20)
Me.txtfamilyname.TabIndex = 2
Me.txtfamilyname.Text = "" 
Me.txtfamilyname.ReadOnly = True
Me.lblname.Location = New System.Drawing.Point(20,52)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 3
Me.lblname.Text = "Имя"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,74)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 4
Me.txtname.Text = "" 
Me.txtname.ReadOnly = True
Me.lblsurname.Location = New System.Drawing.Point(20,99)
Me.lblsurname.name = "lblsurname"
Me.lblsurname.Size = New System.Drawing.Size(200, 20)
Me.lblsurname.TabIndex = 5
Me.lblsurname.Text = "Отчество"
Me.lblsurname.ForeColor = System.Drawing.Color.Black
Me.txtsurname.Location = New System.Drawing.Point(20,121)
Me.txtsurname.name = "txtsurname"
Me.txtsurname.Size = New System.Drawing.Size(200, 20)
Me.txtsurname.TabIndex = 6
Me.txtsurname.Text = "" 
Me.txtsurname.ReadOnly = True
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
Me.txttnum.ReadOnly = True
Me.lbltherole.Location = New System.Drawing.Point(20,193)
Me.lbltherole.name = "lbltherole"
Me.lbltherole.Size = New System.Drawing.Size(200, 20)
Me.lbltherole.TabIndex = 9
Me.lbltherole.Text = "Роль"
Me.lbltherole.ForeColor = System.Drawing.Color.Blue
Me.txttherole.Location = New System.Drawing.Point(20,215)
Me.txttherole.name = "txttherole"
Me.txttherole.ReadOnly = True
Me.txttherole.Size = New System.Drawing.Size(155, 20)
Me.txttherole.TabIndex = 10
Me.txttherole.Text = "" 
Me.cmdtherole.Location = New System.Drawing.Point(176,215)
Me.cmdtherole.name = "cmdtherole"
Me.cmdtherole.Size = New System.Drawing.Size(22, 20)
Me.cmdtherole.TabIndex = 11
Me.cmdtherole.Text = "..." 
Me.cmdtheroleClear.Location = New System.Drawing.Point(198,215)
Me.cmdtheroleClear.name = "cmdtheroleClear"
Me.cmdtheroleClear.Size = New System.Drawing.Size(22, 20)
Me.cmdtheroleClear.TabIndex = 12
Me.cmdtheroleClear.Text = "X" 
Me.lbllogin.Location = New System.Drawing.Point(20,240)
Me.lbllogin.name = "lbllogin"
Me.lbllogin.Size = New System.Drawing.Size(200, 20)
Me.lbllogin.TabIndex = 13
Me.lbllogin.Text = "Логин"
Me.lbllogin.ForeColor = System.Drawing.Color.Blue
Me.txtlogin.Location = New System.Drawing.Point(20,262)
Me.txtlogin.name = "txtlogin"
Me.txtlogin.Size = New System.Drawing.Size(200, 20)
Me.txtlogin.TabIndex = 14
Me.txtlogin.Text = "" 
Me.txtlogin.ReadOnly = True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfamilyname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtfamilyname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsurname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsurname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltnum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttnum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltherole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttherole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtherole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtheroleClear)
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

private sub txtfamilyname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfamilyname.TextChanged
  Changing

end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtsurname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsurname.TextChanged
  Changing

end sub
private sub txttnum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttnum.TextChanged
  Changing

end sub
private sub txttherole_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttherole.TextChanged
  Changing

end sub
private sub cmdtherole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtherole.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdtheroleClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtheroleClear.Click
  try
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

txtfamilyname.text = item.familyname
txtname.text = item.name
txtsurname.text = item.surname
txttnum.text = item.tnum
If Not item.therole Is Nothing Then
  txttherole.Tag = item.therole.id
  txttherole.text = item.therole.brief
else
  txttherole.Tag = System.Guid.Empty 
  txttherole.text = "" 
End If
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

  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtfamilyname.text <> "" ) 
if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =( txtsurname.text <> "" ) 
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
