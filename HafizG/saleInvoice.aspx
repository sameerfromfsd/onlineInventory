<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="saleInvoice.aspx.cs" Inherits="HafizG.saleInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Generate Invoice</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li><a href="#">Sale</a></li>
                            <li class="active">Generate Invoice</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    <script type="text/javascript">
          Sys.Application.add_load(function () {
              jQuery(document).ready(function () {

                  jQuery(".standardSelect").chosen();
              });
          });

                   </script>
     
    
   <div class="content mt-12">
          <div class="row">
              
               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>

                    <div style="text-align:center;">
                       <asp:updateprogress id="UpdateProgress1" runat="server" associatedupdatepanelid="UpdatePanel1" dynamiclayout="true">
                        <progresstemplate>
                            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
                            </div>
                        </progresstemplate>
                       </asp:updateprogress>
                      </div>

                    <div class="col-xs-6 col-sm-6">
             
                      <div class="card">
                        <div class="card-header">
                             <strong class="card-title">Generate Sale Invoice</strong>
                            </div>
                        <div class="card-body">

                              <div class="form-group col-sm-6">
                                    <label for="cuscellTxt" class=" form-control-label">Customer Cell#</label>
                                    <asp:TextBox ID="cuscellTxt"  runat="server" CssClass="form-control" OnTextChanged="cuscellTxt_TextChanged" AutoPostBack="True"></asp:TextBox> 
                              </div>

                              <div class="form-group col-6">
                                    <label for="cusTxt" class=" form-control-label">Customer Name</label>
                                    <asp:TextBox ID="cusTxt"  runat="server" CssClass="form-control"></asp:TextBox> 
                              </div>

                              <div class="form-group col-sm-6">
                                    <label for="addTxt" class=" form-control-label">Customer Address</label>
                                    <asp:TextBox ID="addTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                    
                              </div>

                              <div class="form-group col-6">
                                  <label for="CustTypeDropDown" class="form-control-label">Type</label>
                                  <br />
                                  <asp:TextBox ID="custTypeTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                              </div>

                                <div class="form-group col-sm-6">
                                    <label for="cnicTxt" class=" form-control-label">Customer CNIC</label>
                                    <asp:TextBox ID="cnicTxt"  runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="cnicTxt_TextChanged"></asp:TextBox>
                                    
                              </div>

                                <div class="form-group col-sm-6">
                                    <label for="PreBal" class=" form-control-label">Previous Balance</label>
                                    <asp:TextBox ID="PreBal"  runat="server" Text="0" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    
                              </div>

                              <div class="form-group col-sm-6"> 
                                   <label for="addTxt" class=" form-control-label">Select Product</label>
                                   <asp:DropDownList ID="DDL" runat="server" class="standardSelect" DataSourceID="EntityDataSource1" AppendDataBoundItems = "true" DataTextField="ProductName" DataValueField="ProductId" OnSelectedIndexChanged="DDL_SelectedIndexChanged" AutoPostBack="True">
                                       <asp:ListItem Selected = "True" Text = "" Value = ""></asp:ListItem>
                                   </asp:DropDownList>
                                  
                                   <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Products" Select="it.[ProductId], it.[ProductName], it.[SalePrice], it.[PurchasePrice]">
                                   
                                   </asp:EntityDataSource>
                                   <small class="form-text text-muted">eg: Nuggets</small>
                              </div>
                                <div class="form-group col-sm-6">
                                    <label for="addTxt" class=" form-control-label">Customer Status</label>
                                    <asp:TextBox ID="cusStatusTxt"  runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <small class="form-text text-muted">eg: Defaulter...</small>
                              </div>

                              <div class="form-group col-3">
                                    <label for="qntyTxt" class=" form-control-label">Quantity</label>
                                    <asp:TextBox ID="qntyTxt"  runat="server" Enabled="false" CssClass="form-control" TextMode="Number" min="1" OnTextChanged="qntyTxt_TextChanged" AutoPostBack="True" MaxLength="4"></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required*" ControlToValidate="qntyTxt" ForeColor="Red" ValidationGroup="SaleInvoice"></asp:RequiredFieldValidator>
                              </div>

                              <div class="form-group col-sm-3">
                                    <label for="availTxt" class=" form-control-label">Available</label>
                                    <asp:TextBox ID="availTxt"  runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required*" ControlToValidate="availTxt" ForeColor="Red" ValidationGroup="SaleInvoice"></asp:RequiredFieldValidator>
                             
                              </div>

                              <div class="form-group col-sm-3">
                                    <label for="priceTxt" class=" form-control-label">Price</label>
                                    <asp:TextBox ID="priceTxt"  runat="server" CssClass="form-control" Enabled="True" AutoPostBack="True" OnTextChanged="priceTxt_TextChanged" MaxLength="4" ></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required*" ControlToValidate="priceTxt" ForeColor="Red" ValidationGroup="SaleInvoice"></asp:RequiredFieldValidator>
                             
                              </div>

                              <div class="form-group col-sm-3">
                                    <label for="discTxt" class=" form-control-label">Discount</label>
                                    <asp:TextBox ID="discTxt"  runat="server" Text="0" CssClass="form-control" Enabled="false" TextMode="Number" min="0" AutoPostBack="True" ></asp:TextBox>
                                    <small class="form-text text-muted">ex.1 ~ 25</small>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required*" ControlToValidate="discTxt" ForeColor="Red" ValidationGroup="SaleInvoice"></asp:RequiredFieldValidator>
                             
                              </div>
                                
                              <div class="form-group col-sm-8">
                              <asp:Button ID="Button1" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="Button1_Click" ValidationGroup="SaleInvoice" />
                              </div>

                              <div class="form-group col-sm-3">
                              <span class="badge badge-warning pull-right r-activity"> <asp:Label ID="Label1" CssClass="pull-right"  runat="server" Text="Total "></asp:Label></span>
                              </div>

                              <div class="col-sm-12">
                               <div id="Asucc" class="alert  alert-success alert-dismissible fade show"  role="alert" runat="server">
                                 <span class="badge badge-pill badge-success">Success</span> Successfully Added !!!
                                  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                                  </button>
                              </div>

                              </div>
                            

                            
                            </div>
                      </div>  
                         
                    </div>
                    
                    <div class="col-lg-6">
                     <div class="card">

                       <div class="card-header">
                            <strong class="card-title">Item List</strong>
                        </div>

                       <div class="card-body">

                            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:ButtonField ImageUrl="~/images/if_Delete_1493279.png" Text="Button" CommandName="DeletRow"  ButtonType="Image" />
                                    
                                </Columns>
                            </asp:GridView>
                         
                            <div class="form-group col-sm-3">
                                    <label for="TotaldiscTxt" class=" form-control-label">Discount</label>
                                    <asp:TextBox ID="TotaldiscTxt"  runat="server" CssClass="form-control"  TextMode="Number" min="0" AutoPostBack="True" OnTextChanged="TotaldiscTxt_TextChanged" MaxLength="3"></asp:TextBox>
                                    <small class="form-text text-muted">ex.1 ~ 25</small>
                              </div>

                            <div class="form-group col-sm-3">
                                    <label for="paidTxt" class=" form-control-label">Paid</label>
                                    <asp:TextBox ID="paidTxt"  runat="server" CssClass="form-control"  TextMode="Number" min="0" AutoPostBack="True" OnTextChanged="paidTxt_TextChanged" MaxLength="7"></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                              </div>

                           <div class="form-group col-sm-3">
                                <label for="paidTxt" class=" form-control-label">Check Out</label>
                                   
                              <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Check Out" OnClick="Button2_Click" ValidationGroup="chValidator" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';" />
                            </div>



                            <div id="bk" class="card-body" runat="server">

                              <div class="form-group col-sm-12">
                                    <label for="chqTxt" class=" form-control-label">Cheque Number</label>
                                    <asp:TextBox ID="chqTxt"  runat="server" CssClass="form-control" ></asp:TextBox>           
                              </div>
                              <div class="form-group col-sm-4">
                                    <label for="bnkTxt" class=" form-control-label">Bank</label>
                                    <asp:TextBox ID="bnkTxt"  runat="server" CssClass="form-control" ></asp:TextBox>            
                              </div>
                              <div class="form-group col-sm-4">
                                    <label for="mbTxt" class=" form-control-label">Made By</label>
                                    <asp:TextBox ID="mbTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group col-sm-4">
                                    <label for="ammTxt" class=" form-control-label">Amount</label>
                                    <asp:TextBox ID="ammTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                             </div>

                         </div>

                       <div class="card-body">

                            <div class="form-group col-sm-3">
                              <span class="badge badge-warning pull-right r-activity"> <asp:Label ID="Label2" CssClass="pull-right"  runat="server" Text="Total "></asp:Label></span>
                            </div>

                            <div class="form-group col-sm-3">
                              <span class="badge badge-warning pull-right r-activity"> <asp:Label ID="Label3" CssClass="pull-right"  runat="server" Text="Payable "></asp:Label></span>
                            </div>

                            <div class="form-group col-sm-3">
                              <span class="badge badge-warning pull-right r-activity"> <asp:Label ID="Label4" CssClass="pull-right"  runat="server" Text="Return"></asp:Label></span>
                            </div>

                           

                            <div class="col-sm-12">
                                  <div id="Afail" class="alert  alert-danger alert-dismissible fade show"  role="alert" runat="server">
                                  <span class="badge badge-pill badge-danger">Failed</span> Enter All Field or Valid Ammount!!!
                                  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                                  </button>
                                  </div>
                                </div>
                           <br />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Discount Amount Required *" ControlToValidate="TotaldiscTxt" ForeColor="Red" ValidationGroup="chValidator"></asp:RequiredFieldValidator>
                         <br />         
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Paid Amount Required *" ForeColor="Red" ValidationGroup="chValidator" ControlToValidate="paidTxt"></asp:RequiredFieldValidator>
                         <br />
                        
                       </div>

                          

                     </div>
                    </div>

                  </ContentTemplate>
                </asp:UpdatePanel> 
              
              </div>
       
          </div><!-- .content -->
           
</asp:Content>
