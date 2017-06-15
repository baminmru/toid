Imports System.IO

Module MainModule
    Public Manager As LATIR2.Manager
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Public NFCReader As NFC = Nothing
    Public UserAsOper As toop.toop.to_oper
    Public myImgStore As toimg.toimg.Application
    Public RObj As tor.tor.Application
    Public fStart As frmStartup



    Public MyGlobalComments As List(Of SystemComment) = Nothing
    Public RegistedTags As List(Of SystemComment) = Nothing



    Public Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure
    Private Declare Function SetSystemTime Lib "kernel32" (ByRef lpSystemTime As SYSTEMTIME) As Boolean

    'Public Sub ChangeDate(NewDate As Date)

    '    Dim st As SYSTEMTIME

    '    st.wYear = NewDate.Year
    '    st.wMonth = NewDate.Month
    '    st.wDayOfWeek = NewDate.DayOfWeek
    '    st.wDay = NewDate.Day
    '    st.wHour = NewDate.Hour
    '    st.wMinute = NewDate.Minute
    '    st.wSecond = NewDate.Second
    '    st.wMilliseconds = NewDate.Millisecond

    '    'Set the new time...
    '    SetSystemTime(st)
    'End Sub

    Public Sub ClearOnLogOut()
        UserAsOper = Nothing
        RObj = Nothing
        myImgStore = Nothing
        Manager = Nothing
        GuiManager = Nothing
    End Sub


    Public Function GetOper() As toop.toop.to_oper
        If Manager Is Nothing Then
            ClearOnLogOut()
            Return Nothing
        End If
        If Not UserAsOper Is Nothing Then
            Return UserAsOper
        End If
        Dim dt As DataTable
        Dim id As String
        Dim op As toop.toop.Application
        If Manager.Connected Then
            dt = Manager.GetData("select distinct b2g(to_oper.instanceid) ID  from to_oper join users on to_oper.login =users.login join the_session on the_session.usersid =users.usersid where the_session.the_sessionid=" & Manager.ID2Const(Manager.Session.SessionID))

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)("ID")
                op = Manager.GetInstanceObject(New Guid(id))
                UserAsOper = op.to_oper.Item(1)
                Return UserAsOper
            End If
        End If

        Return Nothing
    End Function


    Public Function GetMyStorePath() As String
        Dim st As toimg.toimg.Application
        Dim idef As toimg.toimg.toimg_def
        st = GetMyStore()
        If Not st Is Nothing Then
            idef = st.toimg_def.Item(1)
            Return idef.imagestore
        Else
            Return ""
        End If
    End Function

    Public Function GetMyStore() As toimg.toimg.Application

        If Manager Is Nothing Then
            ClearOnLogOut()
            Return Nothing
        End If
        If Not myImgStore Is Nothing Then
            Return myImgStore
        End If
        Dim dt As DataTable
        Dim id As String
        Dim gid As Guid
        Dim idef As toimg.toimg.toimg_def
        If Manager.Connected Then
            dt = Manager.GetData("select distinct b2g(toimg_def.instanceid) ID  from toimg_def  where computername='" & Environment.MachineName.ToLower() & "'")



            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)("ID")
                myImgStore = Manager.GetInstanceObject(New Guid(id))
                Return myImgStore
            Else
                gid = Guid.NewGuid
                myImgStore = Manager.NewInstance(gid, "toimg", Environment.MachineName.ToLower())
                If myImgStore IsNot Nothing Then
                    idef = myImgStore.toimg_def.Add()
                    idef.computername = Environment.MachineName.ToLower()
                    Try
                        Directory.CreateDirectory("c:\IMGSTORE")
                    Catch ex As Exception
                        Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
                    End Try
                    idef.imagestore = "c:\IMGSTORE"
                    idef.sharedfolder = "\\" & Environment.MachineName.ToLower() & "\IMGSTORE"
                    idef.Save()
                    Return myImgStore
                End If


            End If
        End If

        Return Nothing
    End Function

    Public sitename As String
    Public username As String
    Public password As String



    Public Sub InitNFC()
        Log("Запуск процесса сбора меток")
        NFCReader = New NFC

    End Sub

    Public Sub Log(ByVal s As String)
        Dim sTemp As String
        sTemp = GetSetting("TOID", "CFG", "TEMPPATH", "c:\temp")
        Try
            File.AppendAllText(sTemp & "\log_" & DateTime.Now.ToString("yyyyMMdd") & ".txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & s & vbCrLf)
        Catch ex As Exception

        End Try
        Debug.Print(s)
        Application.DoEvents()
    End Sub



End Module
