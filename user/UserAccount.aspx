<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UserAccount.aspx.vb" Inherits="user.UserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
          <main id="content" class="bg-gray-01">
            <div class="px-3 px-lg-6 px-xxl-13 py-5 py-lg-10">
              <div class="d-flex flex-wrap flex-md-nowrap mb-6">
                <div class="mr-0 mr-md-auto">
                  <h2 class="mb-0 text-heading fs-22 lh-15">Welcome back, <asp:Label runat="server" ID="fullname" Text="User."></asp:Label></h2>
                </div>
              </div>

              <div class="row">
                <div class="col-sm-12 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-12">
                        <p class="fs-30">Agent Account</p>
                          <p class="fs-15">If you want to become and agent, click the button below</p>
                          <asp:button runat="server" text="Become an Agent" id="btnAgentCMS"/>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

            <div class="row">
                <div class="col-sm-5 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-12">
                        <p class="fs-30">Photo</p>
                          <p class="fs-15">Upload your profile photo</p>
                          <asp:FileUpload ID="photoUpload" runat="server" />
                          <asp:button runat="server" text="Upload Photo" ID="btnUpload"/>
                          <img src="~/img/noPhoto.png" runat="server" id="imgProf" style="height:160px;width:120px"/>
                          
                      </div>
                    </div>
                  </div>
                </div>

                 <div class="col-sm-7 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-12">
                        <p class="fs-30">User Detail</p> <asp:button runat="server" text="Edit" ID="btnEdit"/>
                          <img runat="server" id="imgPri" src=""/>
                          <p class="fs-15 col-sm-6" >Name</p>
                          <asp:TextBox runat="server" ID="txtName" CssClass="form-control form-control-lg border-0" ReadOnly="true"></asp:TextBox>  
                          <p class="fs-15  col-sm-6">Email</p>
                          <asp:TextBox runat="server" ID="txtemail" CssClass="form-control form-control-lg border-0" TextMode="Email" ReadOnly="true"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="revRegEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                           <p class="fs-15 col-sm-6" >DOB</p>
                           <asp:TextBox runat="server" ID="txtdob" TextMode="Date" CssClass="form-control form-control-lg border-0" ReadOnly="true"></asp:TextBox>
                           <p class="fs-15 col-sm-6" >LoginID</p>
                           <asp:TextBox runat="server" ID="txtlogin" CssClass="form-control form-control-lg border-0" ReadOnly="true"></asp:TextBox>
                           <p class="fs-15 col-sm-6" >Area</p>
                          <asp:TextBox runat="server" ID="txtarea" CssClass="form-control form-control-lg border-0" ReadOnly="true"></asp:TextBox>  
                           <p class="fs-15 col-sm-6" >Gender</p>
                          <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control form-control-lg border-0" Enabled="false">  
                                  <asp:ListItem value="M">Male</asp:ListItem>  
                                  <asp:ListItem value="F">Female</asp:ListItem>   
                            </asp:DropDownList>
                          <asp:button runat="server" text="Update Detail" ID="btnupdateDtl"/>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

            </div>

               <div class="row">
                    <div class="col-sm-12 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-12">
                        <p class="fs-30">Referral</p>
                          <p class="fs-15">Your Referral Code</p>
                          <asp:textbox id="txtRefCode" runat="server" ReadOnly="true"></asp:textbox>
                          
                      </div>
                    </div>
                  </div>
                </div>
               </div>

               <div class="row">
                    <div class="col-sm-12 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-12">
                        <p class="fs-30">Change Password</p>
                          <p class="fs-15">Your Current Password</p>
                          <asp:textbox id="txtPwd1" runat="server"></asp:textbox>
                          <p class="fs-15">Your New Password</p>
                          <asp:textbox id="txtPwd2" runat="server"></asp:textbox>
                          <asp:button runat="server" text="Change password" ID="btnchangePwd"/>
                      </div>
                    </div>
                  </div>
                </div>
               </div>
          </main>

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
                            <asp:Button ID="btnRegModalOk" runat="server" Text="Ok" data-dismiss="modal"/>
                        </div>
                    </div>
                </div>
            </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnchangePwd" EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="btnEdit" EventName="Click"/>
                <asp:PostbackTrigger ControlID="btnUpload" />
            </Triggers>
            </asp:UpdatePanel>
            <script type="text/javascript">
                function showModal() {
                    $("#myModal").modal('show');
                }
            </script>

</asp:Content>

