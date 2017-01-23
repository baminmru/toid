
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics

  Public Class viewtotrn_def
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel 
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents Edittotrn_def1 As totrnGUI.edittotrn_def
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Edittotrn_def1 = New totrnGUI.edittotrn_def
        Me.cmdSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Edittotrn_def1
        '
        Me.Edittotrn_def1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Edittotrn_def1.Location = New System.Drawing.Point(0, 40)
        Me.Edittotrn_def1.name = "Edittotrn_def1"
        Me.Edittotrn_def1.Size = New System.Drawing.Size(248, 128)
        Me.Edittotrn_def1.TabIndex = 0
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(8, 8)
        Me.cmdSave.name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(104, 24)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Сохранить"
        '
        'view" & p.name & "
        '
        Me.Controls.Add (Me.cmdSave)
        Me.Controls.Add (Me.Edittotrn_def1)
        Me.name = "viewtotrn_def"
        Me.Size = New System.Drawing.Size(248, 168)
        Me.ResumeLayout (False)

    End Sub

#End Region
    Public item As totrn.totrn.Application
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly as boolean


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean) Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, totrn.totrn.Application)
        GuiManager = gm
        If item.totrn_def.Count = 0 Then
            item.totrn_def.Add()
        End If
        Edittotrn_def1.Attach(gm, item.totrn_def.Item(1),mReadOnly)
        cmdSave.Enabled = false
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        if not mReadOnly then
          if Edittotrn_def1.IsOK() then
            Edittotrn_def1.Save()
            item.totrn_def.Item(1).Save()
            cmdSave.Enabled = false
          Else
            MsgBox("Не все обязательные поля заполнены")
          End If
        Else
          MsgBox("Сохранение невозможно, документ в режиме просмотра")
        End If
    End Sub
    Private Sub Edittotrn_def1_Changed() Handles Edittotrn_def1.Changed
        cmdSave.Enabled = True
    End Sub
 Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
   if not mReadOnly then
     Edittotrn_def1.Save()
     item.totrn_def.Item(1).Save()
     cmdSave.Enabled = false
     Return true
   Else
     Return false
   End If
 End Function
 Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
     Return Edittotrn_def1.IsOK()
 End Function
 Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
   if not mReadOnly then
     Return Edittotrn_def1.IsChanged()
   else
     Return false
   end if
 End Function
 Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
   if not mReadOnly then
     Return  Edittotrn_def1.IsOK()
   else
     Return true
   end if
 End Function
End Class
