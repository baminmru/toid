<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCFG
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPath2IMG = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.fb = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkTabTip = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CloseButton1 = New LATIR2GuiManager.CloseButton()
        Me.lblText = New System.Windows.Forms.Label()
        Me.chkTools = New System.Windows.Forms.CheckBox()
        Me.txtServerSite = New LATIR2GuiManager.TouchTextBox()
        Me.cmdTempPath = New System.Windows.Forms.Button()
        Me.txtTempPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkTOTRN = New System.Windows.Forms.CheckBox()
        Me.cmdClearDB = New System.Windows.Forms.Button()
        Me.chkUpdateCardTags = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Путь  к хранилищу изображений"
        '
        'txtPath2IMG
        '
        Me.txtPath2IMG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath2IMG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPath2IMG.Location = New System.Drawing.Point(22, 153)
        Me.txtPath2IMG.Name = "txtPath2IMG"
        Me.txtPath2IMG.ReadOnly = True
        Me.txtPath2IMG.Size = New System.Drawing.Size(556, 30)
        Me.txtPath2IMG.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(584, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkTabTip
        '
        Me.chkTabTip.AutoSize = True
        Me.chkTabTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkTabTip.Location = New System.Drawing.Point(23, 253)
        Me.chkTabTip.Name = "chkTabTip"
        Me.chkTabTip.Size = New System.Drawing.Size(232, 29)
        Me.chkTabTip.TabIndex = 3
        Me.chkTabTip.Text = "Экранная клавиатура"
        Me.chkTabTip.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Сайт  сервера"
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(-2, -2)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(48, 48)
        Me.CloseButton1.TabIndex = 6
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(-2, -2)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(658, 48)
        Me.lblText.TabIndex = 7
        Me.lblText.Text = "Настройки"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkTools
        '
        Me.chkTools.AutoSize = True
        Me.chkTools.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkTools.Location = New System.Drawing.Point(278, 253)
        Me.chkTools.Name = "chkTools"
        Me.chkTools.Size = New System.Drawing.Size(308, 29)
        Me.chkTools.TabIndex = 8
        Me.chkTools.Text = "Инструменты для настройки"
        Me.chkTools.UseVisualStyleBackColor = True
        '
        'txtServerSite
        '
        Me.txtServerSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtServerSite.Location = New System.Drawing.Point(22, 213)
        Me.txtServerSite.Name = "txtServerSite"
        Me.txtServerSite.Size = New System.Drawing.Size(503, 30)
        Me.txtServerSite.TabIndex = 9
        '
        'cmdTempPath
        '
        Me.cmdTempPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTempPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdTempPath.Location = New System.Drawing.Point(585, 86)
        Me.cmdTempPath.Name = "cmdTempPath"
        Me.cmdTempPath.Size = New System.Drawing.Size(43, 29)
        Me.cmdTempPath.TabIndex = 12
        Me.cmdTempPath.Text = "..."
        Me.cmdTempPath.UseVisualStyleBackColor = True
        '
        'txtTempPath
        '
        Me.txtTempPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTempPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTempPath.Location = New System.Drawing.Point(23, 89)
        Me.txtTempPath.Name = "txtTempPath"
        Me.txtTempPath.ReadOnly = True
        Me.txtTempPath.Size = New System.Drawing.Size(556, 30)
        Me.txtTempPath.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(296, 25)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Папка для временных файлов"
        '
        'chkTOTRN
        '
        Me.chkTOTRN.AutoSize = True
        Me.chkTOTRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkTOTRN.Location = New System.Drawing.Point(22, 300)
        Me.chkTOTRN.Name = "chkTOTRN"
        Me.chkTOTRN.Size = New System.Drawing.Size(210, 29)
        Me.chkTOTRN.TabIndex = 13
        Me.chkTOTRN.Text = "Загружать тренды"
        Me.chkTOTRN.UseVisualStyleBackColor = True
        '
        'cmdClearDB
        '
        Me.cmdClearDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdClearDB.Location = New System.Drawing.Point(22, 351)
        Me.cmdClearDB.Name = "cmdClearDB"
        Me.cmdClearDB.Size = New System.Drawing.Size(294, 55)
        Me.cmdClearDB.TabIndex = 14
        Me.cmdClearDB.Text = "Очистить локальную базу"
        Me.cmdClearDB.UseVisualStyleBackColor = True
        '
        'chkUpdateCardTags
        '
        Me.chkUpdateCardTags.AutoSize = True
        Me.chkUpdateCardTags.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkUpdateCardTags.Location = New System.Drawing.Point(278, 300)
        Me.chkUpdateCardTags.Name = "chkUpdateCardTags"
        Me.chkUpdateCardTags.Size = New System.Drawing.Size(318, 29)
        Me.chkUpdateCardTags.TabIndex = 15
        Me.chkUpdateCardTags.Text = "Обновлять метки в карточках"
        Me.chkUpdateCardTags.UseVisualStyleBackColor = True
        '
        'frmCFG
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(658, 485)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkUpdateCardTags)
        Me.Controls.Add(Me.cmdClearDB)
        Me.Controls.Add(Me.chkTOTRN)
        Me.Controls.Add(Me.cmdTempPath)
        Me.Controls.Add(Me.txtTempPath)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtServerSite)
        Me.Controls.Add(Me.chkTools)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkTabTip)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPath2IMG)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCFG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Настройки"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPath2IMG As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents fb As FolderBrowserDialog
    Friend WithEvents chkTabTip As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents chkTools As CheckBox
    Friend WithEvents txtServerSite As LATIR2GuiManager.TouchTextBox
    Friend WithEvents cmdTempPath As Button
    Friend WithEvents txtTempPath As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkTOTRN As CheckBox
    Friend WithEvents cmdClearDB As Button
    Friend WithEvents chkUpdateCardTags As CheckBox
End Class
