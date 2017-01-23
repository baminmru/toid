
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Расписание ТО режим:adm
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_scheditemsadm
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
Friend WithEvents lbltodate  as  System.Windows.Forms.Label
Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker
Friend WithEvents lblcheckin  as  System.Windows.Forms.Label
Friend WithEvents dtpcheckin As System.Windows.Forms.DateTimePicker
Friend WithEvents lbloper  as  System.Windows.Forms.Label
Friend WithEvents txtoper As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdoper As System.Windows.Forms.Button
Friend WithEvents cmdoperClear As System.Windows.Forms.Button
Friend WithEvents lblisdone  as  System.Windows.Forms.Label
Friend WithEvents cmbisdone As System.Windows.Forms.ComboBox
Friend cmbisdoneDATA As DataTable
Friend cmbisdoneDATAROW As DataRow
Friend WithEvents lblfinishdate  as  System.Windows.Forms.Label
Friend WithEvents dtpfinishdate As System.Windows.Forms.DateTimePicker

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
Me.lbltodate = New System.Windows.Forms.Label
Me.dtptodate = New System.Windows.Forms.DateTimePicker
Me.lblcheckin = New System.Windows.Forms.Label
Me.dtpcheckin = New System.Windows.Forms.DateTimePicker
Me.lbloper = New System.Windows.Forms.Label
Me.txtoper = New LATIR2GuiManager.TouchTextBox
Me.cmdoper = New System.Windows.Forms.Button
Me.cmdoperClear = New System.Windows.Forms.Button
Me.lblisdone = New System.Windows.Forms.Label
Me.cmbisdone = New System.Windows.Forms.ComboBox
Me.lblfinishdate = New System.Windows.Forms.Label
Me.dtpfinishdate = New System.Windows.Forms.DateTimePicker

Me.lblthemachine.Location = New System.Drawing.Point(20,5)
Me.lblthemachine.name = "lblthemachine"
Me.lblthemachine.Size = New System.Drawing.Size(200, 20)
Me.lblthemachine.TabIndex = 1
Me.lblthemachine.Text = "Станок"
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
Me.lbltodate.Location = New System.Drawing.Point(20,52)
Me.lbltodate.name = "lbltodate"
Me.lbltodate.Size = New System.Drawing.Size(200, 20)
Me.lbltodate.TabIndex = 4
Me.lbltodate.Text = "Плановая дата ТО"
Me.lbltodate.ForeColor = System.Drawing.Color.Black
Me.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtptodate.Location = New System.Drawing.Point(20,74)
Me.dtptodate.name = "dtptodate"
Me.dtptodate.Size = New System.Drawing.Size(200,  20)
Me.dtptodate.TabIndex =5
Me.dtptodate.CustomFormat = "dd/MM/yyyy"
Me.dtptodate.ShowCheckBox=False
Me.lblcheckin.Location = New System.Drawing.Point(20,99)
Me.lblcheckin.name = "lblcheckin"
Me.lblcheckin.Size = New System.Drawing.Size(200, 20)
Me.lblcheckin.TabIndex = 6
Me.lblcheckin.Text = "Взят в работу"
Me.lblcheckin.ForeColor = System.Drawing.Color.Blue
Me.dtpcheckin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpcheckin.Location = New System.Drawing.Point(20,121)
Me.dtpcheckin.name = "dtpcheckin"
Me.dtpcheckin.Size = New System.Drawing.Size(200,  20)
Me.dtpcheckin.TabIndex =7
Me.dtpcheckin.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpcheckin.ShowCheckBox=True
Me.lbloper.Location = New System.Drawing.Point(20,146)
Me.lbloper.name = "lbloper"
Me.lbloper.Size = New System.Drawing.Size(200, 20)
Me.lbloper.TabIndex = 8
Me.lbloper.Text = "Оператор"
Me.lbloper.ForeColor = System.Drawing.Color.Blue
Me.txtoper.Location = New System.Drawing.Point(20,168)
Me.txtoper.name = "txtoper"
Me.txtoper.ReadOnly = True
Me.txtoper.Size = New System.Drawing.Size(155, 20)
Me.txtoper.TabIndex = 9
Me.txtoper.Text = "" 
Me.cmdoper.Location = New System.Drawing.Point(176,168)
Me.cmdoper.name = "cmdoper"
Me.cmdoper.Size = New System.Drawing.Size(22, 20)
Me.cmdoper.TabIndex = 10
Me.cmdoper.Text = "..." 
Me.cmdoperClear.Location = New System.Drawing.Point(198,168)
Me.cmdoperClear.name = "cmdoperClear"
Me.cmdoperClear.Size = New System.Drawing.Size(22, 20)
Me.cmdoperClear.TabIndex = 11
Me.cmdoperClear.Text = "X" 
Me.lblisdone.Location = New System.Drawing.Point(20,193)
Me.lblisdone.name = "lblisdone"
Me.lblisdone.Size = New System.Drawing.Size(200, 20)
Me.lblisdone.TabIndex = 12
Me.lblisdone.Text = "ТО проведено"
Me.lblisdone.ForeColor = System.Drawing.Color.Blue
Me.cmbisdone.Location = New System.Drawing.Point(20,215)
Me.cmbisdone.name = "cmbisdone"
Me.cmbisdone.Size = New System.Drawing.Size(200,  20)
Me.cmbisdone.TabIndex = 13
Me.lblfinishdate.Location = New System.Drawing.Point(20,240)
Me.lblfinishdate.name = "lblfinishdate"
Me.lblfinishdate.Size = New System.Drawing.Size(200, 20)
Me.lblfinishdate.TabIndex = 14
Me.lblfinishdate.Text = "Дата завершения ТО"
Me.lblfinishdate.ForeColor = System.Drawing.Color.Blue
Me.dtpfinishdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpfinishdate.Location = New System.Drawing.Point(20,262)
Me.dtpfinishdate.name = "dtpfinishdate"
Me.dtpfinishdate.Size = New System.Drawing.Size(200,  20)
Me.dtpfinishdate.TabIndex =15
Me.dtpfinishdate.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpfinishdate.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthemachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltodate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtptodate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcheckin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpcheckin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbloper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdoperClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblisdone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbisdone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfinishdate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpfinishdate)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_scheditems"
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
        If GuiManager.GetReferenceDialog("tod_st","",System.guid.Empty, id, brief) Then
          txtthemachine.Tag = id
          txtthemachine.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtptodate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
  Changing 

end sub
private sub dtpcheckin_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpcheckin.ValueChanged
  Changing 

end sub
private sub txtoper_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtoper.TextChanged
  Changing

end sub
private sub cmdoper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoper.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("to_oper","",System.guid.Empty, id, brief) Then
          txtoper.Tag = id
          txtoper.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdoperClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoperClear.Click
  try
          txtoper.Tag = Guid.Empty
          txtoper.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbisdone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbisdone.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpfinishdate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfinishdate.ValueChanged
  Changing 

end sub

Public Item As tosched.tosched.to_scheditems
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,tosched.tosched.to_scheditems)
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
dtptodate.value = System.DateTime.Today
if item.todate <> System.DateTime.MinValue then
  try
     dtptodate.value = item.todate
  catch
   dtptodate.value = System.DateTime.MinValue
  end try
end if
dtpcheckin.value = System.DateTime.Now
if item.checkin <> System.DateTime.MinValue then
  try
     dtpcheckin.value = item.checkin
  catch
   dtpcheckin.value = System.DateTime.MinValue
  end try
else
   dtpcheckin.value = System.DateTime.Today
   dtpcheckin.Checked =false
end if
If Not item.oper Is Nothing Then
  txtoper.Tag = item.oper.id
  txtoper.text = item.oper.brief
else
  txtoper.Tag = System.Guid.Empty 
  txtoper.text = "" 
End If
cmbisdoneData = New DataTable
cmbisdoneData.Columns.Add("name", GetType(System.String))
cmbisdoneData.Columns.Add("Value", GetType(System.Int32))
try
cmbisdoneDataRow = cmbisdoneData.NewRow
cmbisdoneDataRow("name") = "Да"
cmbisdoneDataRow("Value") = -1
cmbisdoneData.Rows.Add (cmbisdoneDataRow)
cmbisdoneDataRow = cmbisdoneData.NewRow
cmbisdoneDataRow("name") = "Нет"
cmbisdoneDataRow("Value") = 0
cmbisdoneData.Rows.Add (cmbisdoneDataRow)
cmbisdone.DisplayMember = "name"
cmbisdone.ValueMember = "Value"
cmbisdone.DataSource = cmbisdoneData
 cmbisdone.SelectedValue=CInt(Item.isdone)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
dtpfinishdate.value = System.DateTime.Now
if item.finishdate <> System.DateTime.MinValue then
  try
     dtpfinishdate.value = item.finishdate
  catch
   dtpfinishdate.value = System.DateTime.MinValue
  end try
else
   dtpfinishdate.value = System.DateTime.Today
   dtpfinishdate.Checked =false
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

If not txtthemachine.Tag.Equals(System.Guid.Empty) Then
  item.themachine = Item.Application.FindRowObject("tod_st",txtthemachine.Tag)
Else
   item.themachine = Nothing
End If
  try
    item.todate = dtptodate.value
  catch
    item.todate = System.DateTime.MinValue
  end try
  if dtpcheckin.checked=false then
       item.checkin = System.DateTime.MinValue
  else 
  try
    item.checkin = dtpcheckin.value
  catch
    item.checkin = System.DateTime.MinValue
  end try
  end if
If not txtoper.Tag.Equals(System.Guid.Empty) Then
  item.oper = Item.Application.FindRowObject("to_oper",txtoper.Tag)
Else
   item.oper = Nothing
End If
   item.isdone = cmbisdone.SelectedValue
  if dtpfinishdate.checked=false then
       item.finishdate = System.DateTime.MinValue
  else 
  try
    item.finishdate = dtpfinishdate.value
  catch
    item.finishdate = System.DateTime.MinValue
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

if mIsOK then mIsOK = not txtthemachine.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtptodate.value <> System.DateTime.MinValue)
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
