<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Expense.aspx.cs" Inherits="HafizG.Expense1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <script>
         $(function () {
             $('#<%= datepicker.ClientID %>').datepicker({
                maxDate: 0,
                dateFormat: 'yy-mm-dd'

            });
        });

        $(function () {
            $('#<%= datepicker1.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
        });

         
         </script>

      <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Expense</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">Expense</li>
                            
                        </ol>
                    </div>
                </div>
            </div>
        </div>

      <div class="content mt-3">
            <div class="animated fadeIn">

              <div class="row">              
                    
                 <div class=" col-sm-12">
                     <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Expense List</strong>
                            </div>
                            <div class="card-body">
                                
                                   <div class="form-group col-sm-3">
                                   <label for="CustTypeDropDown" class="form-control-label">Select Branch</label>
                                   <br />
                                   <asp:DropDownList ID="PMDropdownlist"  CssClass="form-control" Class="standardSelect" runat="server" AutoPostBack="True"  DataSourceID="LocDataSource" DataTextField="Name" DataValueField="StockLocId" >
                                     
                                   </asp:DropDownList>
                                   <asp:EntityDataSource ID="LocDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[Name], it.[StockLocId]">
                                       </asp:EntityDataSource>
                                   <small class="form-text text-muted">eg: Shop1 / Factory</small>
                                </div>

                           <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">From Date</label>
                               <br />
                                <asp:TextBox ID ="datepicker" CssClass="form-control"  runat="server"></asp:TextBox>
                                
                               <small class="form-text text-muted">eg: 14/03/2018</small>
                           </div>

                           <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                               <br />
                                <asp:TextBox ID ="datepicker1" CssClass="form-control"  runat="server"></asp:TextBox>
                              
                               <small class="form-text text-muted">eg: 26/04/2018</small>
                            </div>
                                
                              
                               <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">Click to search</label>
                               <br />
                                 <asp:Button ID="Search" Width="100%" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click"  />
                               </div> 
                                 
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" AutoGenerateEditButton="true" CssClass="table table-bordered table-condensed" DataKeyNames="ExpenseId">
                                    <Columns>
                                        
                                        <asp:BoundField DataField="ExpenseId" HeaderText="Id" ReadOnly="True" SortExpression="ExpenseId" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" />
                                        <asp:BoundField DataField="Particular" ControlStyle-CssClass="form-control" HeaderText="Particular" SortExpression="Particular" />
                                        <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                                 <asp:Label ID="TypeLbl" runat="server" DataField="Type" Text='<%# Eval("Type") %>'  SortExpression="Type" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" >
                                                 
                                                 <asp:ListItem>Shop Expense</asp:ListItem>
                                                 <asp:ListItem>Utitlity Bill</asp:ListItem>
                                                 <asp:ListItem>Salary</asp:ListItem>
                                                 <asp:ListItem>Guest</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField DataField="Amount" ControlStyle-CssClass="form-control" HeaderText="Amount" SortExpression="Amount" />
                                        <asp:BoundField DataField="Title" HeaderText="Account" ReadOnly="true" SortExpression="Title" />
                                        <asp:BoundField DataField="Name" HeaderText="User" ReadOnly="true" SortExpression="Name" />
                                        <asp:BoundField DataField="Expr1" HeaderText="Branch" ReadOnly="true" SortExpression="Expr1" />
                                    </Columns>
                               
                                </asp:GridView>                            
                               
                                 <asp:Label ID="tSale" class="badge badge-warning pull-right r-activity" Text ="Total Expense Amount : "  runat="server">
                                     <asp:TextBox ID="tSaleTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                 </asp:Label>

                            </div>
                               
                            <div class="card-footer">
                            </div>
                          </div>
    
                 </div>     

                 <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Expense</strong>
                          </div>
                            <div class="card-body">


                                 <div class="form-group col-sm-8">
                                <label for="prtTxt" class=" form-control-label">Particular</label>
                                <asp:TextBox ID="prtTxt" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>
                               
                                <div class="form-group col-sm-4">
                                <label for="DropDownList" class=" form-control-label">Type</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Shop Expense</asp:ListItem>
                                    <asp:ListItem>Utitlity Bill</asp:ListItem>
                                     <asp:ListItem>Salary</asp:ListItem>
                                    <asp:ListItem>Guest</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                                
                                  <div class="form-group col-sm-4">
                                <label for="amTxt" class=" form-control-label">Amount</label>
                                <asp:TextBox ID="amTxt"  runat="server" CssClass="form-control"  TextMode="Number" min="0"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="DropDownList" class=" form-control-label">Account</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" DataSourceID="AccDataSource" DataTextField="Title" DataValueField="AccountId"></asp:DropDownList>
                                    <asp:EntityDataSource ID="AccDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Accounts" Select="it.[Title], it.[AccountId]">
                                    </asp:EntityDataSource>
                                 </div>

                               

                             </div>
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';"  />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm"  />
                            </div>
                          
                           </div>
                        </div>   
                    
                 <div class="col-sm-12">
                 <div class="alert  alert-success alert-dismissible fade show" id="myalert" role="alert" runat="server">
                  <span class="badge badge-pill badge-success">Success</span> You successfully enter record.
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                 </div>
                 </div> 

                 <div class="col-sm-12">
                 <div class="alert  alert-danger alert-dismissible fade show" id="myfailalert" role="alert" runat="server">
                  <span class="badge badge-pill badge-danger">Failed</span> Failed to Enter Record.
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                 </div>
                 </div> 
                             
               </div>

             </div>

          </div>
</asp:Content>
