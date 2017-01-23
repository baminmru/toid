
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Файлы на удаление режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class edittoimg_todelete
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
Friend WithEvents lblfilerowid  as  System.Windows.Forms.Label
Friend WithEvents txtfilerowid As LATIR2GuiManager.TouchTextBox

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
Me.lblfilerowid = New System.Windows.Forms.Label
Me.txtfilerowid = New LATIR2GuiManager.TouchTextBox

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
Me.lblfilerowid.Location = New System.Drawing.Point(20,52)
Me.lblfilerowid.name = "lblfilerowid"
Me.lblfilerowid.Size = New System.Drawing.Size(200, 20)
Me.lblfilerowid.TabIndex = 3
Me.lblfilerowid.Text = "ид строки дя удаления"
Me.lblfilerowid.ForeColor = System.Drawing.Color.Blue
Me.txtfilerowid.Location = New System.Drawing.Point(20,74)
Me.txtfilerowid.name = "txtfilerowid"
Me.txtfilerowid.Size = New System.Drawing.Size(200, 20)
Me.txtfilerowid.TabIndex = 4
Me.txtfilerowid.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtfname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfilerowid)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtfilerowid)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "edittoimg_todelete"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtfname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfname.TextChanged
  Changing

end sub
private sub txtfilerowid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfilerowid.TextChanged
  Changing

end sub

Public Item As toimg.toimg.toimg_todelete
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,toimg.toimg.toimg_todelete)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtfname.text = item.fname
txtfilerowid.text = item.filerowid
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
item.filerowid = txtfilerowid.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtfname.text <> "" ) 
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
