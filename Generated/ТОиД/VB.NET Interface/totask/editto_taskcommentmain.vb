
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Примечания режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_taskcommentmain
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
Friend WithEvents lblcodetocomment  as  System.Windows.Forms.Label
Friend WithEvents txtcodetocomment As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdcodetocomment As System.Windows.Forms.Button
Friend WithEvents cmdcodetocommentClear As System.Windows.Forms.Button
Friend WithEvents lblthecomment  as  System.Windows.Forms.Label
Friend WithEvents txtthecomment As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_operator  as  System.Windows.Forms.Label
Friend WithEvents txtthe_operator As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_operator As System.Windows.Forms.Button
Friend WithEvents lblthe_date  as  System.Windows.Forms.Label
Friend WithEvents dtpthe_date As System.Windows.Forms.DateTimePicker

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
Me.lblcodetocomment = New System.Windows.Forms.Label
Me.txtcodetocomment = New LATIR2GuiManager.TouchTextBox
Me.cmdcodetocomment = New System.Windows.Forms.Button
Me.cmdcodetocommentClear = New System.Windows.Forms.Button
Me.lblthecomment = New System.Windows.Forms.Label
Me.txtthecomment = New LATIR2GuiManager.TouchTextBox
Me.lblthe_operator = New System.Windows.Forms.Label
Me.txtthe_operator = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_operator = New System.Windows.Forms.Button
Me.lblthe_date = New System.Windows.Forms.Label
Me.dtpthe_date = New System.Windows.Forms.DateTimePicker

Me.lblcodetocomment.Location = New System.Drawing.Point(20,5)
Me.lblcodetocomment.name = "lblcodetocomment"
Me.lblcodetocomment.Size = New System.Drawing.Size(200, 20)
Me.lblcodetocomment.TabIndex = 1
Me.lblcodetocomment.Text = "Узел"
Me.lblcodetocomment.ForeColor = System.Drawing.Color.Blue
Me.txtcodetocomment.Location = New System.Drawing.Point(20,27)
Me.txtcodetocomment.name = "txtcodetocomment"
Me.txtcodetocomment.ReadOnly = True
Me.txtcodetocomment.Size = New System.Drawing.Size(155, 20)
Me.txtcodetocomment.TabIndex = 2
Me.txtcodetocomment.Text = "" 
Me.cmdcodetocomment.Location = New System.Drawing.Point(176,27)
Me.cmdcodetocomment.name = "cmdcodetocomment"
Me.cmdcodetocomment.Size = New System.Drawing.Size(22, 20)
Me.cmdcodetocomment.TabIndex = 3
Me.cmdcodetocomment.Text = "..." 
Me.cmdcodetocommentClear.Location = New System.Drawing.Point(198,27)
Me.cmdcodetocommentClear.name = "cmdcodetocommentClear"
Me.cmdcodetocommentClear.Size = New System.Drawing.Size(22, 20)
Me.cmdcodetocommentClear.TabIndex = 4
Me.cmdcodetocommentClear.Text = "X" 
Me.lblthecomment.Location = New System.Drawing.Point(20,52)
Me.lblthecomment.name = "lblthecomment"
Me.lblthecomment.Size = New System.Drawing.Size(200, 20)
Me.lblthecomment.TabIndex = 5
Me.lblthecomment.Text = "Примечание"
Me.lblthecomment.ForeColor = System.Drawing.Color.Black
Me.txtthecomment.Location = New System.Drawing.Point(20,74)
Me.txtthecomment.name = "txtthecomment"
Me.txtthecomment.MultiLine = True
Me.txtthecomment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthecomment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthecomment.TabIndex = 6
Me.txtthecomment.Text = "" 
Me.txtthecomment.ReadOnly = True
Me.lblthe_operator.Location = New System.Drawing.Point(20,144)
Me.lblthe_operator.name = "lblthe_operator"
Me.lblthe_operator.Size = New System.Drawing.Size(200, 20)
Me.lblthe_operator.TabIndex = 7
Me.lblthe_operator.Text = "Оператор"
Me.lblthe_operator.ForeColor = System.Drawing.Color.Black
Me.txtthe_operator.Location = New System.Drawing.Point(20,166)
Me.txtthe_operator.name = "txtthe_operator"
Me.txtthe_operator.ReadOnly = True
Me.txtthe_operator.Size = New System.Drawing.Size(176, 20)
Me.txtthe_operator.TabIndex = 8
Me.txtthe_operator.Text = "" 
Me.cmdthe_operator.Location = New System.Drawing.Point(198,166)
Me.cmdthe_operator.name = "cmdthe_operator"
Me.cmdthe_operator.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_operator.TabIndex = 9
Me.cmdthe_operator.Text = "..." 
Me.lblthe_date.Location = New System.Drawing.Point(20,191)
Me.lblthe_date.name = "lblthe_date"
Me.lblthe_date.Size = New System.Drawing.Size(200, 20)
Me.lblthe_date.TabIndex = 10
Me.lblthe_date.Text = "Дата комментария"
Me.lblthe_date.ForeColor = System.Drawing.Color.Black
Me.dtpthe_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpthe_date.Location = New System.Drawing.Point(20,213)
Me.dtpthe_date.name = "dtpthe_date"
Me.dtpthe_date.Size = New System.Drawing.Size(200,  20)
Me.dtpthe_date.TabIndex =11
Me.dtpthe_date.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpthe_date.ShowCheckBox=False
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcodetocomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcodetocomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcodetocomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcodetocommentClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthecomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthecomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_operator)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_operator)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_operator)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_date)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpthe_date)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_taskcomment"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtcodetocomment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodetocomment.TextChanged
  Changing

end sub
private sub cmdcodetocomment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcodetocomment.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdcodetocommentClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcodetocommentClear.Click
  try
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthecomment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthecomment.TextChanged
  Changing

end sub
private sub txtthe_operator_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_operator.TextChanged
  Changing

end sub
private sub cmdthe_operator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_operator.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpthe_date_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpthe_date.ValueChanged
  Changing 

end sub

Public Item As totask.totask.to_taskcomment
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totask.totask.to_taskcomment)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.codetocomment Is Nothing Then
  txtcodetocomment.Tag = item.codetocomment.id
  txtcodetocomment.text = item.codetocomment.brief
else
  txtcodetocomment.Tag = System.Guid.Empty 
  txtcodetocomment.text = "" 
End If
txtthecomment.text = item.thecomment
If Not item.the_operator Is Nothing Then
  txtthe_operator.Tag = item.the_operator.id
  txtthe_operator.text = item.the_operator.brief
else
  txtthe_operator.Tag = System.Guid.Empty 
  txtthe_operator.text = "" 
End If
dtpthe_date.value = System.DateTime.Now
if item.the_date <> System.DateTime.MinValue then
  try
     dtpthe_date.value = item.the_date
  catch
   dtpthe_date.value = System.DateTime.MinValue
  end try
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

if mIsOK then mIsOK =( txtthecomment.text <> "" ) 
if mIsOK then mIsOK = not txtthe_operator.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtpthe_date.value <> System.DateTime.MinValue)
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
