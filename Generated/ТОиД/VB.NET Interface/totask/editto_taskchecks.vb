
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Проверки режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editto_taskchecks
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
Friend WithEvents lblthe_system  as  System.Windows.Forms.Label
Friend WithEvents txtthe_system As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_system As System.Windows.Forms.Button
Friend WithEvents lblthesubsystem  as  System.Windows.Forms.Label
Friend WithEvents txtthesubsystem As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_check  as  System.Windows.Forms.Label
Friend WithEvents txtthe_check As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblnormochas  as  System.Windows.Forms.Label
Friend WithEvents txtnormochas As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblvaluetype  as  System.Windows.Forms.Label
Friend WithEvents txtvaluetype As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdvaluetype As System.Windows.Forms.Button
Friend WithEvents lbllowvalue  as  System.Windows.Forms.Label
Friend WithEvents txtlowvalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblhivalue  as  System.Windows.Forms.Label
Friend WithEvents txthivalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_comment As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthevalue  as  System.Windows.Forms.Label
Friend WithEvents txtthevalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_doc  as  System.Windows.Forms.Label
Friend WithEvents txtthe_doc As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblcheckref  as  System.Windows.Forms.Label
Friend WithEvents txtcheckref As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdcheckref As System.Windows.Forms.Button
Friend WithEvents lbltagid  as  System.Windows.Forms.Label
Friend WithEvents txttagid As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltagtime  as  System.Windows.Forms.Label
Friend WithEvents dtptagtime As System.Windows.Forms.DateTimePicker

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
Me.lblthe_system = New System.Windows.Forms.Label
Me.txtthe_system = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_system = New System.Windows.Forms.Button
Me.lblthesubsystem = New System.Windows.Forms.Label
Me.txtthesubsystem = New LATIR2GuiManager.TouchTextBox
Me.lblthe_check = New System.Windows.Forms.Label
Me.txtthe_check = New LATIR2GuiManager.TouchTextBox
Me.lblnormochas = New System.Windows.Forms.Label
Me.txtnormochas = New LATIR2GuiManager.TouchTextBox
Me.lblvaluetype = New System.Windows.Forms.Label
Me.txtvaluetype = New LATIR2GuiManager.TouchTextBox
Me.cmdvaluetype = New System.Windows.Forms.Button
Me.lbllowvalue = New System.Windows.Forms.Label
Me.txtlowvalue = New LATIR2GuiManager.TouchTextBox
Me.lblhivalue = New System.Windows.Forms.Label
Me.txthivalue = New LATIR2GuiManager.TouchTextBox
Me.lblthe_comment = New System.Windows.Forms.Label
Me.txtthe_comment = New LATIR2GuiManager.TouchTextBox
Me.lblthevalue = New System.Windows.Forms.Label
Me.txtthevalue = New LATIR2GuiManager.TouchTextBox
Me.lblthe_doc = New System.Windows.Forms.Label
Me.txtthe_doc = New LATIR2GuiManager.TouchTextBox
Me.lblcheckref = New System.Windows.Forms.Label
Me.txtcheckref = New LATIR2GuiManager.TouchTextBox
Me.cmdcheckref = New System.Windows.Forms.Button
Me.lbltagid = New System.Windows.Forms.Label
Me.txttagid = New LATIR2GuiManager.TouchTextBox
Me.lbltagtime = New System.Windows.Forms.Label
Me.dtptagtime = New System.Windows.Forms.DateTimePicker

Me.lblthe_system.Location = New System.Drawing.Point(20,5)
Me.lblthe_system.name = "lblthe_system"
Me.lblthe_system.Size = New System.Drawing.Size(200, 20)
Me.lblthe_system.TabIndex = 1
Me.lblthe_system.Text = "Группа узлов"
Me.lblthe_system.ForeColor = System.Drawing.Color.Black
Me.txtthe_system.Location = New System.Drawing.Point(20,27)
Me.txtthe_system.name = "txtthe_system"
Me.txtthe_system.ReadOnly = True
Me.txtthe_system.Size = New System.Drawing.Size(176, 20)
Me.txtthe_system.TabIndex = 2
Me.txtthe_system.Text = "" 
Me.cmdthe_system.Location = New System.Drawing.Point(198,27)
Me.cmdthe_system.name = "cmdthe_system"
Me.cmdthe_system.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_system.TabIndex = 3
Me.cmdthe_system.Text = "..." 
Me.lblthesubsystem.Location = New System.Drawing.Point(20,52)
Me.lblthesubsystem.name = "lblthesubsystem"
Me.lblthesubsystem.Size = New System.Drawing.Size(200, 20)
Me.lblthesubsystem.TabIndex = 4
Me.lblthesubsystem.Text = "Узел"
Me.lblthesubsystem.ForeColor = System.Drawing.Color.Black
Me.txtthesubsystem.Location = New System.Drawing.Point(20,74)
Me.txtthesubsystem.name = "txtthesubsystem"
Me.txtthesubsystem.Size = New System.Drawing.Size(200, 20)
Me.txtthesubsystem.TabIndex = 5
Me.txtthesubsystem.Text = "" 
Me.lblthe_check.Location = New System.Drawing.Point(20,99)
Me.lblthe_check.name = "lblthe_check"
Me.lblthe_check.Size = New System.Drawing.Size(200, 20)
Me.lblthe_check.TabIndex = 6
Me.lblthe_check.Text = "Показатель"
Me.lblthe_check.ForeColor = System.Drawing.Color.Black
Me.txtthe_check.Location = New System.Drawing.Point(20,121)
Me.txtthe_check.name = "txtthe_check"
Me.txtthe_check.Size = New System.Drawing.Size(200, 20)
Me.txtthe_check.TabIndex = 7
Me.txtthe_check.Text = "" 
Me.txtthe_check.ReadOnly = True
Me.lblnormochas.Location = New System.Drawing.Point(20,146)
Me.lblnormochas.name = "lblnormochas"
Me.lblnormochas.Size = New System.Drawing.Size(200, 20)
Me.lblnormochas.TabIndex = 8
Me.lblnormochas.Text = "Нормочас"
Me.lblnormochas.ForeColor = System.Drawing.Color.Blue
Me.txtnormochas.Location = New System.Drawing.Point(20,168)
Me.txtnormochas.name = "txtnormochas"
Me.txtnormochas.MultiLine = false
Me.txtnormochas.Size = New System.Drawing.Size(200,  20)
Me.txtnormochas.TabIndex = 9
Me.txtnormochas.Text = "" 
Me.txtnormochas.MaxLength = 27
Me.txtnormochas.ReadOnly = True
Me.lblvaluetype.Location = New System.Drawing.Point(20,193)
Me.lblvaluetype.name = "lblvaluetype"
Me.lblvaluetype.Size = New System.Drawing.Size(200, 20)
Me.lblvaluetype.TabIndex = 10
Me.lblvaluetype.Text = "Измерение"
Me.lblvaluetype.ForeColor = System.Drawing.Color.Black
Me.txtvaluetype.Location = New System.Drawing.Point(20,215)
Me.txtvaluetype.name = "txtvaluetype"
Me.txtvaluetype.ReadOnly = True
Me.txtvaluetype.Size = New System.Drawing.Size(176, 20)
Me.txtvaluetype.TabIndex = 11
Me.txtvaluetype.Text = "" 
Me.cmdvaluetype.Location = New System.Drawing.Point(198,215)
Me.cmdvaluetype.name = "cmdvaluetype"
Me.cmdvaluetype.Size = New System.Drawing.Size(22, 20)
Me.cmdvaluetype.TabIndex = 12
Me.cmdvaluetype.Text = "..." 
Me.lbllowvalue.Location = New System.Drawing.Point(20,240)
Me.lbllowvalue.name = "lbllowvalue"
Me.lbllowvalue.Size = New System.Drawing.Size(200, 20)
Me.lbllowvalue.TabIndex = 13
Me.lbllowvalue.Text = "Нижняя граница ()=)"
Me.lbllowvalue.ForeColor = System.Drawing.Color.Blue
Me.txtlowvalue.Location = New System.Drawing.Point(20,262)
Me.txtlowvalue.name = "txtlowvalue"
Me.txtlowvalue.Size = New System.Drawing.Size(200, 20)
Me.txtlowvalue.TabIndex = 14
Me.txtlowvalue.Text = "" 
Me.txtlowvalue.ReadOnly = True
Me.lblhivalue.Location = New System.Drawing.Point(20,287)
Me.lblhivalue.name = "lblhivalue"
Me.lblhivalue.Size = New System.Drawing.Size(200, 20)
Me.lblhivalue.TabIndex = 15
Me.lblhivalue.Text = "Верхняя граница ((=)"
Me.lblhivalue.ForeColor = System.Drawing.Color.Blue
Me.txthivalue.Location = New System.Drawing.Point(20,309)
Me.txthivalue.name = "txthivalue"
Me.txthivalue.Size = New System.Drawing.Size(200, 20)
Me.txthivalue.TabIndex = 16
Me.txthivalue.Text = "" 
Me.txthivalue.ReadOnly = True
Me.lblthe_comment.Location = New System.Drawing.Point(20,334)
Me.lblthe_comment.name = "lblthe_comment"
Me.lblthe_comment.Size = New System.Drawing.Size(200, 20)
Me.lblthe_comment.TabIndex = 17
Me.lblthe_comment.Text = "Примечание"
Me.lblthe_comment.ForeColor = System.Drawing.Color.Blue
Me.txtthe_comment.Location = New System.Drawing.Point(20,356)
Me.txtthe_comment.name = "txtthe_comment"
Me.txtthe_comment.MultiLine = True
Me.txtthe_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthe_comment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthe_comment.TabIndex = 18
Me.txtthe_comment.Text = "" 
Me.txtthe_comment.ReadOnly = True
Me.lblthevalue.Location = New System.Drawing.Point(230,5)
Me.lblthevalue.name = "lblthevalue"
Me.lblthevalue.Size = New System.Drawing.Size(200, 20)
Me.lblthevalue.TabIndex = 19
Me.lblthevalue.Text = "Значение"
Me.lblthevalue.ForeColor = System.Drawing.Color.Blue
Me.txtthevalue.Location = New System.Drawing.Point(230,27)
Me.txtthevalue.name = "txtthevalue"
Me.txtthevalue.Size = New System.Drawing.Size(200, 20)
Me.txtthevalue.TabIndex = 20
Me.txtthevalue.Text = "" 
Me.txtthevalue.ReadOnly = True
Me.lblthe_doc.Location = New System.Drawing.Point(230,52)
Me.lblthe_doc.name = "lblthe_doc"
Me.lblthe_doc.Size = New System.Drawing.Size(200, 20)
Me.lblthe_doc.TabIndex = 21
Me.lblthe_doc.Text = "Документация"
Me.lblthe_doc.ForeColor = System.Drawing.Color.Blue
Me.txtthe_doc.Location = New System.Drawing.Point(230,74)
Me.txtthe_doc.name = "txtthe_doc"
Me.txtthe_doc.Size = New System.Drawing.Size(200, 20)
Me.txtthe_doc.TabIndex = 22
Me.txtthe_doc.Text = "" 
Me.txtthe_doc.ReadOnly = True
Me.lblcheckref.Location = New System.Drawing.Point(230,99)
Me.lblcheckref.name = "lblcheckref"
Me.lblcheckref.Size = New System.Drawing.Size(200, 20)
Me.lblcheckref.TabIndex = 23
Me.lblcheckref.Text = "Основание для проверки"
Me.lblcheckref.ForeColor = System.Drawing.Color.Black
Me.txtcheckref.Location = New System.Drawing.Point(230,121)
Me.txtcheckref.name = "txtcheckref"
Me.txtcheckref.ReadOnly = True
Me.txtcheckref.Size = New System.Drawing.Size(176, 20)
Me.txtcheckref.TabIndex = 24
Me.txtcheckref.Text = "" 
Me.cmdcheckref.Location = New System.Drawing.Point(408,121)
Me.cmdcheckref.name = "cmdcheckref"
Me.cmdcheckref.Size = New System.Drawing.Size(22, 20)
Me.cmdcheckref.TabIndex = 25
Me.cmdcheckref.Text = "..." 
Me.lbltagid.Location = New System.Drawing.Point(230,146)
Me.lbltagid.name = "lbltagid"
Me.lbltagid.Size = New System.Drawing.Size(200, 20)
Me.lbltagid.TabIndex = 26
Me.lbltagid.Text = "Метка"
Me.lbltagid.ForeColor = System.Drawing.Color.Blue
Me.txttagid.Location = New System.Drawing.Point(230,168)
Me.txttagid.name = "txttagid"
Me.txttagid.Size = New System.Drawing.Size(200, 20)
Me.txttagid.TabIndex = 27
Me.txttagid.Text = "" 
Me.txttagid.ReadOnly = True
Me.lbltagtime.Location = New System.Drawing.Point(230,193)
Me.lbltagtime.name = "lbltagtime"
Me.lbltagtime.Size = New System.Drawing.Size(200, 20)
Me.lbltagtime.TabIndex = 28
Me.lbltagtime.Text = "Дата регистрации метки"
Me.lbltagtime.ForeColor = System.Drawing.Color.Blue
Me.dtptagtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtptagtime.Location = New System.Drawing.Point(230,215)
Me.dtptagtime.name = "dtptagtime"
Me.dtptagtime.Size = New System.Drawing.Size(200,  20)
Me.dtptagtime.TabIndex =29
Me.dtptagtime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtptagtime.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthesubsystem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthesubsystem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_check)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_check)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblnormochas)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtnormochas)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblvaluetype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtvaluetype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdvaluetype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllowvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlowvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblhivalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txthivalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthevalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthevalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_doc)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_doc)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcheckref)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcheckref)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdcheckref)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltagid)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttagid)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltagtime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtptagtime)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editto_taskchecks"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtthe_system_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_system.TextChanged
  Changing

end sub
private sub cmdthe_system_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_system.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthesubsystem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthesubsystem.TextChanged
  Changing

end sub
private sub txtthe_check_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_check.TextChanged
  Changing

end sub
private sub txtnormochas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnormochas.TextChanged
  Changing

end sub
private sub txtvaluetype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvaluetype.TextChanged
  Changing

end sub
private sub cmdvaluetype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvaluetype.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtlowvalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlowvalue.TextChanged
  Changing

end sub
private sub txthivalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthivalue.TextChanged
  Changing

end sub
private sub txtthe_comment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_comment.TextChanged
  Changing

end sub
private sub txtthevalue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthevalue.TextChanged
  Changing

end sub
private sub txtthe_doc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_doc.TextChanged
  Changing

end sub
private sub txtcheckref_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcheckref.TextChanged
  Changing

end sub
private sub cmdcheckref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcheckref.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txttagid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttagid.TextChanged
  Changing

end sub
private sub dtptagtime_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptagtime.ValueChanged
  Changing 

end sub

Public Item As totask.totask.to_taskchecks
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,totask.totask.to_taskchecks)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.the_system Is Nothing Then
  txtthe_system.Tag = item.the_system.id
  txtthe_system.text = item.the_system.brief
else
  txtthe_system.Tag = System.Guid.Empty 
  txtthe_system.text = "" 
End If
txtthesubsystem.text = item.thesubsystem
txtthe_check.text = item.the_check
txtnormochas.text = item.normochas.toString()
If Not item.valuetype Is Nothing Then
  txtvaluetype.Tag = item.valuetype.id
  txtvaluetype.text = item.valuetype.brief
else
  txtvaluetype.Tag = System.Guid.Empty 
  txtvaluetype.text = "" 
End If
txtlowvalue.text = item.lowvalue
txthivalue.text = item.hivalue
txtthe_comment.text = item.the_comment
txtthevalue.text = item.thevalue
txtthe_doc.text = item.the_doc
If Not item.checkref Is Nothing Then
  txtcheckref.Tag = item.checkref.id
  txtcheckref.text = item.checkref.brief
else
  txtcheckref.Tag = System.Guid.Empty 
  txtcheckref.text = "" 
End If
txttagid.text = item.tagid
dtptagtime.value = System.DateTime.Now
if item.tagtime <> System.DateTime.MinValue then
  try
     dtptagtime.value = item.tagtime
  catch
   dtptagtime.value = System.DateTime.MinValue
  end try
else
   dtptagtime.value = System.DateTime.Today
   dtptagtime.Checked =false
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

item.thesubsystem = txtthesubsystem.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtthe_system.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtthesubsystem.text <> "" ) 
if mIsOK then mIsOK =( txtthe_check.text <> "" ) 
if mIsOK then mIsOK = not txtvaluetype.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtcheckref.Tag.Equals(System.Guid.Empty)
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
