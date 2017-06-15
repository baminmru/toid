<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNFC
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtLog = New LATIR2GuiManager.TouchTextBox()
        Me.CloseButton1 = New LATIR2GuiManager.CloseButton()
        Me.lblText = New System.Windows.Forms.Label()
        Me.cmbUzel = New System.Windows.Forms.ListBox()
        Me.cmbMachine = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdWriteID = New System.Windows.Forms.Button()
        Me.txtSubsystems = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkNoWrites = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtLog.Location = New System.Drawing.Point(24, 414)
        Me.txtLog.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(1128, 141)
        Me.txtLog.TabIndex = 2
        '
        'CloseButton1
        '
        Me.CloseButton1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseButton1.Location = New System.Drawing.Point(0, -1)
        Me.CloseButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CloseButton1.Name = "CloseButton1"
        Me.CloseButton1.Size = New System.Drawing.Size(64, 59)
        Me.CloseButton1.TabIndex = 18
        '
        'lblText
        '
        Me.lblText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblText.Location = New System.Drawing.Point(0, -1)
        Me.lblText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(1177, 59)
        Me.lblText.TabIndex = 19
        Me.lblText.Text = "Инициализация меток"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbUzel
        '
        Me.cmbUzel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUzel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbUzel.FormattingEnabled = True
        Me.cmbUzel.ItemHeight = 25
        Me.cmbUzel.Location = New System.Drawing.Point(604, 92)
        Me.cmbUzel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbUzel.Name = "cmbUzel"
        Me.cmbUzel.Size = New System.Drawing.Size(548, 129)
        Me.cmbUzel.TabIndex = 23
        '
        'cmbMachine
        '
        Me.cmbMachine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbMachine.FormattingEnabled = True
        Me.cmbMachine.ItemHeight = 25
        Me.cmbMachine.Location = New System.Drawing.Point(24, 92)
        Me.cmbMachine.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbMachine.Name = "cmbMachine"
        Me.cmbMachine.Size = New System.Drawing.Size(571, 129)
        Me.cmbMachine.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Image = Global.TOID.My.Resources.Resources.box
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(599, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 25)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Группа узлов"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Image = Global.TOID.My.Resources.Resources.bricks
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(25, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 25)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Станок"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdWriteID
        '
        Me.cmdWriteID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdWriteID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdWriteID.Image = Global.TOID.My.Resources.Resources.tag_blue
        Me.cmdWriteID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdWriteID.Location = New System.Drawing.Point(278, 357)
        Me.cmdWriteID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdWriteID.Name = "cmdWriteID"
        Me.cmdWriteID.Size = New System.Drawing.Size(875, 49)
        Me.cmdWriteID.TabIndex = 6
        Me.cmdWriteID.Text = "Записать метку для сочетания Станок+Группа Узлов"
        Me.cmdWriteID.UseVisualStyleBackColor = True
        '
        'txtSubsystems
        '
        Me.txtSubsystems.Location = New System.Drawing.Point(103, 257)
        Me.txtSubsystems.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSubsystems.Multiline = True
        Me.txtSubsystems.Name = "txtSubsystems"
        Me.txtSubsystems.ReadOnly = True
        Me.txtSubsystems.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSubsystems.Size = New System.Drawing.Size(1044, 94)
        Me.txtSubsystems.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 257)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 25)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Узлы:"
        '
        'chkNoWrites
        '
        Me.chkNoWrites.AutoSize = True
        Me.chkNoWrites.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkNoWrites.Location = New System.Drawing.Point(30, 376)
        Me.chkNoWrites.Name = "chkNoWrites"
        Me.chkNoWrites.Size = New System.Drawing.Size(190, 29)
        Me.chkNoWrites.TabIndex = 26
        Me.chkNoWrites.Text = "Только проверка"
        Me.chkNoWrites.UseVisualStyleBackColor = True
        '
        'frmNFC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 571)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkNoWrites)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSubsystems)
        Me.Controls.Add(Me.cmbUzel)
        Me.Controls.Add(Me.cmbMachine)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CloseButton1)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.cmdWriteID)
        Me.Controls.Add(Me.txtLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNFC"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "NFC тест"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtLog As LATIR2GuiManager.TouchTextBox
    Friend WithEvents cmdWriteID As Button
    Friend WithEvents CloseButton1 As LATIR2GuiManager.CloseButton
    Friend WithEvents lblText As Label
    Friend WithEvents cmbUzel As ListBox
    Friend WithEvents cmbMachine As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSubsystems As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkNoWrites As CheckBox
End Class
