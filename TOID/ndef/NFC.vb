
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.ServiceModel
Imports Windows.Networking.Proximity
Imports NdefLibrary.Ndef
Imports System.Text


Public Class NFC

    Public Event TagDetected(ByVal Info As String)
    Private proximityDevice As Windows.Networking.Proximity.ProximityDevice
    Private publishedMessageId As Long = -1
    Private subscribedMessageId As Long = -1

    Public Sub New()
        initializeProximityDevice()
    End Sub

    Private Sub initializeProximityDevice()
        proximityDevice = Windows.Networking.Proximity.ProximityDevice.GetDefault()

        If proximityDevice IsNot Nothing Then

            SubscribeForMessage()

        End If
    End Sub



#Region "NFC Publishing"

    Public Sub PublishLaunchApp(ByVal AppName As String)
        ' Create a new LaunchApp record to launch this app
        ' The app will print the arguments when it is launched (see MainPage.OnNavigatedTo() method)
        Dim record = New NdefLaunchAppRecord()
        record.Arguments = AppName

        ' WindowsPhone is the pre-defined platform ID for WP8.
        ' You can get the application ID from the WMAppManifest.xml file
        record.AddPlatformAppId("WindowsPhone", "{544ec154-b521-4d73-9405-963830adb213}")


        ' The app platform for a Windows 8 computer is Windows. 
        ' The format of the proximity app Id is <package family name>!<app Id>. 
        ' You can get the package family name from the Windows.ApplicationModel.Package.Current.Id.FamilyName property. 
        ' You must copy the app Id value from the Id attribute of the Application element in the 
        ' package manifest for your app.

        record.AddPlatformAppId("Windows", (Windows.ApplicationModel.Package.Current.Id.FamilyName + ("!" + "NdefDemoWin")))
        ' Publish the record using the proximity device
        Me.PublishRecord(record)
    End Sub

    Public Async Sub PublishImage(file As Windows.Storage.StorageFile)
        ' Load an image

        If (Not (file) Is Nothing) Then
            Dim record = Await NdefMimeImageRecord.CreateFromFile(file)
            ' Publish the record using the proximity device
            Me.PublishRecord(record)
        End If

    End Sub

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

    Public Sub PublishRecord(ByVal record As NdefRecord)
        If (proximityDevice Is Nothing) Then
            Return
        End If

        ' Make sure we're not already publishing another message
        StopPublishingMessage()
        ' Wrap the NDEF record into an NDEF message
        Dim message = New NdefMessage()
        message.Add(record)

        ' Convert the NDEF message to a byte array
        Dim msgArray = message.ToByteArray
        RaiseEvent TagDetected("Publish message size:" & msgArray.Length.ToString())
        ' Publish the NDEF message to a tag or to another device, depending on the writeToTag parameter
        ' Save the publication ID so that we can cancel publication later
        publishedMessageId = proximityDevice.PublishBinaryMessage("NDEF:WriteTag", msgArray.AsBuffer, AddressOf MessageWrittenHandler)

    End Sub


    Public Sub PublishMessage(ByVal message As NdefMessage)
        If (proximityDevice Is Nothing) Then
            Return
        End If

        ' Make sure we're not already publishing another message
        StopPublishingMessage()

        ' Convert the NDEF message to a byte array
        Dim msgArray = message.ToByteArray
        RaiseEvent TagDetected("Publish message size:" & msgArray.Length.ToString())


        ' Publish the NDEF message to a tag or to another device, depending on the writeToTag parameter
        ' Save the publication ID so that we can cancel publication later
        publishedMessageId = proximityDevice.PublishBinaryMessage("NDEF:WriteTag", msgArray.AsBuffer, AddressOf MessageWrittenHandler)

    End Sub

    Private Sub MessageWrittenHandler(ByVal sender As ProximityDevice, ByVal messageid As Long)

        StopPublishingMessage()

    End Sub

    'Private Function ParseTagContents(ByVal ndefMessage As NdefMessage, ByVal tagContents As StringBuilder) As Task
    '    ' Loop over all records contained in the NDEF message
    '    For Each record As NdefRecord In ndefMessage
    '        ' --------------------------------------------------------------------------
    '        ' Print generic information about the record
    '        If ((Not (record.Id) Is Nothing) _
    '                        AndAlso (record.Id.Length > 0)) Then
    '            ' Record ID (if present)
    '            tagContents.AppendFormat("Id: {0}" & vbLf, Encoding.UTF8.GetString(record.Id, 0, record.Id.Length))
    '        End If

    '        ' Record type name, as human readable string
    '        tagContents.AppendFormat("Type name: {0}" & vbLf, Me.ConvertTypeNameFormatToString(record.TypeNameFormat))
    '        ' Record type
    '        If ((Not (record.Type) Is Nothing) _
    '                        AndAlso (record.Type.Length > 0)) Then
    '            tagContents.AppendFormat("Record type: {0}" & vbLf, Encoding.UTF8.GetString(record.Type, 0, record.Type.Length))
    '        End If

    '        ' --------------------------------------------------------------------------
    '        ' Check the type of each record
    '        ' Using 'true' as parameter for CheckSpecializedType() also checks for sub-types of records,
    '        ' e.g., it will return the SMS record type if a URI record starts with "sms:"
    '        ' If using 'false', a URI record will always be returned as Uri record and its contents won't be further analyzed
    '        ' Currently recognized sub-types are: SMS, Mailto, Tel, Nokia Accessories, NearSpeak, WpSettings
    '        Dim specializedType = record.CheckSpecializedType(True)
    '        If (specializedType = GetType(NdefMailtoRecord)) Then
    '            ' --------------------------------------------------------------------------
    '            ' Convert and extract Mailto record info
    '            Dim mailtoRecord = New NdefMailtoRecord(record)
    '            tagContents.Append("-> Mailto record" & vbLf)
    '            tagContents.AppendFormat("Address: {0}" & vbLf, mailtoRecord.Address)
    '            tagContents.AppendFormat("Subject: {0}" & vbLf, mailtoRecord.Subject)
    '            tagContents.AppendFormat("Body: {0}" & vbLf, mailtoRecord.Body)
    '        ElseIf (specializedType = GetType(NdefUriRecord)) Then
    '            ' --------------------------------------------------------------------------
    '            ' Convert and extract URI record info
    '            Dim uriRecord = New NdefUriRecord(record)
    '            tagContents.Append("-> URI record" & vbLf)
    '            tagContents.AppendFormat("URI: {0}" & vbLf, uriRecord.Uri)
    '        ElseIf (specializedType = GetType(NdefSpRecord)) Then
    '            ' --------------------------------------------------------------------------
    '            ' Convert and extract Smart Poster info
    '            Dim spRecord = New NdefSpRecord(record)
    '            tagContents.Append("-> Smart Poster record" & vbLf)
    '            tagContents.AppendFormat("URI: {0}", spRecord.Uri)
    '            tagContents.AppendFormat("Titles: {0}", spRecord.TitleCount)
    '            If (spRecord.TitleCount > 1) Then
    '                tagContents.AppendFormat("1. Title: {0}", spRecord.Titles(0).Text)
    '            End If

    '            tagContents.AppendFormat("Action set: {0}", spRecord.ActionInUse)
    '            ' You can also check the action (if in use by the record), 
    '            ' mime type and size of the linked content.
    '        ElseIf (specializedType = GetType(NdefVcardRecordBase)) Then
    '            ' --------------------------------------------------------------------------
    '            ' Convert and extract business card info
    '            Dim vcardRecord = New NdefVcardRecordBase(record)
    '            tagContents.Append(("-> Business Card record" + Environment.NewLine))
    '            'Dim contact = vcardRecord.ContactData
    '            '' Contact has phone or email info set? Use contact manager to show the contact card
    '            'If (contact.Emails.Any OrElse contact.Phones.Any) Then
    '            '    Dim rect = Me.GetElementRect(StatusOutput)
    '            '    ContactManager.ShowContactCard(contact, rect, Placement.Below)
    '            'Else
    '            '    ' No phone or email set - contact manager would not show the contact card.
    '            '    ' -> parse manually
    '            '    tagContents.AppendFormat("Name: {0}" & vbLf, contact.DisplayName)
    '            '    tagContents.Append("[not parsing other values in the demo app]")
    '            'End If


    '        ElseIf (specializedType = GetType(NdefIcalendarRecordBase)) Then


    '        ElseIf (specializedType = GetType(NdefLaunchAppRecord)) Then
    '            ' --------------------------------------------------------------------------
    '            ' Convert and extract LaunchApp record info
    '            Dim launchAppRecord = New NdefLaunchAppRecord(record)
    '            tagContents.Append(("-> LaunchApp record" + Environment.NewLine))
    '            If Not String.IsNullOrEmpty(launchAppRecord.Arguments) Then
    '                tagContents.AppendFormat("Arguments: {0}" & vbLf, launchAppRecord.Arguments)
    '            End If

    '            If (Not (launchAppRecord.PlatformIds) Is Nothing) Then
    '                For Each platformIdTuple In launchAppRecord.PlatformIds
    '                    If (Not (platformIdTuple.Key) Is Nothing) Then
    '                        tagContents.AppendFormat("Platform: {0}" & vbLf, platformIdTuple.Key)
    '                    End If

    '                    If (Not (platformIdTuple.Value) Is Nothing) Then
    '                        tagContents.AppendFormat("App ID: {0}" & vbLf, platformIdTuple.Value)
    '                    End If

    '                Next
    '            End If

    '        ElseIf (specializedType = GetType(NdefMimeImageRecordBase)) Then
    '            ' --------------------------------------------------------------------------
    '            ' Convert and extract Image record info
    '            Dim imgRecord = New NdefMimeImageRecord(record)
    '            tagContents.Append(("-> MIME / Image record" + Environment.NewLine))
    '            'Me._dispatcher.RunAsync(CoreDispatcherPriority.Normal, () >= {}, Me.SetStatusImage(Await imgRecord.GetImageAsBitmap))
    '        Else
    '            ' Other type, not handled by this demo
    '            tagContents.Append(("NDEF record not parsed by this demo app" + Environment.NewLine))
    '        End If

    '    Next
    'End Function


#End Region

#Region "Reading"

    Private Sub SubscribeForMessage()
        ' Only subscribe for the message one time.
        If Not proximityDevice Is Nothing Then
            If subscribedMessageId = -1 Then
                subscribedMessageId = proximityDevice.SubscribeForMessage("NDEF", AddressOf MessageReceived)
            End If
        End If

    End Sub

    Private tagContents As StringBuilder = Nothing
    Public Function GetLastTagInfo() As String
        If tagContents Is Nothing Then Return ""
        Return tagContents.ToString()
    End Function

    Private Sub MessageReceived(ByVal sender As ProximityDevice, ByVal message As ProximityMessage)
        ' Get the raw NDEF message data as byte array
        Dim rawMsg = message.Data.ToArray
        ' Let the NDEF library parse the NDEF message out of the raw byte array
        Dim ndefMessage As NdefMessage = NdefMessage.FromByteArray(rawMsg)
        ' Analysis result
        tagContents = New StringBuilder
        ' Loop over all records contained in the NDEF message
        For Each record As NdefRecord In ndefMessage
            ' --------------------------------------------------------------------------
            ' Print generic information about the record
            If ((Not (record.Id) Is Nothing) _
                            AndAlso (record.Id.Length > 0)) Then
                ' Record ID (if present)
                tagContents.AppendFormat("Id: {0}" & vbCrLf, Encoding.UTF8.GetString(record.Id, 0, record.Id.Length))
            End If

            ' Record type name, as human readable string
            tagContents.AppendFormat("Type name: {0} " & vbCrLf, Me.ConvertTypeNameFormatToString(record.TypeNameFormat))
            ' Record type
            If ((Not (record.Type) Is Nothing) _
                            AndAlso (record.Type.Length > 0)) Then
                tagContents.AppendFormat("Record type: {0}" & vbCrLf, Encoding.UTF8.GetString(record.Type, 0, record.Type.Length))
            End If
            'If Not (record.Payload Is Nothing) AndAlso record.Payload.Length > 0 Then
            '    tagContents.AppendFormat("Record payload[0]={0}" & vbCrLf, record.Payload(0).ToString())
            '    tagContents.AppendFormat("Record payload: {0}" & vbCrLf, Encoding.UTF8.GetString(record.Payload, 0, record.Payload.Length))
            'End If

            ' --------------------------------------------------------------------------
            ' Check the type of each record
            ' Using 'true' as parameter for CheckSpecializedType() also checks for sub-types of records,
            ' e.g., it will return the SMS record type if a URI record starts with "sms:"
            ' If using 'false', a URI record will always be returned as Uri record and its contents won't be further analyzed
            ' Currently recognized sub-types are: SMS, Mailto, Tel, Nokia Accessories, NearSpeak, WpSettings
            Dim specializedType = record.CheckSpecializedType(True)
            If (specializedType = GetType(NdefMailtoRecord)) Then
                ' --------------------------------------------------------------------------
                ' Convert and extract Mailto record info
                Dim mailtoRecord As NdefMailtoRecord = New NdefMailtoRecord(record)
                tagContents.Append("-> Mailto record" & vbCrLf)
                tagContents.AppendFormat("Address: {0}" & vbCrLf, mailtoRecord.Address)
                tagContents.AppendFormat("Subject: {0}" & vbCrLf, mailtoRecord.Subject)
                tagContents.AppendFormat("Body: {0}" & vbCrLf, mailtoRecord.Body)
            ElseIf (specializedType = GetType(NdefTextRecord)) Then
                ' --------------------------------------------------------------------------
                ' Convert and extract Text record info
                Dim textRecord As NdefTextRecord = New NdefTextRecord(record)
                tagContents.Append("-> Text record" & vbCrLf)
                tagContents.AppendFormat("Encoding: {0}" & vbCrLf, textRecord.TextEncoding.ToString())
                tagContents.AppendFormat("LangCode: {0}" & vbCrLf, textRecord.LanguageCode)
                tagContents.AppendFormat("Text: {0}" & vbCrLf, textRecord.Text)
            ElseIf (specializedType = GetType(NdefTelRecord)) Then
                ' --------------------------------------------------------------------------
                ' Convert and extract Tel record info
                Dim telRecord As NdefTelRecord = New NdefTelRecord(record)
                tagContents.Append("-> Telephone record" & vbCrLf)
                tagContents.AppendFormat("Phone: {0}" & vbCrLf, telRecord.TelNumber)
                tagContents.AppendFormat("Uri: {0}" & vbCrLf, telRecord.Uri)
                tagContents.AppendFormat("TitleCount: {0}" & vbCrLf, telRecord.TitleCount.ToString())
                Dim i As Integer
                For i = 0 To telRecord.TitleCount - 1
                    tagContents.AppendFormat("Title{0}: {1}" & vbCrLf, i.ToString(), telRecord.Title(i).Text)
                Next
            ElseIf (specializedType = GetType(NdefUriRecord)) Then
                ' --------------------------------------------------------------------------
                ' Convert and extract URI record info
                Dim uriRecord As NdefUriRecord = New NdefUriRecord(record)
                tagContents.Append("-> URI record" & vbCrLf)
                tagContents.AppendFormat("URI: {0}" & vbCrLf, uriRecord.Uri)
            ElseIf (specializedType = GetType(NdefLaunchAppRecord)) Then
                ' --------------------------------------------------------------------------
                ' Convert and extract LaunchApp record info
                Dim launchAppRecord As NdefLaunchAppRecord = New NdefLaunchAppRecord(record)
                tagContents.Append(("-> LaunchApp record" + Environment.NewLine))
                If Not String.IsNullOrEmpty(launchAppRecord.Arguments) Then
                    tagContents.AppendFormat("Arguments: {0}" & vbCrLf, launchAppRecord.Arguments)
                End If

                If (Not (launchAppRecord.PlatformIds) Is Nothing) Then
                    For Each platformIdTuple In launchAppRecord.PlatformIds
                        If (Not (platformIdTuple.Key) Is Nothing) Then
                            tagContents.AppendFormat("Platform: {0}" & vbCrLf, platformIdTuple.Key)
                        End If

                        If (Not (platformIdTuple.Value) Is Nothing) Then
                            tagContents.AppendFormat("App ID: {0}" & vbCrLf, platformIdTuple.Value)
                        End If

                    Next
                End If

            ElseIf (specializedType = GetType(NdefVcardRecordBase)) Then
                ' --------------------------------------------------------------------------
                '' Convert and extract business card info
                Dim vcardRecord As NdefLibrary.Ndef.NdefVcardRecordBase = New NdefVcardRecordBase(record)
                tagContents.Append(("-> Business Card record" + Environment.NewLine))

                If Not (vcardRecord.Type Is Nothing) AndAlso vcardRecord.Type.Length > 0 Then
                    tagContents.AppendFormat("VCARD type: {0}" & vbCrLf, Encoding.UTF8.GetString(vcardRecord.Type, 0, vcardRecord.Type.Length))
                End If

                If Not (vcardRecord.Payload Is Nothing) AndAlso vcardRecord.Payload.Length > 0 Then
                    tagContents.AppendFormat("VCARD payload: {0}" & vbCrLf, Encoding.UTF8.GetString(vcardRecord.Payload, 0, vcardRecord.Payload.Length))
                End If

                'Dim contact = vcardRecord.Payload  .ContactData
                '    Dim contactInfo = Await contact.GetPropertiesAsync
                '    For Each curProperty In contactInfo.OrderBy(() >= {}, i.Key)
                '        tagContents.Append(String.Format(("{0}: {1}" + Environment.NewLine), curProperty.Key, curProperty.Value))
                '    Next

            Else
                ' Other type, not handled by this demo
                tagContents.Append((" NDEF record not parsed by this demo app" + Environment.NewLine))
            End If

        Next
        RaiseEvent TagDetected(tagContents.ToString())

        SubscribeForMessage()
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

    Private Sub StopSubscribingForMessage()
        If Not proximityDevice Is Nothing Then
            proximityDevice.StopSubscribingForMessage(subscribedMessageId)
        End If
        subscribedMessageId = -1
    End Sub

    Private Sub StopPublishingMessage()
        If Not proximityDevice Is Nothing Then
            proximityDevice.StopPublishingMessage(publishedMessageId)
        End If
        publishedMessageId = -1
    End Sub

    Public Sub CloseDevice()
        If publishedMessageId <> -1 Then StopPublishingMessage()
        If subscribedMessageId <> -1 Then StopSubscribingForMessage()
    End Sub

    Protected Overrides Sub Finalize()

        CloseDevice()
        proximityDevice = Nothing
    End Sub



End Class
