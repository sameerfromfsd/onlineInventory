<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facPrint.aspx.cs" Inherits="HafizG.facPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
     <td style="font-size:12px;">Inv#</td>
    <td style="font-size:12px;"> <%= invId %></td>
    
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
  
<table style="width: auto;" >
   
    <tr>
    <td style="font-size:12px;">Grand Total :</td>
     
    <td style="font-size:10px;"><%= gt %></td>
  </tr>
  <tr>
    <td style="font-size:12px;">Discount :</td>
    
    <td style="font-size:10px;"><%= dis %></td>
  </tr>
  <tr>
    <td style="font-size:12px;">Payable :</td>
    
    <td style="font-size:12px;"><%= pa %></td>
  </tr>

 <tr>
    <td style="font-size:12px;">Customer Balance :</td>
    
    <td style="font-size:12px;"><%= bal %></td>
  </tr>

   
  <tr>
      <td style="font-size:15px;">Thank you for shopping at HFC<br />
      </td>
     
  </tr>
</table>


    </div>
    </form>

  <script>

      function PrintGrid() {

          window.print();
          window.location.replace("saleInvoice.aspx");
      }
    </script>

 

<input type="button" onclick="PrintGrid()" id="printbtn1" name="printbtn1" title="Print"/> 
</body>
</html>
