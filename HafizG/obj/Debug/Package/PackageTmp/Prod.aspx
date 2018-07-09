<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prod.aspx.cs" Inherits="HafizG.Prod" %>
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
                            <li><a href="#">Brands</a></li>
                            <li class="active">Products</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

    <asp:EntityDataSource ID="EntityDataSource1" runat="server"></asp:EntityDataSource>
     <div class="content mt-3">
            <div class="animated fadeIn">

                <div class="row">

                     <script type="text/javascript">
                         Sys.Application.add_load(function () {
                             jQuery(document).ready(function () {

                                 jQuery(".standardSelect").chosen();
                             });
                         });
                     </script>

                      <div class="col-sm-6">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Products</strong>
                          </div>
                            <div class="card-body">
                                <div class="form-group">
                                <label for="proNm" class=" form-control-label">Product Name</label>
                                <asp:TextBox ID="proNm"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="unit" class=" form-control-label">Unit</label>
                                <asp:TextBox ID="unit" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="saleP" class=" form-control-label">Sale Price</label>
                                <asp:TextBox ID="saleP" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="purchP" class=" form-control-label">Purchase Price</label>
                                <asp:TextBox ID="purchP" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="status" class=" form-control-label">Status</label>
                                <asp:TextBox ID="status" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="EntityDataSource2" DataTextField="CompanyName" DataValueField="BrandId"></asp:DropDownList>

                                <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Brands" Select="it.[BrandId], it.[CompanyName]">
                                </asp:EntityDataSource>

                                <br />
                                <div class="col col-md-3"><label for="FileUpload1" class=" form-control-label">Logo/Image</label></div>
                                <div class="col-12 col-md-9"><asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file" /></div>                            </div>
                               
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click"  />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm" OnClick="Button2_Click"   />
                            </div>

                          </div> 
                       </div>

                      <div class="col-sm-6">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Edit Product</strong>
                            </div>
                            <div class="card-body">
                                <asp:DropDownList ID="DropDownList2"  class="standardSelect" runat="server" DataSourceID="prodDataSource" DataTextField="ProductName" DataValueField="ProductId" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <asp:EntityDataSource ID="prodDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Products" Select="it.[ProductId], it.[ProductName]">
                                </asp:EntityDataSource>
                                
                                 <div class="form-group">
                                <label for="proNm" class=" form-control-label">Product Name</label>
                                <asp:TextBox ID="eProNm"  runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required *" ForeColor="Red" ValidationGroup="EditProdGroup" ControlToValidate="eProNm" Font-Strikeout="False"></asp:RequiredFieldValidator>

                                 </div>
                                
                                 <div class="form-group">
                                <label for="unit" class=" form-control-label">Unit</label>
                                <asp:TextBox ID="eunit" runat="server" CssClass="form-control"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Unit Required *" ForeColor="Red" ValidationGroup="EditProdGroup" ControlToValidate="eunit" Font-Strikeout="False"></asp:RequiredFieldValidator>

                                      </div>

                                 <div class="form-group">
                                <label for="saleP" class=" form-control-label">Sale Price</label>
                                <asp:TextBox ID="esaleP" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="purchP" class=" form-control-label">Purchase Price</label>
                                <asp:TextBox ID="epurchP" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="status" class=" form-control-label">Status</label>
                                <asp:TextBox ID="estatus" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Status Required *" ForeColor="Red" ValidationGroup="EditProdGroup" ControlToValidate="estatus" Font-Strikeout="False"></asp:RequiredFieldValidator>
                                 </div>

                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataSourceID="EntityDataSource2" DataTextField="CompanyName" DataValueField="BrandId"></asp:DropDownList>

                                <asp:EntityDataSource ID="EntityDataSource5" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Brands" Select="it.[BrandId], it.[CompanyName]">
                                </asp:EntityDataSource>

                                <br />
                                <div class="col col-md-3"><label for="FileUpload1" class=" form-control-label">Logo/Image</label></div>
                                <div class="col-12 col-md-9"><asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file" /></div>                            </div>
                               
                                <div class="card-footer">
                               <asp:Button ID="Button3" runat="server" Text="Update Record" class="btn btn-primary btn-sm" OnClick="Button3_Click" ValidationGroup="EditProdGroup"   />
                               
                            </div>

                            </div>
                        </div>

                      <asp:Repeater ID="Repeater1" runat="server" DataSourceID="EntityDataSource3">
                      <ItemTemplate>

                      <div class="col-md-4">
                      <aside class="profile-nav alt">
                            <section class="card">
                                <div class="card-header user-header alt bg-dark" >
                                    <div class="media">
                                        <a href="#">
                                            <asp:Image ID="Image1" cssclass="align-self-center rounded-circle mr-1" Width="85" Height="85" ImageUrl='<%# Eval("img") %>' runat="server" />
                                            
                                        </a>
                                        &nbsp;<div class="media-body">
                                            <h7 class="text-light display-6"><%# Eval("ProductName") %></h7>
                                            <p>Company Name</p>
                                        </div>
                                    </div>
                                </div>


                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <a href="#"> <i class="fa fa-envelope-o"></i> Unit <span class="badge badge-primary pull-right"><%# Eval("Unit") %></span></a>
                                    </li>
                                    <li class="list-group-item">
                                        <a href="#"> <i class="fa fa-tasks"></i> Purchase Price <span class="badge badge-danger pull-right"><%# Eval("PurchasePrice") %></span></a>
                                    </li>
                                    <li class="list-group-item">
                                        <a href="#"> <i class="fa fa-bell-o"></i> Sale Price <span class="badge badge-success pull-right"><%# Eval("SalePrice") %></span></a>
                                    </li>
                                    <li class="list-group-item">
                                        <a href="#"> <i class="fa fa-comments-o"></i> Status <span class="badge badge-warning pull-right r-activity"><%# Eval("Status") %></span></a>
                                    </li>
                                </ul>

                            </section>
                        </aside>
                           </div>
                      </ItemTemplate>
                      </asp:Repeater>

                      <asp:EntityDataSource ID="EntityDataSource4" runat="server">
                      </asp:EntityDataSource>

                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Products</strong>
                            </div>
                            <div class="card-body">
                                  
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="EntityDataSource3" CssClass="table table-bordered table-condensed">
                                    <Columns>
                                        <asp:BoundField DataField="ProductName" HeaderText="Name" ReadOnly="True" SortExpression="ProductName" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" ReadOnly="True" SortExpression="Unit" />
                                        <asp:BoundField DataField="SalePrice" HeaderText="S-Price" ReadOnly="True" SortExpression="SalePrice" />
                                        <asp:BoundField DataField="PurchasePrice" HeaderText="P-Price" ReadOnly="True" SortExpression="PurchasePrice" />
                                       
                                        <asp:ImageField HeaderText="Image" ControlStyle-Width="30" ControlStyle-Height="30" ReadOnly="True" DataImageUrlField="img"></asp:ImageField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" />
                                        
                                    </Columns>
                                </asp:GridView>                            
                                <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Products" Select="it.[ProductName], it.[Unit], it.[SalePrice], it.[PurchasePrice], it.[img], it.[Status]">
                                </asp:EntityDataSource>
                            </div>
                               
                            <div class="card-footer">
                            </div>
                          </div>
                           
                        </div>     
                                    
                </div>
                </div>
         
           

   

     <!-- .animated -->
        </div><!-- .content -->
</asp:Content>
