
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_taskinfomain
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
Friend WithEvents lbloper  as  System.Windows.Forms.Label
Friend WithEvents txtoper As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdoper As System.Windows.Forms.Button
Friend WithEvents lblthecard  as  System.Windows.Forms.Label
Friend WithEvents txtthecard As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthecard As System.Windows.Forms.Button
Friend WithEvents cmdthecardClear As System.Windows.Forms.Button
Friend WithEvents lblcrdate  as  System.Windows.Forms.Label
Friend WithEvents dtpcrdate As System.Windows.Forms.DateTimePicker
Friend WithEvents lbltaskfinished  as  System.Windows.Forms.Label
Friend WithEvents cmbtaskfinished As System.Windows.Forms.ComboBox
Friend cmbtaskfinishedDATA As DataTable
Friend cmbtaskfinishedDATAROW As DataRow
Friend WithEvents lblfinishtime  as  System.Windows.Forms.Label
Friend WithEvents dtpfinishtime As System.Windows.Forms.DateTimePicker

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
Me.lbloper = New System.Windows.Forms.Label
Me.txtoper = New LATIR2GuiManager.TouchTextBox
Me.cmdoper = New System.Windows.Forms.Button
Me.lblthecard = New System.Windows.Forms.Label
Me.txtthecard = New LATIR2GuiManager.TouchTextBox
Me.cmdthecard = New System.Windows.Forms.Button
Me.cmdthecardClear = New System.Windows.Forms.Button
Me.lblcrdate = New System.Windows.Forms.Label
Me.dtpcrdate = New System.Windows.Forms.DateTimePicker
Me.lbltaskfinished = New System.Windows.Forms.Label
Me.cmbtaskfinished = New System.Windows.Forms.ComboBox
Me.lblfinishtime = New System.Windows.Forms.Label
Me.dtpfinishtime = New System.Windows.Forms.DateTimePicker

Me.lblthemachine.Location = New System.Drawing.Point(20,5)
Me.lblthemachine.name = "lblthemachine"
Me.lblthemachine.Size = New System.Drawing.Size(200, 20)
Me.lblthemachine.TabIndex = 1
Me.lblthemachine.Text = "Пункт расписания"
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
Me.lbloper.Location = New System.Drawing.Point(20,52)
Me.lbloper.name = "lbloper"
Me.lbloper.Size = New System.Drawing.Size(200, 20)
Me.lbloper.TabIndex = 4
Me.lbloper.Text = "Оператор"
Me.lbloper.ForeColor = System.Drawing.Color.Black
Me.txtoper.Location = New System.Drawing.Point(20,74)
Me.txtoper.name = "txtoper"
Me.txtoper.ReadOnly = True
Me.txtoper.Size = New System.Drawing.Size(176, 20)
Me.txtoper.TabIndex = 5
Me.txtoper.Text = "" 
Me.cmdoper.Location = New System.Drawing.Point(198,74)
Me.cmdoper.name = "cmdoper"
Me.cmdoper.Size = New System.Drawing.Size(22, 20)
Me.cmdoper.TabIndex = 6
Me.cmdoper.Text = "..." 
Me.lblthecard.Location = New System.Drawing.Point(20,99)
Me.lblthecard.name = "lblthecard"
Me.lblthecard.Size = New System.Drawing.Size(200, 20)
Me.lblthecard.TabIndex = 7
Me.lblthecard.Text = "Диагностическая карта"
Me.lblthecard.ForeColor = System.Drawing.Color.Blue
Me.txtthecard.Location = New System.Drawing.Point(20,121)
Me.txtthecard.name = "txtthecard"
Me.txtthecard.ReadOnly = True
Me.txtthecard.Size = New System.Drawing.Size(155, 20)
Me.txtthecard.TabIndex = 8
Me.txtthecard.Text = "" 
Me.cmdthecard.Location = New System.Drawing.Point(176,121)
Me.cmdthecard.name = "cmdthecard"
Me.cmdthecard.Size = New System.Drawing.Size(22, 20)
Me.cmdthecard.TabIndex = 9
Me.cmdthecard.Text = "..." 
Me.cmdthecardClear.Location = New System.Drawing.Point(198,121)
Me.cmdthecardClear.name = "cmdthecardClear"
Me.cmdthecardClear.Size = New System.Drawing.Size(22, 20)
Me.cmdthecardClear.TabIndex = 10
Me.cmdthecardClear.Text = "X" 
Me.lblcrdate.Location = New System.Drawing.Point(20,146)
Me.lblcrdate.name = "lblcrdate"
Me.lblcrdate.Size = New System.Drawing.Size(200, 20)
Me.lblcrdate.TabIndex = 11
Me.lblcrdate.Text = "Дата создания"
Me.lblcrdate.ForeColor = System.Drawing.Color.Black
Me.dtpcrdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpcrdate.Location = New System.Drawing.Point(20,168)
Me.dtpcrdate.name = "dtpcrdate"
Me.dtpcrdate.Size = New System.Drawing.Size(200,  20)
Me.dtpcrdate.TabIndex =12
Me.dtpcrdate.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpcrdate.ShowCheckBox=False
Me.lbltaskfinished.Location = New System.Drawing.Point(20,193)
Me.lbltaskfinished.name = "lbltaskfinished"
Me.lbltaskfinished.Size = New System.Drawing.Size(200, 20)
Me.lbltaskfinished.TabIndex = 13
Me.lbltaskfinished.Text = "Задача завершена"
Me.lbltaskfinished.ForeColor = System.Drawing.Color.Blue
Me.cmbtaskfinished.Location = New System.Drawing.Point(20,215)
Me.cmbtaskfinished.name = "cmbtaskfinished"
Me.cmbtaskfinished.Size = New System.Drawing.Size(200,  20)
Me.cmbtaskfinished.TabIndex = 14
Me.cmbtaskfinished.Enabled = true
Me.lblfinishtime.Location = New System.Drawing.Point(20,240)
Me.lblfinishtime.name = "lblfinishtime"
Me.lblfinishtime.Size = New System.Drawing.Size(200, 20)
Me.lblfinishtime.TabIndex = 15
Me.lblfinishtime.Text = "Время завершения задачи"
Me.lblfinishtime.ForeColor = System.Drawing.Color.Blue
Me.dtpfinishtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpfinishtime.Location = New System.Drawing.Point(20,262)
Me.dtpfinishtime.name = "dtpfinishtime"
Me.dtpfinishtime.Size = New System.Drawing.Size(200,  20)
Me.dtpfinishtime.TabIndex =16
Me.dtpfinishtime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpfinishtime.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbloper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthecard)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthecard)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthecard)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthecardClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcrdate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpcrdate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltaskfinished)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbtaskfinished)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfinishtime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpfinishtime)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_taskinfo"
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
private sub txtoper_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtoper.TextChanged
  Changing

end sub
private sub cmdoper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoper.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthecard_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthecard.TextChanged
  Changing

end sub
private sub cmdthecard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthecard.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdthecardClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthecardClear.Click
  try
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpcrdate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpcrdate.ValueChanged
  Changing 

end sub
private sub cmbtaskfinished_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtaskfinished.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpfinishtime_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfinishtime.ValueChanged
  Changing 

end sub

Public Item As totask.totask.to_taskinfo
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totask.totask.to_taskinfo)
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
If Not item.oper Is Nothing Then
  txtoper.Tag = item.oper.id
  txtoper.text = item.oper.brief
else
  txtoper.Tag = System.Guid.Empty 
  txtoper.text = "" 
End If
If Not item.thecard Is Nothing Then
  txtthecard.Tag = item.thecard.id
  txtthecard.text = item.thecard.brief
else
  txtthecard.Tag = System.Guid.Empty 
  txtthecard.text = "" 
End If
dtpcrdate.value = System.DateTime.Now
if item.crdate <> System.DateTime.MinValue then
  try
     dtpcrdate.value = item.crdate
  catch
   dtpcrdate.value = System.DateTime.MinValue
  end try
end if
cmbtaskfinishedData = New DataTable
cmbtaskfinishedData.Columns.Add("name", GetType(System.String))
cmbtaskfinishedData.Columns.Add("Value", GetType(System.Int32))
try
cmbtaskfinishedDataRow = cmbtaskfinishedData.NewRow
cmbtaskfinishedDataRow("name") = "Да"
cmbtaskfinishedDataRow("Value") = -1
cmbtaskfinishedData.Rows.Add (cmbtaskfinishedDataRow)
cmbtaskfinishedDataRow = cmbtaskfinishedData.NewRow
cmbtaskfinishedDataRow("name") = "Нет"
cmbtaskfinishedDataRow("Value") = 0
cmbtaskfinishedData.Rows.Add (cmbtaskfinishedDataRow)
cmbtaskfinished.DisplayMember = "name"
cmbtaskfinished.ValueMember = "Value"
cmbtaskfinished.DataSource = cmbtaskfinishedData
 cmbtaskfinished.SelectedValue=CInt(Item.taskfinished)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
dtpfinishtime.value = System.DateTime.Now
if item.finishtime <> System.DateTime.MinValue then
  try
     dtpfinishtime.value = item.finishtime
  catch
   dtpfinishtime.value = System.DateTime.MinValue
  end try
else
   dtpfinishtime.value = System.DateTime.Today
   dtpfinishtime.Checked =false
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

  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtthemachine.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtoper.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtpcrdate.value <> System.DateTime.MinValue)
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
