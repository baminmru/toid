
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Записи о рабочих станциях режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittor_info
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
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblserverdata  as  System.Windows.Forms.Label
Friend WithEvents dtpserverdata As System.Windows.Forms.DateTimePicker
Friend WithEvents lblclientdata  as  System.Windows.Forms.Label
Friend WithEvents dtpclientdata As System.Windows.Forms.DateTimePicker

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
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblserverdata = New System.Windows.Forms.Label
Me.dtpserverdata = New System.Windows.Forms.DateTimePicker
Me.lblclientdata = New System.Windows.Forms.Label
Me.dtpclientdata = New System.Windows.Forms.DateTimePicker

Me.lblname.Location = New System.Drawing.Point(20,5)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 1
Me.lblname.Text = "Название станции"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,27)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 2
Me.txtname.Text = "" 
Me.lblserverdata.Location = New System.Drawing.Point(20,52)
Me.lblserverdata.name = "lblserverdata"
Me.lblserverdata.Size = New System.Drawing.Size(200, 20)
Me.lblserverdata.TabIndex = 3
Me.lblserverdata.Text = "Дата сервер"
Me.lblserverdata.ForeColor = System.Drawing.Color.Blue
Me.dtpserverdata.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpserverdata.Location = New System.Drawing.Point(20,74)
Me.dtpserverdata.name = "dtpserverdata"
Me.dtpserverdata.Size = New System.Drawing.Size(200,  20)
Me.dtpserverdata.TabIndex =4
Me.dtpserverdata.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpserverdata.ShowCheckBox=True
Me.lblclientdata.Location = New System.Drawing.Point(20,99)
Me.lblclientdata.name = "lblclientdata"
Me.lblclientdata.Size = New System.Drawing.Size(200, 20)
Me.lblclientdata.TabIndex = 5
Me.lblclientdata.Text = "Дата клиент"
Me.lblclientdata.ForeColor = System.Drawing.Color.Blue
Me.dtpclientdata.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpclientdata.Location = New System.Drawing.Point(20,121)
Me.dtpclientdata.name = "dtpclientdata"
Me.dtpclientdata.Size = New System.Drawing.Size(200,  20)
Me.dtpclientdata.TabIndex =6
Me.dtpclientdata.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpclientdata.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblserverdata)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpserverdata)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblclientdata)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpclientdata)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittor_info"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub dtpserverdata_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpserverdata.ValueChanged
  Changing 

end sub
private sub dtpclientdata_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpclientdata.ValueChanged
  Changing 

end sub

Public Item As tor.tor.tor_info
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tor.tor.tor_info)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtname.text = item.name
dtpserverdata.value = System.DateTime.Now
if item.serverdata <> System.DateTime.MinValue then
  try
     dtpserverdata.value = item.serverdata
  catch
   dtpserverdata.value = System.DateTime.MinValue
  end try
else
   dtpserverdata.value = System.DateTime.Today
   dtpserverdata.Checked =false
end if
dtpclientdata.value = System.DateTime.Now
if item.clientdata <> System.DateTime.MinValue then
  try
     dtpclientdata.value = item.clientdata
  catch
   dtpclientdata.value = System.DateTime.MinValue
  end try
else
   dtpclientdata.value = System.DateTime.Today
   dtpclientdata.Checked =false
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

item.name = txtname.text
  if dtpserverdata.checked=false then
       item.serverdata = System.DateTime.MinValue
  else 
  try
    item.serverdata = dtpserverdata.value
  catch
    item.serverdata = System.DateTime.MinValue
  end try
  end if
  if dtpclientdata.checked=false then
       item.clientdata = System.DateTime.MinValue
  else 
  try
    item.clientdata = dtpclientdata.value
  catch
    item.clientdata = System.DateTime.MinValue
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
