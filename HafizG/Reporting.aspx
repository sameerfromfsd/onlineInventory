<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporting.aspx.cs" Inherits="HafizG.Reporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            font-weight: normal;
        }
        .auto-style4 {
            text-align: left;
        }
    </style>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
      <link rel="stylesheet" href="/resources/demos/style.css"/>
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
      <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
      <script src="assets/js/vendor/jquery-2.1.4.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js"></script>
      <script src="assets/js/plugins.js"></script>
      <script src="assets/js/main.js"></script>


      <link rel="stylesheet" href="assets/css/normalize.css"/>
      <link rel="stylesheet" href="assets/css/bootstrap.min.css"/>

     <script>

         $(function () {
             $('#<%= datepf.ClientID %>').datepicker({
                maxDate: 0,
                dateFormat: 'yy-mm-dd'

            });
        });

        $(function () {
            $('#<%= datept.ClientID %>').datepicker({ maxDate: 0, dateFormat: 'yy-mm-dd' });
        });

      </script> 
</head>
<body>

    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td colspan="2"><h1 style="text-align: center">Hafiz Jee Food Concern</h1>
                    <div>
                        <h3 style="text-align: center">Day End Report </h3>
                    </div>
                    <div class="auto-style2">
                        
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    </div>
                                 <asp:TextBox ID="datepf"  runat="server" ></asp:TextBox>
                                 <asp:TextBox ID="datept" runat="server" OnTextChanged="tdp_TextChanged" AutoPostBack="True"></asp:TextBox>
                                
                            </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h3 class="auto-style3"><strong>Sale Report (Shop) </strong></h3>

                </td>
            </tr>
            <tr>
                <td>- Total Number of Invoices</td>
                <td class="auto-style4"><%= TSaleInv1 %> </td>
            </tr>
            <tr>
                <td>- Total Amount without discount</td>
                <td><%= TSaleAmount1 %> </td>
            </tr>
            <tr>
                <td>- Total Amount with discount</td>
                <td><%= TSalePayable %> </td>
            </tr>
            <tr>
                <td>- Total discount given</td>
                <td><%= TSaleDiscount %> </td>
            </tr>
            <tr>
                <td>- Total Sale on Cash </td>
                <td><%= TSalePaid %> </td>
            </tr>
            <tr>
                <td>- Total Sale on Credit</td>
                <td><%= TSaleCredit %> </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
          
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h3 class="auto-style3"><strong>Sale Report (Factory)</strong></h3></td>
                <td>&nbsp;</td>
          
            </tr>
             <tr>
                <td>- Total Number of Invoices</td>
                <td><%= TSaleInv2 %></td>
          
            </tr>
             <tr>
                <td>- Total Amount without discount</td>
                <td><%= TSaleAmount2 %></td>
          
            </tr>
             <tr>
                <td>- Total Amount with discount</td>
                <td><%= TSalePayable2 %></td>
          
            </tr>
             <tr>
                <td>- Total discount given</td>
                <td><%= TSaleDiscount2 %></td>
            </tr>
            <tr>
                <td>- Total Sale on Cash </td>
                <td><%= TSalePaid2 %></td>
            </tr>
            <tr>
                <td>- Total Sale on Credit</td>
                <td><%= TSaleCredit2 %></td>
            </tr>
           
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h3><strong>Purchase Report(Shop)</strong></h3>
                </td>
            </tr>
            <tr>
                <td>- Total Number of invoices   </td>
                <td><%= TPurchaseInv %></td>
            </tr>
            <tr>
                <td>- Total Payable </td>
                <td><%= TPurchasePay %></td>
            </tr>
            <tr>
                <td>- Total Paid</td>
                <td><%= TPurchasePaid %></td>
            </tr>
            <tr>
                <td>- Remaining to be paid</td>
                <td><%= TPurchaseRemain %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2">
                    <h3><strong>Purchase Report(Factory)</strong></h3>
                </td>
            </tr>
            <tr>
                <td>- Total Number of invoices   </td>
                <td><%= TPurchaseInv1 %></td>
            </tr>
            <tr>
                <td>- Total Payable </td>
                <td><%= TPurchasePay1 %></td>
            </tr>
            <tr>
                <td>- Total Paid</td>
                <td><%= TPurchasePaid1 %></td>
            </tr>
            <tr>
                <td>- Remaining to be paid</td>
                <td><%= TPurchaseRemain1 %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <h3 class="auto-style2"><strong>Expense Report</strong></h3>
                </td>
            </tr>
            <tr>
                <td>- Expense Summary for shop</td>
                <td><%= TExpense %></td>
            </tr>
            <tr>
                <td>- Expense Summary for factory </td>
                <td><%= TExpense1 %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h3><strong>Exclude Report</strong></h3>
                </td>
            </tr>
            <tr>
                <td>- Exclude From Shop</td>
                <td><%= Exclude %></td>
            </tr>
            <tr>
                <td>- Exclude From Factory </td>
                <td><%= Exclude1 %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    
                    <h3><strong>Stock Report (Current Status)</strong></h3>
                    
                </td>
            </tr>
            <tr>
                <td>- Stock value on Purchase Price (Shop)</td>
                <td><%= StockPurch %></td>
            </tr>
            <tr>
                <td>-Stock value on Sale Price (Shop)</td>
                <td><%= StockSale %></td>
            </tr>
            <tr>
                <td>- Stock value on Purchase Price (Factory)</td>
                <td><%= StockPurch1 %></td>
            </tr>
            <tr>
                <td>- Stock value on Sale Price (Factory)</td>
                <td><%= StockSale1 %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <h3><strong>Account (Current Status)</strong></h3>
                 </td>
            </tr>
            <tr>
                <td>- Current balance at Shop </td>
                <td><%= AccBal %></td>
            </tr>
            <tr>
                <td>- Current balance at Factory</td>
                <td><%= AccBal1 %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Report Generated by :&nbsp; Sharry &nbsp;</td>
            </tr>
            </table>
    </div>
    </form>
    <script>

        function PrintGrid() {

            window.print();
            window.location.replace("Default.aspx");
        }
    </script>

 

<input type="button" onclick="PrintGrid()" id="printbtn1" name="printbtn1" title="Print"/> 
</body>
</html>
