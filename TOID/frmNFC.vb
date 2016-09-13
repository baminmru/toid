Imports NdefLibrary.Ndef


Public Class frmNFC
    Private WithEvents NFCReader As NFC = Nothing

    Private sTag As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
    End Sub

    Private Sub frmNFC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NFCReader = New NFC
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not NFCReader Is Nothing Then
            txtLog.Text = sTag
        End If
    End Sub

    Private Sub TagDetected(ByVal s As String) Handles NFCReader.TagDetected
        sTag = s
    End Sub

    Private Sub frmNFC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not NFCReader Is Nothing Then
            NFCReader.CloseDevice()
            NFCReader = Nothing
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not NFCReader Is Nothing And txtMessage.Text <> "" Then
            NFCReader.PublishText(txtMessage.Text)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Not NFCReader Is Nothing Then
            Dim message As NdefMessage

            message = New NdefMessage()


            ' Create a Tel record
            'Dim precord = New NdefTelRecord()
            'precord.TelNumber = DateTime.Now.Ticks.ToString()


            ' Create a Tel title record
            'Dim record As NdefTextRecord
            'record = New NdefTextRecord()
            'record.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
            'record.LanguageCode = "ru"
            'record.Text = "Типа мой телефон"

            'precord.AddTitle(record)

            'Dim record2 As NdefTextRecord
            'record2 = New NdefTextRecord()
            'record2.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
            'record2.LanguageCode = "en"
            'record2.Text = "Master.Bami"

            'precord.AddTitle(record2)

            'message.Add(precord)

            'Dim urecord As NdefUriRecord
            'urecord = New NdefUriRecord()
            'urecord.Uri = "http://abolsoft.ru?T=" & DateTime.Now.Ticks.ToString()
            'message.Add(urecord)

            Dim trecord As NdefTextRecord
            trecord = New NdefTextRecord()
            trecord.LanguageCode = "en"
            trecord.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
            trecord.Text = "Text: " & DateTime.Now.Ticks.ToString()
            message.Add(trecord)

            Dim trecord2 As NdefTextRecord
            trecord2 = New NdefTextRecord()
            trecord2.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
            trecord2.LanguageCode = "ru"
            trecord2.Text = "Текст: " & DateTime.Now.Ticks.ToString()
            message.Add(trecord2)

            trecord = New NdefTextRecord()
            trecord.LanguageCode = "en"
            trecord.TextEncoding = NdefTextRecord.TextEncodingType.Utf8
            trecord.Text = "Text2: " & DateTime.Now.Ticks.ToString()
            message.Add(trecord)
            NFCReader.PublishMessage(message)
        End If


    End Sub
End Class