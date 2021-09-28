Public Class UserPrivelege
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim labeluser As Label = Page.Master.FindControl("lblMasterUserName")
            If Session("NAME") IsNot Nothing And Not String.IsNullOrEmpty(Session("NAME")) Then
                labeluser.Text = Session("NAME")
            Else
                Response.Redirect("UserLogin.aspx")
            End If
        End If
    End Sub

End Class