﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPurchaseInvoice.aspx.cs" Inherits="HafizG.ViewPurchaseInvoice" %>
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
                        <h1>View Purchase Invoices
                        </h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="Default.aspx">Dashboard</a></li>
                            <li class="active">View Purchase Invoices</li>
                            
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
                             <strong class="card-title">Invoices List</strong>
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
                                 <asp:Button ID="Search" Width="100%" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click"   />
                          
                          </div>

                          <div class="form-group col-sm-12">
                          <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                           <Columns>
                               <asp:BoundField DataField="PurchaseInvoiceId" HeaderText="Id" SortExpression="PurchaseInvoiceId" ReadOnly="true" />
                               <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-M-yyyy}" SortExpression="Date" ReadOnly="true" />
                               <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" ReadOnly="true" />
                               <asp:BoundField DataField="Paid" HeaderText="Paid" SortExpression="Paid" ReadOnly="true" />
                               <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="true" />
                               <asp:BoundField DataField="PaymentMode" HeaderText="P-Mode" SortExpression="PaymentMode" />
                           </Columns>
                          </asp:GridView>  
                                <asp:Label ID="tSale" class="badge badge-warning pull-right r-activity" Text ="Total Paid Amount : "  runat="server">
                                     <asp:TextBox ID="tSaleTxt" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                 </asp:Label>

                          </div>

                          <div class="form-group col-sm-4">
                           <asp:DetailsView ID="DetailsView1"  CssClass="table table-bordered table-condensed" runat="server" Height="50px" Width="100%" AutoGenerateDeleteButton="True">
                           <RowStyle Width="200px" />
                                
                           </asp:DetailsView>
                          </div>

                         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>

                          <div class="form-group col-sm-8">
                          <asp:GridView ID="GridView2" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit">
                              <Columns> 

                                  <asp:TemplateField HeaderText="ID">
                                      <ItemTemplate>
                                          <asp:Label ID="pdId" CssClass="col-form-label" runat="server" Text='<%# Eval("PurchaseDetailId") %>' />
                                      </ItemTemplate>
                                  </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Product">
                                      <ItemTemplate>
                                          
                                          <asp:Label ID="prodNm" runat="server" CssClass="form-control" Text='<%# Eval("ProductName") %>' ></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Qnty">
                                      <ItemTemplate>
                                          <asp:TextBox ID="qnty" Width="70" TextMode="Number" min="0"  CssClass="form-control" runat="server" Text='<%# Eval("Quantity") %>' ></asp:TextBox>
                                            </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Cost">
                                      <ItemTemplate>
                                          <asp:TextBox ID="pTxt" Width="90" TextMode="Number" min="0" CssClass="form-control" runat="server" Text='<%# Eval("Price") %>' />
                                         
                                      </ItemTemplate>
                                  </asp:TemplateField>

                                  
                                
                                   <asp:TemplateField HeaderText="Edit" ShowHeader="false">  
                                    <EditItemTemplate>  
                                     <asp:LinkButton ID="lnkbtnUpdate" runat="server" CausesValidation="true" Text="Update" CommandName="Update"></asp:LinkButton>  
                                     <asp:LinkButton ID="lnkbtnCancel" runat="server" CausesValidation="false" Text="Cancel" CommandName="Cancel"></asp:LinkButton>  
                                    </EditItemTemplate>

                                    <ItemTemplate>  
                                      <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>  
                                    </ItemTemplate>  
                                   </asp:TemplateField>  

                              </Columns>
                          </asp:GridView>
                         </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                       </div>
                               
                         <div class="card-footer">
                         </div>
                       </div>
                           
                </div>              
               </div>
             </div>
          </div>
</asp:Content>
