<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.opf = New System.Windows.Forms.OpenFileDialog()
        Me.cmdFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.txtERR = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'opf
        '
        Me.opf.Filter = "Excel |*.xlsx"
        '
        'cmdFile
        '
        Me.cmdFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFile.Location = New System.Drawing.Point(528, 28)
        Me.cmdFile.Name = "cmdFile"
        Me.cmdFile.Size = New System.Drawing.Size(74, 28)
        Me.cmdFile.TabIndex = 0
        Me.cmdFile.Text = "..."
        Me.cmdFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Файл для загрузки"
        '
        'txtFile
        '
        Me.txtFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFile.Location = New System.Drawing.Point(10, 33)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(512, 20)
        Me.txtFile.TabIndex = 2
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(10, 74)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(586, 123)
        Me.txtLog.TabIndex = 3
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Location = New System.Drawing.Point(13, 217)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(203, 59)
        Me.cmdLoad.TabIndex = 4
        Me.cmdLoad.Text = "Загрузить карты"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'txtERR
        '
        Me.txtERR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtERR.Location = New System.Drawing.Point(267, 206)
        Me.txtERR.Multiline = True
        Me.txtERR.Name = "txtERR"
        Me.txtERR.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtERR.Size = New System.Drawing.Size(334, 69)
        Me.txtERR.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 279)
        Me.Controls.Add(Me.txtERR)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFile)
        Me.Name = "Form1"
        Me.Text = "ТОиД. Загрузка диагностических карт."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents opf As OpenFileDialog
    Friend WithEvents cmdFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFile As TextBox
    Friend WithEvents txtLog As TextBox
    Friend WithEvents cmdLoad As Button
    Friend WithEvents txtERR As TextBox
End Class
