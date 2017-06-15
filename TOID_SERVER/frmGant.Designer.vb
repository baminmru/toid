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
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSched = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCard = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chart1 = New Braincase.GanttChart.Chart()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdAddAll = New System.Windows.Forms.Button()
        Me.mnuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuContext
        '
        Me.mnuContext.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSched, Me.mnuCard})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(325, 64)
        Me.mnuContext.Text = "Открыть пункт расписания"
        '
        'mnuSched
        '
        Me.mnuSched.Name = "mnuSched"
        Me.mnuSched.Size = New System.Drawing.Size(324, 30)
        Me.mnuSched.Text = "Открыть пункт расписания"
        '
        'mnuCard
        '
        Me.mnuCard.Name = "mnuCard"
        Me.mnuCard.Size = New System.Drawing.Size(324, 30)
        Me.mnuCard.Text = "Открыть  карточку задачи"
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
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(536, 18)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(252, 30)
        Me.dtpFrom.TabIndex = 5
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(535, 58)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(252, 30)
        Me.dtpTo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(489, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "C:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(489, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "По:"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.FullDateStringFormat = Nothing
        Me.Chart1.Location = New System.Drawing.Point(0, 110)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1408, 394)
        Me.Chart1.TabIndex = 10
        '
        'cmdReport
        '
        Me.cmdReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdReport.Image = Global.TOIDADMIN.My.Resources.Resources.export_icon_29_1
        Me.cmdReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdReport.Location = New System.Drawing.Point(1173, 14)
        Me.cmdReport.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(180, 79)
        Me.cmdReport.TabIndex = 9
        Me.cmdReport.Text = "Отчет"
        Me.cmdReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnCopy.Image = Global.TOIDADMIN.My.Resources.Resources.copy
        Me.btnCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCopy.Location = New System.Drawing.Point(248, 12)
        Me.btnCopy.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(224, 78)
        Me.btnCopy.TabIndex = 4
        Me.btnCopy.Text = "Скопировать..."
        Me.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnCopy, "Добавить станки")
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdPrint.Image = Global.TOIDADMIN.My.Resources.Resources.Print
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPrint.Location = New System.Drawing.Point(985, 15)
        Me.cmdPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(180, 78)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "Печать"
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdRefresh.Image = Global.TOIDADMIN.My.Resources.Resources.refresh_48
        Me.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdRefresh.Location = New System.Drawing.Point(807, 12)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(171, 78)
        Me.cmdRefresh.TabIndex = 2
        Me.cmdRefresh.Text = "Обновить"
        Me.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdAddAll
        '
        Me.cmdAddAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdAddAll.Image = Global.TOIDADMIN.My.Resources.Resources.add1
        Me.cmdAddAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdAddAll.Location = New System.Drawing.Point(16, 12)
        Me.cmdAddAll.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAddAll.Name = "cmdAddAll"
        Me.cmdAddAll.Size = New System.Drawing.Size(224, 78)
        Me.cmdAddAll.TabIndex = 1
        Me.cmdAddAll.Text = "Добавить станки"
        Me.cmdAddAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdAddAll, "Добавить станки")
        Me.cmdAddAll.UseVisualStyleBackColor = True
        '
        'frmGant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1433, 513)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdAddAll)
        Me.Controls.Add(Me.Chart1)
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents cmdReport As Button
End Class
