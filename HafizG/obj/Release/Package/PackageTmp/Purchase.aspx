<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="HafizG.Purchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Purchase Invoice</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li><a href="#">Purchase</a></li>
                            <li class="active">Generate Invoice</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
 
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
     <asp:UpdatePanel ID="up1" runat="server">
     <ContentTemplate>

     <div style="text-align:center;">
        <asp:updateprogress id="UpdateProgress1" runat="server" associatedupdatepanelid="up1" dynamiclayout="true">
           <progresstemplate>
              <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
               <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
              </div>
           </progresstemplate>
        </asp:updateprogress>
      </div>

     <div class="content mt-3">
        <div class="row"> 

             <script type="text/javascript">
                     Sys.Application.add_load(function () {
                         jQuery(document).ready(function () {

                             jQuery(".standardSelect").chosen();
                         });
                     });

                   </script>

             <div class="col-xs-6 col-sm-6">
                 <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Generate Purchase Sale Invoice</strong>
                          </div>

                            <div class="card-body">

                             
                                 <div class="form-group col-sm-6">
                                    <label for="spcellTxt" class=" form-control-label">Supplier Cell#</label>
                                    <asp:TextBox ID="spcellTxt"  runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="spcellTxt_TextChanged" ></asp:TextBox>
                                    
                              </div>

                              <div class="form-group col-6">
                                    <label for="spTxt" class=" form-control-label">Supplier Name</label>
                                    <asp:TextBox ID="spnmTxt"  runat="server" CssClass="form-control" ></asp:TextBox>
                                    
                              </div>

                             

                              <div class="form-group col-sm-6">
                                    <label for="spaddTxt" class=" form-control-label">Supplier Address</label>
                                    <asp:TextBox ID="spaddTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                    
                              </div>

                              <div class="form-group col-sm-6">
                                    <label for="spcomTxt" class=" form-control-label">Company</label>
                                    <asp:TextBox ID="spcomTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                    
                              </div>

                             

                              <div class="form-group col-sm-12"> 
                                   <asp:DropDownList ID="DDL" runat="server" class="standardSelect" AppendDataBoundItems = "true" DataSourceID="EntityDataSource1" DataTextField="ProductName" DataValueField="ProductId">
                                      
                                       <asp:ListItem>Select Product</asp:ListItem>
                                      
                                   </asp:DropDownList>
                                   
                                  <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Products" Select="it.[ProductId], it.[ProductName], it.[SalePrice], it.[PurchasePrice]">
                                   </asp:EntityDataSource>
                                   <small class="form-text text-muted">Select Product</small>
                              </div>

                              <div class="form-group col-3">
                                    <label for="qntyTxt" class=" form-control-label">Quantity</label>
                                    <asp:TextBox ID="qntyTxt"  runat="server" CssClass="form-control" TextMode="Number" min="1" ></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required*" ControlToValidate="qntyTxt" ForeColor="Red" ValidationGroup="purchaseValidation"></asp:RequiredFieldValidator>

                              </div>
                              
                            
                              <div class="form-group col-sm-3">
                                    <label for="costTxt" class=" form-control-label">Total Cost</label>
                                    <asp:TextBox ID="costTxt"  runat="server" CssClass="form-control" TextMode="Number" min="1" AutoPostBack="True" OnTextChanged="costTxt_TextChanged" ></asp:TextBox>
                                    <small class="form-text text-muted">ex.1 ~ 25</small>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required*" ControlToValidate="costTxt" ForeColor="Red" ValidationGroup="purchaseValidation"></asp:RequiredFieldValidator>

                              </div>
                               
                                <div class="form-group col-3">
                                    <label for="rateTxt" class=" form-control-label">Rate</label>
                                    <asp:TextBox ID="rateTxt"  runat="server" CssClass="form-control" TextMode="Number" min="1" ></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required*" ControlToValidate="rateTxt" ForeColor="Red" ValidationGroup="purchaseValidation"></asp:RequiredFieldValidator>

                                </div>

                              <div class="form-group col-sm-3">
                                    <label for="ppriceTxt" class=" form-control-label">Sale Price</label>
                                    <asp:TextBox ID="ppriceTxt"  runat="server" CssClass="form-control" TextMode="Number" min="1" OnTextChanged="ppriceTxt_TextChanged" ></asp:TextBox>
                                    <small class="form-text text-muted">ex.1 ~ 25</small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required*" ControlToValidate="ppriceTxt" ForeColor="Red" ValidationGroup="purchaseValidation"></asp:RequiredFieldValidator>

                              </div>
                                
                              <div class="form-group col-sm-3">
                              <asp:Button ID="Button1" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="Button1_Click" ValidationGroup="purchaseValidation" TabIndex="1"/>
                              </div>

                              <div class="col-sm-9">
                               <div id="Asucc" class="alert  alert-success alert-dismissible fade show"  role="alert" runat="server">
                                 <span class="badge badge-pill badge-success">Success</span> Successfully Added !!!
                                  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                                  </button>
                              </div>
                             </div>
                                <div class="col-sm-9">
                                  <div id="Afail" class="alert  alert-danger alert-dismissible fade show"  role="alert" runat="server">
                                  <span class="badge badge-pill badge-danger">Failed</span> Enter All Field!!!
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

                            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"  >
                                
                                <Columns>
                                    <asp:ButtonField ImageUrl="~/images/if_Delete_1493279.png" Text="Button" CommandName="DeletRow"  ButtonType="Image" />
                                    
                                </Columns>
                                
                            </asp:GridView>

                            <div class="form-group col-sm-3">
                                  <label for="brdDropDown" class="form-control-label">Brand</label>
                                  <br />
                                  <asp:DropDownList ID="brdDropDown" CssClass="form-control" runat="server" DataSourceID="BrandDataSource" DataTextField="CompanyName" DataValueField="BrandId">   
                                  </asp:DropDownList>
                                  <asp:EntityDataSource ID="BrandDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Brands" Select="it.[BrandId], it.[CompanyName]">
                                  </asp:EntityDataSource>
                                 <small class="form-text text-muted">eg : K&N's</small>
                              </div>

                            <div class="form-group col-sm-3">
                                    <label for="refTxt" class=" form-control-label">Ref #</label>
                                    <asp:TextBox ID="refTxt"  runat="server" CssClass="form-control" ></asp:TextBox>
                                    <small class="form-text text-muted">ex.156655</small>
                              </div>

                            <div class="form-group col-sm-3">
                                    <label for="amountTxt" class=" form-control-label">Amount</label>
                                    <asp:TextBox ID="amountTxt"  runat="server" CssClass="form-control" ></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                              </div>

                            <div class="form-group col-sm-3">
                                    <label for="paidTxt" class=" form-control-label">Paid</label>
                                    <asp:TextBox ID="paidTxt"  runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <small class="form-text text-muted">ex. 1 ~ 999</small>
                              </div>

                            <div class="form-group col-sm-4">
                                  <label for="brnchDropDown" class="form-control-label">Branch</label>
                                  <br />
                                  <asp:DropDownList ID="brnchDownList" CssClass="form-control" runat="server" DataSourceID="brnchDataSource" DataTextField="Name" DataValueField="StockLocId">   
                                  </asp:DropDownList>
                                  
                                  <asp:EntityDataSource ID="brnchDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[StockLocId], it.[Name]">
                                  </asp:EntityDataSource>
                                  
                                 <small class="form-text text-muted">Branch</small>
                              </div>

                            <div class="form-group col-sm-4">
                                  <label for="CustTypeDropDown" class="form-control-label">Pay Mode</label>
                                  <br />
                                  <asp:DropDownList ID="PMDropdownlist" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PMDropdownlist_SelectedIndexChanged" >
                                      <asp:ListItem></asp:ListItem>
                                      <asp:ListItem>Cash</asp:ListItem>
                                     
                                      
                                  </asp:DropDownList>
                                 <small class="form-text text-muted">eg: Cash / Cheque</small>
                              </div>

                            <div class="form-group col-sm-4">
                                  <label for="AccDropDown" class="form-control-label">Account</label>
                                  <br />
                                  <asp:DropDownList ID="AccDropDownlist" CssClass="form-control" runat="server"  DataTextField="Title" DataValueField="AccountId">   
                                  </asp:DropDownList>
                                 <small class="form-text text-muted">Account #</small>
                              </div>

                            <div id="bk" class="col-lg-12" runat="server">

                              <div class="form-group col-sm-12">
                                    <label for="chqTxt" class=" form-control-label">Cheque Number</label>
                                    <asp:TextBox ID="chqTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                    
                              </div>

                              <div class="form-group col-sm-4">
                                    <label for="bnkTxt" class=" form-control-label">Bank</label>
                                    <asp:TextBox ID="bnkTxt"  runat="server" CssClass="form-control"></asp:TextBox>
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

                             <hr />
                             <div class="form-group col-sm-3">
                             <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Check Out" OnClick="Button2_Click"  ValidationGroup="checkOut" />
                             </div>

                             <div class="form-group col-sm-3">
                              <span class="badge badge-warning pull-right r-activity"> <asp:Label ID="Label2" CssClass="pull-right"  runat="server" Text="Total "></asp:Label></span>
                             </div>

                            <div class="col-sm-12">
                           
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Paid Amount *" ControlToValidate="paidTxt" ForeColor="Red" ValidationGroup="checkOut"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Select Payment Mode *" ControlToValidate="PMDropdownlist" ForeColor="Red" ValidationGroup="checkOut" InitialValue=" "></asp:RequiredFieldValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Account *" ControlToValidate="AccDropDownlist" ForeColor="Red" ValidationGroup="checkOut"></asp:RequiredFieldValidator>
                          <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Valid Amount *" ControlToValidate="ammTxt" ForeColor="Red" ValidationGroup="checkOut"></asp:RequiredFieldValidator>
                            
                            <div class="col-sm-9">
                                  <div id="Div1" class="alert  alert-danger alert-dismissible fade show"  role="alert" runat="server">
                                  <span class="badge badge-pill badge-danger">Failed</span> Add some items!!!
                                  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                                  </button>
                                  </div>
                               </div>
                            <div class="col-sm-9">
                             <div id="Div2" class="alert  alert-success alert-dismissible fade show"  role="alert" runat="server">
                             <span class="badge badge-pill badge-success">Success</span> Invoice Generated !!!
                             <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                             <span aria-hidden="true">&times;</span>
                             </button>
                             </div>
                            </div>
                      </div>
                 </div>
             </div>

        </div>
     </div><!-- .content -->

     <script type="text/javascript">
       $(document).ready(function () {
       $('#<%= spcellTxt.ClientID %>').masked("9999-999999");
         });
     </script>

     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>