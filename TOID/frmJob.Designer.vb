<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob
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
        Me.ImageGallery1 = New gPic.ImageGallery()
        Me.CloseButton1 = New LATIR2GuiManager.CloseButton()
        Me.lblText = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ImageGallery1
        '
        Me.ImageGallery1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageGallery1.AutoScroll = True
        Me.ImageGallery1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImageGallery1.Directorypath = Nothing
        Me.ImageGallery1.Location = New System.Drawing.Point(0, 43)
        Me.ImageGallery1.Name = "ImageGallery1"
        Me.ImageGallery1.PGap = "10"
        Me.ImageGallery1.PicHeight = "113"
        Me.ImageGallery1.PicWidth = "180"
        Me.ImageGallery1.Size = New System.Drawing.Size(599, 380)
        Me.ImageGallery1.TabIndex = 0
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(0, -2)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(48, 48)
        Me.CloseButton1.TabIndex = 16
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(0, -2)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(599, 48)
        Me.lblText.TabIndex = 17
        Me.lblText.Text = "Текущие задачи ТоиД"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'frmJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 423)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.ImageGallery1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Текущие задачи ТоиД"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageGallery1 As gPic.ImageGallery
    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents Timer1 As Timer
End Class
