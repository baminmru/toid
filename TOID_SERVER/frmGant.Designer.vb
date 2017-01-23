<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGant))
        Me.Chart1 = New Braincase.GanttChart.Chart()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSched = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCard = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.cmdAddAll = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mnuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.FullDateStringFormat = Nothing
        Me.Chart1.Location = New System.Drawing.Point(9, 89)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(878, 326)
        Me.Chart1.TabIndex = 0
        '
        'mnuContext
        '
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSched, Me.mnuCard})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(224, 48)
        Me.mnuContext.Text = "Открыть пункт расписания"
        '
        'mnuSched
        '
        Me.mnuSched.Name = "mnuSched"
        Me.mnuSched.Size = New System.Drawing.Size(223, 22)
        Me.mnuSched.Text = "Открыть пункт расписания"
        '
        'mnuCard
        '
        Me.mnuCard.Name = "mnuCard"
        Me.mnuCard.Size = New System.Drawing.Size(223, 22)
        Me.mnuCard.Text = "Открыть  карточку задачи"
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnCopy.Image = Global.TOIDADMIN.My.Resources.Resources.copy
        Me.btnCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCopy.Location = New System.Drawing.Point(186, 10)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(168, 63)
        Me.btnCopy.TabIndex = 4
        Me.btnCopy.Text = "Скопировать..."
        Me.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnCopy, "Добавить станки")
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'cmdAddAll
        '
        Me.cmdAddAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdAddAll.Image = Global.TOIDADMIN.My.Resources.Resources.add1
        Me.cmdAddAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdAddAll.Location = New System.Drawing.Point(12, 10)
        Me.cmdAddAll.Name = "cmdAddAll"
        Me.cmdAddAll.Size = New System.Drawing.Size(168, 63)
        Me.cmdAddAll.TabIndex = 1
        Me.cmdAddAll.Text = "Добавить станки"
        Me.cmdAddAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdAddAll, "Добавить станки")
        Me.cmdAddAll.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdPrint.Image = Global.TOIDADMIN.My.Resources.Resources.Print
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPrint.Location = New System.Drawing.Point(739, 12)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(135, 63)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "Печать"
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdRefresh.Image = Global.TOIDADMIN.My.Resources.Resources.refresh
        Me.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdRefresh.Location = New System.Drawing.Point(605, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(128, 63)
        Me.cmdRefresh.TabIndex = 2
        Me.cmdRefresh.Text = "Обновить"
        Me.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(402, 15)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(190, 26)
        Me.dtpFrom.TabIndex = 5
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(401, 47)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(190, 26)
        Me.dtpTo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(367, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "C:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(367, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "По:"
        '
        'frmGant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 417)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdAddAll)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "frmGant"
        Me.Text = "Расписание ТО"
        Me.mnuContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As Braincase.GanttChart.Chart
    Friend WithEvents mnuContext As ContextMenuStrip
    Friend WithEvents mnuSched As ToolStripMenuItem
    Friend WithEvents mnuCard As ToolStripMenuItem
    Friend WithEvents cmdAddAll As Button
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmdPrint As Button
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents btnCopy As Button
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
