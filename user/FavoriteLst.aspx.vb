Imports MySql.Data.MySqlClient

Public Class FavoriteLst
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim labeluser As Label = Page.Master.FindControl("lblMasterUserName")
            Dim labeltitle As Label = Page.Master.FindControl("lblMasterTitle")
            labeltitle.Text = "Favourite Properties"
            If Session("NAME") IsNot Nothing And Not String.IsNullOrEmpty(Session("NAME")) Then
                labeluser.Text = Session("NAME")
            Else
                Response.Redirect("UserLogin.aspx")
            End If
        End If

        gvListing.DataSource = getData()
        gvListing.DataBind()
    End Sub

    Protected Function getData() As DataTable

        Dim sqlQuery As String
        sqlQuery = "select post_title,(select meta_value from wpy2_postmeta where post_id = a.PROPERTYID and meta_key = 'real_estate_property_address') as post_address,post_date,"
        sqlQuery += "CONCAT('https://mhartanah.com/property/',post_name,'/') as post_url,"
        sqlQuery += "(select meta_value from wpy2_postmeta where post_id = a.PROPERTYID and meta_key = 'real_estate_property_price') as post_price,"
        sqlQuery += "CONCAT('https://mhartanah.com/wp-content/uploads/',(select meta_value from wpy2_postmeta where post_id =  (select meta_value as pic_id from wpy2_postmeta where post_id = a.PROPERTYID and meta_key = '_thumbnail_id') and meta_key = '_wp_attached_file')) as post_pic "
        sqlQuery += "from mm_user_bhv a left join wpy2_posts b ON a.PROPERTYID = b.ID "
        sqlQuery += "where a.STATUS = 'F' and a.USERID = @userid"
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return dt
    End Function


End Class