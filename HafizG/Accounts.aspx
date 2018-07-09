<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="HafizG.Accounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Accounts</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li><a href="#">Admin Setting</a></li>
                            <li class="active">Accounts</li>
                            
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
                    
                    <div class=" col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Accounts</strong>
                            </div>
                            <div class="card-body">
                                  
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccountsDataSource" CssClass="table table-bordered table-condensed" DataKeyNames="AccountId">
                                    <Columns>
                                        <asp:BoundField DataField="AccountId" HeaderText="Id" ReadOnly="True" SortExpression="AccountId" />
                                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                        <asp:BoundField DataField="AccountNumber" HeaderText="AccountNumber" SortExpression="AccountNumber" />
                                        <asp:BoundField DataField="Bank" HeaderText="Bank" SortExpression="Bank" />
                                       
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        
                                        <asp:BoundField DataField="CurrentBalance" HeaderText="Balance" SortExpression="CurrentBalance" />
                                        
                                    </Columns>
                                </asp:GridView>                            
                                <asp:EntityDataSource ID="AccountsDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Accounts">
                                </asp:EntityDataSource>
                            </div>
                               
                            <div class="card-footer">
                            </div>
                          </div>
                           
                        </div> 
                    



                    
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Account</strong>
                          </div>
                            <div class="card-body">

                                <div class="form-group col-sm-4">
                                <label for="titleTxt" class=" form-control-label">Title</label>
                                <asp:TextBox ID="titleTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="AccTxt" class=" form-control-label">Account Number</label>
                                <asp:TextBox ID="AccTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="BankTxt" class=" form-control-label">Bank</label>
                                <asp:TextBox ID="BankTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                               
                                <div class="form-group col-sm-4">
                                <label for="DropDownList" class=" form-control-label">Type</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Bank</asp:ListItem>
                                    <asp:ListItem>InHand</asp:ListItem>
                                   
                                    </asp:DropDownList>
                                </div>

                                 <div class="form-group col-sm-8">
                                <label for="BalTxt" class=" form-control-label">Balance</label>
                                <asp:TextBox ID="BalTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                

                             </div>
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click"  />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm" OnClick="Button2_Click"   />
                            </div>
                          
                           </div>
                        </div>   
                    
                                    
                </div>

            </div>


            </div>
</asp:Content>
