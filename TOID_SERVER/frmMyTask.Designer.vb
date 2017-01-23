<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMyTask
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.PageInfo = New System.Windows.Forms.TabPage()
        Me.PageImages = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageGallery1 = New gPic.ImageGallery()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.PageInfo)
        Me.TabControl1.Controls.Add(Me.PageImages)
        Me.TabControl1.Location = New System.Drawing.Point(1, 212)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(704, 146)
        Me.TabControl1.TabIndex = 1
        '
        'PageInfo
        '
        Me.PageInfo.Location = New System.Drawing.Point(4, 22)
        Me.PageInfo.Name = "PageInfo"
        Me.PageInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.PageInfo.Size = New System.Drawing.Size(696, 120)
        Me.PageInfo.TabIndex = 0
        Me.PageInfo.Text = "Описание"
        Me.PageInfo.UseVisualStyleBackColor = True
        '
        'PageImages
        '
        Me.PageImages.Location = New System.Drawing.Point(4, 22)
        Me.PageImages.Name = "PageImages"
        Me.PageImages.Padding = New System.Windows.Forms.Padding(3)
        Me.PageImages.Size = New System.Drawing.Size(696, 120)
        Me.PageImages.TabIndex = 1
        Me.PageImages.Text = "Фото"
        Me.PageImages.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageGallery1
        '
        Me.ImageGallery1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageGallery1.AutoScroll = True
        Me.ImageGallery1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImageGallery1.Directorypath = Nothing
        Me.ImageGallery1.Location = New System.Drawing.Point(1, -2)
        Me.ImageGallery1.MinimumSize = New System.Drawing.Size(4, 200)
        Me.ImageGallery1.Name = "ImageGallery1"
        Me.ImageGallery1.PGap = "10"
        Me.ImageGallery1.PicHeight = "113"
        Me.ImageGallery1.PicWidth = "180"
        Me.ImageGallery1.Size = New System.Drawing.Size(704, 200)
        Me.ImageGallery1.TabIndex = 2
        '
        'frmMyTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 370)
        Me.Controls.Add(Me.ImageGallery1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmMyTask"
        Me.Text = "Мои задачи"
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PageInfo As TabPage
    Friend WithEvents PageImages As TabPage
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageGallery1 As gPic.ImageGallery
End Class
