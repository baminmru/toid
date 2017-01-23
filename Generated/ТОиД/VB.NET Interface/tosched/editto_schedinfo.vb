
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_schedinfo
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
Friend WithEvents lbldfrom  as  System.Windows.Forms.Label
Friend WithEvents dtpdfrom As System.Windows.Forms.DateTimePicker
Friend WithEvents lbldto  as  System.Windows.Forms.Label
Friend WithEvents dtpdto As System.Windows.Forms.DateTimePicker

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
Me.lbldfrom = New System.Windows.Forms.Label
Me.dtpdfrom = New System.Windows.Forms.DateTimePicker
Me.lbldto = New System.Windows.Forms.Label
Me.dtpdto = New System.Windows.Forms.DateTimePicker

Me.lbldfrom.Location = New System.Drawing.Point(20,5)
Me.lbldfrom.name = "lbldfrom"
Me.lbldfrom.Size = New System.Drawing.Size(200, 20)
Me.lbldfrom.TabIndex = 1
Me.lbldfrom.Text = "С"
Me.lbldfrom.ForeColor = System.Drawing.Color.Black
Me.dtpdfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpdfrom.Location = New System.Drawing.Point(20,27)
Me.dtpdfrom.name = "dtpdfrom"
Me.dtpdfrom.Size = New System.Drawing.Size(200,  20)
Me.dtpdfrom.TabIndex =2
Me.dtpdfrom.CustomFormat = "dd/MM/yyyy"
Me.dtpdfrom.ShowCheckBox=False
Me.lbldto.Location = New System.Drawing.Point(20,52)
Me.lbldto.name = "lbldto"
Me.lbldto.Size = New System.Drawing.Size(200, 20)
Me.lbldto.TabIndex = 3
Me.lbldto.Text = "По"
Me.lbldto.ForeColor = System.Drawing.Color.Blue
Me.dtpdto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpdto.Location = New System.Drawing.Point(20,74)
Me.dtpdto.name = "dtpdto"
Me.dtpdto.Size = New System.Drawing.Size(200,  20)
Me.dtpdto.TabIndex =4
Me.dtpdto.CustomFormat = "dd/MM/yyyy"
Me.dtpdto.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbldfrom)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpdfrom)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbldto)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpdto)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_schedinfo"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub dtpdfrom_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdfrom.ValueChanged
  Changing 

end sub
private sub dtpdto_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdto.ValueChanged
  Changing 

end sub

Public Item As tosched.tosched.to_schedinfo
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tosched.tosched.to_schedinfo)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

dtpdfrom.value = System.DateTime.Today
if item.dfrom <> System.DateTime.MinValue then
  try
     dtpdfrom.value = item.dfrom
  catch
   dtpdfrom.value = System.DateTime.MinValue
  end try
end if
dtpdto.value = System.DateTime.Today
if item.dto <> System.DateTime.MinValue then
  try
     dtpdto.value = item.dto
  catch
   dtpdto.value = System.DateTime.MinValue
  end try
else
   dtpdto.value = System.DateTime.Today
   dtpdto.Checked =false
end if
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

  try
    item.dfrom = dtpdfrom.value
  catch
    item.dfrom = System.DateTime.MinValue
  end try
  if dtpdto.checked=false then
       item.dto = System.DateTime.MinValue
  else 
  try
    item.dto = dtpdto.value
  catch
    item.dto = System.DateTime.MinValue
  end try
  end if
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = (dtpdfrom.value <> System.DateTime.MinValue)
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
