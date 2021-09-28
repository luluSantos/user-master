Imports MySql.Data.MySqlClient

Public Class password_recovery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Function getUserID(ByVal email As String, ByRef AgentID As Integer)
        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "SELECT ID FROM mm_user_list WHERE EMAIL=@email AND ISACTIVE=1"
        Dim dt As New DataTable

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlCmd.Parameters.AddWithValue("@email", email)
                sqlConn.Open()
                Dim sdr As New MySqlDataAdapter
                AgentID = sqlCmd.ExecuteScalar()
                sqlConn.Close()
            End Using

            If AgentID > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
            sqlConn.Dispose()
        End Try

    End Function

    Private Sub btnagSubmit_Click(sender As Object, e As EventArgs) Handles btnagSubmit.Click
        Dim receipient = txtemail.Text.TrimEnd
        Dim agentId As Integer = 0
        Dim GetagentId = getUserID(receipient, agentId)

        If GetagentId Then
            Dim result As Boolean = False
            Dim subject = "Request to change new password"
            Dim strsender = "abc@email.com"

            Dim strMessage = "<p>Please click the link below to setup new password.</p><br/>"
            strMessage += "<a href='https://localhost:44393/UserNewPassword?agentid=" + agentId + "'>Click Here</a>"

            Dim _temp As Boolean = SendMailSMTPAUTH(subject, strsender, receipient, strMessage)
            result = _temp

            If result = True Then
                lblRegModalTitle.Text = "Success"
                lblRegModalMessage.Text = "Email has been sent. Please check your inbox"
            Else
                lblRegModalTitle.Text = "Error"
                lblRegModalMessage.Text = "Error sending email."
            End If
        Else
            lblRegModalTitle.Text = "Failed"
            lblRegModalMessage.Text = "Send email failed. Invalid emaill address."
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
    End Sub

    Protected Function SendMailSMTPAUTH(strSubject As String, strSender As String, strRecipient As String, strMessage As String) As Boolean
        Try
            Dim mail As New Net.Mail.MailMessage()
            mail.IsBodyHtml = True
            mail.From = New Net.Mail.MailAddress(strSender)
            mail.To.Add(strRecipient)

            mail.Subject = strSubject
            mail.Body = strMessage

            Dim smtp As New Net.Mail.SmtpClient("smtp.gmail.com")
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New Net.NetworkCredential("mhartanah6@gmail.com", "pqlamz1234")

            smtp.Port = 587
            smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            smtp.EnableSsl = True
            smtp.Timeout = 2 * 60 * 1000

            smtp.Send(mail)
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


End Class