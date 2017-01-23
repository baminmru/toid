Imports NdefLibrary.Ndef


Public Class frmNFC


    Private sTag As String
    Private myresizer As New LATIR2GuiManager.Resizer
    Private WithEvents mynfc As NFC
    Private HasTag As Boolean

    Private Sub lblText_Click(sender As Object, e As EventArgs) Handles lblText.Click
        Me.StartPosition = FormStartPosition.Manual
        Me.WindowState = FormWindowState.Normal
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub frmNFC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myresizer = New LATIR2GuiManager.Resizer
        If RegistedTags Is Nothing Then
            RegistedTags = New List(Of SystemComment)
        End If



        InitNFC()
        If Not NFCReader Is Nothing Then
            If NFCReader.HasNFC Then
                mynfc = NFCReader
                Timer1.Enabled = True
            End If
        End If
        Try

            Dim dt As DataTable = Nothing
            dt = Manager.GetData("SELECT DISTINCT to_cardinfo_the_machine_id id , to_cardinfo_the_machine name FROM v_autoTO_CARDINFO WHERE to_cardinfo_card_archived_val=0 order by to_cardinfo_the_machine")
            cmbMachine.DataSource = dt
            cmbMachine.DisplayMember = "name"
            cmbMachine.ValueMember = "id"
            cmbMachine_SelectedIndexChanged(Me, Nothing)

        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
        myresizer.FindAllControls(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub



    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged
        If cmbMachine.SelectedValue Is Nothing Then Exit Sub
        Try
            Dim dt2 As DataTable
            dt2 = Manager.GetData("SELECT DISTINCT tc.TO_CARDCHECKS_THE_SYSTEM_ID ID,tc.TO_CARDCHECKS_THE_SYSTEM NAME FROM v_autoTO_CARDCHECKS tc JOIN v_autoTO_CARDINFO ti ON tc.instanceid=ti.instanceid WHERE to_cardinfo_card_archived_val=0 AND  to_cardinfo_the_machine_id='" & cmbMachine.SelectedValue.ToString & "' order by TO_CARDCHECKS_THE_SYSTEM")

            cmbUzel.DataSource = dt2
            cmbUzel.DisplayMember = "name"
            cmbUzel.ValueMember = "id"
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Private Sub cmbUzel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUzel.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = Manager.GetData("SELECT distinct thesubsystem name FROM TO_CARDCHECKS JOIN TO_CARDINFO  ON  TO_CARDCHECKS.instanceid=TO_CARDINFO.instanceid  WHERE TO_CARDINFO.THE_MACHINE=" + Manager.ID2Const(New Guid(cmbMachine.SelectedValue.ToString)) + " AND TO_CARDCHECKS.THE_SYSTEM=" + Manager.ID2Const(New Guid(cmbUzel.SelectedValue.ToString())))
            If dt.Rows.Count > 0 Then
                Dim i As Integer
                Dim s As String = ""
                For i = 0 To dt.Rows.Count - 1
                    If s <> "" Then
                        s = s & vbCrLf
                    End If
                    s = s & dt.Rows(i)("name")
                Next
                If s <> "" Then
                    txtSubsystems.Text = s
                End If
            End If
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try
    End Sub

    Dim TAGS As List(Of TOIDTAG)

    Private inTimer As Boolean = False
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If inTimer Then Exit Sub
        inTimer = True
        If HasTag Then
            HasTag = False

            If Not NFCReader Is Nothing Then
                Try
                    Dim cnt As Integer
                    cnt = NFCReader.GetLastTagInfoCount()

                    If cnt > 0 Then
                        TAGS = NFCReader.GetLastTagInfo()
                        Dim i As Integer
                        txtLog.Text = ""
                        For i = 0 To cnt - 1
                            With TAGS(i)
                                txtLog.Text += "Метка: " & .ID.ToString & vbCrLf ' & " Part:" & .Part & vbCrLf & " Data:" & .Data & vbCrLf
                                Log("Метка " & .ID.ToString)
                                Application.DoEvents()
                                If Not .ID.Equals(Guid.Empty) And .Part = "TOID" Then
                                    Dim dt As DataTable
                                    Dim ii As Integer
                                    If Manager.Provider.ProviderType = LATIR2.DBProvider.DBProviderType.MYSQL Then
                                        dt = Manager.GetData("select c.id,s.to_cardinfo_the_machine,c.to_cardchecks_the_system  from v_autoto_cardchecks c join v_autoto_cardinfo s on  s.instanceid=c.instanceid where concat(s.to_cardinfo_the_machine_id,'|',c.to_cardchecks_the_system_id) ='" & .Data & "' ")
                                    ElseIf Manager.Provider.ProviderType = LATIR2.DBProvider.DBProviderType.ORACLE Then
                                        dt = Manager.GetData("select c.id,s.to_cardinfo_the_machine,c.to_cardchecks_the_system  from v_autoto_cardchecks c join v_autoto_cardinfo s on  s.instanceid=c.instanceid where (s.to_cardinfo_the_machine_id || '|' || c.to_cardchecks_the_system_id) ='" & .Data.ToUpper & "' ")
                                    Else
                                        dt = New DataTable
                                    End If

                                    If dt.Rows.Count > 0 Then
                                        txtLog.Text += "Регистрируем для:" & vbCrLf
                                    End If
                                    Dim cid As Guid
                                    Dim sc As SystemComment
                                    For ii = 0 To dt.Rows.Count - 1
                                        cid = New Guid(dt.Rows(ii)("id").ToString())
                                        If ii = 0 Then
                                            txtLog.Text += dt.Rows(ii)("to_cardinfo_the_machine").ToString() & "->" & dt.Rows(ii)("to_cardchecks_the_system").ToString() & vbCrLf
                                        End If

                                        Manager.GetData("update to_cardchecks set changestamp =" & Manager.Provider.DateFunc() & ", tagid='" & LATIR2.Utils.GUID2String(.ID) & "' where to_cardchecksid=" & Manager.ID2Const(cid))

                                        '--------------
                                        sc = New SystemComment
                                        sc.SystemID = cid
                                        sc.Comment = .ID.ToString
                                        SyncLock RegistedTags
                                            RegistedTags.Add(sc)
                                        End SyncLock

                                    Next
                                End If


                            End With



                        Next
                        NFCReader.ClearLastTagInfo()
                        HasTag = False
                        TAGS.Clear()
                    End If
                Catch ex As Exception
                    Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                End Try



            End If
        End If
        inTimer = False
    End Sub





    Private Sub cmdWriteID_Click(sender As Object, e As EventArgs) Handles cmdWriteID.Click

        If Not NFCReader Is Nothing Then
            If cmbMachine.SelectedValue IsNot Nothing And cmbUzel.SelectedValue IsNot Nothing Then
                Dim s As String
                s = cmbMachine.SelectedValue & "|" & cmbUzel.SelectedValue
                NFCReader.PublishRaw(Guid.NewGuid(), "TOID", s)
            End If
        End If
    End Sub


    Private Sub CloseButton1_Click_1(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Me.Close()
    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub

    Private Sub frmNFC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
        mynfc = Nothing
        If NFCReader IsNot Nothing Then
            Log("Завершение сбора меток. Форма разметки.")
            NFCReader.CloseDevice()
            NFCReader = Nothing
        End If
    End Sub

    Private Sub mynfc_TagDetected() Handles mynfc.TagDetected
        HasTag = True
    End Sub
End Class