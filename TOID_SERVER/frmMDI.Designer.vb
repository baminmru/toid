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
        Me.tod_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.sched_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.card_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.oper_menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogins = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGraphics = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScale = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLinkImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLinkImageSys = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCFG = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolsMenu, Me.WindowsMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1087, 40)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tod_menu, Me.ToolStripSeparator3, Me.sched_menu, Me.card_menu, Me.oper_menu, Me.mnuLogins, Me.ToolStripMenuItem1, Me.mnuGraphics, Me.ToolStripSeparator4, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(83, 36)
        Me.FileMenu.Text = "Файл"
        '
        'tod_menu
        '
        Me.tod_menu.Image = CType(resources.GetObject("tod_menu.Image"), System.Drawing.Image)
        Me.tod_menu.ImageTransparentColor = System.Drawing.Color.Black
        Me.tod_menu.Name = "tod_menu"
        Me.tod_menu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.tod_menu.Size = New System.Drawing.Size(336, 36)
        Me.tod_menu.Text = "Справочник"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(333, 6)
        '
        'sched_menu
        '
        Me.sched_menu.Image = CType(resources.GetObject("sched_menu.Image"), System.Drawing.Image)
        Me.sched_menu.ImageTransparentColor = System.Drawing.Color.Black
        Me.sched_menu.Name = "sched_menu"
        Me.sched_menu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.sched_menu.Size = New System.Drawing.Size(336, 36)
        Me.sched_menu.Text = "Расписание"
        '
        'card_menu
        '
        Me.card_menu.Image = CType(resources.GetObject("card_menu.Image"), System.Drawing.Image)
        Me.card_menu.Name = "card_menu"
        Me.card_menu.Size = New System.Drawing.Size(336, 36)
        Me.card_menu.Text = "Карточки"
        '
        'oper_menu
        '
        Me.oper_menu.Image = CType(resources.GetObject("oper_menu.Image"), System.Drawing.Image)
        Me.oper_menu.Name = "oper_menu"
        Me.oper_menu.Size = New System.Drawing.Size(336, 36)
        Me.oper_menu.Text = "Оператор"
        '
        'mnuLogins
        '
        Me.mnuLogins.Image = Global.TOIDADMIN.My.Resources.Resources.user_key
        Me.mnuLogins.Name = "mnuLogins"
        Me.mnuLogins.Size = New System.Drawing.Size(336, 36)
        Me.mnuLogins.Text = "Учетные записи"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.TOIDADMIN.My.Resources.Resources.wrench_orange
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(336, 36)
        Me.ToolStripMenuItem1.Text = "Задачи"
        '
        'mnuGraphics
        '
        Me.mnuGraphics.Image = Global.TOIDADMIN.My.Resources.Resources.chart_bar
        Me.mnuGraphics.Name = "mnuGraphics"
        Me.mnuGraphics.Size = New System.Drawing.Size(336, 36)
        Me.mnuGraphics.Text = "Графики показателей"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(333, 6)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(333, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(336, 36)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuScale, Me.mnuLinkImage, Me.mnuLinkImageSys, Me.mnuCFG})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(143, 36)
        Me.ToolsMenu.Text = "Настройка"
        '
        'mnuScale
        '
        Me.mnuScale.Image = CType(resources.GetObject("mnuScale.Image"), System.Drawing.Image)
        Me.mnuScale.Name = "mnuScale"
        Me.mnuScale.Size = New System.Drawing.Size(455, 36)
        Me.mnuScale.Text = "Шкала"
        Me.mnuScale.Visible = False
        '
        'mnuLinkImage
        '
        Me.mnuLinkImage.Image = Global.TOIDADMIN.My.Resources.Resources.picture_add
        Me.mnuLinkImage.Name = "mnuLinkImage"
        Me.mnuLinkImage.Size = New System.Drawing.Size(455, 36)
        Me.mnuLinkImage.Text = "Привязка изображений станков"
        '
        'mnuLinkImageSys
        '
        Me.mnuLinkImageSys.Image = Global.TOIDADMIN.My.Resources.Resources.pictures
        Me.mnuLinkImageSys.Name = "mnuLinkImageSys"
        Me.mnuLinkImageSys.Size = New System.Drawing.Size(455, 36)
        Me.mnuLinkImageSys.Text = "Привязка изображений узлов"
        '
        'mnuCFG
        '
        Me.mnuCFG.Image = Global.TOIDADMIN.My.Resources.Resources.folder_wrench
        Me.mnuCFG.Name = "mnuCFG"
        Me.mnuCFG.Size = New System.Drawing.Size(455, 36)
        Me.mnuCFG.Text = "Пути..."
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuAbout})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(83, 36)
        Me.WindowsMenu.Text = "Окна"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(387, 36)
        Me.CascadeToolStripMenuItem.Text = "Каскад"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(387, 36)
        Me.TileVerticalToolStripMenuItem.Text = "Разложить вертикально"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(387, 36)
        Me.TileHorizontalToolStripMenuItem.Text = "Разложить горизонтально"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(387, 36)
        Me.CloseAllToolStripMenuItem.Text = "Закрыть все"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(384, 6)
        '
        'mnuAbout
        '
        Me.mnuAbout.Image = Global.TOIDADMIN.My.Resources.Resources.bullet_home
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(387, 36)
        Me.mnuAbout.Text = "О программе"
        '
        'frmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
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
End Class
