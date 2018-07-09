<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewExpense.aspx.cs" Inherits="HafizG.ViewExpense" %>
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
                        <h1>View Expense
                        </h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">View Expense</li>
                            
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
                                
                               <small class="form-text text-muted">eg: 2018-03-01</small>
                           </div>

                          <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                               <br />
                                <asp:TextBox ID ="datepicker1" CssClass="form-control"  runat="server"></asp:TextBox>
                              
                               <small class="form-text text-muted">eg: 2018-03-01</small>
                            </div>

                          <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">Click to search</label>
                               <br />
                                 <asp:Button ID="Search" Width="100%" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click"   />
                          
                          </div>

                          <div class="form-group col-sm-12">
                          <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed" >
                          
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
