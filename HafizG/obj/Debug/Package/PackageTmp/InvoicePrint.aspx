<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePrint.aspx.cs" Inherits="HafizG.InvoicePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hafiz Jee Food</title>
    <style>
@page { size: auto;  margin: 0mm; height:auto }
        .auto-style1 {
            text-align: left;
        }
        .auto-style2 {
            width: 52px;
        }
        .auto-style3 {
            text-align: left;
            width: 52px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
<table border="0" style="width: auto">
 <tr>
   <th colspan="5" style="font-size:20px;"><u>Hafiz Jee Food Concern</u></th>
 </tr>
 <tr>
   <th colspan="5" style="font-size:12px;">Shop No 25 Tullinton Market, Lahore, PAK<br />www.HafizjeeFood.com<br />Phone # 042-37424629</th>
  </tr>
  <tr>
    <td colspan="5"><hr style="width: auto" /></td>
  </tr>
   <tr>
    <td style="font-size:12px;">Inv# </td>
    <td style="font-size:12px;"><%= invId %></td>
  </tr>
  <tr>
    <td style="font-size:12px;">Cashier:</td>
    <td style="font-size:12px;" ><%= userId %></td>
    <td>&nbsp;</td>
    <td style="font-size:12px;">&nbsp;</td>
    <td style="font-size:12px;"><%= shop %></td>
  </tr>
  <tr>
    <td style="font-size:12px;">Date: </td>
    <td style="font-size:12px;"><%= dt %></td>
    <td>&nbsp;</td>
    <td style="font-size:12px;">Time</td>
    <td style="font-size:12px;"> <%= ti %></td>
    
  </tr>
 
  <tr>
    <td style="font-size:12px;">Name:</td>
    <td style="font-size:12px;"><%= cuName %></td>
    <td>&nbsp;</td>
    <td style="font-size:12px;">Cell :</td>
    <td style="font-size:12px;"><%= cell %></td>
  </tr>

    </table>

    
    <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="230" Font-Size="Small" CssClass="table-bordered table-condensed" style="border-collapse: collapse;" runat="server">
        <Columns>
            <asp:BoundField ControlStyle-Font-Size="Small" DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
            <asp:BoundField ControlStyle-Font-Size="Small" DataField="Quatity" HeaderText="Qnty" SortExpression="Quatity" />
            <asp:BoundField ControlStyle-Font-Size="Small" DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
            <asp:BoundField ControlStyle-Font-Size="Small" DataField="DiscountedRate" HeaderText="Total" SortExpression="DiscountedRate" />
        </Columns>
    </asp:GridView>
  
<table style="width: 228px; height: 118px;" >
   
    <tr>
    <td style="font-size:12px;">Grand Total :</td>
    <td style="font-size:10px; text-align: right;" class="auto-style2"><%= gt %></td>
  </tr>
  <tr>
    <td style="font-size:12px;" class="auto-style1">Discount :</td>
    <td style="font-size:10px;" class="auto-style3"><%= dis %></td>
  </tr>
  <tr>
    <td style="font-size:12px;">Payable :</td>
    <td style="font-size:12px; text-align: left;" class="auto-style2"><%= pa %></td>
  </tr>

  <tr>
    <td style="font-size:12px;">Paid :</td>
    <td style="font-size:12px; text-align: left;" class="auto-style2"><%= pi %></td>
  </tr>

 <tr>
    <td style="font-size:12px;">Customer Balance :</td>
    <td style="font-size:12px; text-align: left;" class="auto-style2"><%= bal %></td>
  </tr>

   
  <tr>
      <td colspan="2" style="font-size:15px; text-align: center;">Thank you for shopping at HFC<br /></td>
  </tr>
    <tr>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="2" style="font-size:8px;">Online Inventory system Contact:0336-2332332 , 0342-4349495 </td>
    </tr>
</table>


    </div>
    </form>

  <script>
     
function PrintGrid()
{  
 
    window.print();
    window.location.replace("saleInvoice.aspx");
}
    </script>

 

<input type="button" onclick="PrintGrid()" id="printbtn1" name="printbtn1" title="Print"/> 
</body>
</html>
