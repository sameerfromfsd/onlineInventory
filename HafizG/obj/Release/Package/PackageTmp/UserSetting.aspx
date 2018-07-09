<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserSetting.aspx.cs" Inherits="HafizG.UserSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Users</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li><a href="#">Admin Setting</a></li>
                            <li class="active">Users</li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </div>


      <div class="content mt-3">
            <div class="animated fadeIn">

                <div class="row">              
                      <asp:EntityDataSource ID="UsersDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="LoginUsers">
                                </asp:EntityDataSource>
                  
                             <div class="col-md-4">
                        <div class="card">
                            <div class="card-header">
                                <i class="fa fa-user"></i><strong class="card-title pl-2">Profile Card</strong>
                            </div>
                            <div class="card-body">
                                <div class="mx-auto d-block">
                                    <asp:Image ImageUrl='<%# imgUrl %>' ID="Image1" runat="server" />
                                    
                                    <h5 class="text-sm-center mt-2 mb-1" runat="server">'<%# name %>'</h5>
                                    <div class="location text-sm-center"><i class="fa fa-envelope"></i> <%# email %></div>
                                    <div class="location text-sm-center"><i class="fa fa-shield"></i> Status : <%# status %></div>
                                    <div class="location text-sm-center"><i class="fa fa-user"></i> Designation : <%# desig %></div>
                                    <div class="location text-sm-center"><i class="fa fa-mobile"></i> Cell : <%# cell %></div>
                                    <div class="location text-sm-center"><i class="fa fa-rub"></i> Pass : <%# pass %></div>
                                   
                                    
                                </div>
                                <hr>
                                <div class="card-text text-sm-center">
                                    <a href="#"><i class="fa fa-facebook pr-1"></i></a>
                                    <a href="#"><i class="fa fa-twitter pr-1"></i></a>
                                    <a href="#"><i class="fa fa-linkedin pr-1"></i></a>
                                    <a href="#"><i class="fa fa-pinterest pr-1"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                      

               

                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Update Users</strong>
                          </div>
                            <div class="card-body">

                                <div class="form-group col-sm-4">
                                <label for="NmTxt" class=" form-control-label">Name</label>
                                <asp:TextBox ID="NmTxt" EnableViewState="true" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="PassTxt" class=" form-control-label">Password</label>
                                <asp:TextBox ID="PassTxt" EnableViewState="true" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="EmailTxt" class=" form-control-label">Email Id</label>
                                <asp:TextBox ID="EmailTxt" EnableViewState="true"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                  <div class="form-group col-sm-4">
                                <label for="CellTxt" class=" form-control-label">Contact Number</label>
                                <asp:TextBox ID="CellTxt" EnableViewState="true" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>


                                 <div class="form-group col-sm-4">
                                <label for="AddTxt" class=" form-control-label">Image</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file" />                          
                                </div>

                                

                             </div>
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-primary btn-sm" OnClick="Button1_Click"   />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm"   />
                            </div>
                          
                           </div>
                        </div>   
                    
                                    
                </div>

            </div>


            </div>
</asp:Content>
