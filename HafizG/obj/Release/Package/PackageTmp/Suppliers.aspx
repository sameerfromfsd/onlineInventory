<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="HafizG.Suppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
         $(function () {
             $('#<%= datepicker.ClientID %>').datepicker({
                maxDate: 0,
                dateFormat: 'yy-mm-dd'

            });
        });

        $(function () {
            $('#<%= datepicker1.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
        });

        function PrintGridData() {

            //var prtGrid1 = document.getElementById('ReportHead');
            //prtGrid.border = 1;
            var prtGrid = document.getElementById('<%=ctlGridView.ClientID %>');
            prtGrid.border = 1;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
           
            //prtwin.document.write(prtGrid1.outerHTML);
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
      </script>   
    <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Suppliers</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">Suppliers</li>
                            
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
                             <strong class="card-title">Supplier</strong>
                            </div>
                            <div class="card-body">
                                  
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true" DataSourceID="SupplierDataSource" CssClass="table table-bordered table-condensed" DataKeyNames="SupplierId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="SupplierId" HeaderText="Id" ReadOnly="True" SortExpression="SupplierId" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="CellNumber" HeaderText="Number" SortExpression="CellNumber" />
                                        <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />                                      
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
                                        
                                    </Columns>
                                </asp:GridView>                            
                                <asp:EntityDataSource ID="SupplierDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Suppliers">
                                </asp:EntityDataSource>
                            </div>
                               
                            <div class="card-footer">
                            </div>
                          </div>
                           
                        </div>  
                    
                    <div class=" col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Supplier</strong>
                            </div>
                            <div class="card-body">
        
                                 <div id ="fundDeposit" runat="server">

                                 <div id="ReportDiv" runat="server" class="form-group col-sm-12">

                                     <table id="ReportHead" class="table table-bordered table-condensed" style="border:1px solid">
                                         <tr>
                                             <td colspan="6" style="text-align:center"><b>SUPPLIER REPORT</b></td>
                                         </tr>
                                         <tr>
                                             <td colspan="3" style="text-align:center">From : <%= fdt %></td>
                                              <td colspan="3" style="text-align:center">To : <%= tdt %></td>
                                         </tr>
                                         <tr>
                                             <th>Id</th>
                                             <th>Name</th>
                                             <th>Cell</th>
                                             <th>Company</th>
                                             <th>Address</th>
                                             <th>Balance</th>
                                         </tr>
                                         <tr>
                                             <td><%= id %></td>
                                             <td><%= supNm %></td>
                                             <td><%= cellNum %></td>
                                             <td><%= compNm %></td>
                                             <td><%= address %></td>
                                             <td><%= balance %></td>
                                         </tr>
                                     </table>
                                  <asp:GridView ID="ctlGridView" runat="server" style="border-collapse: collapse;" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" gridlines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <columns>
                                      <asp:boundfield datafield="Particular" HeaderText="Particular" sortexpression="Particular" />
                                      <asp:boundfield datafield="Date" DataFormatString="{0:dd-MMM-yyyy}" headertext="Date" sortexpression="Date" />
                                      <asp:boundfield datafield="Amount" headertext="Total Amount" />
                                      <asp:BoundField DataField="Credit" HeaderText="Credit Amount"/>
                                      <asp:BoundField DataField="Debit" HeaderText="Debit Amount" />
                                   </columns>
                                   <FooterStyle BackColor="#CCCCCC" />
                                   <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                   <SortedAscendingHeaderStyle BackColor="#808080" />
                                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                   <SortedDescendingHeaderStyle BackColor="#383838" />
                                   </asp:GridView>

                               <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label" >From Date</label>
                                <br />
                                <asp:TextBox ID ="datepicker" CssClass="form-control"  runat="server"></asp:TextBox>
                                <small class="form-text text-muted">eg: 02-May-2018</small>
                               </div>

                               <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                                <br />
                                <asp:TextBox ID ="datepicker1" CssClass="form-control"  runat="server"></asp:TextBox>
                                <small class="form-text text-muted">eg: 02-May-2018</small>
                               </div>

                                <div class="form-group col-sm-3">
                                <label for="addTxt" class="form-control-label">Click to search </label>
                                <br />
                                <asp:Button ID="Button3" runat="server" Text="Search..." CssClass="btn btn-primary" OnClick="Button3_Click" />
                                <small class="form-text text-muted">...</small>
                               </div>

                                  <input id="Button4" type="button" value="Print Record" onclick="PrintGridData()" />

                                 </div>

                                <div class="form-group col-sm-4">
                                 <label for="addTxt" class="form-control-label">Enter Amount to Deposit </label>
                                 <asp:TextBox ID ="fundTxt" CssClass="form-control" TextMode="Number" min="1" Enabled="false"  runat="server"></asp:TextBox>
                                 <small class="form-text text-muted">eg: 123...</small>
                                </div>

                                <div class="form-group col-sm-4">
                                 <label for="addTxt" class="form-control-label">Click to Deposit </label>
                                 <asp:Button ID="Deposit_btn" Width="100%" CssClass="btn btn-primary" runat="server" Text="Deposit Fund" OnClick="Deposit_btn_Click"  />
                                </div>

                                <div class="form-group col-sm-4">
                                    <label for="addTxt" class="form-control-label">Select Account </label>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" DataTextField="Title" DataValueField="AccountId" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-sm-12">
                                  <asp:GridView ID="GridView3" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-condensed" >
                                    <Columns>
                                        <asp:BoundField DataField="PurchaseInvoiceId" HeaderText="Id" ReadOnly="True" SortExpression="PurchaseInvoiceId" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" />                                    
                                        <asp:BoundField DataField="StockLocId" HeaderText="BranchId" SortExpression="StockLocId" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />   
                                       
                                        <asp:BoundField DataField="Paid" HeaderText="Paid" SortExpression="Paid" />
                                        <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" /> 
                                        <asp:BoundField DataField="SupplierId" HeaderText="S-Id" SortExpression="SupplierId" /> 
                                   </Columns>
                                  </asp:GridView>                           
                                </div> 
                                          
                               </div>
                               </div>
                        
                            <div class="card-footer">
                            
                        </div>
                        </div>
                   </div>   

                     
   

                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Supplier</strong>
                          </div>
                            <div class="card-body">

                                <div class="form-group col-sm-4">
                                <label for="NmTxt" class=" form-control-label">Name</label>
                                <asp:TextBox ID="NmTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="CellTxt" class=" form-control-label">Contact Number</label>
                                <asp:TextBox ID="CellTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="CompTxt" class=" form-control-label">Company</label>
                                <asp:TextBox ID="CompTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-8">
                                <label for="AddTxt" class=" form-control-label">Address</label>
                                <asp:TextBox ID="AddTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="BalTxt" class=" form-control-label">Balance</label>
                                <asp:TextBox ID="BalTxt" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
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
