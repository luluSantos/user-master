<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserLogin.aspx.vb" Inherits="user.UserLogin" MasterPageFile="~/Site1.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main id="content">
      <section class="py-13">
        <div class="container">
          <div class="row login-register">
            <div class="col-lg-12">
              <div class="card border-0 shadow-xxs-2 mb-6">
                <div class="card-body px-8 py-6">
                  <h2 class="card-title fs-30 font-weight-600 text-dark lh-16 mb-2">Log In</h2>
                  <p class="mb-4">Don't have an account yet? <a href="UserRegistration" class="text-heading hover-primary"><u>Register
                        now</u></a></p>
                    <div class="form-group mb-4">
                      <label for="username-1">Login ID</label>
                      <asp:textbox runat="server" id="txtLoginID" class="form-control border-0 shadow-none fs-13"></asp:textbox>
                    </div>
                    <div class="form-group mb-4">
                      <label for="password-2">Password</label>
                      <div class="input-group input-group-lg">
                       <asp:textbox runat="server" id="txtPassword" class="form-control border-0 shadow-none fs-13" TextMode="Password"></asp:textbox>
<%--                        <div class="input-group-append">
                          <span class="input-group-text bg-gray-01 border-0 text-body fs-18">
                            <i class="far fa-eye-slash"></i>
                          </span>
                        </div>--%>
                      </div>
                    </div>
                    <div class="d-flex mb-4">
                      <div class="form-check">
                        <input class="form-check-input" type="checkbox" value="" id="remember-me-1" name="remember">
                        <label class="form-check-label" for="remember-me-1">
                          Stay signed in
                        </label>
                      </div>
                      <a href="password-recovery.aspx" class="d-inline-block ml-auto fs-13 lh-2 text-body">
                        <u>Forgot your password?</u>
                      </a>
                    </div>
                    <asp:button runat="server" id="btnSubmitLogin" class="btn btn-primary btn-lg btn-block rounded" Text="Submit"/>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </main>
</asp:Content>
