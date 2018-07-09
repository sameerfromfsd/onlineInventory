﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="au.aspx.cs" Inherits="HafizG.au" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                     <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                             <strong class="card-title">Add Users</strong>
                          </div>
                            <div class="card-body">

                                <div class="form-group col-sm-4">
                                <label for="NmTxt" class=" form-control-label">Name</label>
                                <asp:TextBox ID="NmTxt"  runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="PassTxt" class=" form-control-label">Password</label>
                                <asp:TextBox ID="PassTxt" runat="server" required="true" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="EmailTxt" class=" form-control-label">Email Id</label>
                                <asp:TextBox ID="EmailTxt"  runat="server" TextMode="Email" required="true" CssClass="form-control"></asp:TextBox>
                                </div>

                               

                               <div class="form-group col-sm-4">
                                <label for="DesTxt" class=" form-control-label">Designation</label>
                                <asp:TextBox ID="DesTxt"  runat="server" required="true" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="DropDownList" class=" form-control-label">Status</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Deactive</asp:ListItem>                       
                                    </asp:DropDownList>
                                </div>

                                  <div class="form-group col-sm-4">
                                <label for="CellTxt" class=" form-control-label">Contact Number</label>
                                <asp:TextBox ID="CellTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>


                                 <div class="form-group col-sm-4">
                                <label for="AddTxt" class=" form-control-label">Image</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file" />                          
                                </div>

                                <div class="form-group col-sm-4">
                                <label for="DropDownList" class=" form-control-label">Type</label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" DataSourceID="BranchDataSource" DataTextField="Name" DataValueField="StockLocId">
                                                      
                                    </asp:DropDownList>
                                    <asp:EntityDataSource ID="BranchDataSource" runat="server" ConnectionString="name=AdvInvSystemEntities" DefaultContainerName="AdvInvSystemEntities" EnableFlattening="False" EntitySetName="StockLocations" Select="it.[StockLocId], it.[Name]">
                                    </asp:EntityDataSource>
                                </div>


                             </div>
                             <div class="card-footer">
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click"/>
                               <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-danger btn-sm"/>
                            </div>
                          
                           </div>
                        </div>   
    </div>
    </form>
</body>
</html>
