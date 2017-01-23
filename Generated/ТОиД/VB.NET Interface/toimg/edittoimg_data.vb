
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Картинки режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittoimg_data
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
Friend WithEvents lblfname  as  System.Windows.Forms.Label
Friend WithEvents txtfname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllink2part  as  System.Windows.Forms.Label
Friend WithEvents txtlink2part As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllink2id  as  System.Windows.Forms.Label
Friend WithEvents txtlink2id As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblfiletype  as  System.Windows.Forms.Label
Friend WithEvents txtfiletype As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllink1part  as  System.Windows.Forms.Label
Friend WithEvents txtlink1part As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllink1id  as  System.Windows.Forms.Label
Friend WithEvents txtlink1id As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbloper  as  System.Windows.Forms.Label
Friend WithEvents txtoper As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdoper As System.Windows.Forms.Button
Friend WithEvents cmdoperClear As System.Windows.Forms.Button

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
Me.lblfname = New System.Windows.Forms.Label
Me.txtfname = New LATIR2GuiManager.TouchTextBox
Me.lbllink2part = New System.Windows.Forms.Label
Me.txtlink2part = New LATIR2GuiManager.TouchTextBox
Me.lbllink2id = New System.Windows.Forms.Label
Me.txtlink2id = New LATIR2GuiManager.TouchTextBox
Me.lblfiletype = New System.Windows.Forms.Label
Me.txtfiletype = New LATIR2GuiManager.TouchTextBox
Me.lbllink1part = New System.Windows.Forms.Label
Me.txtlink1part = New LATIR2GuiManager.TouchTextBox
Me.lbllink1id = New System.Windows.Forms.Label
Me.txtlink1id = New LATIR2GuiManager.TouchTextBox
Me.lbloper = New System.Windows.Forms.Label
Me.txtoper = New LATIR2GuiManager.TouchTextBox
Me.cmdoper = New System.Windows.Forms.Button
Me.cmdoperClear = New System.Windows.Forms.Button

Me.lblfname.Location = New System.Drawing.Point(20,5)
Me.lblfname.name = "lblfname"
Me.lblfname.Size = New System.Drawing.Size(200, 20)
Me.lblfname.TabIndex = 1
Me.lblfname.Text = "Имя файла"
Me.lblfname.ForeColor = System.Drawing.Color.Black
Me.txtfname.Location = New System.Drawing.Point(20,27)
Me.txtfname.name = "txtfname"
Me.txtfname.Size = New System.Drawing.Size(200, 20)
Me.txtfname.TabIndex = 2
Me.txtfname.Text = "" 
Me.lbllink2part.Location = New System.Drawing.Point(20,52)
Me.lbllink2part.name = "lbllink2part"
Me.lbllink2part.Size = New System.Drawing.Size(200, 20)
Me.lbllink2part.TabIndex = 3
Me.lbllink2part.Text = "Раздел привязки"
Me.lbllink2part.ForeColor = System.Drawing.Color.Black
Me.txtlink2part.Location = New System.Drawing.Point(20,74)
Me.txtlink2part.name = "txtlink2part"
Me.txtlink2part.Size = New System.Drawing.Size(200, 20)
Me.txtlink2part.TabIndex = 4
Me.txtlink2part.Text = "" 
Me.lbllink2id.Location = New System.Drawing.Point(20,99)
Me.lbllink2id.name = "lbllink2id"
Me.lbllink2id.Size = New System.Drawing.Size(200, 20)
Me.lbllink2id.TabIndex = 5
Me.lbllink2id.Text = "Идентификатор привязки"
Me.lbllink2id.ForeColor = System.Drawing.Color.Black
Me.txtlink2id.Location = New System.Drawing.Point(20,121)
Me.txtlink2id.name = "txtlink2id"
Me.txtlink2id.Size = New System.Drawing.Size(200, 20)
Me.txtlink2id.TabIndex = 6
Me.txtlink2id.Text = "" 
Me.lblfiletype.Location = New System.Drawing.Point(20,146)
Me.lblfiletype.name = "lblfiletype"
Me.lblfiletype.Size = New System.Drawing.Size(200, 20)
Me.lblfiletype.TabIndex = 7
Me.lblfiletype.Text = "Тип файла"
Me.lblfiletype.ForeColor = System.Drawing.Color.Blue
Me.txtfiletype.Location = New System.Drawing.Point(20,168)
Me.txtfiletype.name = "txtfiletype"
Me.txtfiletype.Size = New System.Drawing.Size(200, 20)
Me.txtfiletype.TabIndex = 8
Me.txtfiletype.Text = "" 
Me.lbllink1part.Location = New System.Drawing.Point(20,193)
Me.lbllink1part.name = "lbllink1part"
Me.lbllink1part.Size = New System.Drawing.Size(200, 20)
Me.lbllink1part.TabIndex = 9
Me.lbllink1part.Text = "Раздел2"
Me.lbllink1part.ForeColor = System.Drawing.Color.Blue
Me.txtlink1part.Location = New System.Drawing.Point(20,215)
Me.txtlink1part.name = "txtlink1part"
Me.txtlink1part.Size = New System.Drawing.Size(200, 20)
Me.txtlink1part.TabIndex = 10
Me.txtlink1part.Text = "" 
Me.lbllink1id.Location = New System.Drawing.Point(20,240)
Me.lbllink1id.name = "lbllink1id"
Me.lbllink1id.Size = New System.Drawing.Size(200, 20)
Me.lbllink1id.TabIndex = 11
Me.lbllink1id.Text = "Идентификатор2"
Me.lbllink1id.ForeColor = System.Drawing.Color.Blue
Me.txtlink1id.Location = New System.Drawing.Point(20,262)
Me.txtlink1id.name = "txtlink1id"
Me.txtlink1id.Size = New System.Drawing.Size(200, 20)
Me.txtlink1id.TabIndex = 12
Me.txtlink1id.Text = "" 
Me.lbloper.Location = New System.Drawing.Point(20,287)
Me.lbloper.name = "lbloper"
Me.lbloper.Size = New System.Drawing.Size(200, 20)
Me.lbloper.TabIndex = 13
Me.lbloper.Text = "Оператор"
Me.lbloper.ForeColor = System.Drawing.Color.Blue
Me.txtoper.Location = New System.Drawing.Point(20,309)
Me.txtoper.name = "txtoper"
Me.txtoper.ReadOnly = True
Me.txtoper.Size = New System.Drawing.Size(155, 20)
Me.txtoper.TabIndex = 14
Me.txtoper.Text = "" 
Me.cmdoper.Location = New System.Drawing.Point(176,309)
Me.cmdoper.name = "cmdoper"
Me.cmdoper.Size = New System.Drawing.Size(22, 20)
Me.cmdoper.TabIndex = 15
Me.cmdoper.Text = "..." 
Me.cmdoperClear.Location = New System.Drawing.Point(198,309)
Me.cmdoperClear.name = "cmdoperClear"
Me.cmdoperClear.Size = New System.Drawing.Size(22, 20)
Me.cmdoperClear.TabIndex = 16
Me.cmdoperClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtfname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllink2part)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlink2part)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllink2id)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlink2id)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfiletype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtfiletype)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllink1part)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlink1part)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllink1id)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlink1id)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbloper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdoper)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdoperClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittoimg_data"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtfname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfname.TextChanged
  Changing

end sub
private sub txtlink2part_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlink2part.TextChanged
  Changing

end sub
private sub txtlink2id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlink2id.TextChanged
  Changing

end sub
private sub txtfiletype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfiletype.TextChanged
  Changing

end sub
private sub txtlink1part_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlink1part.TextChanged
  Changing

end sub
private sub txtlink1id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlink1id.TextChanged
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

Public Item As toimg.toimg.toimg_data
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,toimg.toimg.toimg_data)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtfname.text = item.fname
txtlink2part.text = item.link2part
txtlink2id.text = item.link2id
txtfiletype.text = item.filetype
txtlink1part.text = item.link1part
txtlink1id.text = item.link1id
If Not item.oper Is Nothing Then
  txtoper.Tag = item.oper.id
  txtoper.text = item.oper.brief
else
  txtoper.Tag = System.Guid.Empty 
  txtoper.text = "" 
End If
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

item.fname = txtfname.text
item.link2part = txtlink2part.text
item.link2id = txtlink2id.text
item.filetype = txtfiletype.text
item.link1part = txtlink1part.text
item.link1id = txtlink1id.text
If not txtoper.Tag.Equals(System.Guid.Empty) Then
  item.oper = Item.Application.FindRowObject("to_oper",txtoper.Tag)
Else
   item.oper = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtfname.text <> "" ) 
if mIsOK then mIsOK =( txtlink2part.text <> "" ) 
if mIsOK then mIsOK =( txtlink2id.text <> "" ) 
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
