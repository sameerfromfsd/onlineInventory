<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ab.aspx.cs" Inherits="HafizG.ab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div class="col-sm-12">
             
             <table style="width: 100%; border:dotted" border="1">
                 <tr>
                     <th colspan="3" class="auto-style1">
                         <h1>Add Branches</h1>
                     </th>
                 </tr>
                 <tr>
                     <td><label for="NmTxt" class=" form-control-label">Name</label></td>
                     <td>&nbsp;</td>
                     <td><asp:TextBox ID="NmTxt"  runat="server" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><label for="LocTxt" class=" form-control-label">Location</label></td>
                     <td>&nbsp;</td>
                     <td><asp:TextBox ID="LocTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><label for="SupTxt" class=" form-control-label">Supervisor</label></td>
                     <td>&nbsp;</td>
                     <td><asp:TextBox ID="SupTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><label for="NumTxt" class=" form-control-label">Contact Number</label></td>
                     <td>&nbsp;</td>
                     <td><asp:TextBox ID="NumTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-primary btn-sm" OnClick="Button1_Click" /></td>
                     <td>&nbsp;</td>
                     <td><asp:Button ID="Button2" runat="server" Text="Reset anomynous" class="btn btn-danger btn-sm" OnClick="Button2_Click" /></td>
                 </tr>
                 <tr>
                     <td colspan="3"><asp:Label ID="Label1" runat="server" ForeColor="Red" Visible ="false" Text="Label" style="font-weight: 700"></asp:Label></td>
                 </tr>

                 <tr>
                     <td>Set Balance for Shop Account</td>
                     <td><asp:TextBox ID="TextBox1" TextMode="Number" min="0" runat="server"></asp:TextBox></td>
                     <td><asp:Button ID="Button3" runat="server" Text="Update shop" OnClick="Button3_Click" /></td>
                 </tr>

                  <tr>
                     <td>Set Balance for factory Account</td>
                     <td><asp:TextBox ID="TextBox2" TextMode="Number" min="0" runat="server"></asp:TextBox></td>
                     <td><asp:Button ID="Button4" runat="server" Text="Update Fac" OnClick="Button4_Click" /></td>
                 </tr>
                  <tr>
                     
                     <td colspan="3"><asp:Label ID="Label2" runat="server" Visible="False" Text="Label" ForeColor="#FF3300" style="font-weight: 700"></asp:Label></td>

                 </tr>
             </table>       
       </div>   
    </div>
    </form>
</body>
</html>
