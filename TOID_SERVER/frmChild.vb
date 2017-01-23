Public Class frmChild
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not Item Is Nothing Then
                Try
                    Item.UnLockResource()
                Catch
                End Try
            End If
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents pnlObj As System.Windows.Forms.Panel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlObj = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlObj
        '
        Me.pnlObj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlObj.Location = New System.Drawing.Point(0, 0)
        Me.pnlObj.Name = "pnlObj"
        Me.pnlObj.Size = New System.Drawing.Size(528, 325)
        Me.pnlObj.TabIndex = 1
        '
        'frmChild
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 325)
        Me.Controls.Add(Me.pnlObj)
        Me.MinimizeBox = False
        Me.Name = "frmChild"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private DataControl As LATIR2GuiManager.IViewPanel
    Private GuiManager As LATIR2GuiManager.LATIRGuiManager
    Public Item As LATIR2.Document.Doc_Base

    Public Sub AppendControl(ByVal uc As System.Windows.Forms.UserControl)
        Me.SuspendLayout()
        pnlObj.SuspendLayout()
        DataControl = uc
        uc.Location = New Point(0, 0)
        uc.Dock = DockStyle.Fill
        pnlObj.Controls.Add(DataControl)
        pnlObj.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal DOcItem As LATIR2.Document.Doc_Base)
        GuiManager = gm
        Me.Text = DOcItem.Name
        Item = DOcItem

        If Item.IsLocked = LATIR2.Session.LockStyle.ExternalLockPermanent Or Item.IsLocked = LATIR2.Session.LockStyle.ExternalLockSession Then
            CType(DataControl, LATIR2GuiManager.IViewPanel).Attach(DOcItem, gm, True)
        Else
            CType(DataControl, LATIR2GuiManager.IViewPanel).Attach(DOcItem, gm, False)
            Item.LockResource(False)
        End If






    End Sub



    Private Function CheckAndSave() As Boolean

        Dim iv As LATIR2GuiManager.IViewPanel
        iv = CType(DataControl, LATIR2GuiManager.IViewPanel)
        If iv.IsChanged() Then
            If iv.Verify(True) Then
                Return iv.Save(True, True)
            End If
            Return False
        End If
        Return False

    End Function

    Private Sub ctlStatus_BeforeChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid)
        Dim bst As LATIR2.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            bst.BeforeChangeState(DocItem, NewStateID)
        End If

    End Sub

    Private Sub ctlStatus_CheckFor(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid, ByRef OK As Boolean)
        Dim CanSwitch As Boolean

        CanSwitch = True 'RoleDocCanSwitchStatus(DocItem)
        If Not CanSwitch Then
            MsgBox("Для текущего документа не разрешена смена состояния", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Смена состояния")
            OK = False
            Exit Sub
        End If

        OK = True

        Dim bst As LATIR2.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            OK = bst.CheckFor(DocItem, NewStateID)
        End If
    End Sub

    Private Sub ctlStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmChild_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        CheckAndSave()

    End Sub

    Private Sub frmChild_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub
End Class
