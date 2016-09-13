Imports System.Windows.Forms

Public Class frmMDI

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Manager = New LATIR2.Manager
        GuiManager = New LATIR2GuiManager.LATIRGuiManager
        GuiManager.Attach(Manager)
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)

        Dim username As String = GetSetting("TOID", "SETTING", "UID", "")
        Dim sitename As String = GetSetting("TOID", "SETTING", "SITE", "")
        If Not GuiManager.Login(username, sitename) Then
            End
        End If
        SaveSetting("TOID", "SETTING", "UID", username)
        SaveSetting("TOID", "SETTING", "SITE", sitename)


        Me.Text = Application.ProductName & " :: " & sitename

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(ChildForm)
        ChildForm.Show()
    End Sub

    Private Sub tod_click(ByVal sender As Object, ByVal e As EventArgs) Handles tod_menu.Click
        Dim dt As DataTable
        Dim oID As System.Guid
        Dim dic As LATIR2.Document.Doc_Base
        Dim f As frmChild
        f = New frmChild
        Dim ObjTypeName As String = "tod.todGUI"
        Try
            dt = GuiManager.Manager.Session.GetRowsExDT("INSTANCE", GuiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='tod'")
            oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
            'Dim meta As MTZMetaModel.MTZMetaModel.Application
            dic = GuiManager.Manager.GetInstanceObject(oID)
            Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = GuiManager.GetTypeGUI(dic.TypeName, RootDllPath)
            If (Not Doc_GUIBase Is Nothing) Then
                Dim obj As Object = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
                f.AppendControl(obj)
                f.MdiParent = Me
                f.Attach(GuiManager, dic)
                f.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tocard_Click(ByVal sender As Object, ByVal e As EventArgs) Handles card_menu.Click
        Dim f As frmJournalViewIG
        f = New frmJournalViewIG
        f.MdiParent = Me
        f.Attach(GuiManager, "tocard", "Карты диагностики")
        AddHandler f.jv.JVOnAdd, AddressOf tocard_jv_JVOnAdd
        f.Show()

    End Sub


    Private Sub tocard_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
        Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
        Dim ID As Guid


        ID = Guid.NewGuid
        Manager.NewInstance(ID, "tocard", "Карта диагностики" & " " & Now)
        o1 = Manager.GetInstanceObject(ID)
        If o1 Is Nothing Then
            MsgBox("Отсутствует объектная библиотека для типа:" & "Карта диагностики", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        o2 = GuiManager.GetTypeGUI(o1.TypeName)
        If o2 Is Nothing Then
            MsgBox("Отсутствует интерфейсный компонент для типа:" & "Карта диагностики", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        o2.ShowForm("", o1)

        UseDefault = False
        Refesh = True

    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Dim tabtip As String
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")


        If tabtip = "true" Then
            mnuOnScreenKeyBoard.Checked = True
        Else
            mnuOnScreenKeyBoard.Checked = False
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuScale.Click
        Dim f As frmScale
        f = New frmScale
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub tosched_Click(sender As Object, e As EventArgs) Handles sched_menu.Click
        '    Dim dt As DataTable
        '    Dim oID As System.Guid
        '    Dim dic As LATIR2.Document.Doc_Base
        '    Dim f As frmChild
        '    f = New frmChild
        '    Dim ObjTypeName As String = "tosched.toschedGUI"
        '    Try
        '        dt = GuiManager.Manager.Session.GetRowsExDT("INSTANCE", GuiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='tosched'")
        '        oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
        '        'Dim meta As MTZMetaModel.MTZMetaModel.Application
        '        dic = GuiManager.Manager.GetInstanceObject(oID)
        '        Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
        '        Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
        '        Doc_GUIBase = GuiManager.GetTypeGUI(dic.TypeName, RootDllPath)
        '        If (Not Doc_GUIBase Is Nothing) Then
        '            Dim obj As Object = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
        '            f.AppendControl(obj)
        '            f.MdiParent = Me
        '            f.Attach(GuiManager, dic)
        '            f.Show()
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try
        'End Sub

        Dim f As frmJournalViewIG
        f = New frmJournalViewIG
        f.MdiParent = Me
        f.Attach(GuiManager, "tosched", "Расписание")
        AddHandler f.jv.JVOnAdd, AddressOf tosched_jv_JVOnAdd
        f.Show()

    End Sub


    Private Sub tosched_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
        Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
        Dim ID As Guid
        ID = Guid.NewGuid
        Manager.NewInstance(ID, "tosched", "Расписание" & " " & Now)
        o1 = Manager.GetInstanceObject(ID)
        If o1 Is Nothing Then
            MsgBox("Отсутствует объектная библиотека для типа:" & "Расписание", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        o2 = GuiManager.GetTypeGUI(o1.TypeName)
        If o2 Is Nothing Then
            MsgBox("Отсутствует интерфейсный компонент для типа:" & "Расписание", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        o2.ShowForm("", o1)

        UseDefault = False
        Refesh = True

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        tod_click(sender, e)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        tosched_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        tocard_Click(sender, e)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        OptionsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub oper_menu_Click(sender As Object, e As EventArgs) Handles oper_menu.Click

        Dim f As frmJournalViewIG
        f = New frmJournalViewIG
        f.MdiParent = Me
        f.Attach(GuiManager, "toop", "Операторы")
        AddHandler f.jv.JVOnAdd, AddressOf toop_jv_JVOnAdd
        f.Show()

    End Sub


    Private Sub toop_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
        Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
        Dim ID As Guid
        ID = Guid.NewGuid
        Manager.NewInstance(ID, "toop", "Операторы" & " " & Now)
        o1 = Manager.GetInstanceObject(ID)
        If o1 Is Nothing Then
            MsgBox("Отсутствует объектная библиотека для типа:" & "Оператор", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        o2 = GuiManager.GetTypeGUI(o1.TypeName)
        If o2 Is Nothing Then
            MsgBox("Отсутствует интерфейсный компонент для типа:" & "Оператор", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        o2.ShowForm("", o1)

        UseDefault = False
        Refesh = True

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        oper_menu_Click(sender, e)
    End Sub

    Private Sub HelpMenu_Click(sender As Object, e As EventArgs) Handles HelpMenu.Click
        Dim f As SplashScreen1
        f = New SplashScreen1
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim f As frmGant
        f = New frmGant
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim f As frmNFC
        f = New frmNFC
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuOnScreenKeyBoard_Click(sender As Object, e As EventArgs) Handles mnuOnScreenKeyBoard.Click
        Dim tabtip As String
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")
        If tabtip = "true" Then
            tabtip = "false"
        Else
            tabtip = "true"
        End If

        SaveSetting("LATIR4", "CFG", "TABTIP", tabtip)

        If tabtip = "true" Then
            mnuOnScreenKeyBoard.Checked = True
        Else
            mnuOnScreenKeyBoard.Checked = False
        End If

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        mnuGraphics_Click(sender, e)
    End Sub

    Private Sub mnuGraphics_Click(sender As Object, e As EventArgs) Handles mnuGraphics.Click
        Dim f As frmChart
        f = New frmChart
        f.MdiParent = Me
        f.Show()

    End Sub
End Class
