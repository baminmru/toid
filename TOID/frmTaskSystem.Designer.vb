<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTaskSystem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CloseButton1 = New LATIR2GuiManager.CloseButton()
        Me.lblText = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDelegate = New System.Windows.Forms.Button()
        Me.cmdDone = New System.Windows.Forms.Button()
        Me.ImageGallery1 = New gPic.ImageGallery()
        Me.SuspendLayout()
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(-1, -3)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(48, 48)
        Me.CloseButton1.TabIndex = 19
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(1, -3)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(716, 48)
        Me.lblText.TabIndex = 20
        Me.lblText.Text = "Разузловка"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.Image = Global.TOID.My.Resources.Resources.iu_montag
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(6, 304)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 67)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Графики"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Image = Global.TOID.My.Resources.Resources.iu_accept
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(6, 203)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 86)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Данные по станку"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnDelegate
        '
        Me.btnDelegate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDelegate.Image = Global.TOID.My.Resources.Resources.iu_convert
        Me.btnDelegate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelegate.Location = New System.Drawing.Point(5, 129)
        Me.btnDelegate.Name = "btnDelegate"
        Me.btnDelegate.Size = New System.Drawing.Size(104, 68)
        Me.btnDelegate.TabIndex = 22
        Me.btnDelegate.Text = "Передать"
        Me.btnDelegate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelegate.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdDone.Image = Global.TOID.My.Resources.Resources.iu_zavershen
        Me.cmdDone.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDone.Location = New System.Drawing.Point(5, 57)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(105, 66)
        Me.cmdDone.TabIndex = 21
        Me.cmdDone.Text = "Завершить"
        Me.cmdDone.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'ImageGallery1
        '
        Me.ImageGallery1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageGallery1.AutoScroll = True
        Me.ImageGallery1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImageGallery1.Directorypath = Nothing
        Me.ImageGallery1.Location = New System.Drawing.Point(116, 48)
        Me.ImageGallery1.MinimumSize = New System.Drawing.Size(4, 200)
        Me.ImageGallery1.Name = "ImageGallery1"
        Me.ImageGallery1.PGap = "10"
        Me.ImageGallery1.PicHeight = "113"
        Me.ImageGallery1.PicWidth = "180"
        Me.ImageGallery1.Size = New System.Drawing.Size(589, 448)
        Me.ImageGallery1.TabIndex = 18
        Me.ImageGallery1.TextColor = System.Drawing.Color.Blue
        '
        'frmTaskSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 495)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDelegate)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.ImageGallery1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTaskSystem"
        Me.Text = "frmTaskSystem"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents ImageGallery1 As gPic.ImageGallery
    Friend WithEvents cmdDone As Button
    Friend WithEvents btnDelegate As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
