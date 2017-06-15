Imports System.ComponentModel
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class frmAddPhoto
    Private myresizer As New LATIR2GuiManager.Resizer

    Public SysName As String
    Public SysID As Guid
    Public StName As String
    Public chk As totask.totask.to_taskchecks


    Private videoDevices As FilterInfoCollection
    Private videoDevice As VideoCaptureDevice

    Private deviceNames(2) As String

    Private Sub CloseButton1_Click(sender As Object, e As EventArgs) Handles CloseButton1.Click
        Try
            If VideoSourcePlayer.VideoSource IsNot Nothing Then
                VideoSourcePlayer.Stop()
                VideoSourcePlayer.VideoSource = Nothing
            End If


        Catch ex As Exception
        End Try

        Try
            If videoDevice IsNot Nothing Then
                videoDevice = Nothing
            End If
        Catch ex As Exception

        End Try

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAddPhoto_Load(sender As Object, e As EventArgs) Handles Me.Load
        myresizer = New LATIR2GuiManager.Resizer
        videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        If videoDevices.Count <> 0 Then
            Dim i As Integer
            i = 1
            For Each device As FilterInfo In videoDevices
                deviceNames(i) = device.Name
                i = i + 1
                If i > 2 Then
                    Exit For
                End If
            Next

        Else
            MsgBox("Видеокамеры не найдены")

            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If

        myresizer.FindAllControls(Me)
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        videoDevice = Nothing
        If videoDevices.Count > 1 Then
            videoDevice = New VideoCaptureDevice(videoDevices(1).MonikerString)
        End If

        If videoDevice IsNot Nothing Then
            Button1.Enabled = False
            Button2.Enabled = False

            Dim myVideoCapabilities As VideoCapabilities()
            myVideoCapabilities = videoDevice.VideoCapabilities()

            Dim maxCapIdx As Integer
            Dim curIdx As Integer
            Dim maxRes As Long
            maxCapIdx = -1
            maxRes = 0
            curIdx = -1
            For Each capabilty As VideoCapabilities In myVideoCapabilities
                curIdx += 1
                If maxRes < capabilty.FrameSize.Width * capabilty.FrameSize.Height Then
                    maxRes = capabilty.FrameSize.Width * capabilty.FrameSize.Height
                    maxCapIdx = curIdx
                End If
            Next

            If maxCapIdx >= 0 Then
                videoDevice.VideoResolution = myVideoCapabilities(maxCapIdx)
            End If

            VideoSourcePlayer.VideoSource = videoDevice
            VideoSourcePlayer.Start()
            cmdGetPhoto.Enabled = True
            cmdSave.Enabled = True
        End If
    End Sub

    Private Sub Disconnect()
        If VideoSourcePlayer.VideoSource IsNot Nothing Then
            VideoSourcePlayer.SignalToStop()
            VideoSourcePlayer.WaitForStop()
            VideoSourcePlayer.VideoSource = Nothing


        End If
    End Sub
    Private Sub frmAddPhoto_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Disconnect()
    End Sub


    Private bGetImage As Boolean = False
    Private SavedImage As Bitmap = Nothing
    Private Sub VideoSourcePlayer_NewFrame(sender As Object, ByRef image As Bitmap) Handles VideoSourcePlayer.NewFrame
        If bGetImage Then
            If SavedImage IsNot Nothing Then
                SavedImage.Dispose()
                SavedImage = Nothing
            End If

            SavedImage = image.Clone()
            picPhoto.Image = SavedImage
            bGetImage = False
        End If
    End Sub

    Private Sub cmdGetPhoto_Click(sender As Object, e As EventArgs) Handles cmdGetPhoto.Click
        bGetImage = True
        SavedImage = Nothing
    End Sub

    Private ti As toimg.toimg.Application
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If SavedImage IsNot Nothing Then
            bGetImage = False
            cmdGetPhoto.Enabled = False

            If ti Is Nothing Then
                ti = GetMyStore()
            End If

            If ti Is Nothing Then
                MsgBox("нет списка изображений в базе данных")
                Exit Sub
            End If

            Dim tPic As toimg.toimg.toimg_data

            Dim sPath As String
            sPath = GetMyStorePath()
            Dim sSrc As String
            sSrc = Guid.NewGuid.ToString().Replace("{", "").Replace("}", "") + ".jpg"
            Debug.Print(sPath & "\" & sSrc)


            Try
                SavedImage.Save(sPath & "\" & sSrc, Imaging.ImageFormat.Jpeg)

                tPic = ti.toimg_data.Add
                With tPic
                    .link2part = "tod_system"
                    .link2id = LATIR2.Utils.GUID2String(SysID)
                    .link1part = "to_taskchecks"
                    .link1id = LATIR2.Utils.GUID2String(chk.ID)
                    .filetype = "jpg"
                    .fname = sSrc
                    .oper = GetOper()
                    .Save()
                End With
            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try


            Try
                Disconnect()

            Catch ex As Exception
                Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
            End Try

            Try
                If videoDevice IsNot Nothing Then
                    videoDevice = Nothing
                End If
            Catch ex As Exception

            End Try


            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Сделайте снимок перед сохранением")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        videoDevice = Nothing
        If videoDevices.Count > 0 Then
            videoDevice = New VideoCaptureDevice(videoDevices(0).MonikerString)
        End If

        If videoDevice IsNot Nothing Then
            Button1.Enabled = False
            Button2.Enabled = False

            Dim myVideoCapabilities As VideoCapabilities()
            myVideoCapabilities = videoDevice.VideoCapabilities()

            Dim maxCapIdx As Integer
            Dim curIdx As Integer
            Dim maxRes As Long
            maxCapIdx = -1
            maxRes = 0
            curIdx = -1
            For Each capabilty As VideoCapabilities In myVideoCapabilities
                curIdx += 1
                If maxRes < capabilty.FrameSize.Width * capabilty.FrameSize.Height Then
                    maxRes = capabilty.FrameSize.Width * capabilty.FrameSize.Height
                    maxCapIdx = curIdx
                End If
            Next

            If maxCapIdx >= 0 Then
                videoDevice.VideoResolution = myVideoCapabilities(maxCapIdx)
            End If


            VideoSourcePlayer.VideoSource = videoDevice

                VideoSourcePlayer.Start()
                cmdGetPhoto.Enabled = True
                cmdSave.Enabled = True
            End If

    End Sub

    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myresizer.ResizeAllControls(Me)
    End Sub
End Class