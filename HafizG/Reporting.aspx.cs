using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Reporting : System.Web.UI.Page
    {
        public String TSaleInv1;
        public int TSaleAmount1 = 0;
        public int TSalePayable = 0;
        public int TSaleDiscount = 0;
        public int TSalePaid = 0;
        public int TSaleCredit = 0;

        public String TSaleInv2;
        public int TSaleAmount2 = 0;
        public int TSalePayable2 = 0;
        public int TSaleDiscount2 = 0;
        public int TSalePaid2 = 0;
        public int TSaleCredit2 = 0;

        public int TPurchaseInv = 0;
        public int TPurchasePay = 0;
        public int TPurchasePaid = 0;
        public int TPurchaseRemain = 0;

        public int TPurchaseInv1 = 0;
        public int TPurchasePay1 = 0;
        public int TPurchasePaid1 = 0;
        public int TPurchaseRemain1 = 0;

        public int TExpense = 0;
        public int TExpense1 = 0;

        public int Exclude = 0;
        public int Exclude1 = 0;

        public int StockSale = 0;
        public int StockPurch = 0;

        public int StockSale1 = 0;
        public int StockPurch1 = 0;

        public int AccBal = 0;
        public int AccBal1 = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tdp_TextChanged(object sender, EventArgs e)
        {
            DateTime tdt;
            if (datept.Text != "")
            {
                tdt = DateTime.Parse(datept.Text);
            }
            else
            {
                tdt = System.DateTime.Now;
            }
            DateTime fdt = DateTime.Parse(datepf.Text);
            
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    // Sale invoice for shop
                    var si = dbobj.sp_search_saleInvoices(1,fdt, tdt).ToList();
                    TSaleInv1 = si.Count().ToString();
                    for (int i = 0; i < si.Count() ; i++)
                    {
                        TSaleAmount1  += si[i].Amount;
                        TSalePayable  += si[i].Payable;
                        TSaleDiscount += Convert.ToInt32(si[i].Discount);
                           TSalePaid  += si[i].Paid;
                           TSaleCredit = TSalePayable - TSalePaid;
                    }

                    // Sale invoice for Factory
                    var si1 = dbobj.sp_search_saleInvoices(2, fdt, tdt).ToList();
                    TSaleInv2 = si1.Count().ToString();
                    for (int i = 0; i < si1.Count(); i++)
                    {
                        TSaleAmount2 += si1[i].Amount;
                        TSalePayable2 += si1[i].Payable;
                        TSaleDiscount2 += Convert.ToInt32(si1[i].Discount);
                        TSalePaid2 += si1[i].Paid;
                        TSaleCredit2 = TSalePayable2 - TSalePaid2;
                    }

                    var pi = dbobj.sp_search_purchaseInvoices(1, fdt, tdt).ToList();
                    TPurchaseInv = pi.Count();
                    for (int i = 0; i < pi.Count(); i++)
                    {
                        TPurchasePay += pi[i].Amount;
                        TPurchasePaid += pi[i].Paid;
                        TPurchaseRemain = TPurchasePay - TPurchasePaid;
                    }

                    var pi1 = dbobj.sp_search_purchaseInvoices(2, fdt, tdt).ToList();
                    TPurchaseInv1 = pi1.Count();
                    for (int i = 0; i < pi1.Count(); i++)
                    {
                        TPurchasePay1 += pi1[i].Amount;
                        TPurchasePaid1 += pi1[i].Paid;
                        TPurchaseRemain1 = TPurchasePay1 - TPurchasePaid1;
                    }

                    var exp = dbobj.sp_Search_Expense(1, fdt, tdt).ToList();
                    for (int i = 0; i < exp.Count; i++)
                    {
                        TExpense += exp[i].Amount;
                    }

                    var exp1 = dbobj.sp_Search_Expense(2, fdt, tdt).ToList();
                    for (int i = 0; i < exp1.Count; i++)
                    {
                        TExpense1 += exp1[i].Amount;
                    }

                    var exc = dbobj.sp_Search_Exclude(1, fdt, tdt).ToList();
                    for (int i = 0; i < exc.Count; i++)
                    {
                        Exclude += Convert.ToInt32(exc[i].Worth);
                    }

                    var exc1 = dbobj.sp_Search_Exclude(2, fdt, tdt).ToList();
                    for (int i = 0; i < exc1.Count; i++)
                    {
                        Exclude1 += Convert.ToInt32(exc1[i].Worth);
                    }

                    var st = dbobj.sp_finalStockList(1).ToList();
                    for (int i = 0; i < st.Count; i++)
                    {
                        StockSale += st[i].SalePrice * st[i].Quantity;
                        StockPurch += st[i].PurchasePrice * st[i].Quantity;
                    }

                    var st1 = dbobj.sp_finalStockList(2).ToList();
                    for (int i = 0; i < st1.Count; i++)
                    {
                        StockSale1 += st1[i].SalePrice * st1[i].Quantity;
                        StockPurch1 += st1[i].PurchasePrice * st1[i].Quantity;
                    }

                    var acc = (from a in dbobj.Accounts where a.AccountId == 1 select a).First();
                    AccBal = Convert.ToInt32(acc.CurrentBalance);

                    var acc1 = (from a in dbobj.Accounts where a.AccountId == 2 select a).First();
                    AccBal1 = Convert.ToInt32(acc1.CurrentBalance);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}