Imports MySql.Data.MySqlClient

Public Class UserNewPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnagSubmit_Click(sender As Object, e As EventArgs) Handles btnagSubmit.Click
        Dim result As Boolean = False
        Dim userid = Request.QueryString("userid").ToString
        Dim password As String = txtPassword.Text.Trim
        Dim sec As New clsEncryption
        password = sec.EncryptData(password)
        Dim _temp As Boolean = SetNewPassword(password, userid)
        result = _temp

        If result = True Then
            lblRegModalTitle.Text = "Success"
            lblRegModalMessage.Text = "New password setuped successfully"
        Else
            lblRegModalTitle.Text = "Failed"
            lblRegModalMessage.Text = "New password setuped failed"
        End If


        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
    End Sub

    Protected Function SetNewPassword(ByVal password As String, ByVal userid As String)

        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "UPDATE mm_user_list SET PWD=@newpwd,UPDATEDDATE=@updateddate WHERE USERID=@userid"

        Dim returnResult As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlConn.Open()
                sqlCmd.Parameters.AddWithValue("@newpwd", password)
                sqlCmd.Parameters.AddWithValue("@updateddate", DateTime.Now)
                sqlCmd.Parameters.AddWithValue("@userid", userid)
                returnResult = sqlCmd.ExecuteNonQuery()
                sqlConn.Close()
            End Using
            If returnResult = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
            sqlConn.Dispose()
        End Try
    End Function

End Class