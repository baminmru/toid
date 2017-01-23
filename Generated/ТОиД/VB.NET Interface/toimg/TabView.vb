


''' <summary>
'''Компонент, реализующий редактирование всего документа
''' </summary>
''' <remarks>
'''
''' </remarks>
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class Tabview
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
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtoimg_def As toimgGUI.viewtoimg_def
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtoimg_data As toimgGUI.viewtoimg_data
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtoimg_todelete As toimgGUI.viewtoimg_todelete
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   Viewtoimg_def = new viewtoimg_def
   TabPage2 = New System.Windows.Forms.TabPage
   Viewtoimg_data = new viewtoimg_data
   TabPage3 = New System.Windows.Forms.TabPage
   Viewtoimg_todelete = new viewtoimg_todelete
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Location = New System.Drawing.Point(0, 0)
        Me.tab.name = "tab"
        Me.tab.Size = New System.Drawing.Size(528, 392)
        Me.tab.TabIndex = 0
        Me.tab.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add (Me.Viewtoimg_def)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Описание хранилища"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'Viewtoimg_def
        '
        Me.Viewtoimg_def.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtoimg_def.Location = New System.Drawing.Point(0, 0)
        Me.Viewtoimg_def.name = "Viewtoimg_def"
        Me.Viewtoimg_def.Size = New System.Drawing.Size(504, 352)
        Me.Viewtoimg_def.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.Viewtoimg_data)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Картинки"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'Viewtoimg_data
        '
        Me.Viewtoimg_data.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtoimg_data.Location = New System.Drawing.Point(0, 0)
        Me.Viewtoimg_data.name = "Viewtoimg_data"
        Me.Viewtoimg_data.Size = New System.Drawing.Size(504, 352)
        Me.Viewtoimg_data.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.Viewtoimg_todelete)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Файлы на удаление"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'Viewtoimg_todelete
        '
        Me.Viewtoimg_todelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtoimg_todelete.Location = New System.Drawing.Point(0, 0)
        Me.Viewtoimg_todelete.name = "Viewtoimg_todelete"
        Me.Viewtoimg_todelete.Size = New System.Drawing.Size(504, 352)
        Me.Viewtoimg_todelete.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
        '
        'Tabview
        '
        Me.Controls.Add (Me.tab)
        Me.name = "TabView"
        Me.Size = New System.Drawing.Size(528, 392)
        Me.tab.ResumeLayout (False)
   Me.TabPage1.ResumeLayout (False)
   Me.TabPage2.ResumeLayout (False)
   Me.TabPage3.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As toimg.toimg.Application
    Private mReadOnly as boolean



''' <summary>
'''Объект управления визуальными компонентами
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager



''' <summary>
'''Инициализация контрольного элемента
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval DocReadOnly as boolean  ) Implements LATIR2GUIManager.IViewPanel.Attach
        item = CType(docItem, toimg.toimg.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        Viewtoimg_def.Attach(item, GuiManager,DocReadOnly)
        Viewtoimg_data.Attach(item, GuiManager,DocReadOnly)
        Viewtoimg_todelete.Attach(item, GuiManager,DocReadOnly)
    End Sub


''' <summary>
'''Сохранение всех изменений
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
    Dim ok As Boolean
    ok = True
        ok = ok And Viewtoimg_def.Save(Sielent, NoError)
        ok = ok And Viewtoimg_data.Save(Sielent, NoError)
        ok = ok And Viewtoimg_todelete.Save(Sielent, NoError)
       Return ok
    End function


''' <summary>
'''Корректны ли измененные данные проверка после Verify
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
    Dim ok As Boolean
    ok = True
        ok = ok And Viewtoimg_def.IsOK()
        ok = ok And Viewtoimg_data.IsOK()
        ok = ok And Viewtoimg_todelete.IsOK()
       Return ok
    End function


''' <summary>
'''Были ли изменения данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
    Dim ok As Boolean
    if mReadOnly then return false
    ok = False
        ok = ok or Viewtoimg_def.IsChanged()
        ok = ok or Viewtoimg_data.IsChanged()
        ok = ok or Viewtoimg_todelete.IsChanged()
       Return ok
    End function


''' <summary>
'''Проверить корректность данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
    Dim ok As Boolean
    if mReadOnly then return true
    ok = True
        ok = ok And Viewtoimg_def.Verify(NoError)
        ok = ok And Viewtoimg_data.Verify(NoError)
        ok = ok And Viewtoimg_todelete.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If Viewtoimg_def.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtoimg_def.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If Viewtoimg_data.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtoimg_data.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If Viewtoimg_todelete.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtoimg_todelete.Save(True, False)
            End If
        End If
    End Sub
End Class
