<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Branches.aspx.cs" Inherits="HafizG.Branches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Branches</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">Branches</li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </div>

     <div class="col-sm-12">
                <div class="alert  alert-success alert-dismissible fade show" role="alert">
                  <span class="badge badge-pill badge-success">Success</span> You successfully read this important alert message.
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>

     <div class="content mt-3">
            <div class="animated fadeIn">

                <div class="row">              
                    <div class="col-sm-4">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Branches</strong>
                          </div>
                            <div class="card-body">
                                <div class="form-group">
                                <label for="NmTxt" class=" form-control-label">Name</label>
                                <asp:TextBox ID="NmTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="LocTxt" class=" form-control-label">Location</label>
                                <asp:TextBox ID="LocTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="SupTxt" class=" form-control-label">Supervisor</label>
                                <asp:TextBox ID="SupTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                <label for="NumTxt" class=" form-control-label">Contact Number</label>
                                <asp:TextBox ID="NumTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

</div>
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click"  />
                               <asp:Button ID="Button2" runat="server" Text="Update" class="btn btn-danger btn-sm" OnClick="Button2_Click"   />
                            </div>
                          
                           </div>
                        </div>   
                    
                    <div class="col-xs-8 col-sm-8">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Branches</strong>
                            </div>
                            <div class="card-body">
                                  
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="BranchDataSource" CssClass="table table-bordered table-condensed" DataKeyNames="StockLocId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                                    <Columns>
                                        
                                        <asp:BoundField DataField="StockLocId" HeaderText="Id" ReadOnly="True" SortExpression="StockLocId" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                                        <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" SortExpression="Supervisor" />
                                       
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Number" SortExpression="ContactNumber" />
                                        
                                    </Columns>
                                </asp:GridView>                            
                                <asp:EntityDataSource ID="BranchDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations">
                                </asp:EntityDataSource>
                                <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Products" Select="it.[ProductName], it.[Unit], it.[SalePrice], it.[PurchasePrice], it.[img], it.[Status]">
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
