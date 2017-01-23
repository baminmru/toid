Module MainModule
    Public Manager As LATIR2.Manager
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Dim UserAsOper As toop.toop.to_oper



    Public fOper As frmJournalView
    Public fCard As frmJournalView
    Public fTask As frmJournalView
    Public fSched As frmJournalView
    Public fTOd As frmChild
    Public fGnt As frmGant
    Public fChrt As frmChart
    Public fUsr As frmChild
    Public fPicU As frmImageTool
    Public fPicST As frmImageToolST
    Public DocMode As String = ""



    Public Function GetOper() As toop.toop.to_oper

        If Not UserAsOper Is Nothing Then
            Return UserAsOper
        End If
        Dim dt As DataTable
        Dim id As String
        Dim op As toop.toop.Application
        dt = Manager.Session.GetData("select distinct " & Manager.Base2ID("to_oper.instanceid", "id") & "  from to_oper join users on to_oper.login =users.login join the_session on the_session.usersid =users.usersid where the_session.the_sessionid=" & Manager.ID2Const(Manager.Session.SessionID))

        If dt.Rows.Count > 0 Then
            id = dt.Rows(0)("ID")
            op = Manager.GetInstanceObject(New Guid(id))
            UserAsOper = op.to_oper.Item(1)
            Dim role As tod.tod.tod_oprole
            role = UserAsOper.therole
            If role IsNot Nothing Then
                If role.name = "Администратор" Then
                    DocMode = "adm"
                Else
                    DocMode = ""
                End If
                'Else
                '    DocMode = "adm"
            End If


            Return UserAsOper
        End If
        Return Nothing
    End Function


    Public sitename As String
    Public username As String
    Public Function DoLogon() As Boolean
        Manager = New LATIR2.Manager
        GuiManager = New LATIR2GuiManager.LATIRGuiManager
        GuiManager.Attach(Manager)


        username = GetSetting("TOID", "SETTING", "UID", "")
        sitename = GetSetting("TOID", "SETTING", "SITE", "")
        If Not GuiManager.Login(username, sitename) Then
            End
        End If
        SaveSetting("TOID", "SETTING", "UID", username)
        SaveSetting("TOID", "SETTING", "SITE", sitename)
        Return True
    End Function


    Public Function BuildNewTask(ByRef ServerManager As LATIR2.Manager, ByVal ShedID As String) As totask.totask.Application



        Dim dt As DataTable
        Dim dtcard As DataTable
        dt = ServerManager.GetData("select * from v_autoto_scheditems where id='" & LATIR2.Utils.GUID2String(New Guid(ShedID)) & "'")
        If dt.Rows.Count = 1 Then

            Dim tsched As tosched.tosched.Application
            Dim tsi As tosched.tosched.to_scheditems
            tsched = ServerManager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString()))
            tsi = tsched.FindObject("to_scheditems", LATIR2.Utils.GUID2String(New Guid(ShedID)))
            If Not tsi Is Nothing Then

                Dim nid As Guid
                Dim tsk As totask.totask.Application
                Dim tcard As tocard.tocard.Application

                If Not tsi.oper Is Nothing Then
                    dtcard = ServerManager.GetData("select instanceid from v_autoto_taskinfo where to_taskinfo_themachine_id='" & dt.Rows(0)("id") & "'")
                    If dtcard.Rows.Count > 0 Then
                        tsk = ServerManager.GetInstanceObject(New Guid(dtcard.Rows(0)("instanceid").ToString()))
                        'If tsk.to_taskinfo.Item(1).oper Is GetOper() Then

                        Return tsk
                        'Else
                        'MsgBox("Задача закреплена за другим оператором")
                        'End If

                    End If

                    Return Nothing
                End If

                tsi.oper = GetOper()

                tsi.checkin = DateTime.Now
                tsi.Save()


                nid = Guid.NewGuid
                tsk = ServerManager.NewInstance(nid, "totask", dt.Rows(0)("to_scheditems_themachine").ToString)
                If Not tsk Is Nothing Then

                    Dim mid As String
                    mid = dt.Rows(0)("to_scheditems_themachine_id")

                    dtcard = ServerManager.GetData("select instanceid from v_autoto_cardinfo where to_cardinfo_the_machine_id='" & mid & "' and to_cardinfo_card_archived_val=0")
                    If dtcard.Rows.Count >= 0 Then
                        tcard = ServerManager.GetInstanceObject(New Guid(dtcard.Rows(0)("instanceid").ToString()))

                        If Not tcard Is Nothing Then
                            Dim ti As totask.totask.to_taskinfo
                            ti = tsk.to_taskinfo.Add()
                            ti.theMachine = tsi
                            ti.theCard = tcard.to_cardinfo.Item(1)
                            ti.crDate = Date.Now
                            ti.taskFinished = totask.totask.enumBoolean.Boolean_Net
                            ti.oper = GetOper()
                            ti.Save()

                            Dim i As Integer
                            Dim tchk As totask.totask.to_taskchecks
                            'Dim cardcheck As tocard.tocard.to_cardchecks
                            For i = 1 To tcard.to_cardchecks.Count

                                tchk = tsk.to_taskchecks.Add()
                                tchk.checkref = tcard.to_cardchecks.Item(i)
                                tchk.the_check = tcard.to_cardchecks.Item(i).the_check
                                tchk.the_system = tcard.to_cardchecks.Item(i).the_system
                                ' tchk.thesubsystem = tcard.to_cardchecks.Item(i).thesubsystem
                                tchk.ValueType = tcard.to_cardchecks.Item(i).ValueType
                                tchk.lowvalue = tcard.to_cardchecks.Item(i).lowvalue
                                tchk.hivalue = tcard.to_cardchecks.Item(i).hivalue
                                tchk.the_comment = tcard.to_cardchecks.Item(i).the_comment
                                tchk.the_doc = tcard.to_cardchecks.Item(i).the_doc
                                tchk.Save()


                            Next


                            Return tsk

                        End If
                    End If

                End If

            End If
        End If
        Return Nothing
    End Function

End Module
