
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Расписание ТО режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_scheditems
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
Friend WithEvents lblTheMachine  as  System.Windows.Forms.Label
Friend WithEvents txtTheMachine As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheMachine As System.Windows.Forms.Button
Friend WithEvents lbltodate  as  System.Windows.Forms.Label
Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker

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
Me.lblTheMachine = New System.Windows.Forms.Label
Me.txtTheMachine = New LATIR2GuiManager.TouchTextBox
Me.cmdTheMachine = New System.Windows.Forms.Button
Me.lbltodate = New System.Windows.Forms.Label
Me.dtptodate = New System.Windows.Forms.DateTimePicker

Me.lblTheMachine.Location = New System.Drawing.Point(20,5)
Me.lblTheMachine.name = "lblTheMachine"
Me.lblTheMachine.Size = New System.Drawing.Size(200, 20)
Me.lblTheMachine.TabIndex = 1
Me.lblTheMachine.Text = "Станок"
Me.lblTheMachine.ForeColor = System.Drawing.Color.Black
Me.txtTheMachine.Location = New System.Drawing.Point(20,27)
Me.txtTheMachine.name = "txtTheMachine"
Me.txtTheMachine.ReadOnly = True
Me.txtTheMachine.Size = New System.Drawing.Size(176, 20)
Me.txtTheMachine.TabIndex = 2
Me.txtTheMachine.Text = "" 
Me.cmdTheMachine.Location = New System.Drawing.Point(198,27)
Me.cmdTheMachine.name = "cmdTheMachine"
Me.cmdTheMachine.Size = New System.Drawing.Size(22, 20)
Me.cmdTheMachine.TabIndex = 3
Me.cmdTheMachine.Text = "..." 
Me.lbltodate.Location = New System.Drawing.Point(20,52)
Me.lbltodate.name = "lbltodate"
Me.lbltodate.Size = New System.Drawing.Size(200, 20)
Me.lbltodate.TabIndex = 4
Me.lbltodate.Text = "Дата проведения ТО"
Me.lbltodate.ForeColor = System.Drawing.Color.Black
Me.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtptodate.Location = New System.Drawing.Point(20,74)
Me.dtptodate.name = "dtptodate"
Me.dtptodate.Size = New System.Drawing.Size(200,  20)
Me.dtptodate.TabIndex =5
Me.dtptodate.CustomFormat = "dd/MM/yyyy"
Me.dtptodate.ShowCheckBox=False
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheMachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheMachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheMachine)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltodate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtptodate)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_scheditems"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheMachine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheMachine.TextChanged
  Changing

end sub
private sub cmdTheMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheMachine.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_st","",System.guid.Empty, id, brief) Then
          txtTheMachine.Tag = id
          txtTheMachine.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtptodate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
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

If Not item.TheMachine Is Nothing Then
  txtTheMachine.Tag = item.TheMachine.id
  txtTheMachine.text = item.TheMachine.brief
else
  txtTheMachine.Tag = System.Guid.Empty 
  txtTheMachine.text = "" 
End If
dtptodate.value = System.DateTime.Today
if item.todate <> System.DateTime.MinValue then
 dtptodate.value = item.todate
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

If not txtTheMachine.Tag.Equals(System.Guid.Empty) Then
  item.TheMachine = Item.Application.FindRowObject("tod_st",txtTheMachine.Tag)
Else
   item.TheMachine = Nothing
End If
  if  dtptodate.value=System.DateTime.MinValue then
    item.todate = System.DateTime.MinValue
  else
    item.todate = dtptodate.value
  end if
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheMachine.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtptodate.value <> nothing)
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
