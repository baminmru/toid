<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemTO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemTO))
        Me.lblText = New System.Windows.Forms.Label()
        Me.panelInfo = New System.Windows.Forms.Panel()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.lblCommentHeader = New System.Windows.Forms.Label()
        Me.panelPhoto = New System.Windows.Forms.Panel()
        Me.lblPhotoHeader = New System.Windows.Forms.Label()
        Me.lstMeasure = New System.Windows.Forms.ListView()
        Me.LargeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblValueType = New System.Windows.Forms.Label()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.lblMax = New System.Windows.Forms.Label()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.lblCheck = New System.Windows.Forms.Label()
        Me.CloseButton1 = New LATIR2GuiManager.CloseButton()
        Me.txtValue = New gPic.touchInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSubsystem = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.picIMAGE = New System.Windows.Forms.PictureBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.btnDelPhoto = New System.Windows.Forms.Button()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAddPhoto = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnDelComment = New System.Windows.Forms.Button()
        Me.btnCommentNext = New System.Windows.Forms.Button()
        Me.btnAddComment = New System.Windows.Forms.Button()
        Me.btnCommentPrev = New System.Windows.Forms.Button()
        Me.panelInfo.SuspendLayout()
        Me.panelPhoto.SuspendLayout()
        CType(Me.picIMAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(1, -2)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(921, 48)
        Me.lblText.TabIndex = 19
        Me.lblText.Text = "ТО"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelInfo
        '
        Me.panelInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelInfo.Controls.Add(Me.btnDelComment)
        Me.panelInfo.Controls.Add(Me.txtComment)
        Me.panelInfo.Controls.Add(Me.btnCommentNext)
        Me.panelInfo.Controls.Add(Me.btnAddComment)
        Me.panelInfo.Controls.Add(Me.btnCommentPrev)
        Me.panelInfo.Controls.Add(Me.lblCommentHeader)
        Me.panelInfo.Location = New System.Drawing.Point(192, 342)
        Me.panelInfo.Name = "panelInfo"
        Me.panelInfo.Size = New System.Drawing.Size(349, 293)
        Me.panelInfo.TabIndex = 22
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtComment.Location = New System.Drawing.Point(8, 73)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ReadOnly = True
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComment.Size = New System.Drawing.Size(324, 208)
        Me.txtComment.TabIndex = 3
        '
        'lblCommentHeader
        '
        Me.lblCommentHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCommentHeader.Location = New System.Drawing.Point(8, 5)
        Me.lblCommentHeader.Name = "lblCommentHeader"
        Me.lblCommentHeader.Size = New System.Drawing.Size(324, 25)
        Me.lblCommentHeader.TabIndex = 0
        Me.lblCommentHeader.Text = "Комментарии (1 из 2)"
        Me.lblCommentHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'panelPhoto
        '
        Me.panelPhoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPhoto.Controls.Add(Me.btnDelPhoto)
        Me.panelPhoto.Controls.Add(Me.picPhoto)
        Me.panelPhoto.Controls.Add(Me.Button1)
        Me.panelPhoto.Controls.Add(Me.btnAddPhoto)
        Me.panelPhoto.Controls.Add(Me.Button2)
        Me.panelPhoto.Controls.Add(Me.lblPhotoHeader)
        Me.panelPhoto.Location = New System.Drawing.Point(547, 342)
        Me.panelPhoto.Name = "panelPhoto"
        Me.panelPhoto.Size = New System.Drawing.Size(375, 293)
        Me.panelPhoto.TabIndex = 23
        '
        'lblPhotoHeader
        '
        Me.lblPhotoHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblPhotoHeader.Location = New System.Drawing.Point(8, 5)
        Me.lblPhotoHeader.Name = "lblPhotoHeader"
        Me.lblPhotoHeader.Size = New System.Drawing.Size(353, 24)
        Me.lblPhotoHeader.TabIndex = 0
        Me.lblPhotoHeader.Text = "Фотографии (1 из 2)"
        Me.lblPhotoHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstMeasure
        '
        Me.lstMeasure.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lstMeasure.FullRowSelect = True
        Me.lstMeasure.GridLines = True
        Me.lstMeasure.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMeasure.HideSelection = False
        Me.lstMeasure.LabelWrap = False
        Me.lstMeasure.LargeImageList = Me.LargeImageList
        Me.lstMeasure.Location = New System.Drawing.Point(2, 48)
        Me.lstMeasure.MultiSelect = False
        Me.lstMeasure.Name = "lstMeasure"
        Me.lstMeasure.ShowItemToolTips = True
        Me.lstMeasure.Size = New System.Drawing.Size(184, 281)
        Me.lstMeasure.SmallImageList = Me.ImageList1
        Me.lstMeasure.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstMeasure.StateImageList = Me.ImageList1
        Me.lstMeasure.TabIndex = 24
        Me.lstMeasure.TileSize = New System.Drawing.Size(203, 64)
        Me.lstMeasure.UseCompatibleStateImageBehavior = False
        Me.lstMeasure.View = System.Windows.Forms.View.List
        '
        'LargeImageList
        '
        Me.LargeImageList.ImageStream = CType(resources.GetObject("LargeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LargeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.LargeImageList.Images.SetKeyName(0, "Accept-icon.png")
        Me.LargeImageList.Images.SetKeyName(1, "clock.png")
        Me.LargeImageList.Images.SetKeyName(2, "comment.png")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        Me.ImageList1.Images.SetKeyName(1, "clock_red.png")
        Me.ImageList1.Images.SetKeyName(2, "comment.png")
        '
        'lblValueType
        '
        Me.lblValueType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblValueType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblValueType.Location = New System.Drawing.Point(803, 183)
        Me.lblValueType.Name = "lblValueType"
        Me.lblValueType.Size = New System.Drawing.Size(107, 74)
        Me.lblValueType.TabIndex = 30
        '
        'lblComment
        '
        Me.lblComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblComment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblComment.Location = New System.Drawing.Point(192, 183)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(349, 146)
        Me.lblComment.TabIndex = 29
        Me.lblComment.Text = "Примечание"
        '
        'lblMax
        '
        Me.lblMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMax.Location = New System.Drawing.Point(848, 298)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(65, 31)
        Me.lblMax.TabIndex = 27
        Me.lblMax.Text = ">= 10"
        '
        'lblMin
        '
        Me.lblMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMin.Location = New System.Drawing.Point(844, 267)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(69, 31)
        Me.lblMin.TabIndex = 26
        Me.lblMin.Text = "5<="
        '
        'lblCheck
        '
        Me.lblCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblCheck.Location = New System.Drawing.Point(192, 102)
        Me.lblCheck.Name = "lblCheck"
        Me.lblCheck.Size = New System.Drawing.Size(349, 64)
        Me.lblCheck.TabIndex = 25
        Me.lblCheck.Text = "Работа механизма зажима поперечины"
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(-1, -2)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(49, 48)
        Me.CloseButton1.TabIndex = 18
        '
        'txtValue
        '
        Me.txtValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValue.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValue.InputMode = gPic.touchInput.iMode.Number
        Me.txtValue.InputValue = "NaN"
        Me.txtValue.Location = New System.Drawing.Point(547, 48)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(241, 296)
        Me.txtValue.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(794, 267)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Мин."
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(794, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Макс."
        '
        'lblSubsystem
        '
        Me.lblSubsystem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubsystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblSubsystem.ForeColor = System.Drawing.Color.Blue
        Me.lblSubsystem.Location = New System.Drawing.Point(192, 51)
        Me.lblSubsystem.Name = "lblSubsystem"
        Me.lblSubsystem.Size = New System.Drawing.Size(347, 43)
        Me.lblSubsystem.TabIndex = 35
        Me.lblSubsystem.Text = "Шпиндель"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button3.Image = Global.TOID.My.Resources.Resources.cancel
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(798, 113)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 53)
        Me.Button3.TabIndex = 36
        Me.Button3.Text = "Не проверен"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'picIMAGE
        '
        Me.picIMAGE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picIMAGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picIMAGE.Location = New System.Drawing.Point(4, 342)
        Me.picIMAGE.Name = "picIMAGE"
        Me.picIMAGE.Size = New System.Drawing.Size(181, 293)
        Me.picIMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIMAGE.TabIndex = 32
        Me.picIMAGE.TabStop = False
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdSave.Image = Global.TOID.My.Resources.Resources.accept
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSave.Location = New System.Drawing.Point(798, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(120, 53)
        Me.cmdSave.TabIndex = 28
        Me.cmdSave.Text = "Сохранить"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'btnDelPhoto
        '
        Me.btnDelPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDelPhoto.Image = Global.TOID.My.Resources.Resources.camera_delete
        Me.btnDelPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelPhoto.Location = New System.Drawing.Point(206, 33)
        Me.btnDelPhoto.Name = "btnDelPhoto"
        Me.btnDelPhoto.Size = New System.Drawing.Size(110, 35)
        Me.btnDelPhoto.TabIndex = 7
        Me.btnDelPhoto.Text = "Удалить"
        Me.btnDelPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelPhoto.UseVisualStyleBackColor = True
        '
        'picPhoto
        '
        Me.picPhoto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPhoto.Location = New System.Drawing.Point(8, 73)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(353, 208)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPhoto.TabIndex = 5
        Me.picPhoto.TabStop = False
        '
        'Button1
        '
        Me.Button1.Image = Global.TOID.My.Resources.Resources.resultset_next
        Me.Button1.Location = New System.Drawing.Point(322, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 39)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnAddPhoto
        '
        Me.btnAddPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnAddPhoto.Image = Global.TOID.My.Resources.Resources.camera_add
        Me.btnAddPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddPhoto.Location = New System.Drawing.Point(54, 32)
        Me.btnAddPhoto.Name = "btnAddPhoto"
        Me.btnAddPhoto.Size = New System.Drawing.Size(123, 36)
        Me.btnAddPhoto.TabIndex = 4
        Me.btnAddPhoto.Text = "Добавить"
        Me.btnAddPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddPhoto.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.TOID.My.Resources.Resources.resultset_previous
        Me.Button2.Location = New System.Drawing.Point(8, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 39)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnDelComment
        '
        Me.btnDelComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDelComment.Image = Global.TOID.My.Resources.Resources.comment_delete
        Me.btnDelComment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelComment.Location = New System.Drawing.Point(173, 33)
        Me.btnDelComment.Name = "btnDelComment"
        Me.btnDelComment.Size = New System.Drawing.Size(113, 34)
        Me.btnDelComment.TabIndex = 6
        Me.btnDelComment.Text = "Удалить"
        Me.btnDelComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelComment.UseVisualStyleBackColor = True
        '
        'btnCommentNext
        '
        Me.btnCommentNext.Image = Global.TOID.My.Resources.Resources.resultset_next
        Me.btnCommentNext.Location = New System.Drawing.Point(292, 28)
        Me.btnCommentNext.Name = "btnCommentNext"
        Me.btnCommentNext.Size = New System.Drawing.Size(40, 39)
        Me.btnCommentNext.TabIndex = 2
        Me.btnCommentNext.UseVisualStyleBackColor = True
        '
        'btnAddComment
        '
        Me.btnAddComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnAddComment.Image = Global.TOID.My.Resources.Resources.comment_add
        Me.btnAddComment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddComment.Location = New System.Drawing.Point(54, 33)
        Me.btnAddComment.Name = "btnAddComment"
        Me.btnAddComment.Size = New System.Drawing.Size(105, 34)
        Me.btnAddComment.TabIndex = 5
        Me.btnAddComment.Text = "Добавить"
        Me.btnAddComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddComment.UseVisualStyleBackColor = True
        '
        'btnCommentPrev
        '
        Me.btnCommentPrev.Image = Global.TOID.My.Resources.Resources.resultset_previous
        Me.btnCommentPrev.Location = New System.Drawing.Point(8, 28)
        Me.btnCommentPrev.Name = "btnCommentPrev"
        Me.btnCommentPrev.Size = New System.Drawing.Size(40, 39)
        Me.btnCommentPrev.TabIndex = 1
        Me.btnCommentPrev.UseVisualStyleBackColor = True
        '
        'frmSystemTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 640)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblSubsystem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picIMAGE)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.lblValueType)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblMax)
        Me.Controls.Add(Me.lblMin)
        Me.Controls.Add(Me.lblCheck)
        Me.Controls.Add(Me.lstMeasure)
        Me.Controls.Add(Me.panelPhoto)
        Me.Controls.Add(Me.panelInfo)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSystemTO"
        Me.Text = "frmSystemTO"
        Me.panelInfo.ResumeLayout(False)
        Me.panelInfo.PerformLayout()
        Me.panelPhoto.ResumeLayout(False)
        CType(Me.picIMAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents panelInfo As Panel
    Friend WithEvents panelPhoto As Panel
    Friend WithEvents lblCommentHeader As Label
    Friend WithEvents lblPhotoHeader As Label
    Friend WithEvents lstMeasure As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnCommentNext As Button
    Friend WithEvents btnCommentPrev As Button
    Friend WithEvents picPhoto As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnAddPhoto As Button
    Friend WithEvents txtComment As TextBox
    Friend WithEvents btnAddComment As Button
    Friend WithEvents LargeImageList As ImageList
    Friend WithEvents btnDelComment As Button
    Friend WithEvents btnDelPhoto As Button
    Friend WithEvents lblValueType As Label
    Friend WithEvents lblComment As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents lblMax As Label
    Friend WithEvents lblMin As Label
    Friend WithEvents lblCheck As Label
    Friend WithEvents txtValue As gPic.touchInput
    Friend WithEvents picIMAGE As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSubsystem As Label
    Friend WithEvents Button3 As Button
End Class
