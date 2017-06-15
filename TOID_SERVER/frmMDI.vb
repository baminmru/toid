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
        GetOper()


        Me.Text = Application.ProductName & " :: " & sitename

        Me.WindowState = FormWindowState.Maximized
    End Sub



    Public Sub tod_click(ByVal sender As Object, ByVal e As EventArgs) Handles tod_menu.Click
        Dim dt As DataTable
        Dim oID As System.Guid
        Dim dic As LATIR2.Document.Doc_Base

        If fTOd IsNot Nothing Then
            If fTOd.Visible = True Then
                fTOd.Focus()
                Exit Sub
            End If
            Try
                fTOd.Close()
                fTOd.Dispose()
            Catch ex As Exception

            End Try
        End If
        fTOd = New frmChild
        Dim ObjTypeName As String = "tod.todGUI"
        Try
            dt = Manager.Session.GetRowsExDT("INSTANCE", Manager.Provider.InstanceFieldList, , , "OBJTYPE='tod'")
            oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
            'Dim meta As MTZMetaModel.MTZMetaModel.Application
            dic = GuiManager.Manager.GetInstanceObject(oID)
            Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = GuiManager.GetTypeGUI(dic.TypeName, RootDllPath)
            If (Not Doc_GUIBase Is Nothing) Then
                Dim obj As Object = Doc_GUIBase.GetObjectControl(DocMode, ObjTypeName)
                fTOd.AppendControl(obj)
                fTOd.MdiParent = Me
                fTOd.Attach(GuiManager, dic)
                fTOd.Show()
                fTOd.WindowState = FormWindowState.Maximized
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub tocard_jv_JVOnPrint(InstanceID As Guid, RowID As Guid, ViewBase As String, ByRef UseDefault As Boolean)
        UseDefault = False
        Dim tc As tocard.tocard.Application
        Dim tci As tocard.tocard.to_cardinfo

        tc = Manager.GetInstanceObject(InstanceID)
        tci = tc.to_cardinfo.Item(1)

        Dim f As frmReport
        f = New frmReport
        f.StID = tci.the_machine.ID
        f.StName = tci.the_machine.Brief

        f.ShowDialog()
    End Sub


    Private Sub tocard_Click(ByVal sender As Object, ByVal e As EventArgs) Handles card_menu.Click
        If fCard IsNot Nothing Then
            If fCard.Visible = True Then
                fCard.Focus()
                Exit Sub
            End If
            Try
                fCard.Close()
                fCard.Dispose()
            Catch ex As Exception

            End Try
        End If
        fCard = New frmJournalView
        fCard.MdiParent = Me
        fCard.Attach(GuiManager, "tocard", "Карты диагностики")
        AddHandler fCard.jv.JVOnAdd, AddressOf tocard_jv_JVOnAdd
        AddHandler fCard.jv.JVOnPrint, AddressOf tocard_jv_JVOnPrint
        fCard.Show()
        fCard.WindowState = FormWindowState.Maximized

    End Sub


    Private Sub tocard_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refresh As Boolean)
        If DocMode <> "" Then
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
            o2.ShowForm(DocMode, o1)
        Else
            MsgBox("Операция доступна только администратору", MsgBoxStyle.OkOnly)
        End If


        UseDefault = False
        Refresh = True

    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
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

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
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

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuScale.Click
        Dim f As frmScale
        f = New frmScale
        f.MdiParent = Me

        f.Show()
    End Sub


    Private Sub tosched_jv_JVOnRun(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refresh As Boolean)
        UseDefault = False
        Refresh = False
        If fGnt IsNot Nothing Then
            If fGnt.Visible = True Then
                fGnt.Focus()
                Exit Sub
            End If
            Try
                fGnt.Close()
                fGnt.Dispose()
            Catch ex As Exception

            End Try
        End If

        fGnt = New frmGant
        fGnt.SchedID = InstanceID
        fGnt.MdiParent = Me
        fGnt.Show()


    End Sub

    Private Sub tosched_Click(sender As Object, e As EventArgs) Handles sched_menu.Click


        If fSched IsNot Nothing Then
            If fSched.Visible = True Then
                fSched.Focus()
                Exit Sub
            End If
            Try
                fSched.Close()
                fSched.Dispose()
            Catch ex As Exception

            End Try
        End If
        fSched = New frmJournalView

        fSched.MdiParent = Me
        fSched.Attach(GuiManager, "tosched", "Расписание")
        AddHandler fSched.jv.JVOnAdd, AddressOf tosched_jv_JVOnAdd
        AddHandler fSched.jv.JVOnRun, AddressOf tosched_jv_JVOnRun
        AddHandler fSched.jv.JVOnPrint, AddressOf tosched_jv_JVOnPrint
        fSched.Show()
        fSched.WindowState = FormWindowState.Maximized

    End Sub


    Private Sub tosched_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refresh As Boolean)
        If DocMode <> "" Then
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
        Else
            MessageBox.Show("Операция доступна только администратору")
        End If

        UseDefault = False
        Refresh = True

    End Sub


    Private Sub oper_menu_Click(sender As Object, e As EventArgs) Handles oper_menu.Click

        If fOper IsNot Nothing Then
            If fOper.Visible = True Then
                fOper.Focus()
                Exit Sub
            End If
            Try
                fOper.Close()
                fOper.Dispose()
            Catch ex As Exception

            End Try
        End If
        fOper = New frmJournalView
        fOper.MdiParent = Me
        fOper.Attach(GuiManager, "toop", "Операторы")
        AddHandler fOper.jv.JVOnAdd, AddressOf toop_jv_JVOnAdd
        fOper.Show()
        fOper.WindowState = FormWindowState.Maximized


    End Sub


    Private Sub toop_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refresh As Boolean)
        If DocMode <> "" Then


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
            o2.ShowForm(DocMode, o1)
        Else
            MessageBox.Show("Операция доступна только администратору")

        End If

        UseDefault = False
        Refresh = True

    End Sub

    Private Sub totask_jv_JVOnAdd(ByRef UseDefault As Boolean, ByRef Refresh As Boolean)
        If DocMode <> "" Then
            Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
            Dim ID As Guid
            ID = Guid.NewGuid
            Manager.NewInstance(ID, "totask", "Задача" & " " & Now)
            o1 = Manager.GetInstanceObject(ID)
            If o1 Is Nothing Then
                MsgBox("Отсутствует объектная библиотека для типа:" & "Задача", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            o2 = GuiManager.GetTypeGUI(o1.TypeName)
            If o2 Is Nothing Then
                MsgBox("Отсутствует интерфейсный компонент для типа:" & "Задача", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            o2.ShowForm(DocMode, o1)
        Else
            MessageBox.Show("Операция доступна только администратору")
        End If

        UseDefault = False
        Refresh = True

    End Sub


    Private Sub totask_jv_JVOnPrint(InstanceID As Guid, RowID As Guid, ViewBase As String, ByRef UseDefault As Boolean)
        UseDefault = False


        Dim f As frmRPT
        f = New frmRPT
        f.tID = InstanceID
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub tosched_jv_JVOnPrint(InstanceID As Guid, RowID As Guid, ViewBase As String, ByRef UseDefault As Boolean)
        UseDefault = False


        Dim f As frmRPT_SHED
        f = New frmRPT_SHED
        f.tID = InstanceID
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub



    Private Sub HelpMenu_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        Dim f As SplashScreen1
        f = New SplashScreen1
        f.ShowDialog()
    End Sub





    Private Sub mnuOnScreenKeyBoard_Click(sender As Object, e As EventArgs)
        Dim tabtip As String
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")
        If tabtip = "true" Then
            tabtip = "false"
        Else
            tabtip = "true"
        End If

        SaveSetting("LATIR4", "CFG", "TABTIP", tabtip)



    End Sub



    Private Sub mnuGraphics_Click(sender As Object, e As EventArgs) Handles mnuGraphics.Click
        If fChrt IsNot Nothing Then
            If fChrt.Visible = True Then
                fChrt.Focus()
                Exit Sub
            End If
            Try
                fChrt.Close()
                fChrt.Dispose()
            Catch ex As Exception

            End Try
        End If

        fChrt = New frmChart
        fChrt.MdiParent = Me
        fChrt.Show()
        fChrt.WindowState = FormWindowState.Maximized

    End Sub



    Private Sub mnuLinkImage_Click(sender As Object, e As EventArgs) Handles mnuLinkImage.Click
        If fPicST IsNot Nothing Then
            If fPicST.Visible = True Then
                fPicST.Focus()
                Exit Sub
            End If
            Try
                fPicST.Close()
                fPicST.Dispose()
            Catch ex As Exception

            End Try
        End If


        fPicST = New frmImageToolST
        fPicST.MdiParent = Me

        fPicST.Show()
        fPicST.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub mnuCFG_Click(sender As Object, e As EventArgs) Handles mnuCFG.Click
        Dim f As frmCFG
        f = New frmCFG
        f.ShowDialog()
    End Sub

    Private Sub mnuLinkImageSys_Click(sender As Object, e As EventArgs) Handles mnuLinkImageSys.Click
        If fPicU IsNot Nothing Then
            If fPicU.Visible = True Then
                fPicU.Focus()
                Exit Sub
            End If
            Try
                fPicU.Close()
                fPicU.Dispose()
            Catch ex As Exception

            End Try
        End If

        fPicU = New frmImageTool
        fPicU.MdiParent = Me

        fPicU.Show()
        fPicU.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If fTask IsNot Nothing Then
            If fTask.Visible = True Then
                fTask.Focus()
                Exit Sub
            End If
            Try
                fTask.Close()
                fTask.Dispose()
            Catch ex As Exception

            End Try
        End If
        fTask = New frmJournalView
        fTask.MdiParent = Me
        fTask.Attach(GuiManager, "totask", "Задачи диагностики")
        AddHandler fTask.jv.JVOnAdd, AddressOf totask_jv_JVOnAdd
        AddHandler fTask.jv.JVOnPrint, AddressOf totask_jv_JVOnPrint
        fTask.Show()
        fTask.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub mnuGantt_Click(sender As Object, e As EventArgs)
        If fGnt IsNot Nothing Then
            If fGnt.Visible = True Then
                fGnt.Focus()
                Exit Sub
            End If
            Try
                fGnt.Close()
                fGnt.Dispose()
            Catch ex As Exception

            End Try
        End If

        fGnt = New frmGant
        fGnt.MdiParent = Me
        fGnt.Show()

    End Sub

    Private Sub mnuLogins_Click(sender As Object, e As EventArgs) Handles mnuLogins.Click

        If DocMode <> "" Then
            Dim dt As DataTable
            Dim oID As System.Guid
            Dim dic As LATIR2.Document.Doc_Base

            If fUsr IsNot Nothing Then
                If fUsr.Visible = True Then
                    fUsr.Focus()
                    Exit Sub
                End If
                Try
                    fUsr.Close()
                    fUsr.Dispose()
                Catch ex As Exception

                End Try
            End If

            fUsr = New frmChild
            Dim ObjTypeName As String = "mtzusers.mtzusersGUI"
            Try
                dt = Manager.Session.GetData("select * from v_instance where OBJTYPE='mtzusers'")
                oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
                'Dim meta As MTZMetaModel.MTZMetaModel.Application
                dic = GuiManager.Manager.GetInstanceObject(oID)
                Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
                Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
                Doc_GUIBase = GuiManager.GetTypeGUI(dic.TypeName, RootDllPath)
                If (Not Doc_GUIBase Is Nothing) Then
                    Dim obj As Object = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
                    fUsr.AppendControl(obj)
                    fUsr.MdiParent = Me
                    fUsr.Attach(GuiManager, dic)
                    fUsr.Show()
                    fUsr.WindowState = FormWindowState.Maximized
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Операция доступна только администратору")
        End If

    End Sub

    Private Sub mnuTaskChart_Click(sender As Object, e As EventArgs) Handles mnuTaskChart.Click

        Dim fTG As frmTaskGraph
        fTG = New frmTaskGraph
        fTG.MdiParent = Me
        fTG.Show()
        fTG.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdActiveTask_Click(sender As Object, e As EventArgs) Handles cmdActiveTask.Click
        If fTaskA IsNot Nothing Then
            If fTaskA.Visible = True Then
                fTaskA.Focus()
                Exit Sub
            End If
            Try
                fTaskA.Close()
                fTaskA.Dispose()
            Catch ex As Exception

            End Try
        End If
        fTaskA = New frmJournalView
        fTaskA.MdiParent = Me
        fTaskA.jv.Filters.Add("autoto_taskinfo", "to_taskinfo_taskfinished ='Нет'")
        fTaskA.Attach(GuiManager, "totask", "Активные задачи")

        AddHandler fTaskA.jv.JVOnAdd, AddressOf totask_jv_JVOnAdd
        AddHandler fTaskA.jv.JVOnPrint, AddressOf totask_jv_JVOnPrint
        fTaskA.Show()
        fTaskA.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ПоЗадачамToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоЗадачамToolStripMenuItem.Click
        Dim f As frmRPT
        f = New frmRPT
        f.tID = Guid.Empty
        f.MdiParent = Me

        f.Show()

    End Sub


    Private Sub ПоПланамToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоПланамToolStripMenuItem.Click
        Dim f As frmRPT_SHED
        f = New frmRPT_SHED
        f.tID = Guid.Empty
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuReportST_Click(sender As Object, e As EventArgs) Handles mnuReportST.Click
        Dim f As frmRPT_ST
        f = New frmRPT_ST
        f.tID = Guid.Empty
        f.MdiParent = Me

        f.Show()
    End Sub
End Class
