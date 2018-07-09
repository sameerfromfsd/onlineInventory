<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewStock.aspx.cs" Inherits="HafizG.AddNewStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <script>
         $(function () {
             $('#<%= fdpTxt.ClientID %>').datepicker({
                 maxDate: 0,
                 dateFormat: 'yy-mm-dd'

             });
         });

         $(function () {
             $('#<%= tdpTxt.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
     });


         </script>


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
                            <li class="active">Add Stock</li>
                            
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
                             <strong class="card-title">Add Stock</strong>
                            </div>
                            <div class="card-body">
                        
                                  <div class="form-group col-sm-6">
                                  <label for="CustTypeDropDown" class="form-control-label">Select Branch</label>
                                  <br />
                                  <asp:DropDownList ID="PMDropdownlist" Class="standardSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PMDropdownlist_SelectedIndexChanged" DataSourceID="LocDataSource" DataTextField="Name" DataValueField="StockLocId" >
                                  </asp:DropDownList>
                                  <asp:EntityDataSource ID="LocDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[Name], it.[StockLocId]">
                                  </asp:EntityDataSource>
                                  <small class="form-text text-muted">eg: Shop1 / Factory</small>
                                  </div>
                                  
                                 <div class="form-group col-sm-6">
                                  <label for="CustTypeDropDown" class="form-control-label">Select Product</label>
                                  <br />
                                  <asp:DropDownList ID="ProductList" Class="standardSelect"  DataTextField="ProductName" DataValueField="ProductId"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProductList_SelectedIndexChanged"></asp:DropDownList>
                                  <small class="form-text text-muted">eg: Nuggets / Hot Shot</small>
                                  </div>
                                  
                                 <div id="txt" runat="server">

                                  <div class="form-group col-sm-3">
                                  <label for="Qnty" class="form-control-label">Quantity</label>
                                  <br />
                                  <asp:TextBox ID="Qnty" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>

                                 <div class="form-group col-sm-3">
                                  <label for="SPrice" class="form-control-label">S-Price</label>
                                  <br />
                                  <asp:TextBox ID="SPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>

                                  <div class="form-group col-sm-3">
                                  <label for="PPrice" class="form-control-label">P-Price</label>
                                  <br />
                                  <asp:TextBox ID="PPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>

                                  <div class="form-group col-sm-3">
                                  <label for="SPrice" class="form-control-label">Add Stock</label>
                                  <br />
                                  <asp:Button ID="updateBtn"  runat="server" Text="Add Record" CssClass="btn btn-primary" OnClick="updateBtn_Click"/>
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


               <div class="row">              
                    <div class="col-xs-12 col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">View Add Stock</strong>
                            </div>
                            <div class="card-body">
                               <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label">Select Branch</label>
                                <br />
                                <asp:DropDownList ID="DropDownList1" Class="standardSelect" runat="server" AutoPostBack="True"  DataSourceID="LocDataSource" DataTextField="Name" DataValueField="StockLocId" >
                                </asp:DropDownList>
                                <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[Name], it.[StockLocId]">
                                </asp:EntityDataSource>
                                <small class="form-text text-muted">eg: Shop1 / Factory</small>
                               </div>

                               <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">From Date</label>
                               <br />
                                <asp:TextBox ID ="fdpTxt" CssClass="form-control"  runat="server"></asp:TextBox>
                                
                               <small class="form-text text-muted">eg: 14/03/2018</small>
                               </div>

                               <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                               <br />
                                <asp:TextBox ID ="tdpTxt" CssClass="form-control"  runat="server"></asp:TextBox>
                              
                               <small class="form-text text-muted">eg: 26/04/2018</small>
                               </div>


                               <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">Click to search</label>
                               <br />
                                 <asp:Button ID="Search" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click" />
                          
                              </div>

                                  <div class="col-12">
                                 
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                     <Columns>
                                             
                                        <asp:BoundField DataField="AddStockId" HeaderText="Id" ReadOnly="True" SortExpression="AddStockId" />
                                        
                                       
                                        
                                        <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                         <asp:Label ID="ProdNm" Text='<%# Eval("ProductName") %>' SortExpression="ProductName" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qnty">
                                        <ItemTemplate>
                                          <asp:TextBox ID="qntyTxt" DataField="Quantity" CssClass="form-control" Width="80" Text='<%# Eval("Quantity") %>' runat="server" />
                                       </ItemTemplate>
                                        </asp:TemplateField>

                                       

                                        <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                        <asp:Label ID="Dt" DataField="Date" Text='<%# Eval("Date","{0:dd/MMM/yyyy}") %>'  SortExpression="Date" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                         

                                        <asp:TemplateField HeaderText="User">
                                        <ItemTemplate>
                                        <asp:Label ID="UserNm" Text='<%# Eval("Name") %>'  SortExpression="Name" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Edit" ShowHeader="false">  
                                 
                                     <EditItemTemplate>  
                                     <asp:LinkButton ID="lnkbtnUpdate" runat="server" CausesValidation="true" Text="Update" CommandName="Update"></asp:LinkButton>  
                                     <asp:LinkButton ID="lnkbtnCancel" runat="server" CausesValidation="false" Text="Cancel" CommandName="Cancel"></asp:LinkButton>  
                                    </EditItemTemplate>

                                    <ItemTemplate>  
                                      <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>  
                                    </ItemTemplate>  
                                   </asp:TemplateField>  
                                   </Columns>
                                </asp:GridView>
                             </div>


                            </div>
                            <div class="card-footer">
                            </div>
                        </div>
                    </div>     
                 </div>


            </div>
     </div>     
</asp:Content>
