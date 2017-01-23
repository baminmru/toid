Imports System.Collections.Generic
Imports Windows.Networking.Proximity
Imports Windows.Storage.Streams
Imports NdefLibrary.Ndef
Imports System.Text

Public Class TOIDTAG
    Public ID As Guid
    Public Part As String
    Public Data As String

    Public Sub New()

    End Sub
    Public Sub New(ByVal _ID As Guid, ByVal _Part As String, Optional ByVal _Data As String = "")
        ID = _ID
        Part = _Part
        Data = _Data
    End Sub

    Public Sub New(ByVal record As NdefRecord)
        If ((Not (record.Id) Is Nothing) _
                          AndAlso (record.Id.Length > 0)) Then
            ' Record ID (if present)

            Try
                Dim g As Guid
                g = New Guid(record.Id)
                ID = g
            Catch ex As Exception
                ID = Guid.Empty
            End Try

        End If

        If ((Not (record.Type) Is Nothing) _
                           AndAlso (record.Type.Length > 0)) Then
            Part = Encoding.UTF8.GetString(record.Type, 0, record.Type.Length)
        End If

        If ((Not (record.Payload) Is Nothing) _
                           AndAlso (record.Payload.Length > 0)) Then
            Data = Encoding.UTF8.GetString(record.Payload, 0, record.Payload.Length)
        End If

    End Sub
End Class

Public Class NFC

    Public Event TagDetected()

    Private WithEvents myDevice As Windows.Networking.Proximity.ProximityDevice = Nothing
    Private publishedMessageId As Long = 0
    Private subscribedMessageId As Long = 0
    Private LastTag As List(Of TOIDTAG)
    Private EmulatorTag As List(Of TOIDTAG) = Nothing

    'Public Sub New(Emulation As List(Of TOIDTAG))
    '    EmulatorTag = Emulation
    'End Sub

    Public Sub New()
        initializeProximityDevice()
    End Sub

    Private Sub myDevice_DeviceArrived(sender As ProximityDevice)
        SubscribeForMessage(myDevice)
    End Sub

    Private Sub myDevice_DeviceDeparted(sender As ProximityDevice)
        StopSubscribingForMessage(myDevice)
    End Sub


    Private Sub initializeProximityDevice()
        Try
            myDevice = Windows.Networking.Proximity.ProximityDevice.GetDefault()
        Catch ex As Exception
            myDevice = Nothing
            Log("NFC create device: " + ex.Message)
        End Try

        If Not myDevice Is Nothing Then
            AddHandler myDevice.DeviceArrived, AddressOf myDevice_DeviceArrived
            AddHandler myDevice.DeviceDeparted, AddressOf myDevice_DeviceDeparted
        End If
    End Sub

    Public Function HasNFC() As Boolean
        If myDevice Is Nothing Then Return False
        Return True
    End Function








#Region "NFC Publishing"



    Public Sub PublishMailTo(ByVal Addr As String, ByVal Subj As String, ByVal Body As String)
        ' Create a new mailto record, set the relevant properties for the email
        Dim record = New NdefMailtoRecord()
        record.Address = Addr
        record.Subject = Subj
        record.Body = Body
        ' Publish the record using the proximity device
        Me.PublishRecord(record)
    End Sub

    Public Sub PublishUri(ByVal Uri As String)
        ' Create a URI record
        Dim record = New NdefUriRecord()
        record.Uri = Uri

        ' Publish the record using the proximity device
        Me.PublishRecord(record)
    End Sub

    Public Sub PublishText(ByVal Text As String)
        ' Create a URI record
        Dim record = New NdefTextRecord()
        record.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
        record.Text = Text

        ' Publish the record using the proximity device
        Me.PublishRecord(record)
    End Sub

    Public Sub PublishTel(ByVal Title As String, ByVal Phone As String)
        ' Create a Tel title record
        Dim record = New NdefTextRecord()
        record.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
        record.Text = Title

        ' Create a Tel record
        Dim precord = New NdefTelRecord()
        precord.TelNumber = Phone
        precord.Titles.Add(record)


        ' Publish the record using the proximity device
        Me.PublishRecord(precord)
    End Sub

    Public Sub PublishTag(Tag As TOIDTAG)
        PublishRaw(Tag.ID, Tag.Part, Tag.Data)
    End Sub

    Public Sub PublishRaw(ByVal Id As Guid, ByVal TypeName As String, ByVal TagPayload As String)
        If HasNFC() Then
            Dim record = New NdefRecord(NdefRecord.TypeNameFormatType.ExternalRtd, System.Text.Encoding.UTF8.GetBytes(TypeName))
            If Not Id.Equals(Guid.Empty) Then
                record.Id = Id.ToByteArray
            End If
            If TagPayload <> "" Then
                record.Payload = System.Text.Encoding.UTF8.GetBytes(TagPayload)
            End If
            Me.PublishRecord(record)
        End If

    End Sub

    Public Sub PublishRecord(ByVal record As NdefRecord)
        If (myDevice Is Nothing) Then
            Return
        End If

        ' Make sure we're not already publishing another message
        StopPublishingMessage()
        ' Wrap the NDEF record into an NDEF message
        Dim message = New NdefMessage()
        message.Add(record)

        ' Convert the NDEF message to a byte array
        Dim msgArray = message.ToByteArray
        'AddInfo("Publish message size:" & msgArray.Length.ToString())
        '' Publish the NDEF message to a tag or to another device, depending on the writeToTag parameter
        ' Save the publication ID so that we can cancel publication later

        Dim writer As DataWriter
        writer = New DataWriter
        writer.WriteBytes(msgArray)

        publishedMessageId = myDevice.PublishBinaryMessage("NDEF:WriteTag", writer.DetachBuffer(), AddressOf MessageWrittenHandler)

    End Sub


    Public Sub PublishMessage(ByVal message As NdefMessage)
        If (myDevice Is Nothing) Then
            Return
        End If

        ' Make sure we're not already publishing another message
        StopPublishingMessage()

        ' Convert the NDEF message to a byte array
        Dim msgArray = message.ToByteArray
        'AddInfo("Publish message size:" & msgArray.Length.ToString())
        Dim writer As DataWriter
        writer = New DataWriter
        writer.WriteBytes(msgArray)

        ' Publish the NDEF message to a tag or to another device, depending on the writeToTag parameter
        ' Save the publication ID so that we can cancel publication later
        publishedMessageId = myDevice.PublishBinaryMessage("NDEF:WriteTag", writer.DetachBuffer(), AddressOf MessageWrittenHandler)

    End Sub

    Private Sub MessageWrittenHandler(ByVal sender As ProximityDevice, ByVal messageid As Long)

        StopPublishingMessage()

    End Sub




#End Region

#Region "Reading"

    Private Sub SubscribeForMessage(sender As ProximityDevice)
        If Not sender Is Nothing Then
            If subscribedMessageId = 0 Then
                subscribedMessageId = sender.SubscribeForMessage("NDEF", AddressOf MessageReceivedHandler)
                '  AddInfo(String.Format("Subscribe To NDEF message {0}" & vbCrLf, subscribedMessageId.ToString()))
            End If
        End If
    End Sub




    Public Function GetLastTagInfoCount() As Integer

        If LastTag Is Nothing Then Return 0
        Return LastTag.Count
    End Function

    Public Function GetLastTagInfo() As List(Of TOIDTAG)
        If LastTag Is Nothing Then Return Nothing
        Dim ll As List(Of TOIDTAG)
        ll = New List(Of TOIDTAG)
        SyncLock LastTag
            ll.AddRange(LastTag)
        End SyncLock
        Return ll
    End Function


    Public Sub ClearLastTagInfo()
        SyncLock LastTag
            LastTag.Clear()
        End SyncLock
    End Sub


    Private Sub MessageReceivedHandler(ByVal sender As ProximityDevice, ByVal message As ProximityMessage)
        If LastTag Is Nothing Then
            LastTag = New List(Of TOIDTAG)
        End If


        Dim mTAG As TOIDTAG

        Dim rawMsg() As Byte

        ReDim rawMsg(message.Data.Length - 1)
        Try
            Dim reader As DataReader = DataReader.FromBuffer(message.Data)
            reader.ReadBytes(rawMsg)
        Catch ex As Exception
            Log(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.Source)
        End Try

        Dim ndefMessage As NdefMessage = NdefMessage.FromByteArray(rawMsg)

        ' Loop over all records contained in the NDEF message
        For Each record As NdefRecord In ndefMessage

            mTAG = New TOIDTAG(record)
            SyncLock LastTag
                LastTag.Add(mTAG)
            End SyncLock


            RaiseEvent TagDetected()
            Log("NDEF:" & mTAG.ID.ToString())
        Next

    End Sub



    Private Function ConvertTypeNameFormatToString(ByVal tnf As NdefRecord.TypeNameFormatType) As String
        ' Each record contains a type name format, which defines which format
        ' the type name is actually in.
        ' This method converts the constant to a human-readable string.
        Dim tnfString As String
        Select Case (tnf)
            Case NdefRecord.TypeNameFormatType.Empty
                tnfString = "Empty NDEF record (does not contain a payload)"
            Case NdefRecord.TypeNameFormatType.NfcRtd
                tnfString = "NFC RTD Specification"
            Case NdefRecord.TypeNameFormatType.Mime
                tnfString = "RFC 2046 (Mime)"
            Case NdefRecord.TypeNameFormatType.Uri
                tnfString = "RFC 3986 (Url)"
            Case NdefRecord.TypeNameFormatType.ExternalRtd
                tnfString = "External type name"
            Case NdefRecord.TypeNameFormatType.Unknown
                tnfString = "Unknown record type; should be treated similar to content with MIME type 'application/octet-stream' w" &
                    "ithout further context"
            Case NdefRecord.TypeNameFormatType.Unchanged
                tnfString = "Unchanged (partial record)"
            Case NdefRecord.TypeNameFormatType.Reserved
                tnfString = "Reserved"
            Case Else
                tnfString = "Unknown." + tnf.ToString()
        End Select

        Return tnfString
    End Function
#End Region

    Private Sub StopSubscribingForMessage(sender As ProximityDevice)
        If Not sender Is Nothing Then
            If subscribedMessageId <> 0 Then
                sender.StopSubscribingForMessage(subscribedMessageId)
                'AddInfo("Unsubscribe")
            End If
        End If
        subscribedMessageId = 0
    End Sub

    Private Sub StopPublishingMessage()
        If Not myDevice Is Nothing Then
            myDevice.StopPublishingMessage(publishedMessageId)
        End If
        publishedMessageId = 0
    End Sub

    Public Sub CloseDevice()

        If publishedMessageId <> 0 Or subscribedMessageId <> 0 Then Log("Остановка процесса сбора меток")
        If publishedMessageId <> 0 Then StopPublishingMessage()
        If subscribedMessageId <> 0 Then StopSubscribingForMessage(myDevice)

    End Sub

    Protected Overrides Sub Finalize()
        CloseDevice()
        myDevice = Nothing
    End Sub

End Class
