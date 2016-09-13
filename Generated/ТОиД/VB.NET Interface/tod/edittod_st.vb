
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Станки режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittod_st
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
Friend WithEvents lblINVN  as  System.Windows.Forms.Label
Friend WithEvents txtINVN As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_model  as  System.Windows.Forms.Label
Friend WithEvents txtthe_model As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_model As System.Windows.Forms.Button
Friend WithEvents cmdthe_modelClear As System.Windows.Forms.Button

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
Me.lblINVN = New System.Windows.Forms.Label
Me.txtINVN = New LATIR2GuiManager.TouchTextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblthe_model = New System.Windows.Forms.Label
Me.txtthe_model = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_model = New System.Windows.Forms.Button
Me.cmdthe_modelClear = New System.Windows.Forms.Button

Me.lblINVN.Location = New System.Drawing.Point(20,5)
Me.lblINVN.name = "lblINVN"
Me.lblINVN.Size = New System.Drawing.Size(200, 20)
Me.lblINVN.TabIndex = 1
Me.lblINVN.Text = "Инвентарный номер"
Me.lblINVN.ForeColor = System.Drawing.Color.Black
Me.txtINVN.Location = New System.Drawing.Point(20,27)
Me.txtINVN.name = "txtINVN"
Me.txtINVN.Size = New System.Drawing.Size(200, 20)
Me.txtINVN.TabIndex = 2
Me.txtINVN.Text = "" 
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 3
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 4
Me.txtName.Text = "" 
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
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblINVN)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtINVN)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_model)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_model)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_model)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_modelClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittod_st"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtINVN_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtINVN.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
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

txtINVN.text = item.INVN
txtName.text = item.Name
If Not item.the_model Is Nothing Then
  txtthe_model.Tag = item.the_model.id
  txtthe_model.text = item.the_model.brief
else
  txtthe_model.Tag = System.Guid.Empty 
  txtthe_model.text = "" 
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

item.INVN = txtINVN.text
item.Name = txtName.text
If not txtthe_model.Tag.Equals(System.Guid.Empty) Then
  item.the_model = Item.Application.FindRowObject("tod_model",txtthe_model.Tag)
Else
   item.the_model = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtINVN.text <> "" ) 
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
