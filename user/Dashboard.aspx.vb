Imports MySql.Data.MySqlClient

Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim labeluser As Label = Page.Master.FindControl("lblMasterUserName")
            Dim labeltitle As Label = Page.Master.FindControl("lblMasterTitle")
            labeltitle.Text = "Dashboard"
            If Session("NAME") IsNot Nothing And Not String.IsNullOrEmpty(Session("NAME")) Then
                labeluser.Text = Session("NAME")
            Else
                Response.Redirect("UserLogin.aspx")
            End If
        End If

        Dim sqlQuery As String = "SELECT (Select COUNT(PROPERTYID) from mm_user_bhv where status = 'F' and userid = @userid) as Fav_count,(select COUNT(PROPERTYID) from mm_user_bhv where status = 'P'and userid = @userid) as Purchased_count from mm_user_bhv"
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
            id_favpro.Text = dt.Rows(0).Item("Fav_count").ToString
            id_favpro.Attributes("data-end") = dt.Rows(0).Item("Fav_count").ToString
            id_purpro.Text = dt.Rows(0).Item("Purchased_count").ToString
            id_purpro.Attributes("data-end") = dt.Rows(0).Item("Purchased_count").ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class