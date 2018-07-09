<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportSum.aspx.cs" Inherits="HafizG.ReportSum" %>
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
                             <strong class="card-title">Report Duration</strong>
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
                                
                               <small class="form-text text-muted">eg: Shop1 / Factory</small>
                           </div>

                          <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                               <br />
                                <asp:TextBox ID ="datepicker1" CssClass="form-control"  runat="server"></asp:TextBox>
                              
                               <small class="form-text text-muted">eg: Shop1 / Factory</small>
                            </div>
                                
                               <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">Click to search</label>
                               <br />
                                 <asp:Button ID="Search" Width="100%" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click"  />
                               </div> 
                            </div>  
                            <div class="card-footer">
                            </div>
                          </div>
    
                  </div>     

             <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Sale Report </strong>
                             </div>
                            <div class="card-body">
                                <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"  >
                               <AlternatingRowStyle BackColor="#CCCCFF" />
                                     <Columns>
                                    <asp:BoundField DataField="SaleInvoicId" HeaderText="Id" SortExpression="SaleInvoicId" ReadOnly="true" />
                                    
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" ReadOnly="true" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" ReadOnly="true" />
                                    <asp:BoundField DataField="Paid" HeaderText="Paid" SortExpression="Paid" ReadOnly="true" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="true" />
                                    <asp:BoundField DataField="PaymentMode" HeaderText="Mode" SortExpression="Mode" ReadOnly="true" />
                                </Columns>   
                                </asp:GridView>                 
                             </div>
                             <div class="card-footer">
                                 <asp:Label ID="Label3" class="badge badge-warning pull-right r-activity" Text ="Total Recived Amount : "  runat="server">
                                     <asp:TextBox ID="saleTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                 </asp:Label> 
                            </div>
                          
                           </div>
                      </div> 
             
             <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Purchase Report</strong>
                             </div>
                            <div class="card-body">
                                 <asp:GridView ID="GridView2" runat="server"  CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" AllowPaging="True"  >
                          <AlternatingRowStyle BackColor="#CCCCFF" />
                                      <Columns>
                               <asp:BoundField DataField="PurchaseInvoiceId" HeaderText="Id" SortExpression="PurchaseInvoiceId" ReadOnly="true" />
                               <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" ReadOnly="true" />
                               <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" ReadOnly="true" />
                               <asp:BoundField DataField="Paid" HeaderText="Paid" SortExpression="Paid" ReadOnly="true" />
                               <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="true" />
                               <asp:BoundField DataField="PaymentMode" HeaderText="P-Mode" SortExpression="PaymentMode" />
                           </Columns>
                          </asp:GridView>  
                                               
                             </div>
                             <div class="card-footer">
                                <asp:Label ID="tSale" class="badge badge-warning pull-right r-activity" Text ="Total Paid Amount : "  runat="server">
                                     <asp:TextBox ID="purchTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                 </asp:Label>     
                            </div>
                          
                           </div>
                      </div> 
             
             <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Expense</strong>
                             </div>
                            <div class="card-body">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed" DataKeyNames="ExpenseId" AllowPaging="True">
                                    <AlternatingRowStyle BackColor="#CCCCFF" />
                                    <Columns>
                                        <asp:BoundField DataField="ExpenseId" HeaderText="Id" ReadOnly="True" SortExpression="ExpenseId" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" />
                                        <asp:BoundField DataField="Particular" HeaderText="Particular" SortExpression="Particular" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                        <asp:BoundField DataField="Title" HeaderText="Account" SortExpression="Title" />
                                        <asp:BoundField DataField="Name" HeaderText="User" SortExpression="Name" />
                                        <asp:BoundField DataField="Expr1" HeaderText="Branch" SortExpression="Expr1" />
                                    </Columns>
                               
                                </asp:GridView>                            
                             </div>
                             <div class="card-footer">
                                <asp:Label ID="Label2" class="badge badge-warning pull-right r-activity" Text ="Total Expense Amount : "  runat="server">
                                     <asp:TextBox ID="ExpTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                 </asp:Label>
                            </div>
                          
                           </div>
                      </div>   
                    
       
         </div>
       </div>
    </div>
</asp:Content>
