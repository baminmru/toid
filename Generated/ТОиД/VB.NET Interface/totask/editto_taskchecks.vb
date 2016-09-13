
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
Friend WithEvents lblthe_check  as  System.Windows.Forms.Label
Friend WithEvents txtthe_check As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblnormochas  as  System.Windows.Forms.Label
Friend WithEvents txtnormochas As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblValueType  as  System.Windows.Forms.Label
Friend WithEvents txtValueType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdValueType As System.Windows.Forms.Button
Friend WithEvents lbllowvalue  as  System.Windows.Forms.Label
Friend WithEvents txtlowvalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblhivalue  as  System.Windows.Forms.Label
Friend WithEvents txthivalue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_comment As LATIR2GuiManager.TouchTextBox

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
Me.lblthe_check = New System.Windows.Forms.Label
Me.txtthe_check = New LATIR2GuiManager.TouchTextBox
Me.lblnormochas = New System.Windows.Forms.Label
Me.txtnormochas = New LATIR2GuiManager.TouchTextBox
Me.lblValueType = New System.Windows.Forms.Label
Me.txtValueType = New LATIR2GuiManager.TouchTextBox
Me.cmdValueType = New System.Windows.Forms.Button
Me.lbllowvalue = New System.Windows.Forms.Label
Me.txtlowvalue = New LATIR2GuiManager.TouchTextBox
Me.lblhivalue = New System.Windows.Forms.Label
Me.txthivalue = New LATIR2GuiManager.TouchTextBox
Me.lblthe_comment = New System.Windows.Forms.Label
Me.txtthe_comment = New LATIR2GuiManager.TouchTextBox

Me.lblthe_system.Location = New System.Drawing.Point(20,5)
Me.lblthe_system.name = "lblthe_system"
Me.lblthe_system.Size = New System.Drawing.Size(200, 20)
Me.lblthe_system.TabIndex = 1
Me.lblthe_system.Text = "Узел"
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
Me.lblthe_check.Location = New System.Drawing.Point(20,52)
Me.lblthe_check.name = "lblthe_check"
Me.lblthe_check.Size = New System.Drawing.Size(200, 20)
Me.lblthe_check.TabIndex = 4
Me.lblthe_check.Text = "Показатель"
Me.lblthe_check.ForeColor = System.Drawing.Color.Black
Me.txtthe_check.Location = New System.Drawing.Point(20,74)
Me.txtthe_check.name = "txtthe_check"
Me.txtthe_check.Size = New System.Drawing.Size(200, 20)
Me.txtthe_check.TabIndex = 5
Me.txtthe_check.Text = "" 
Me.lblnormochas.Location = New System.Drawing.Point(20,99)
Me.lblnormochas.name = "lblnormochas"
Me.lblnormochas.Size = New System.Drawing.Size(200, 20)
Me.lblnormochas.TabIndex = 6
Me.lblnormochas.Text = "Нормочас"
Me.lblnormochas.ForeColor = System.Drawing.Color.Black
Me.txtnormochas.Location = New System.Drawing.Point(20,121)
Me.txtnormochas.name = "txtnormochas"
Me.txtnormochas.MultiLine = false
Me.txtnormochas.Size = New System.Drawing.Size(200,  20)
Me.txtnormochas.TabIndex = 7
Me.txtnormochas.Text = "" 
Me.txtnormochas.MaxLength = 27
Me.lblValueType.Location = New System.Drawing.Point(20,146)
Me.lblValueType.name = "lblValueType"
Me.lblValueType.Size = New System.Drawing.Size(200, 20)
Me.lblValueType.TabIndex = 8
Me.lblValueType.Text = "Измерение"
Me.lblValueType.ForeColor = System.Drawing.Color.Black
Me.txtValueType.Location = New System.Drawing.Point(20,168)
Me.txtValueType.name = "txtValueType"
Me.txtValueType.ReadOnly = True
Me.txtValueType.Size = New System.Drawing.Size(176, 20)
Me.txtValueType.TabIndex = 9
Me.txtValueType.Text = "" 
Me.cmdValueType.Location = New System.Drawing.Point(198,168)
Me.cmdValueType.name = "cmdValueType"
Me.cmdValueType.Size = New System.Drawing.Size(22, 20)
Me.cmdValueType.TabIndex = 10
Me.cmdValueType.Text = "..." 
Me.lbllowvalue.Location = New System.Drawing.Point(20,193)
Me.lbllowvalue.name = "lbllowvalue"
Me.lbllowvalue.Size = New System.Drawing.Size(200, 20)
Me.lbllowvalue.TabIndex = 11
Me.lbllowvalue.Text = "Нижняя граница ()=)"
Me.lbllowvalue.ForeColor = System.Drawing.Color.Blue
Me.txtlowvalue.Location = New System.Drawing.Point(20,215)
Me.txtlowvalue.name = "txtlowvalue"
Me.txtlowvalue.Size = New System.Drawing.Size(200, 20)
Me.txtlowvalue.TabIndex = 12
Me.txtlowvalue.Text = "" 
Me.lblhivalue.Location = New System.Drawing.Point(20,240)
Me.lblhivalue.name = "lblhivalue"
Me.lblhivalue.Size = New System.Drawing.Size(200, 20)
Me.lblhivalue.TabIndex = 13
Me.lblhivalue.Text = "Верхняя граница ((=)"
Me.lblhivalue.ForeColor = System.Drawing.Color.Blue
Me.txthivalue.Location = New System.Drawing.Point(20,262)
Me.txthivalue.name = "txthivalue"
Me.txthivalue.Size = New System.Drawing.Size(200, 20)
Me.txthivalue.TabIndex = 14
Me.txthivalue.Text = "" 
Me.lblthe_comment.Location = New System.Drawing.Point(20,287)
Me.lblthe_comment.name = "lblthe_comment"
Me.lblthe_comment.Size = New System.Drawing.Size(200, 20)
Me.lblthe_comment.TabIndex = 15
Me.lblthe_comment.Text = "Примечание"
Me.lblthe_comment.ForeColor = System.Drawing.Color.Blue
Me.txtthe_comment.Location = New System.Drawing.Point(20,309)
Me.txtthe_comment.name = "txtthe_comment"
Me.txtthe_comment.MultiLine = True
Me.txtthe_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthe_comment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthe_comment.TabIndex = 16
Me.txtthe_comment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_system)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_check)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_check)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblnormochas)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtnormochas)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblValueType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtValueType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdValueType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllowvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlowvalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblhivalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txthivalue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_comment)
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
        If GuiManager.GetReferenceDialog("tod_system","",System.guid.Empty, id, brief) Then
          txtthe_system.Tag = id
          txtthe_system.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthe_check_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_check.TextChanged
  Changing

end sub
        Private Sub txtnormochas_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnormochas.Validating
        If txtnormochas.Text <> "" Then
            try
            If Not IsNumeric(txtnormochas.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtnormochas.Text) < -922337203685478# Or Val(txtnormochas.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtnormochas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnormochas.TextChanged
  Changing

end sub
private sub txtValueType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValueType.TextChanged
  Changing

end sub
private sub cmdValueType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValueType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("tod_valtype","",System.guid.Empty, id, brief) Then
          txtValueType.Tag = id
          txtValueType.text = brief
        End If
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
txtthe_check.text = item.the_check
txtnormochas.text = item.normochas.toString()
If Not item.ValueType Is Nothing Then
  txtValueType.Tag = item.ValueType.id
  txtValueType.text = item.ValueType.brief
else
  txtValueType.Tag = System.Guid.Empty 
  txtValueType.text = "" 
End If
txtlowvalue.text = item.lowvalue
txthivalue.text = item.hivalue
txtthe_comment.text = item.the_comment
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

If not txtthe_system.Tag.Equals(System.Guid.Empty) Then
  item.the_system = Item.Application.FindRowObject("tod_system",txtthe_system.Tag)
Else
   item.the_system = Nothing
End If
item.the_check = txtthe_check.text
item.normochas = cdbl(txtnormochas.text)
If not txtValueType.Tag.Equals(System.Guid.Empty) Then
  item.ValueType = Item.Application.FindRowObject("tod_valtype",txtValueType.Tag)
Else
   item.ValueType = Nothing
End If
item.lowvalue = txtlowvalue.text
item.hivalue = txthivalue.text
item.the_comment = txtthe_comment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtthe_system.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtthe_check.text <> "" ) 
if mIsOK then mIsOK =( txtnormochas.text <> "" ) 
if mIsOK then mIsOK = not txtValueType.Tag.Equals(System.Guid.Empty)
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
