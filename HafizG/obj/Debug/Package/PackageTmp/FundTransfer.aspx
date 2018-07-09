<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FundTransfer.aspx.cs" Inherits="HafizG.FundTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#<%= datepicker.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd'  });
        });

        $(function () {
            $('#<%= datepicker1.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
        });


        $(function () {
            $('#<%= dp1.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
         });

         $(function () {
             $('#<%= dp2.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
         });

        $(function () {
            $('#<%= dp3.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
         });

         $(function () {
             $('#<%= dp4.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
         });
        
      </script>   

      <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Fund Transfer</h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li><a href="#">Admin Setting</a></li>
                            <li class="active">Fund Transfer</li>
                            
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
                             <strong class="card-title">Add Funds</strong>
                            </div>
                            <div class="card-body">


                                <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label" >From Date</label>
                                <br />
                                <asp:TextBox ID ="dp3" CssClass="form-control"  runat="server"></asp:TextBox>
                                <small class="form-text text-muted">eg: 02-May-2018</small>
                               </div>

                               <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                                <br />
                                <asp:TextBox ID ="dp4" CssClass="form-control"  runat="server"></asp:TextBox>
                                <small class="form-text text-muted">eg: 02-May-2018</small>
                               </div>

                               <div class="form-group col-sm-3">
                                <label for="addTxt" class="form-control-label">Click to search </label>
                                <br />
                                <asp:Button ID="Button8" runat="server" Text="Search..." CssClass="btn btn-primary" OnClick="Button8_Click" />
                                <small class="form-text text-muted">...</small>
                               </div>

                               <div class="form-group col-sm-12">

                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed">
                                    <Columns>
                                        <asp:BoundField DataField="Particular" HeaderText="Particular" SortExpression="Particular" />
                                       
                                        <asp:BoundField DataField="Title" HeaderText="Account" SortExpression="Title" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                        <asp:BoundField DataField="Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date" SortExpression="Date" />
                                        <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />                                    
                                        <asp:BoundField DataField="Name" HeaderText="User" SortExpression="Name" />
                                        <asp:BoundField DataField="BranchNm" HeaderText="Branch" SortExpression="BranchNm" />  
                                          
                                    </Columns>
                                </asp:GridView>                           

                            </div>




                                 <div class="form-group col-sm-4">
                                <label for="PartTxt" class=" form-control-label">Particular</label>
                                <asp:TextBox ID="PartTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="AmTxt" class=" form-control-label">Amount</label>
                                <asp:TextBox ID="AmTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-4">
                                <label for="DropDownList" class=" form-control-label">Type</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" DataSourceID="AccDataSource1" DataTextField="Title" DataValueField="AccountId">
                                   
                                    </asp:DropDownList>
                                    <asp:EntityDataSource ID="AccDataSource1" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Accounts" Select="it.[AccountId], it.[Title]">
                                    </asp:EntityDataSource>
                                </div>

                                <div id="addFundError" runat="server" class="col-sm-12" visible="false">
                                 <div class="alert  alert-danger alert-dismissible fade show" role="alert">
                                  <span class="badge badge-pill badge-danger">Fail</span> Amount required to complete transection.
                                   <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                   <span aria-hidden="true">&times;</span>
                                   </button>
                                 </div>
                                </div>

                             </div>

                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';"  />
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm" OnClick="Button2_Click"   />
                            </div>
                          
                           </div>
                      </div>  

                <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Transfer Funds</strong>
                          </div>
                            <div class="card-body">
                                <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label" >From Date</label>
                                <br />
                                <asp:TextBox ID ="dp1" CssClass="form-control"  runat="server"></asp:TextBox>
                                <small class="form-text text-muted">eg: 02-May-2018</small>
                               </div>

                               <div class="form-group col-sm-3">
                                <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                                <br />
                                <asp:TextBox ID ="dp2" CssClass="form-control"  runat="server"></asp:TextBox>
                                <small class="form-text text-muted">eg: 02-May-2018</small>
                               </div>

                               <div class="form-group col-sm-3">
                                <label for="addTxt" class="form-control-label">Click to search </label>
                                <br />
                                <asp:Button ID="Button6" runat="server" Text="Search..." CssClass="btn btn-primary" OnClick="Button6_Click"/>
                                <small class="form-text text-muted">...</small>
                               </div>

                               <div class="form-group col-sm-12">

                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed">
                                    <Columns>
                                        <asp:BoundField DataField="Particular" HeaderText="Particular" SortExpression="Particular" />
                                        <asp:BoundField DataField="FromAccount" HeaderText="From" SortExpression="FromAccount" />
                                        <asp:BoundField DataField="ToAccount" HeaderText="To" SortExpression="ToAccount" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                        <asp:BoundField DataField="Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date" SortExpression="Date" />
                                        <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />                                    
                                        <asp:BoundField DataField="Name" HeaderText="Branch" SortExpression="Name" />
                                        <asp:BoundField DataField="Expr1" HeaderText="User" SortExpression="Expr1" />  
                                          
                                    </Columns>
                                </asp:GridView>                           

                            </div>

                                <div class="form-group col-sm-3">
                                <label for="TpartTxt" class=" form-control-label">Particular</label>
                                <asp:TextBox ID="TpartTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-3">
                                <label for="TAmTxt" class=" form-control-label">Amount</label>
                                <asp:TextBox ID="TAmTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-3">
                                <label for="DropDownList" class=" form-control-label">From</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" DataSourceID="AccDataSource1" DataTextField="Title" DataValueField="AccountId">
                                   
                                    </asp:DropDownList>
                                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Accounts" Select="it.[AccountId], it.[Title]">
                                    </asp:EntityDataSource>
                                </div>

                                <div class="form-group col-sm-3">
                                <label for="DropDownList" class=" form-control-label">TO</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" DataSourceID="AccDataSource1" DataTextField="Title" DataValueField="AccountId">
                                   
                                    </asp:DropDownList>
                                    <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Accounts" Select="it.[AccountId], it.[Title]">
                                    </asp:EntityDataSource>
                                </div>

                                <div id="fundTransError" runat="server" class="col-sm-12">
                                 <div class="alert  alert-danger alert-dismissible fade show" role="alert">
                                  <span class="badge badge-pill badge-danger">Fail</span> You cannot select same accounts to transfer fund and Amount required to complete transection.
                                   <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                   <span aria-hidden="true">&times;</span>
                                   </button>
                                 </div>
                                </div>

                             </div>
                             <div class="card-footer">
                               <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button3_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';"   />
                               <asp:Button ID="Button4" runat="server" Text="Reset" class="btn btn-danger btn-sm" OnClick="Button4_Click" />
                            </div>
                          
                           </div>
                        </div>   

                <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Withdraw Funds</strong>
                          </div>
                            <div class="card-body">

                                <div class="form-group col-sm-3">
                                <label for="TpartTxt" class=" form-control-label">Particular</label>
                                <asp:TextBox ID="wPartTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="form-group col-sm-3">
                                <label for="TAmTxt" class=" form-control-label">Amount</label>
                                <asp:TextBox ID="wAmTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-3">
                                <label for="DropDownList" class=" form-control-label">From</label>
                                <asp:DropDownList CssClass="form-control" ID="WDAccDropDownList" runat="server" DataSourceID="AccDataSource1" DataTextField="Title" DataValueField="AccountId">
                                 </asp:DropDownList>
                                 <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="Accounts" Select="it.[AccountId], it.[Title]">
                                 </asp:EntityDataSource>
                                </div>              

                             </div>
                            <div class="card-footer">
                               <asp:Button ID="Button5" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button5_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait...';"  />
                              </div>
                          
                        </div>
                </div>   

                <div class="col-sm-12">
                    <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Withdraw Detail</strong>
                            </div>
                            <div class="card-body">

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
                                <asp:Button ID="Button7" runat="server" Text="Search..." CssClass="btn btn-primary" OnClick="Button7_Click" />
                                <small class="form-text text-muted">...</small>
                               </div>

                               <div class="form-group col-sm-12">
                                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed">
                                    <Columns>
                                        <asp:BoundField DataField="Particular" HeaderText="Particular" SortExpression="Particular" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                        <asp:BoundField DataField="Date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date" SortExpression="Date" />
                                        <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />                                    
                                        <asp:BoundField DataField="Name" HeaderText="User" SortExpression="Name" />
                                        <asp:BoundField DataField="Expr1" HeaderText="Branch" SortExpression="Expr1" />  
                                        <asp:BoundField DataField="Title" HeaderText="Account" SortExpression="Title" />   
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
