<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddComment
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
        Me.lstStd = New System.Windows.Forms.ListBox()
        Me.txtMy = New LATIR2GuiManager.TouchTextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.chkAddToDict = New System.Windows.Forms.CheckBox()
        Me.cmdToMy = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(-1, -3)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(48, 48)
        Me.CloseButton1.TabIndex = 21
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(1, -3)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(804, 48)
        Me.lblText.TabIndex = 22
        Me.lblText.Text = "Комментарийк отчету"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstStd
        '
        Me.lstStd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstStd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lstStd.FormattingEnabled = True
        Me.lstStd.ItemHeight = 24
        Me.lstStd.Location = New System.Drawing.Point(7, 55)
        Me.lstStd.Name = "lstStd"
        Me.lstStd.Size = New System.Drawing.Size(294, 364)
        Me.lstStd.TabIndex = 23
        '
        'txtMy
        '
        Me.txtMy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMy.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtMy.Location = New System.Drawing.Point(380, 98)
        Me.txtMy.Multiline = True
        Me.txtMy.Name = "txtMy"
        Me.txtMy.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMy.Size = New System.Drawing.Size(413, 218)
        Me.txtMy.TabIndex = 24
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdAdd.Image = Global.TOID.My.Resources.Resources.comment_add
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdAdd.Location = New System.Drawing.Point(380, 322)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(412, 114)
        Me.cmdAdd.TabIndex = 25
        Me.cmdAdd.Text = "Добавить комментарий"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'chkAddToDict
        '
        Me.chkAddToDict.AutoSize = True
        Me.chkAddToDict.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkAddToDict.Location = New System.Drawing.Point(380, 55)
        Me.chkAddToDict.Name = "chkAddToDict"
        Me.chkAddToDict.Size = New System.Drawing.Size(386, 24)
        Me.chkAddToDict.TabIndex = 26
        Me.chkAddToDict.Text = "Добавить  в справочник стандартных проблем"
        Me.chkAddToDict.UseVisualStyleBackColor = True
        '
        'cmdToMy
        '
        Me.cmdToMy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdToMy.Location = New System.Drawing.Point(307, 181)
        Me.cmdToMy.Name = "cmdToMy"
        Me.cmdToMy.Size = New System.Drawing.Size(60, 85)
        Me.cmdToMy.TabIndex = 27
        Me.cmdToMy.Text = ">>"
        Me.cmdToMy.UseVisualStyleBackColor = True
        '
        'frmAddComment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 448)
        Me.Controls.Add(Me.cmdToMy)
        Me.Controls.Add(Me.chkAddToDict)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtMy)
        Me.Controls.Add(Me.lstStd)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAddComment"
        Me.Text = "frmAddComment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents lstStd As ListBox
    Friend WithEvents txtMy As LATIR2GuiManager.TouchTextBox
    Friend WithEvents cmdAdd As Button
    Friend WithEvents chkAddToDict As CheckBox
    Friend WithEvents cmdToMy As Button
End Class
