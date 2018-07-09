<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Custom.aspx.cs" Inherits="HafizG.Customers" %>
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
            
           
            var prtGrid2 = document.getElementById('PrintDiv');
            prtGrid2.border = 1;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
           
            prtwin.document.write(prtGrid2.outerHTML);
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
                        <h1>Customers</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">Customers</li>
                            
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
                             <strong class="card-title">Customers</strong>
                            </div>
                            <div class="card-body">
                                 
                               
                               <div class="form-group col-sm-3">
                                 <label for="addTxt" class=" form-control-label">Enter Cell Number</label>
                                 <asp:TextBox ID="cusCellTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                 <small class="form-text text-muted">eg: 0300...</small>
                               </div>

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


                               <div id="PrintDiv" class="form-group col-sm-12">

                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed" DataKeyNames="CustomerId">
                                    <Columns>
                                        <asp:BoundField DataField="CustomerId" HeaderText="Id" ReadOnly="True" SortExpression="CustomerId" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName" />
                                        <asp:BoundField DataField="CellNumber" HeaderText="CellNumber" SortExpression="CellNumber" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />                                    
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />   
                                    </Columns>
                                </asp:GridView>                           

                                   <asp:GridView ID="ctlGridView" runat="server" style="border-collapse: collapse;" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" gridlines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black">
                                   <AlternatingRowStyle BackColor="#CCCCCC" />
                                   <columns>
                                     <asp:boundfield datafield="Particular" HeaderText="Particular" sortexpression="Particular" />
                                     <asp:boundfield datafield="Date" DataFormatString="{0:dd-M-yyyy}" headertext="Date" sortexpression="Date" />
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
                                    <asp:Label ID="tSale" class="badge badge-warning pull-right r-activity" Text ="Total Sale Amount : "  runat="server">
                                     <asp:TextBox ID="tSaleTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </asp:Label>
                                    </div>

                                   <div class="form-group col-sm-3">
                                   <asp:Label ID="Label2" class="badge badge-warning pull-right r-activity" Text ="Total Credit Amount : "  runat="server">
                                     <asp:TextBox ID="tCredTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                   </asp:Label>
                                   </div>

                                   <div class="form-group col-sm-3">
                                    <asp:Label ID="Label1" class="badge badge-warning pull-right r-activity" Text ="Total Recived Amount : "  runat="server">
                                     <asp:TextBox ID="tRecTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </asp:Label>
                                    </div>

                                   <br />
                                  <input id="Button4" type="button" value="Print Record" onclick="PrintGridData()" />

                                   <asp:GridView ID="gw4" CssClass="table table-bordered table-condensed" runat="server">
                                       
                                   </asp:GridView>
                               </div>

                                 <div id ="fundDeposit" runat="server">

                                <div class="form-group col-sm-4">
                                    <label for="addTxt" class="form-control-label">Enter Amount to Deposit </label>
                                 <asp:TextBox ID ="fundTxt" CssClass="form-control" TextMode="Number" min="1" Enabled="false"  runat="server"></asp:TextBox>
                                 <small class="form-text text-muted">eg: 123...</small>
                                    <asp:Label ID="errorLbl" ForeColor="Red" Visible="false" Text="Amount is greater than Previous Negative Balance!!!" runat="server"></asp:Label>
                                </div>

                                
                                <div class="form-group col-sm-4">
                                    <label for="addTxt" class="form-control-label">Select Account </label>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" DataTextField="Title" DataValueField="AccountId" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >

                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-sm-4">
                                    <label for="addTxt" class="form-control-label">Click to Deposit </label>
                                 <asp:Button ID="Deposit_btn" Width="100%" CssClass="btn btn-primary" runat="server" Text="Deposit Fund" OnClick="Deposit_btn_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';"  />
                                </div>

                                <div class="form-group col-sm-12">

                                <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-condensed" >
                                    <Columns>
                                        <asp:BoundField DataField="SaleInvoicId" HeaderText="Id" ReadOnly="True" SortExpression="SaleInvoicId" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" />                                    
                                        <asp:BoundField DataField="BranchId" HeaderText="BranchId" SortExpression="BranchId" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />   
                                        <asp:BoundField DataField="Payable" HeaderText="Payable" SortExpression="Payable" />
                                        <asp:BoundField DataField="Paid" HeaderText="Paid" SortExpression="Paid" />
                                         <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" /> 

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
                             <strong class="card-title">Add Customer</strong>
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
                                <label for="DropDownList" class=" form-control-label">Type</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Walking</asp:ListItem>
                                    <asp:ListItem>Regular</asp:ListItem>
                                    <asp:ListItem>ShopKeeper</asp:ListItem>
                                    </asp:DropDownList>
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
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';" />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm" OnClick="Button2_Click"   />
                            </div>
                          
                           </div>
                    </div>                 
                </div>

            </div>
      </div>
</asp:Content>
