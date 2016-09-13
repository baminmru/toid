


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
    Friend WithEvents Viewtod_model As todGUI.viewtod_model
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtod_st As todGUI.viewtod_st
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtod_system As todGUI.viewtod_system
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtod_edizm As todGUI.viewtod_edizm
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtod_bug As todGUI.viewtod_bug
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtod_valtype As todGUI.viewtod_valtype
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Viewtod_material As todGUI.viewtod_material
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   Viewtod_model = new viewtod_model
   TabPage2 = New System.Windows.Forms.TabPage
   Viewtod_st = new viewtod_st
   TabPage3 = New System.Windows.Forms.TabPage
   Viewtod_system = new viewtod_system
   TabPage4 = New System.Windows.Forms.TabPage
   Viewtod_edizm = new viewtod_edizm
   TabPage5 = New System.Windows.Forms.TabPage
   Viewtod_bug = new viewtod_bug
   TabPage6 = New System.Windows.Forms.TabPage
   Viewtod_valtype = new viewtod_valtype
   TabPage7 = New System.Windows.Forms.TabPage
   Viewtod_material = new viewtod_material
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
   Me.TabPage4.SuspendLayout()
   Me.TabPage5.SuspendLayout()
   Me.TabPage6.SuspendLayout()
   Me.TabPage7.SuspendLayout()
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
        Me.TabPage1.Controls.Add (Me.Viewtod_model)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Модели станков"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'Viewtod_model
        '
        Me.Viewtod_model.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_model.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_model.name = "Viewtod_model"
        Me.Viewtod_model.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_model.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.Viewtod_st)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Станки"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'Viewtod_st
        '
        Me.Viewtod_st.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_st.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_st.name = "Viewtod_st"
        Me.Viewtod_st.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_st.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.Viewtod_system)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Узлы станков"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'Viewtod_system
        '
        Me.Viewtod_system.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_system.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_system.name = "Viewtod_system"
        Me.Viewtod_system.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_system.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add (Me.Viewtod_edizm)
        Me.TabPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage4.name = "TabPage4"
        Me.TabPage4.Text = "Единицы измерения"
        Me.TabPage4.Size = New System.Drawing.Size(520, 366)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.AutoScroll = True
        '
        'Viewtod_edizm
        '
        Me.Viewtod_edizm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_edizm.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_edizm.name = "Viewtod_edizm"
        Me.Viewtod_edizm.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_edizm.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add (Me.Viewtod_bug)
        Me.TabPage5.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage5.name = "TabPage5"
        Me.TabPage5.Text = "Типичные проблемы"
        Me.TabPage5.Size = New System.Drawing.Size(520, 366)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.AutoScroll = True
        '
        'Viewtod_bug
        '
        Me.Viewtod_bug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_bug.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_bug.name = "Viewtod_bug"
        Me.Viewtod_bug.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_bug.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add (Me.Viewtod_valtype)
        Me.TabPage6.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage6.name = "TabPage6"
        Me.TabPage6.Text = "Тип измерения"
        Me.TabPage6.Size = New System.Drawing.Size(520, 366)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.AutoScroll = True
        '
        'Viewtod_valtype
        '
        Me.Viewtod_valtype.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_valtype.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_valtype.name = "Viewtod_valtype"
        Me.Viewtod_valtype.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_valtype.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add (Me.Viewtod_material)
        Me.TabPage7.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage7.name = "TabPage7"
        Me.TabPage7.Text = "Материалы и инструменты"
        Me.TabPage7.Size = New System.Drawing.Size(520, 366)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.AutoScroll = True
        '
        'Viewtod_material
        '
        Me.Viewtod_material.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewtod_material.Location = New System.Drawing.Point(0, 0)
        Me.Viewtod_material.name = "Viewtod_material"
        Me.Viewtod_material.Size = New System.Drawing.Size(504, 352)
        Me.Viewtod_material.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
   Me.tab.Controls.Add (Me.TabPage4)
   Me.tab.Controls.Add (Me.TabPage5)
   Me.tab.Controls.Add (Me.TabPage6)
   Me.tab.Controls.Add (Me.TabPage7)
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
   Me.TabPage4.ResumeLayout (False)
   Me.TabPage5.ResumeLayout (False)
   Me.TabPage6.ResumeLayout (False)
   Me.TabPage7.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As tod.tod.Application
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
        item = CType(docItem, tod.tod.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        Viewtod_model.Attach(item, GuiManager,DocReadOnly)
        Viewtod_st.Attach(item, GuiManager,DocReadOnly)
        Viewtod_system.Attach(item, GuiManager,DocReadOnly)
        Viewtod_edizm.Attach(item, GuiManager,DocReadOnly)
        Viewtod_bug.Attach(item, GuiManager,DocReadOnly)
        Viewtod_valtype.Attach(item, GuiManager,DocReadOnly)
        Viewtod_material.Attach(item, GuiManager,DocReadOnly)
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
        ok = ok And Viewtod_model.Save(Sielent, NoError)
        ok = ok And Viewtod_st.Save(Sielent, NoError)
        ok = ok And Viewtod_system.Save(Sielent, NoError)
        ok = ok And Viewtod_edizm.Save(Sielent, NoError)
        ok = ok And Viewtod_bug.Save(Sielent, NoError)
        ok = ok And Viewtod_valtype.Save(Sielent, NoError)
        ok = ok And Viewtod_material.Save(Sielent, NoError)
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
        ok = ok And Viewtod_model.IsOK()
        ok = ok And Viewtod_st.IsOK()
        ok = ok And Viewtod_system.IsOK()
        ok = ok And Viewtod_edizm.IsOK()
        ok = ok And Viewtod_bug.IsOK()
        ok = ok And Viewtod_valtype.IsOK()
        ok = ok And Viewtod_material.IsOK()
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
        ok = ok or Viewtod_model.IsChanged()
        ok = ok or Viewtod_st.IsChanged()
        ok = ok or Viewtod_system.IsChanged()
        ok = ok or Viewtod_edizm.IsChanged()
        ok = ok or Viewtod_bug.IsChanged()
        ok = ok or Viewtod_valtype.IsChanged()
        ok = ok or Viewtod_material.IsChanged()
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
        ok = ok And Viewtod_model.Verify(NoError)
        ok = ok And Viewtod_st.Verify(NoError)
        ok = ok And Viewtod_system.Verify(NoError)
        ok = ok And Viewtod_edizm.Verify(NoError)
        ok = ok And Viewtod_bug.Verify(NoError)
        ok = ok And Viewtod_valtype.Verify(NoError)
        ok = ok And Viewtod_material.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If Viewtod_model.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_model.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If Viewtod_st.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_st.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If Viewtod_system.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_system.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Leave
        If Viewtod_edizm.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage4.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_edizm.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Leave
        If Viewtod_bug.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage5.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_bug.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Leave
        If Viewtod_valtype.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage6.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_valtype.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Leave
        If Viewtod_material.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage7.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewtod_material.Save(True, False)
            End If
        End If
    End Sub
End Class
