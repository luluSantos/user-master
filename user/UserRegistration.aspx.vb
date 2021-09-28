Imports MySql.Data.MySqlClient

Public Class UserRegistration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnagSubmit_Click(sender As Object, e As EventArgs) Handles btnagSubmit.Click
        Dim emailCheck As Boolean = CheckEmailExists(txtemail.Text.Trim)
        Dim result As Boolean = False
        If Not emailCheck Then
            Dim password As String = txtPassword.Text.Trim
            Dim sec As New clsEncryption
            password = sec.EncryptData(password)
            Dim _temp As Boolean = RegisterUser(txtName.Text.Trim, txtemail.Text.Trim, txtdob.Text.Trim, txtloginid.Text.Trim, txtarea.Text.Trim, password, ddlGender.SelectedValue)
            result = _temp
        Else
            lblRegModalTitle.Text = "Registration Error"
            lblRegModalMessage.Text = "Email already registered."
            Session("RS") = 1
        End If

        If result = True Then
            lblRegModalTitle.Text = "Registration Successful"
            lblRegModalMessage.Text = "Please check your email for verification."
            Session("RS") = 0
        End If


        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
    End Sub

    Private Function RegisterUser(ByVal username As String, ByVal useremail As String, ByVal userdob As String, ByVal userloginid As String, ByVal userarea As String, ByVal userpwd As String, ByVal usergender As String) As Boolean
        Dim refid As Integer
        Dim refcode As String = ""
        generateRefCode(refid, refcode)
        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "INSERT INTO mm_user_list(NAME,EMAIL,DOB,LOGINID,PRIVILEGE,AREA,PWD,REFERRALID,REFERRALCODE,GENDER,ISACTIVE,CREATEDDATE,UPDATEDDATE) "
        sqlQuery += "VALUES (@username,@useremail,@userdob,@userloginid,@userpriv,@userarea,@userpwd,@userrefid,@userrefcode,@usergender,@isactive,@createddate,@updateddate)"

        Dim returnResult As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlCmd.Parameters.AddWithValue("@username", username)
                sqlCmd.Parameters.AddWithValue("@useremail", useremail)
                sqlCmd.Parameters.AddWithValue("@userdob", userdob)
                sqlCmd.Parameters.AddWithValue("@userloginid", userloginid)
                sqlCmd.Parameters.AddWithValue("@userpriv", 0)
                sqlCmd.Parameters.AddWithValue("@userarea", userarea)
                sqlCmd.Parameters.AddWithValue("@userpwd", userpwd)
                sqlCmd.Parameters.AddWithValue("@userrefid", refid)
                sqlCmd.Parameters.AddWithValue("@userrefcode", refcode)
                sqlCmd.Parameters.AddWithValue("@usergender", usergender)
                sqlCmd.Parameters.AddWithValue("@isactive", 1)
                sqlCmd.Parameters.AddWithValue("@createddate", DateTime.Now)
                sqlCmd.Parameters.AddWithValue("@updateddate", DateTime.Now)
                sqlConn.Open()
                returnResult = sqlCmd.ExecuteNonQuery()
                sqlConn.Close()
            End Using
            'MsgBox(returnResult.ToString)
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

    Protected Sub generateRefCode(ByRef refid As Integer, ByRef refcode As String)
        Dim sqlQuery As String = "SELECT COUNT(REFERRALID) from mm_user_list"
        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim dt As New DataTable

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlConn.Open()
                refid = sqlCmd.ExecuteScalar()
                sqlConn.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim r = New Random()
        Dim A As Integer = r.Next(10000, 9999999)
        refcode = A.ToString("X5")
    End Sub

    Private Function CheckEmailExists(ByVal email As String) As Boolean

        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "SELECT COUNT(EMAIL) FROM mm_user_list WHERE EMAIL=@email"
        Dim returnCount As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlCmd.Parameters.AddWithValue("@email", email)
                sqlConn.Open()
                returnCount = sqlCmd.ExecuteScalar()
                sqlConn.Close()
            End Using
            'MsgBox(returnCount.ToString)
            If returnCount = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return True
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
            sqlConn.Dispose()
        End Try

    End Function

End Class