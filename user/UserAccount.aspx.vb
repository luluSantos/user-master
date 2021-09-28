Imports MySql.Data.MySqlClient

Public Class UserAccount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim labeluser As Label = Page.Master.FindControl("lblMasterUserName")
            Dim labeltitle As Label = Page.Master.FindControl("lblMasterTitle")
            labeltitle.Text = "User Account"
            If Session("NAME") IsNot Nothing And Not String.IsNullOrEmpty(Session("NAME")) Then
                labeluser.Text = Session("NAME")
                fullname.Text = Session("NAME")
            Else
                Response.Redirect("UserLogin.aspx")
            End If

            Dim sqlQuery As String = "SELECT NAME, EMAIL, DOB, LOGINID, PRIVILEGE, AREA, REFERRALCODE, GENDER,PROFILEPIC FROM mm_user_list where USERID = @userid;"
            Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
            Dim dt As New DataTable

            Try
                Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                    sqlCmd.Parameters.AddWithValue("@userid", Session("USERID"))
                    sqlConn.Open()
                    Dim sda As New MySqlDataAdapter
                    sda.SelectCommand = sqlCmd
                    sda.Fill(dt)
                    sqlConn.Close()
                End Using
                txtName.Text = dt.Rows(0).Item("NAME").ToString
                txtemail.Text = dt.Rows(0).Item("EMAIL").ToString
                txtdob.Text = DateTime.Parse(dt.Rows(0).Item("DOB")).ToString("yyyy-MM-dd")
                txtlogin.Text = dt.Rows(0).Item("LOGINID").ToString
                txtarea.Text = dt.Rows(0).Item("AREA").ToString
                txtRefCode.Text = dt.Rows(0).Item("REFERRALCODE").ToString
                ddlGender.SelectedValue = dt.Rows(0).Item("GENDER").ToString
                imgProf.Src = "~/img/upload/" + dt.Rows(0).Item("PROFILEPIC").ToString
                Dim privilege As Integer = dt.Rows(0).Item("PRIVILEGE").ToString
                If privilege = 1 Then
                    imgPri.Src = "img/bronze.PNG"
                ElseIf privilege = 2 Then
                    imgPri.Src = "img/silver.PNG"
                ElseIf privilege = 3 Then
                    imgPri.Src = "img/gold.PNG"
                ElseIf privilege = 4 Then
                    imgPri.Src = "img/diamond.PNG"
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Me.Page.Form.Enctype = "multipart/form-data"
    End Sub

    Public Sub btnuploadclick(sender As Object, e As EventArgs) Handles btnUpload.Click
        MsgBox(photoUpload.HasFile.ToString)
        If photoUpload.HasFile Then
            Dim filename = photoUpload.FileName.ToString
            Dim path As String = Server.MapPath("~/img/upload/") + filename
            photoUpload.SaveAs(path)
            imgProf.Src = path
            Dim save = SavePhototoDB(filename)
            If save Then
                lblRegModalTitle.Text = "Success"
                lblRegModalMessage.Text = "Photo uploaded."
            Else
                lblRegModalTitle.Text = "Error"
                lblRegModalMessage.Text = "Unable to save photo."
            End If

        Else
            lblRegModalTitle.Text = "Error"
            lblRegModalMessage.Text = "No file uploaded."
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
    End Sub

    Public Function SavePhototoDB(ByVal path As String)
        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "UPDATE mm_user_list SET PROFILEPIC=@path,UPDATEDDATE=@updateddate WHERE USERID=@userid"

        Dim returnResult As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlConn.Open()
                sqlCmd.Parameters.AddWithValue("@path", path)
                sqlCmd.Parameters.AddWithValue("@updateddate", DateTime.Now)
                sqlCmd.Parameters.AddWithValue("@userid", Session("USERID"))
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

    Public Sub btnEditClick(sender As Object, e As EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            txtName.ReadOnly = False
            txtemail.ReadOnly = False
            txtdob.ReadOnly = False
            txtarea.ReadOnly = False
            ddlGender.Enabled = True
            btnEdit.Text = "Cancel"
        Else
            txtName.ReadOnly = True
            txtemail.ReadOnly = True
            txtdob.ReadOnly = True
            txtarea.ReadOnly = True
            ddlGender.Enabled = False
            btnEdit.Text = "Edit"
        End If
    End Sub

    Public Sub btnupdateDtlClick(sender As Object, e As EventArgs) Handles btnupdateDtl.Click
        Dim emailCheck As Boolean = CheckEmailExists(txtemail.Text.Trim)

        If emailCheck Then
            lblRegModalTitle.Text = "Error"
            lblRegModalMessage.Text = "This email has already register in another account."
        Else
            Dim updateDtl = UpdateDetail()
            If updateDtl Then
                lblRegModalTitle.Text = "Success"
                lblRegModalMessage.Text = "Update successfully."
            Else
                lblRegModalTitle.Text = "Error"
                lblRegModalMessage.Text = "Unable to update details."
            End If
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
    End Sub

    Public Function UpdateDetail()
        Dim name = txtName.Text
        Dim email = txtemail.Text
        Dim DOB = txtdob.Text.Trim
        Dim area = txtarea.Text
        Dim gender = ddlGender.SelectedValue

        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "UPDATE mm_user_list SET NAME = @username,EMAIL = @useremail, DOB = @userdob, AREA = @userarea, GENDER = @usergender, updateddate=@updateddate WHERE USERID = @userid"
        Dim returnResult As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlCmd.Parameters.AddWithValue("@username", name)
                sqlCmd.Parameters.AddWithValue("@useremail", email)
                sqlCmd.Parameters.AddWithValue("@userdob", DOB)
                sqlCmd.Parameters.AddWithValue("@userarea", area)
                sqlCmd.Parameters.AddWithValue("@usergender", gender)
                sqlCmd.Parameters.AddWithValue("@updateddate", DateTime.Now)
                sqlCmd.Parameters.AddWithValue("@userid", Session("USERID"))
                sqlConn.Open()
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

    Public Sub btnchangePwdClick(sender As Object, e As EventArgs) Handles btnchangePwd.Click
        Dim oldPassword As String = txtPwd1.Text
        Dim newPassword As String = txtPwd2.Text
        Dim pwdOK As Boolean = checkPassword(oldPassword)

        If pwdOK Then
            Dim update = UpdatePassword(newPassword)
            If update Then
                lblRegModalTitle.Text = "Success"
                lblRegModalMessage.Text = "New password saved."
            Else
                lblRegModalTitle.Text = "Error"
                lblRegModalMessage.Text = "Unable to save new password."
            End If
        Else
            lblRegModalTitle.Text = "Error"
            lblRegModalMessage.Text = "Incorrect password."
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "showModal();", True)
    End Sub

    Public Function UpdatePassword(ByVal newpassword As String)
        Dim sec As New clsEncryption
        Dim password = sec.EncryptData(newpassword)
        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "UPDATE mm_user_list SET PWD=@newpwd,UPDATEDDATE=@updateddate WHERE USERID=@userid"

        Dim returnResult As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlConn.Open()
                sqlCmd.Parameters.AddWithValue("@newpwd", password)
                sqlCmd.Parameters.AddWithValue("@updateddate", DateTime.Now)
                sqlCmd.Parameters.AddWithValue("@userid", Session("USERID"))
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

    Public Function checkPassword(pwd) As Boolean
        Dim sec As New clsEncryption
        Dim password = sec.EncryptData(pwd)
        Dim sqlQuery As String = "SELECT COUNT(USERID) from mm_user_list where PWD = @userpwd"
        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim dt As New DataTable
        Dim checkpwd As Integer
        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlConn.Open()
                sqlCmd.Parameters.AddWithValue("@userpwd", password)
                checkpwd = sqlCmd.ExecuteScalar()
                sqlConn.Close()
            End Using

            If checkpwd > 0 Then
                Return True
            Else Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Function CheckEmailExists(ByVal email As String) As Boolean

        Dim sqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("mhaDB").ConnectionString)
        Dim sqlQuery As String = "SELECT COUNT(EMAIL) FROM mm_user_list WHERE EMAIL=@email AND USERID <> @userid"
        Dim returnCount As Integer = 0

        Try
            Using sqlCmd As New MySqlCommand(sqlQuery, sqlConn)
                sqlCmd.Parameters.AddWithValue("@email", email)
                sqlCmd.Parameters.AddWithValue("@userid", Session("USERID"))
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