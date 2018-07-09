<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductStock.aspx.cs" Inherits="HafizG.ProductStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    
   
      <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Stock</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">Stock</li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </div>

      <div class="content mt-3">
            <div class="animated fadeIn">

                <div class="row">              
                   
                    <div class="col-xs-12 col-sm-12">
                      <div class="card">
                         <div class="card-header">
                         <strong class="card-title">Stock Exclude</strong>
                         </div>
                         <div class="card-body">
                                  
                                  <div class="form-group col-sm-3">
                                  <label for="CustTypeDropDown" class="form-control-label">Select Product</label>
                                  <br />
                                  <asp:DropDownList ID="ExProdList" Class="standardSelect"  DataTextField="ProductName" DataValueField="ProductId"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ExProdList_SelectedIndexChanged" ></asp:DropDownList>
                                  </div>

                                  <div class="form-group col-sm-3">
                                  <label for="ParticularTxt" class="form-control-label">Particular</label>
                                  <br />
                                  <asp:TextBox ID="ParticularTxt" CssClass="form-control"  runat="server" MaxLength="100" ValidationGroup="ExStock"></asp:TextBox>
                                   
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ParticularTxt" ErrorMessage="Particular Required*" ForeColor="Red" ValidationGroup="ExStock"></asp:RequiredFieldValidator>
                                      
                                  </div>

                                  <div class="form-group col-sm-2">
                                  <label for="Qnty" class="form-control-label">Quantity</label>
                                 
                                  <asp:TextBox ID="exQntyTxt" CssClass="form-control"  runat="server"></asp:TextBox>
                                  
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="exQntyTxt" ErrorMessage="Qnty Required*" ForeColor="Red" ValidationGroup="ExStock"></asp:RequiredFieldValidator> 
                                  </div>

                                  <div class="form-group col-sm-2">
                                  <label for="Worth" class="form-control-label">Worth</label>
                                  <br />
                                  <asp:TextBox ID="worthTxt" CssClass="form-control" runat="server"></asp:TextBox>
                                  
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="worthTxt" ErrorMessage="Worth Required *" ForeColor="Red" ValidationGroup="ExStock"></asp:RequiredFieldValidator>
                                  
                                  </div>

                                  <div class="form-group col-sm-2">
                                  <label for="SPrice" class="form-control-label">Update Stock</label>
                                  <br />
                                  <asp:Button ID="ExProdStock"  runat="server" Text="Update Record" CssClass="btn btn-primary" OnClick="ExProdStock_Click" ValidationGroup="ExStock" />
                                     </div>

                           


                         </div>
                      </div>
                    </div>
                    
                    <div class="col-xs-12 col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Stock</strong>
                            </div>
                            <div class="card-body">
                                 
                                 
                                

                                  <div class="form-group col-sm-3">
                                  <label for="CustTypeDropDown" class="form-control-label">Select Branch</label>
                                  <br />
                                  <asp:DropDownList ID="PMDropdownlist" Class="standardSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PMDropdownlist_SelectedIndexChanged" DataSourceID="LocDataSource" DataTextField="Name" DataValueField="StockLocId" >
                                  </asp:DropDownList>
                                  <asp:EntityDataSource ID="LocDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[Name], it.[StockLocId]">
                                  </asp:EntityDataSource>
                                  <small class="form-text text-muted">eg: Shop1 / Factory</small>
                                  </div>
                                  
                                 <div class="form-group col-sm-3">
                                  <label for="CustTypeDropDown" class="form-control-label">Select Product</label>
                                  <br />
                                  <asp:DropDownList ID="ProductList" Class="standardSelect"  DataTextField="ProductName" DataValueField="ProductId"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProductList_SelectedIndexChanged"></asp:DropDownList>
                                  <small class="form-text text-muted">eg: Nuggets / Hot Shot</small>
                                  </div>
                                  
                                 <div id="txt" runat="server">

                                  <div class="form-group col-sm-1">
                                  <label for="Qnty" class="form-control-label">Quantity</label>
                                  <br />
                                  <asp:TextBox ID="Qnty" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>

                                 <div class="form-group col-sm-1">
                                  <label for="SPrice" class="form-control-label">S-Price</label>
                                  <br />
                                  <asp:TextBox ID="SPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>

                                  <div class="form-group col-sm-1">
                                  <label for="PPrice" class="form-control-label">P-Price</label>
                                  <br />
                                  <asp:TextBox ID="PPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>

                                  <div class="form-group col-sm-2">
                                  <label for="SPrice" class="form-control-label">Update Stock</label>
                                  <br />
                                  <asp:Button ID="updateBtn"  runat="server" Text="Update Record" CssClass="btn btn-primary" OnClick="updateBtn_Click"/>
                                  </div>

                                </div>


                                <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False">
                                    <Columns>    
                                        <asp:BoundField DataField="CompanyName" HeaderText="Company" ReadOnly="True" SortExpression="CompanyName" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Id" SortExpression="ProductId" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                                       
                                        
                                        <asp:BoundField DataField="SalePrice" HeaderText="S-Price" SortExpression="SalePrice" />
                                      
                                        <asp:BoundField DataField="PurchasePrice" HeaderText="P-Price" SortExpression="PurchasePrice" />
                                        
                                        <asp:BoundField DataField="Quantity" HeaderText="Qnty" SortExpression="Quantity" />
                                         <asp:ImageField DataImageUrlField="img" HeaderText="Image" SortExpression="img" ItemStyle-Width="70" ItemStyle-Height="70" />
                                   </Columns>
                                </asp:GridView>
                                <asp:EntityDataSource ID="EntityDataSource1" runat="server">
                                </asp:EntityDataSource>
                            </div>
                               
                            <div class="card-footer">
                            </div>
                          </div>
                           
                        </div>     
                    
           
                </div>
            </div>
     </div>    
    
             
</asp:Content>
