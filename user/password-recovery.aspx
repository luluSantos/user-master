<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="password-recovery.aspx.vb" Inherits="user.password_recovery" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-7">
              <div class="card border-0">
                <div class="card-body px-6 pr-lg-0 pl-xl-13 py-6">
                  <h2 class="card-title fs-30 font-weight-600 text-dark lh-16 mb-2">Email for set up new password</h2>
                    <div class="form-row mx-n2">
                       <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="email" class="text-heading">Email</label>
                            <asp:TextBox runat="server" ID="txtemail" CssClass="form-control form-control-lg border-0" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRegEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Email cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRegEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                      </div>
                    </div>
                    <asp:Button runat="server" ID="btnagSubmit" CssClass="btn btn-primary btn-lg btn-block rounded" Text="Submit" />
                </div>
              </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">                           
                            <h4 class="modal-title"><asp:Label ID="lblRegModalTitle" runat="server" Text="Registration"></asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal" style="float:right">&times;</button>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblRegModalMessage" runat="server" Text="Test"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnRegModalOk" runat="server" Text="Ok"/>
                        </div>
                    </div>
                </div>
            </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnagSubmit" EventName="Click"/>
            </Triggers>
            </asp:UpdatePanel>
            <script type="text/javascript">
                function showModal() {
                    $("#myModal").modal('show');
                }
            </script>
</asp:Content>
