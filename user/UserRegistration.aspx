<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="UserRegistration.aspx.vb" Inherits="user.UserRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-7">
              <div class="card border-0">
                <div class="card-body px-6 pr-lg-0 pl-xl-13 py-6">
                  <h2 class="card-title fs-30 font-weight-600 text-dark lh-16 mb-2">Sign Up</h2>
                  <p class="mb-4">Already have an account? <a href="Login" class="text-heading hover-primary"><u>Sign
                        in now</u></a></p>
                    <div class="form-row mx-n2">
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="firstName" class="text-heading">Name</label>
                          <asp:TextBox runat="server" ID="txtName" CssClass="form-control form-control-lg border-0"></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="rfvRegName" runat="server" ControlToValidate="txtName" ErrorMessage="Name cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="lastName" class="text-heading">Login ID</label>
                            <asp:TextBox runat="server" ID="txtloginid" CssClass="form-control form-control-lg border-0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRegLoginID" runat="server" ControlToValidate="txtloginid" ErrorMessage="Login ID cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                    </div>
                     <div class="form-row mx-n2">
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="firstName" class="text-heading">Area</label>
                          <asp:TextBox runat="server" ID="txtarea" CssClass="form-control form-control-lg border-0"></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="rfvRegArea" runat="server" ControlToValidate="txtarea" ErrorMessage="Area cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="lastName" class="text-heading">Gender</label>
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control form-control-lg border-0">  
                                  <asp:ListItem value="M">Male</asp:ListItem>  
                                  <asp:ListItem value="F">Female</asp:ListItem>   
                            </asp:DropDownList>  
                        </div>
                      </div>
                    </div>
                    <div class="form-row mx-n2">
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="email" class="text-heading">Email</label>
                            <asp:TextBox runat="server" ID="txtemail" CssClass="form-control form-control-lg border-0" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRegEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Email cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRegEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                      </div>
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="user-role" class="text-heading">Date of Birth</label>
                          <asp:TextBox runat="server" ID="txtdob" TextMode="Date" CssClass="form-control form-control-lg border-0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdob" ErrorMessage="DOB cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                    </div>
                    <div class="form-row mx-n2">
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="password-1" class="text-heading">Password</label>
                          <div class="input-group input-group-lg">
                              <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control border-0 shadow-none"></asp:TextBox>                             
                          </div>
                            <asp:RequiredFieldValidator ID="rfvRegPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password cannot be empty." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="revRegPassword" runat="server" ValidationExpression="^.*(?=.{8,})(?=.*[\d]).*$" ControlToValidate="txtPassword" ErrorMessage="Password must be alphanumerical and contain at least 8 characters." ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                      </div>
                      <div class="col-sm-6 px-2">
                        <div class="form-group">
                          <label for="re-password">Re-Enter Password</label>
                          <div class="input-group input-group-lg">
                              <asp:TextBox runat="server" ID="txtagPassword2" TextMode="Password" CssClass="form-control border-0 shadow-none"></asp:TextBox>
                          </div>
                          <asp:CompareValidator runat="server" id="cmpagPassword2" controltovalidate="txtagPassword2" controltocompare="txtPassword" operator="Equal" type="String" errormessage="The password is not same." ForeColor="Red" Display="Dynamic" /><br />
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
