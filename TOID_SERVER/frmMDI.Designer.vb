<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDI))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоЗадачамToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоПланамToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tod_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.sched_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.card_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.oper_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogins = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdActiveTask = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGraphics = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTaskChart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScale = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLinkImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLinkImageSys = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCFG = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportST = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolStripMenuItem2, Me.ToolsMenu, Me.WindowsMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1449, 49)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tod_menu, Me.ToolStripSeparator3, Me.sched_menu, Me.card_menu, Me.oper_menu, Me.mnuLogins, Me.ToolStripMenuItem1, Me.cmdActiveTask, Me.mnuGraphics, Me.ToolStripSeparator4, Me.mnuTaskChart, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(100, 45)
        Me.FileMenu.Text = "Файл"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(425, 6)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(425, 6)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(425, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ПоЗадачамToolStripMenuItem, Me.ПоПланамToolStripMenuItem, Me.mnuReportST})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(131, 45)
        Me.ToolStripMenuItem2.Text = "Отчеты"
        '
        'ПоЗадачамToolStripMenuItem
        '
        Me.ПоЗадачамToolStripMenuItem.Name = "ПоЗадачамToolStripMenuItem"
        Me.ПоЗадачамToolStripMenuItem.Size = New System.Drawing.Size(261, 46)
        Me.ПоЗадачамToolStripMenuItem.Text = "По задачам"
        '
        'ПоПланамToolStripMenuItem
        '
        Me.ПоПланамToolStripMenuItem.Name = "ПоПланамToolStripMenuItem"
        Me.ПоПланамToolStripMenuItem.Size = New System.Drawing.Size(261, 46)
        Me.ПоПланамToolStripMenuItem.Text = "По планам"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuScale, Me.mnuLinkImage, Me.mnuLinkImageSys, Me.mnuCFG})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(175, 45)
        Me.ToolsMenu.Text = "Настройка"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuAbout})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(100, 45)
        Me.WindowsMenu.Text = "Окна"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(464, 46)
        Me.CascadeToolStripMenuItem.Text = "Каскад"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(464, 46)
        Me.TileVerticalToolStripMenuItem.Text = "Разложить вертикально"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(464, 46)
        Me.TileHorizontalToolStripMenuItem.Text = "Разложить горизонтально"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(464, 46)
        Me.CloseAllToolStripMenuItem.Text = "Закрыть все"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(461, 6)
        '
        'tod_menu
        '
        Me.tod_menu.Image = CType(resources.GetObject("tod_menu.Image"), System.Drawing.Image)
        Me.tod_menu.ImageTransparentColor = System.Drawing.Color.Black
        Me.tod_menu.Name = "tod_menu"
        Me.tod_menu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.tod_menu.Size = New System.Drawing.Size(428, 46)
        Me.tod_menu.Text = "Справочник"
        '
        'sched_menu
        '
        Me.sched_menu.Image = CType(resources.GetObject("sched_menu.Image"), System.Drawing.Image)
        Me.sched_menu.ImageTransparentColor = System.Drawing.Color.Black
        Me.sched_menu.Name = "sched_menu"
        Me.sched_menu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.sched_menu.Size = New System.Drawing.Size(428, 46)
        Me.sched_menu.Text = "Расписание"
        '
        'card_menu
        '
        Me.card_menu.Image = CType(resources.GetObject("card_menu.Image"), System.Drawing.Image)
        Me.card_menu.Name = "card_menu"
        Me.card_menu.Size = New System.Drawing.Size(428, 46)
        Me.card_menu.Text = "Карточки"
        '
        'oper_menu
        '
        Me.oper_menu.Image = CType(resources.GetObject("oper_menu.Image"), System.Drawing.Image)
        Me.oper_menu.Name = "oper_menu"
        Me.oper_menu.Size = New System.Drawing.Size(428, 46)
        Me.oper_menu.Text = "Оператор"
        '
        'mnuLogins
        '
        Me.mnuLogins.Image = Global.TOIDADMIN.My.Resources.Resources.user_key
        Me.mnuLogins.Name = "mnuLogins"
        Me.mnuLogins.Size = New System.Drawing.Size(428, 46)
        Me.mnuLogins.Text = "Учетные записи"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.TOIDADMIN.My.Resources.Resources.wrench_orange
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(428, 46)
        Me.ToolStripMenuItem1.Text = "Все Задачи"
        '
        'cmdActiveTask
        '
        Me.cmdActiveTask.Image = Global.TOIDADMIN.My.Resources.Resources.gear_icon_32px
        Me.cmdActiveTask.Name = "cmdActiveTask"
        Me.cmdActiveTask.Size = New System.Drawing.Size(428, 46)
        Me.cmdActiveTask.Text = "Активные задачи"
        '
        'mnuGraphics
        '
        Me.mnuGraphics.Image = Global.TOIDADMIN.My.Resources.Resources.chart_bar
        Me.mnuGraphics.Name = "mnuGraphics"
        Me.mnuGraphics.Size = New System.Drawing.Size(428, 46)
        Me.mnuGraphics.Text = "Графики показателей"
        '
        'mnuTaskChart
        '
        Me.mnuTaskChart.Image = Global.TOIDADMIN.My.Resources.Resources.IELTS_Line_Graph
        Me.mnuTaskChart.Name = "mnuTaskChart"
        Me.mnuTaskChart.Size = New System.Drawing.Size(428, 46)
        Me.mnuTaskChart.Text = "Графики по данным ТО"
        Me.mnuTaskChart.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(428, 46)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'mnuScale
        '
        Me.mnuScale.Image = CType(resources.GetObject("mnuScale.Image"), System.Drawing.Image)
        Me.mnuScale.Name = "mnuScale"
        Me.mnuScale.Size = New System.Drawing.Size(546, 46)
        Me.mnuScale.Text = "Шкала"
        Me.mnuScale.Visible = False
        '
        'mnuLinkImage
        '
        Me.mnuLinkImage.Image = Global.TOIDADMIN.My.Resources.Resources.picture_add
        Me.mnuLinkImage.Name = "mnuLinkImage"
        Me.mnuLinkImage.Size = New System.Drawing.Size(546, 46)
        Me.mnuLinkImage.Text = "Привязка изображений станков"
        '
        'mnuLinkImageSys
        '
        Me.mnuLinkImageSys.Image = Global.TOIDADMIN.My.Resources.Resources.pictures
        Me.mnuLinkImageSys.Name = "mnuLinkImageSys"
        Me.mnuLinkImageSys.Size = New System.Drawing.Size(546, 46)
        Me.mnuLinkImageSys.Text = "Привязка изображений узлов"
        '
        'mnuCFG
        '
        Me.mnuCFG.Image = Global.TOIDADMIN.My.Resources.Resources.folder_wrench
        Me.mnuCFG.Name = "mnuCFG"
        Me.mnuCFG.Size = New System.Drawing.Size(546, 46)
        Me.mnuCFG.Text = "Пути..."
        '
        'mnuAbout
        '
        Me.mnuAbout.Image = Global.TOIDADMIN.My.Resources.Resources.bullet_home
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(464, 46)
        Me.mnuAbout.Text = "О программе"
        '
        'mnuReportST
        '
        Me.mnuReportST.Name = "mnuReportST"
        Me.mnuReportST.Size = New System.Drawing.Size(261, 46)
        Me.mnuReportST.Text = "По станку"
        '
        'frmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1449, 558)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMDI"
        Me.Text = "frmMDI"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuScale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents card_menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tod_menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sched_menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents oper_menu As ToolStripMenuItem
    Friend WithEvents mnuGraphics As ToolStripMenuItem
    Friend WithEvents mnuLinkImage As ToolStripMenuItem
    Friend WithEvents mnuCFG As ToolStripMenuItem
    Friend WithEvents mnuLinkImageSys As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents mnuLogins As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuAbout As ToolStripMenuItem
    Friend WithEvents mnuTaskChart As ToolStripMenuItem
    Friend WithEvents cmdActiveTask As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ПоЗадачамToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ПоПланамToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuReportST As ToolStripMenuItem
End Class
