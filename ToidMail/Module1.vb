
Imports Oracle.ManagedDataAccess.Client
Imports System.Data
Imports System.Net.Mail
Imports System.IO


Module Module1



    Private cm As CMConnector


    Sub Main()



        cm = New CMConnector()

        Send()


    End Sub

    Public Function Send() As Boolean

        Dim SmtpServer As SmtpClient = New SmtpClient()
        SmtpServer.Credentials = New System.Net.NetworkCredential(cm.smtp_usr, cm.smtp_pwd)
        SmtpServer.Port = Int32.Parse(cm.smtp_port)
        SmtpServer.Host = cm.smtp
        SmtpServer.EnableSsl = False
        Dim mail As MailMessage
        Dim dt As DataTable
        Dim dts As DataTable

        Dim i As Integer
        Dim j As Integer

        dts = cm.QuerySelect(" SELECT todate,INVN,tod_st.NAME,tod_factory.name zavod, tod_building.name ceh FROM to_scheditems JOIN tod_st  " +
                " ON to_scheditems.themachine= tod_st.tod_stid  " +
                " Join tod_building ON tod_st.thebuilding=tod_building.tod_buildingid  " +
                " JOIN tod_factory ON tod_building.thefactory=tod_factory.tod_factoryid  " +
                " where todate <= sysdate And oper Is NULL  " +
                " order BY todate ")
        If dts.Rows.Count > 0 Then



            dt = cm.QuerySelect("SELECT distinct email FROM users JOIN TO_OPER ON users.login=TO_OPER.LOGIN  WHERE EMAIL is NOT NULL ")
            If dt.Rows.Count > 0 Then

                For j = 0 To dt.Rows.Count - 1
                    mail = New MailMessage
                    mail.From = New MailAddress("toid@powerm.ru", "TOID", System.Text.Encoding.UTF8)
                    mail.To.Add(dt.Rows(j)("email").ToString)
                    ' Console.WriteLine(dt.Rows(j)("email").ToString)


                    Dim bdy As String
                    bdy = "<!DOCTYPE html><html lang=""en""><head>    <meta charset=""utf-8""></head><body>"
                    bdy = bdy + "<p>Следующие станки требуют технического осмотра:</p>" & vbCrLf
                    bdy = bdy + "<table border=""1"" >"
                    bdy = bdy + "<tr><th>Дата</th><th>Инв. №</th><th>Название</th><th>Завод</th><th>Цех</th></tr>" & vbCrLf

                    For i = 0 To dts.Rows.Count - 1
                        Dim d As Date
                        d = dts.Rows(i)("todate")
                        bdy = bdy + "<tr><td>" & d.ToString("dd/MM/yyyy") & "</td><td>" & dts.Rows(i)("INVN") & "</td><td>" & dts.Rows(i)("NAME") & "</td><td>" & dts.Rows(i)("ZAVOD") & "</td><td>" & dts.Rows(i)("CEH") & "</td></tr>" & vbCrLf

                    Next
                    bdy = bdy + "</table></body>"
                    mail.Subject = "Запланированые ТО (" & Date.Today.ToString("dd/MM/yyyy") & ")"
                    mail.Body = bdy
                    mail.IsBodyHtml = True
                    Try
                        'Console.WriteLine(bdy)
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                        mail.ReplyToList.Add("toid@powerm.ru")
                        SmtpServer.Send(mail)
                        '' Console.WriteLine(bdy)

                        File.WriteAllText(cm.LogPath & "\" & Date.Today.ToString("ddMMyyyy") & "_" & dt.Rows(j)("email").ToString & ".html", bdy)
                    Catch ex As Exception
                        File.WriteAllText(cm.LogPath & "\" & Date.Today.ToString("ddMMyyyy") & "_" & dt.Rows(j)("email").ToString & ".error", ex.Message)
                        'Console.WriteLine(ex.Message)
                        'Return False
                    End Try

                Next



            End If
        End If

        Return True
    End Function




End Module
