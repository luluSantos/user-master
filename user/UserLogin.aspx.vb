Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class UserLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnSubmitLogin_Click(sender As Object, e As EventArgs) Handles btnSubmitLogin.Click

        Dim password As String = txtPassword.Text.Trim
        If Not String.IsNullOrEmpty(password) Then
            Dim sec As New clsEncryption
            password = sec.EncryptData(password)
        End If
        Dim _temp = AuthenticateUser(txtLoginID.Text.Trim, password)
        If _temp Then
            Response.Redirect("Dashboard.aspx")
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
        End If

    End Sub


    Private Function AuthenticateUser(ByVal LoginID As String, ByVal password As String) As Boolean

        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "SELECT USERID,NAME,EMAIL,DOB,PRIVILEGE,AREA,REFERRALID,REFERRALCODE,GENDER,ISACTIVE FROM mm_user_list WHERE LOGINID=@userLogin AND PWD=@userPwd AND ISACTIVE=1"
        Dim dt As New DataTable

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlCmd.Parameters.AddWithValue("@userLogin", LoginID)
                sqlCmd.Parameters.AddWithValue("@userPwd", password)
                sqlConn.Open()
                Dim sdr As New MySqlDataAdapter
                sdr.SelectCommand = sqlCmd
                sdr.Fill(dt)
                sqlConn.Close()
            End Using
            'MsgBox(dt.Rows.Count)
            If dt.Rows.Count = 0 Then
                Session("NAME") = ""
                Session("USERID") = ""
                Return False
            Else
                Session("NAME") = dt.Rows(0).Item("NAME")
                Session("USERID") = dt.Rows(0).Item("USERID")
                Return True
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

End Class