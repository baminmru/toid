
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_cardinfomain
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
Friend WithEvents lblthe_machine  as  System.Windows.Forms.Label
Friend WithEvents txtthe_machine As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_machine As System.Windows.Forms.Button
Friend WithEvents lblcard_date  as  System.Windows.Forms.Label
Friend WithEvents dtpcard_date As System.Windows.Forms.DateTimePicker
Friend WithEvents lblcard_archived  as  System.Windows.Forms.Label
Friend WithEvents cmbcard_archived As System.Windows.Forms.ComboBox
Friend cmbcard_archivedDATA As DataTable
Friend cmbcard_archivedDATAROW As DataRow

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
Me.lblthe_machine = New System.Windows.Forms.Label
Me.txtthe_machine = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_machine = New System.Windows.Forms.Button
Me.lblcard_date = New System.Windows.Forms.Label
Me.dtpcard_date = New System.Windows.Forms.DateTimePicker
Me.lblcard_archived = New System.Windows.Forms.Label
Me.cmbcard_archived = New System.Windows.Forms.ComboBox

Me.lblthe_machine.Location = New System.Drawing.Point(20,5)
Me.lblthe_machine.name = "lblthe_machine"
Me.lblthe_machine.Size = New System.Drawing.Size(200, 20)
Me.lblthe_machine.TabIndex = 1
Me.lblthe_machine.Text = "Станок"
Me.lblthe_machine.ForeColor = System.Drawing.Color.Black
Me.txtthe_machine.Location = New System.Drawing.Point(20,27)
Me.txtthe_machine.name = "txtthe_machine"
Me.txtthe_machine.ReadOnly = True
Me.txtthe_machine.Size = New System.Drawing.Size(176, 20)
Me.txtthe_machine.TabIndex = 2
Me.txtthe_machine.Text = "" 
Me.cmdthe_machine.Location = New System.Drawing.Point(198,27)
Me.cmdthe_machine.name = "cmdthe_machine"
Me.cmdthe_machine.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_machine.TabIndex = 3
Me.cmdthe_machine.Text = "..." 
Me.lblcard_date.Location = New System.Drawing.Point(20,52)
Me.lblcard_date.name = "lblcard_date"
Me.lblcard_date.Size = New System.Drawing.Size(200, 20)
Me.lblcard_date.TabIndex = 4
Me.lblcard_date.Text = "Дата составления карты"
Me.lblcard_date.ForeColor = System.Drawing.Color.Blue
Me.dtpcard_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpcard_date.Location = New System.Drawing.Point(20,74)
Me.dtpcard_date.name = "dtpcard_date"
Me.dtpcard_date.Size = New System.Drawing.Size(200,  20)
Me.dtpcard_date.TabIndex =5
Me.dtpcard_date.CustomFormat = "dd/MM/yyyy"
Me.dtpcard_date.ShowCheckBox=True
Me.lblcard_archived.Location = New System.Drawing.Point(20,99)
Me.lblcard_archived.name = "lblcard_archived"
Me.lblcard_archived.Size = New System.Drawing.Size(200, 20)
Me.lblcard_archived.TabIndex = 6
Me.lblcard_archived.Text = "Архивная карта"
Me.lblcard_archived.ForeColor = System.Drawing.Color.Blue
Me.cmbcard_archived.Location = New System.Drawing.Point(20,121)
Me.cmbcard_archived.name = "cmbcard_archived"
Me.cmbcard_archived.Size = New System.Drawing.Size(200,  20)
Me.cmbcard_archived.TabIndex = 7
Me.cmbcard_archived.Enabled = true
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_machine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_machine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_machine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcard_date)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpcard_date)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcard_archived)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbcard_archived)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_cardinfo"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtthe_machine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_machine.TextChanged
  Changing

end sub
private sub cmdthe_machine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_machine.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpcard_date_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpcard_date.ValueChanged
  Changing 

end sub
private sub cmbcard_archived_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcard_archived.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As tocard.tocard.to_cardinfo
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tocard.tocard.to_cardinfo)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.the_machine Is Nothing Then
  txtthe_machine.Tag = item.the_machine.id
  txtthe_machine.text = item.the_machine.brief
else
  txtthe_machine.Tag = System.Guid.Empty 
  txtthe_machine.text = "" 
End If
dtpcard_date.value = System.DateTime.Today
if item.card_date <> System.DateTime.MinValue then
  try
     dtpcard_date.value = item.card_date
  catch
   dtpcard_date.value = System.DateTime.MinValue
  end try
else
   dtpcard_date.value = System.DateTime.Today
   dtpcard_date.Checked =false
end if
cmbcard_archivedData = New DataTable
cmbcard_archivedData.Columns.Add("name", GetType(System.String))
cmbcard_archivedData.Columns.Add("Value", GetType(System.Int32))
try
cmbcard_archivedDataRow = cmbcard_archivedData.NewRow
cmbcard_archivedDataRow("name") = "Да"
cmbcard_archivedDataRow("Value") = -1
cmbcard_archivedData.Rows.Add (cmbcard_archivedDataRow)
cmbcard_archivedDataRow = cmbcard_archivedData.NewRow
cmbcard_archivedDataRow("name") = "Нет"
cmbcard_archivedDataRow("Value") = 0
cmbcard_archivedData.Rows.Add (cmbcard_archivedDataRow)
cmbcard_archived.DisplayMember = "name"
cmbcard_archived.ValueMember = "Value"
cmbcard_archived.DataSource = cmbcard_archivedData
 cmbcard_archived.SelectedValue=CInt(Item.card_archived)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

if mIsOK then mIsOK = not txtthe_machine.Tag.Equals(System.Guid.Empty)
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
