
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Данные тренда режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittotrn_data
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
Friend WithEvents lbltime_label  as  System.Windows.Forms.Label
Friend WithEvents dtptime_label As System.Windows.Forms.DateTimePicker
Friend WithEvents lblthevalue  as  System.Windows.Forms.Label
Friend WithEvents txtthevalue As LATIR2GuiManager.TouchTextBox

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
Me.lbltime_label = New System.Windows.Forms.Label
Me.dtptime_label = New System.Windows.Forms.DateTimePicker
Me.lblthevalue = New System.Windows.Forms.Label
Me.txtthevalue = New LATIR2GuiManager.TouchTextBox

Me.lbltime_label.Location = New System.Drawing.Point(20,5)
Me.lbltime_label.name = "lbltime_label"
Me.lbltime_label.Size = New System.Drawing.Size(200, 20)
Me.lbltime_label.TabIndex = 1
Me.lbltime_label.Text = "Временная метка"
Me.lbltime_label.ForeColor = System.Drawing.Color.Black
Me.dtptime_label.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtptime_label.Location = New System.Drawing.Point(20,27)
Me.dtptime_label.name = "dtptime_label"
Me.dtptime_label.Size = New System.Drawing.Size(200,  20)
Me.dtptime_label.TabIndex =2
Me.dtptime_label.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtptime_label.ShowCheckBox=False
Me.lblthevalue.Location = New System.Drawing.Point(20,52)
Me.lblthevalue.name = "lblthevalue"
Me.lblthevalue.Size = New System.Drawing.Size(200, 20)
Me.lblthevalue.TabIndex = 3
Me.lblthevalue.Text = "Значение"
Me.lblthevalue.ForeColor = System.Drawing.Color.Black
Me.txtthevalue.Location = New System.Drawing.Point(20,74)
Me.txtthevalue.name = "txtthevalue"
Me.txtthevalue.MultiLine = false
Me.txtthevalue.Size = New System.Drawing.Size(200,  20)
Me.txtthevalue.TabIndex = 4
Me.txtthevalue.Text = "" 
Me.txtthevalue.MaxLength = 27
Me.txtthevalue.ReadOnly = True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltime_label)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtptime_label)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthevalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthevalue)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittotrn_data"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub dtptime_label_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptime_label.ValueChanged
  Changing 

end sub
private sub txtthevalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthevalue.TextChanged
  Changing

end sub

Public Item As totrn.totrn.totrn_data
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totrn.totrn.totrn_data)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

dtptime_label.value = System.DateTime.Now
if item.time_label <> System.DateTime.MinValue then
  try
     dtptime_label.value = item.time_label
  catch
   dtptime_label.value = System.DateTime.MinValue
  end try
end if
txtthevalue.text = item.thevalue.toString()
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

if mIsOK then mIsOK = (dtptime_label.value <> System.DateTime.MinValue)
if mIsOK then mIsOK =( txtthevalue.text <> "" ) 
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
