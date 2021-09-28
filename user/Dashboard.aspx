<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.vb" Inherits="user.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

          <main id="content" class="bg-gray-01">
            <div class="px-3 px-lg-6 px-xxl-13 py-5 py-lg-10">
              <div class="row">
                <div class="col-sm-6 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-5">
                        <span class="w-83px h-83 d-flex align-items-center justify-content-center fs-36 badge badge-blue badge-circle">
                          <svg class="icon icon-1">
                            <use xlink:href="#icon-1"></use>
                          </svg>
                        </span>
                      </div>
                      <div class="col-7 text-center">
                        <asp:label runat="server" id="id_favpro" class="fs-42 lh-12 mb-0 counterup" data-start="0"
                           data-end="1" data-decimals="0"
                           data-duration="0" data-separator=""></asp:label>
                        <p>Favorite Properties</p>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="col-sm-6 col-xxl-3 mb-6">
                  <div class="card">
                    <div class="card-body row align-items-center px-6 py-7">
                      <div class="col-5">
                        <span class="w-83px h-83 d-flex align-items-center justify-content-center fs-36 badge badge-green badge-circle">
                          <svg class="icon icon-2"><use xlink:href="#icon-2"></use></svg>
                        </span>
                      </div>
                      <div class="col-7 text-center">
                        <asp:label runat="server" id="id_purpro" class="fs-42 lh-12 mb-0 counterup" data-start="0"
                           data-end="1" data-decimals="0"
                           data-duration="0" data-separator=""></asp:label>
                        <p>Purchased Properties</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </main>

</asp:Content>
