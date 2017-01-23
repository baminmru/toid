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
        Me.cmdtemp = New System.Windows.Forms.Button()
        Me.txtTemp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Путь  к хранилищу изображений"
        '
        'txtPath2IMG
        '
        Me.txtPath2IMG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath2IMG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPath2IMG.Location = New System.Drawing.Point(12, 39)
        Me.txtPath2IMG.Name = "txtPath2IMG"
        Me.txtPath2IMG.ReadOnly = True
        Me.txtPath2IMG.Size = New System.Drawing.Size(452, 26)
        Me.txtPath2IMG.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(491, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 35)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkTabTip
        '
        Me.chkTabTip.AutoSize = True
        Me.chkTabTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkTabTip.Location = New System.Drawing.Point(12, 145)
        Me.chkTabTip.Name = "chkTabTip"
        Me.chkTabTip.Size = New System.Drawing.Size(194, 24)
        Me.chkTabTip.TabIndex = 3
        Me.chkTabTip.Text = "Экранная клавиатура"
        Me.chkTabTip.UseVisualStyleBackColor = True
        '
        'cmdtemp
        '
        Me.cmdtemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdtemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdtemp.Location = New System.Drawing.Point(491, 90)
        Me.cmdtemp.Name = "cmdtemp"
        Me.cmdtemp.Size = New System.Drawing.Size(43, 38)
        Me.cmdtemp.TabIndex = 6
        Me.cmdtemp.Text = "..."
        Me.cmdtemp.UseVisualStyleBackColor = True
        '
        'txtTemp
        '
        Me.txtTemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTemp.Location = New System.Drawing.Point(12, 91)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.ReadOnly = True
        Me.txtTemp.Size = New System.Drawing.Size(452, 26)
        Me.txtTemp.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Папка для временных файлов"
        '
        'frmCFG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 181)
        Me.Controls.Add(Me.cmdtemp)
        Me.Controls.Add(Me.txtTemp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkTabTip)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPath2IMG)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCFG"
        Me.Text = "Настройки"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPath2IMG As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents fb As FolderBrowserDialog
    Friend WithEvents chkTabTip As CheckBox
    Friend WithEvents cmdtemp As Button
    Friend WithEvents txtTemp As TextBox
    Friend WithEvents Label2 As Label
End Class
