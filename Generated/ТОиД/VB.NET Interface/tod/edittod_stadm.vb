
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Станки режим:adm
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittod_stadm
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
Friend WithEvents lblinvn  as  System.Windows.Forms.Label
Friend WithEvents txtinvn As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_model  as  System.Windows.Forms.Label
Friend WithEvents txtthe_model As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_model As System.Windows.Forms.Button
Friend WithEvents cmdthe_modelClear As System.Windows.Forms.Button
Friend WithEvents lblthebuilding  as  System.Windows.Forms.Label
Friend WithEvents txtthebuilding As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthebuilding As System.Windows.Forms.Button
Friend WithEvents cmdthebuildingClear As System.Windows.Forms.Button

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
Me.lblinvn = New System.Windows.Forms.Label
Me.txtinvn = New LATIR2GuiManager.TouchTextBox
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblthe_model = New System.Windows.Forms.Label
Me.txtthe_model = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_model = New System.Windows.Forms.Button
Me.cmdthe_modelClear = New System.Windows.Forms.Button
Me.lblthebuilding = New System.Windows.Forms.Label
Me.txtthebuilding = New LATIR2GuiManager.TouchTextBox
Me.cmdthebuilding = New System.Windows.Forms.Button
Me.cmdthebuildingClear = New System.Windows.Forms.Button

Me.lblinvn.Location = New System.Drawing.Point(20,5)
Me.lblinvn.name = "lblinvn"
Me.lblinvn.Size = New System.Drawing.Size(200, 20)
Me.lblinvn.TabIndex = 1
Me.lblinvn.Text = "Инвентарный номер"
Me.lblinvn.ForeColor = System.Drawing.Color.Black
Me.txtinvn.Location = New System.Drawing.Point(20,27)
Me.txtinvn.name = "txtinvn"
Me.txtinvn.Size = New System.Drawing.Size(200, 20)
Me.txtinvn.TabIndex = 2
Me.txtinvn.Text = "" 
Me.lblname.Location = New System.Drawing.Point(20,52)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 3
Me.lblname.Text = "Название"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,74)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 4
Me.txtname.Text = "" 
Me.lblthe_model.Location = New System.Drawing.Point(20,99)
Me.lblthe_model.name = "lblthe_model"
Me.lblthe_model.Size = New System.Drawing.Size(200, 20)
Me.lblthe_model.TabIndex = 5
Me.lblthe_model.Text = "Модель станка"
Me.lblthe_model.ForeColor = System.Drawing.Color.Blue
Me.txtthe_model.Location = New System.Drawing.Point(20,121)
Me.txtthe_model.name = "txtthe_model"
Me.txtthe_model.ReadOnly = True
Me.txtthe_model.Size = New System.Drawing.Size(155, 20)
Me.txtthe_model.TabIndex = 6
Me.txtthe_model.Text = "" 
Me.cmdthe_model.Location = New System.Drawing.Point(176,121)
Me.cmdthe_model.name = "cmdthe_model"
Me.cmdthe_model.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_model.TabIndex = 7
Me.cmdthe_model.Text = "..." 
Me.cmdthe_modelClear.Location = New System.Drawing.Point(198,121)
Me.cmdthe_modelClear.name = "cmdthe_modelClear"
Me.cmdthe_modelClear.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_modelClear.TabIndex = 8
Me.cmdthe_modelClear.Text = "X" 
Me.lblthebuilding.Location = New System.Drawing.Point(20,146)
Me.lblthebuilding.name = "lblthebuilding"
Me.lblthebuilding.Size = New System.Drawing.Size(200, 20)
Me.lblthebuilding.TabIndex = 9
Me.lblthebuilding.Text = "Цех"
Me.lblthebuilding.ForeColor = System.Drawing.Color.Blue
Me.txtthebuilding.Location = New System.Drawing.Point(20,168)
Me.txtthebuilding.name = "txtthebuilding"
Me.txtthebuilding.ReadOnly = True
Me.txtthebuilding.Size = New System.Drawing.Size(155, 20)
Me.txtthebuilding.TabIndex = 10
Me.txtthebuilding.Text = "" 
Me.cmdthebuilding.Location = New System.Drawing.Point(176,168)
Me.cmdthebuilding.name = "cmdthebuilding"
Me.cmdthebuilding.Size = New System.Drawing.Size(22, 20)
Me.cmdthebuilding.TabIndex = 11
Me.cmdthebuilding.Text = "..." 
Me.cmdthebuildingClear.Location = New System.Drawing.Point(198,168)
Me.cmdthebuildingClear.name = "cmdthebuildingClear"
Me.cmdthebuildingClear.Size = New System.Drawing.Size(22, 20)
Me.cmdthebuildingClear.TabIndex = 12
Me.cmdthebuildingClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblinvn)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtinvn)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_model)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_model)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_model)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_modelClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthebuilding)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthebuilding)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthebuilding)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthebuildingClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittod_st"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtinvn_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinvn.TextChanged
  Changing

end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtthe_model_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_model.TextChanged
  Changing

end sub
private sub cmdthe_model_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_model.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_model","",System.guid.Empty, id, brief) Then
          txtthe_model.Tag = id
          txtthe_model.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdthe_modelClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_modelClear.Click
  try
          txtthe_model.Tag = Guid.Empty
          txtthe_model.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthebuilding_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthebuilding.TextChanged
  Changing

end sub
private sub cmdthebuilding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthebuilding.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_building","",System.guid.Empty, id, brief) Then
          txtthebuilding.Tag = id
          txtthebuilding.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdthebuildingClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthebuildingClear.Click
  try
          txtthebuilding.Tag = Guid.Empty
          txtthebuilding.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As tod.tod.tod_st
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tod.tod.tod_st)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtinvn.text = item.invn
txtname.text = item.name
If Not item.the_model Is Nothing Then
  txtthe_model.Tag = item.the_model.id
  txtthe_model.text = item.the_model.brief
else
  txtthe_model.Tag = System.Guid.Empty 
  txtthe_model.text = "" 
End If
If Not item.thebuilding Is Nothing Then
  txtthebuilding.Tag = item.thebuilding.id
  txtthebuilding.text = item.thebuilding.brief
else
  txtthebuilding.Tag = System.Guid.Empty 
  txtthebuilding.text = "" 
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

item.invn = txtinvn.text
item.name = txtname.text
If not txtthe_model.Tag.Equals(System.Guid.Empty) Then
  item.the_model = Item.Application.FindRowObject("tod_model",txtthe_model.Tag)
Else
   item.the_model = Nothing
End If
If not txtthebuilding.Tag.Equals(System.Guid.Empty) Then
  item.thebuilding = Item.Application.FindRowObject("tod_building",txtthebuilding.Tag)
Else
   item.thebuilding = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtinvn.text <> "" ) 
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
