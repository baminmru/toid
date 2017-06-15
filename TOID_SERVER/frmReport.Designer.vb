<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.wb = New System.Windows.Forms.WebBrowser()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdBuildReport = New System.Windows.Forms.Button()
        Me.chkUseDates = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.pb = New System.Windows.Forms.ProgressBar()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'wb
        '
        Me.wb.AllowNavigation = False
        Me.wb.AllowWebBrowserDrop = False
        Me.wb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.wb.IsWebBrowserContextMenuEnabled = False
        Me.wb.Location = New System.Drawing.Point(20, 50)
        Me.wb.Margin = New System.Windows.Forms.Padding(4)
        Me.wb.MinimumSize = New System.Drawing.Size(27, 25)
        Me.wb.Name = "wb"
        Me.wb.ScrollBarsEnabled = False
        Me.wb.Size = New System.Drawing.Size(4000, 10000)
        Me.wb.TabIndex = 26
        Me.wb.WebBrowserShortcutsEnabled = False
        '
        'gv
        '
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Location = New System.Drawing.Point(540, 395)
        Me.gv.Name = "gv"
        Me.gv.RowTemplate.Height = 24
        Me.gv.Size = New System.Drawing.Size(240, 150)
        Me.gv.TabIndex = 30
        Me.gv.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmdBuildReport)
        Me.Panel1.Controls.Add(Me.chkUseDates)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.pb)
        Me.Panel1.Location = New System.Drawing.Point(1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1095, 88)
        Me.Panel1.TabIndex = 33
        '
        'cmdBuildReport
        '
        Me.cmdBuildReport.Location = New System.Drawing.Point(898, 11)
        Me.cmdBuildReport.Name = "cmdBuildReport"
        Me.cmdBuildReport.Size = New System.Drawing.Size(177, 47)
        Me.cmdBuildReport.TabIndex = 38
        Me.cmdBuildReport.Text = "Построить отчет"
        Me.cmdBuildReport.UseVisualStyleBackColor = True
        '
        'chkUseDates
        '
        Me.chkUseDates.AutoSize = True
        Me.chkUseDates.Checked = True
        Me.chkUseDates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkUseDates.Location = New System.Drawing.Point(19, 5)
        Me.chkUseDates.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUseDates.Name = "chkUseDates"
        Me.chkUseDates.Size = New System.Drawing.Size(87, 29)
        Me.chkUseDates.TabIndex = 37
        Me.chkUseDates.Text = "Даты"
        Me.chkUseDates.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(516, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 25)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "По:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(140, 5)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 25)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "C:"
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(611, 5)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(252, 30)
        Me.dtpTo.TabIndex = 34
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(189, 4)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(252, 30)
        Me.dtpFrom.TabIndex = 33
        '
        'pb
        '
        Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb.Location = New System.Drawing.Point(4, 46)
        Me.pb.Margin = New System.Windows.Forms.Padding(4)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(859, 25)
        Me.pb.TabIndex = 30
        Me.pb.Visible = False
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 82)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.wb)
        Me.Controls.Add(Me.gv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Сводка по станку"
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wb As WebBrowser
    Friend WithEvents Timer1 As Timer
    Friend WithEvents gv As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pb As ProgressBar
    Friend WithEvents chkUseDates As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents cmdBuildReport As Button
End Class
