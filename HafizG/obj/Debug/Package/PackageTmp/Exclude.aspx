<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exclude.aspx.cs" Inherits="HafizG.Exclude" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <script>
         $(function () {
             $('#<%= fdpTxt.ClientID %>').datepicker({
             maxDate: 0,
             dateFormat: 'yy-mm-dd'

         });
     });

     $(function () {
         $('#<%= tdpTxt.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
         });


         </script>
   
   

                  <div class="col-xs-12 col-sm-12">
                      <div class="card">
                         <div class="card-header">
                         <strong class="card-title">Stock Exclude</strong>
                         </div>
                         <div class="card-body">

                                 <div class="form-group col-sm-3">
                                  <label for="CustTypeDropDown" class="form-control-label">Select Branch</label>
                                  <br />
                                  <asp:DropDownList ID="PMDropdownlist" Class="standardSelect" AppendDataBoundItems = "true" runat="server" AutoPostBack="True"  DataSourceID="LocDataSource" DataTextField="Name" DataValueField="StockLocId" OnSelectedIndexChanged="PMDropdownlist_SelectedIndexChanged" >
                                 <asp:ListItem Selected = "True" Text = "" Value = ""></asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:EntityDataSource ID="LocDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[Name], it.[StockLocId]">
                                  </asp:EntityDataSource>
                                  <small class="form-text text-muted">eg: Shop1 / Factory</small>
                                  </div>

                              <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">From Date</label>
                               <br />
                                <asp:TextBox ID ="fdpTxt" CssClass="form-control"  runat="server"></asp:TextBox>
                                
                               <small class="form-text text-muted">eg: 14/03/2018</small>
                               </div>

                          <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">To Date</label>
                               <br />
                                <asp:TextBox ID ="tdpTxt" CssClass="form-control"  runat="server"></asp:TextBox>
                              
                               <small class="form-text text-muted">eg: 26/04/2018</small>
                            </div>


                          <div class="form-group col-sm-3">
                               <label for="CustTypeDropDown" class="form-control-label">Click to search</label>
                               <br />
                                 <asp:Button ID="Search" Width="100%" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click"  />
                          
                          </div>

                               <div class="col-12">
                                 
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                     <Columns>
                                             
                                        <asp:BoundField DataField="ExId" HeaderText="Id" ReadOnly="True" SortExpression="ExId" />
                                        
                                        <asp:TemplateField HeaderText="Particular">
                                        <ItemTemplate>                          
                                         <asp:Label ID="PartiTxt" Text='<%# Eval("Particular") %>' SortExpression="Particular" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                         <asp:Label ID="ProdNm" Text='<%# Eval("ProductName") %>' SortExpression="ProductName" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qnty">
                                        <ItemTemplate>
                                          <asp:TextBox ID="qntyTxt" DataField="Quantity" CssClass="form-control" Width="50" Text='<%# Eval("Quantity") %>' runat="server" />
                                       </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Cost">
                                        <ItemTemplate>
                                          <asp:TextBox ID="worthTxt" DataField="Worth" CssClass="form-control" Width="80" Text='<%# Eval("Worth") %>' runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                        <asp:Label ID="UserNm" Text='<%# Eval("Name") %>'  SortExpression="Name" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                        <asp:Label ID="Dt" DataField="Date" Text='<%# Eval("Date","{0:dd/MMM/yyyy}") %>'  SortExpression="Date" runat="server" />
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


                           </div>
                          </div>
                     </div> 


</asp:Content>
