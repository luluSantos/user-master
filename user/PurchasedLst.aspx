<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PurchasedLst.aspx.vb" Inherits="user.PurchasedLst" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        
          <main id="content" class="bg-gray-01">
              <div class="table-responsive">
              <asp:GridView runat="server" ID="gvListing" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CssClass="table table-hover bg-white border rounded-lg">
                  <Columns>
                      <asp:TemplateField HeaderText="Listings">
                          <HeaderStyle CssClass="thead-sm thead-black"/>
                          <ItemTemplate>
                              <a href='<%#DataBinder.Eval(Container.DataItem, "post_url")%>'>
                              <img src='<%#DataBinder.Eval(Container.DataItem, "post_pic")%>' alt="Home in Metric Way" style="max-height:80px;width:100%"></a>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="">
                          <HeaderStyle CssClass="thead-sm thead-black"/>
                          <ItemTemplate>
                            <a href='<%#DataBinder.Eval(Container.DataItem, "post_url")%>' class="text-dark hover-primary">
                              <h5 class="fs-16 mb-0 lh-18"><asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "post_title")%>'></asp:Label></h5>
                            </a>
                            <p class="mb-1 font-weight-500"><asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "post_address")%>'></asp:Label></p>
                            <span class="text-heading lh-15 font-weight-bold fs-17"><asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "post_price")%>'></asp:Label></span>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Date Published">
                          <HeaderStyle CssClass="thead-sm thead-black"/>
                          <ItemTemplate>
                              <asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "post_date")%>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                      <div align="center">No records found.</div>
                  </EmptyDataTemplate>
              </asp:GridView>
            </div>
          </main>

</asp:Content>
