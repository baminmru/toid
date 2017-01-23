<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPhoto
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
        Me.CloseButton1 = New LATIR2GuiManager.CloseButton()
        Me.lblText = New System.Windows.Forms.Label()
        Me.VideoSourcePlayer = New AForge.Controls.VideoSourcePlayer()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdGetPhoto = New System.Windows.Forms.Button()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(2, -2)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(48, 48)
        Me.CloseButton1.TabIndex = 14
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(-2, -2)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(710, 48)
        Me.lblText.TabIndex = 15
        Me.lblText.Text = "Фото к отчету"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VideoSourcePlayer
        '
        Me.VideoSourcePlayer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VideoSourcePlayer.Location = New System.Drawing.Point(12, 92)
        Me.VideoSourcePlayer.Name = "VideoSourcePlayer"
        Me.VideoSourcePlayer.Size = New System.Drawing.Size(278, 262)
        Me.VideoSourcePlayer.TabIndex = 17
        Me.VideoSourcePlayer.Text = "VideoSourcePlayer1"
        Me.VideoSourcePlayer.VideoSource = Nothing
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.Image = Global.TOID.My.Resources.Resources.camera
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(12, 52)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 32)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Камера 1"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Enabled = False
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdSave.Image = Global.TOID.My.Resources.Resources.photo_add
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSave.Location = New System.Drawing.Point(597, 52)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(111, 302)
        Me.cmdSave.TabIndex = 21
        Me.cmdSave.Text = "Сохранить"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdGetPhoto
        '
        Me.cmdGetPhoto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGetPhoto.Enabled = False
        Me.cmdGetPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdGetPhoto.Image = Global.TOID.My.Resources.Resources.photo
        Me.cmdGetPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGetPhoto.Location = New System.Drawing.Point(296, 52)
        Me.cmdGetPhoto.Name = "cmdGetPhoto"
        Me.cmdGetPhoto.Size = New System.Drawing.Size(295, 32)
        Me.cmdGetPhoto.TabIndex = 20
        Me.cmdGetPhoto.Text = "Сделать снимок"
        Me.cmdGetPhoto.UseVisualStyleBackColor = True
        '
        'picPhoto
        '
        Me.picPhoto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPhoto.Location = New System.Drawing.Point(296, 92)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(295, 262)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPhoto.TabIndex = 19
        Me.picPhoto.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Image = Global.TOID.My.Resources.Resources.camera
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(161, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 32)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Камера 2"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmAddPhoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 366)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdGetPhoto)
        Me.Controls.Add(Me.picPhoto)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.VideoSourcePlayer)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAddPhoto"
        Me.Text = "frmAddPhoto"
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents VideoSourcePlayer As AForge.Controls.VideoSourcePlayer
    Friend WithEvents Button1 As Button
    Friend WithEvents picPhoto As PictureBox
    Friend WithEvents cmdGetPhoto As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents Button2 As Button
End Class
