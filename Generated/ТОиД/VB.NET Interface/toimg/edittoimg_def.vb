
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание хранилища режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittoimg_def
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
Friend WithEvents lblcomputername  as  System.Windows.Forms.Label
Friend WithEvents txtcomputername As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblimagestore  as  System.Windows.Forms.Label
Friend WithEvents txtimagestore As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblsharedfolder  as  System.Windows.Forms.Label
Friend WithEvents txtsharedfolder As LATIR2GuiManager.TouchTextBox

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
Me.lblcomputername = New System.Windows.Forms.Label
Me.txtcomputername = New LATIR2GuiManager.TouchTextBox
Me.lblimagestore = New System.Windows.Forms.Label
Me.txtimagestore = New LATIR2GuiManager.TouchTextBox
Me.lblsharedfolder = New System.Windows.Forms.Label
Me.txtsharedfolder = New LATIR2GuiManager.TouchTextBox

Me.lblcomputername.Location = New System.Drawing.Point(20,5)
Me.lblcomputername.name = "lblcomputername"
Me.lblcomputername.Size = New System.Drawing.Size(200, 20)
Me.lblcomputername.TabIndex = 1
Me.lblcomputername.Text = "Имя  станции"
Me.lblcomputername.ForeColor = System.Drawing.Color.Blue
Me.txtcomputername.Location = New System.Drawing.Point(20,27)
Me.txtcomputername.name = "txtcomputername"
Me.txtcomputername.Size = New System.Drawing.Size(200, 20)
Me.txtcomputername.TabIndex = 2
Me.txtcomputername.Text = "" 
Me.lblimagestore.Location = New System.Drawing.Point(20,52)
Me.lblimagestore.name = "lblimagestore"
Me.lblimagestore.Size = New System.Drawing.Size(200, 20)
Me.lblimagestore.TabIndex = 3
Me.lblimagestore.Text = "Папка с фотографиями"
Me.lblimagestore.ForeColor = System.Drawing.Color.Blue
Me.txtimagestore.Location = New System.Drawing.Point(20,74)
Me.txtimagestore.name = "txtimagestore"
Me.txtimagestore.Size = New System.Drawing.Size(200, 20)
Me.txtimagestore.TabIndex = 4
Me.txtimagestore.Text = "" 
Me.lblsharedfolder.Location = New System.Drawing.Point(20,99)
Me.lblsharedfolder.name = "lblsharedfolder"
Me.lblsharedfolder.Size = New System.Drawing.Size(200, 20)
Me.lblsharedfolder.TabIndex = 5
Me.lblsharedfolder.Text = "Имя общей директории"
Me.lblsharedfolder.ForeColor = System.Drawing.Color.Blue
Me.txtsharedfolder.Location = New System.Drawing.Point(20,121)
Me.txtsharedfolder.name = "txtsharedfolder"
Me.txtsharedfolder.Size = New System.Drawing.Size(200, 20)
Me.txtsharedfolder.TabIndex = 6
Me.txtsharedfolder.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcomputername)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcomputername)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblimagestore)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtimagestore)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsharedfolder)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsharedfolder)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittoimg_def"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtcomputername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcomputername.TextChanged
  Changing

end sub
private sub txtimagestore_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtimagestore.TextChanged
  Changing

end sub
private sub txtsharedfolder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsharedfolder.TextChanged
  Changing

end sub

Public Item As toimg.toimg.toimg_def
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,toimg.toimg.toimg_def)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtcomputername.text = item.computername
txtimagestore.text = item.imagestore
txtsharedfolder.text = item.sharedfolder
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

item.computername = txtcomputername.text
item.imagestore = txtimagestore.text
item.sharedfolder = txtsharedfolder.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

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
