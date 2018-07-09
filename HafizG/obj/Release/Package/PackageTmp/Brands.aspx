<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="HafizG.Brands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Brands</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            
                            <li class="active">Brands</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

     <div class="content mt-3">
            <div class="animated fadeIn">

                <div class="row">
         <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Brands"></asp:EntityDataSource>

         <asp:Repeater ID="Repeater1" runat="server" DataSourceID="EntityDataSource1" OnItemCommand="Repeater1_ItemCommand">
             <ItemTemplate>
              <div class="col-md-4">
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-title mb-3"><%# Eval("CompanyName")  %></strong>
                            </div>
                            <div class="card-body">
                                <div class="mx-auto d-block">
                                    
                                    <asp:ImageButton ID="Image1" Width="200" Height="150" ImageUrl='<%# Eval("Logo") %>' CssClass="rounded-circle mx-auto d-block" runat="server" OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("BrandId") %>' />
                                     <h5 class="text-sm-center mt-2 mb-1"><%# Eval("ContactPerson") %></h5>
                                    <div class="location text-sm-center"><i class="fa fa-map-marker"></i><%# Eval("ContactNumber")%>></div>
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

             </ItemTemplate>
         </asp:Repeater>
                    
                   


                    <div class="col-xs-4 col-sm-4">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Brands</strong>
                          </div>
                            <div class="card-body">
                                <div class="form-group">
                                <label for="companyName" class=" form-control-label">Company Name</label>
                                <asp:TextBox ID="compNm"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="compPers" class=" form-control-label">Contact Person Name</label>
                                <asp:TextBox ID="compPers" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="cellNm" class=" form-control-label">Contact Number</label>
                                <asp:TextBox ID="cellNm" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col col-md-3"><label for="FileUpload1" class=" form-control-label">Logo/Image</label></div>
                                <div class="col-12 col-md-9"><asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file" /></div>                            </div>
                               
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click"  />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm" OnClick="Button2_Click"   />
                            </div>
                          </div>
                           
                        </div>    
                                    
                </div>

              </div>


            </div><!-- .animated -->
        </div><!-- .content -->

</asp:Content>
