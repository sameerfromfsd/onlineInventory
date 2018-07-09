using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Customers : System.Web.UI.Page
    {
        int fund;
        int flag = 0;
        AdvInvSystemEntities dbobj = new AdvInvSystemEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            if (!IsPostBack)
            {
                DropDownList2.DataSource = dbobj.sp_Accounts_type("InHand");
                DropDownList2.DataBind();
            }
            errorLbl.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                Customer cs = new Customer();
                cs.CustomerName = NmTxt.Text;
                cs.CellNumber = CellTxt.Text;
                cs.Address = AddTxt.Text;
                cs.Balance = Convert.ToInt32(BalTxt.Text);
                cs.Type = DropDownList1.SelectedItem.Value;

                dbobj.Customers.Add(cs);
                dbobj.SaveChanges();

               
            }

            NmTxt.Text = "";
            CellTxt.Text = "";
            AddTxt.Text = "";
            BalTxt.Text = "0";
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            NmTxt.Text = "";
            CellTxt.Text = "";
            AddTxt.Text = "";
            BalTxt.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            string tempcell = cusCellTxt.Text;
            DateTime tdt;
            int tempAmount = 0;
            int tempCredit = 0;
            int tempDebit = 0;
            try
            {
                using(AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                 var   cu = (from c in dbobj.Customers where c.CellNumber == tempcell select c).ToList();
                 GridView1.DataSource = cu;
                 GridView1.DataBind();
                 if (GridView1.Rows.Count != 0)
                 {
                     fundTxt.Enabled = true;

                     int tempCustId = Convert.ToInt32(GridView1.Rows[0].Cells[0].Text);
                     var si = (from s in dbobj.SaleInvoices where s.CustomerId == tempCustId && s.Status != "Cleared" select s).ToList();

                     GridView2.DataSource = si;
                     GridView2.DataBind();

                     if (datepicker.Text != "")
                     {

                         if (datepicker1.Text != "")
                         {
                             tdt = DateTime.Parse(datepicker1.Text);
                         }
                         else
                         {
                             tdt = System.DateTime.Now;
                         }
                         DateTime fdt = DateTime.Parse(datepicker.Text);

                         var cusRep = dbobj.sp_Customer_Report(tempCustId, fdt, tdt).ToList();
                         ctlGridView.DataSource = cusRep;
                         ctlGridView.DataBind();

                         for (int i = 0; i < ctlGridView.Rows.Count; i++)
                         {
                             if (ctlGridView.Rows[i].Cells[0].Text != "Fund Deposit")
                             {
                                 tempAmount += Convert.ToInt32(ctlGridView.Rows[i].Cells[2].Text);
                                
                             }
                             tempCredit += Convert.ToInt32(ctlGridView.Rows[i].Cells[3].Text);
                             tempDebit += Convert.ToInt32(ctlGridView.Rows[i].Cells[4].Text);
                         }
                         tSaleTxt.Text = tempAmount.ToString();
                         tCredTxt.Text = tempCredit.ToString();
                         tRecTxt.Text = tempDebit.ToString();

                         List<int> tempInvId = new List<int>();
                         var tempInv = (from i in dbobj.SaleInvoices where i.CustomerId == tempCustId & i.Date >= fdt & i.Date < tdt select i).ToList();
                         for (int i = 0; i < tempInv.Count; i++)
                         {
                             tempInvId.Add(tempInv[i].SaleInvoicId);
                         }

                         List<saleProduct> sp = new List<saleProduct>();

                         
                         for (int i = 0; i < tempInvId.Count; i++)
                         {
                             int myinvId = tempInvId[i];
                             var saleProductList = dbobj.sp_sale_detail(myinvId).ToList();

                             for (int j = 0; j < saleProductList.Count; j++)
                             {
                                 if (sp.Count >= 1)
                                 {
                                     for (int k = 0; k < sp.Count; k++)
                                     {
                                         if (sp[k].ProductNm == saleProductList[j].ProductName)
                                         {
                                             sp[k].ProductQnty = (Convert.ToInt32(sp[k].ProductQnty) + Convert.ToInt32(saleProductList[j].Quatity));
                                             sp[k].ProductCost = sp[k].ProductQnty * Convert.ToInt32(saleProductList[j].Rate);
                                             flag = 1;
                                             break;  
                                         }

                                     }
                                     if (flag == 0)
                                     {
                                         sp.Add(new saleProduct { ProductNm = saleProductList[j].ProductName, ProductQnty = saleProductList[j].Quatity, ProductCost = saleProductList[j].Rate * saleProductList[j].Quatity });
                                     }
                                     flag = 0;
                                 }
                                 else
                                 {
                                     sp.Add(new saleProduct { ProductNm = saleProductList[j].ProductName, ProductQnty = saleProductList[j].Quatity, ProductCost = saleProductList[j].Rate * saleProductList[j].Quatity });
                                 }
                            }
                         }
                         gw4.DataSource = sp;
                         gw4.DataBind();

                     }
                 }
                
                }
            }

            catch(Exception)
            {
            }
        }

        protected void Deposit_btn_Click(object sender, EventArgs e)
        {
            int acId = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            fund = Convert.ToInt32(fundTxt.Text);
            if (fundTxt.Text != "" || Convert.ToInt32(fundTxt.Text) != 0)
            {
                int tempCustId = Convert.ToInt32(GridView1.Rows[0].Cells[0].Text);
                fund = Convert.ToInt32(fundTxt.Text);
                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                        Customer cu = new Customer();
                        cu = (from c in dbobj.Customers where c.CustomerId == tempCustId select c).FirstOrDefault();
                       
                            cu.Balance = cu.Balance + fund;
                            dbobj.SaveChanges();



                            CustomersAccount ca = new CustomersAccount();
                            ca.CustomerId = tempCustId;
                            ca.Date = System.DateTime.Now;
                            ca.Particular = "Fund Deposit";
                            ca.Amount = fund;
                            ca.Debit = fund;
                            ca.Credit = 0;
                            ca.Status = "Cleared";
                            dbobj.CustomersAccounts.Add(ca);
                            dbobj.SaveChanges();

                            //fund = (Int32)cu.Balance;

                            if (GridView2.Rows.Count >= 1)
                            {
                                for (int i = 0; i <= GridView2.Rows.Count; i++)
                                {
                                    if (fund != 0)
                                    {
                                        int tempSInv = Convert.ToInt32(GridView2.Rows[i].Cells[0].Text);
                                        SaleInvoice si = new SaleInvoice();

                                        si = (from s in dbobj.SaleInvoices where s.SaleInvoicId == tempSInv select s).FirstOrDefault();
                                        int tempBal = si.Payable - si.Paid;
                                        if (fund >= tempBal)
                                        {

                                            si.Paid = si.Payable;

                                            si.Status = "Cleared";
                                            dbobj.SaveChanges();

                                            //cu.Balance = cu.Balance - tempBal;
                                            //dbobj.SaveChanges();

                                            AccountDetail acd = new AccountDetail();
                                            acd.Particular = "Sale inv# " + si.SaleInvoicId;
                                            acd.Amount = tempBal;
                                            acd.Mode = "Inward";
                                            acd.DateTime = System.DateTime.Now;
                                            acd.UserId = Convert.ToInt32(Session["UserId"]);
                                            acd.SaleInvId = si.SaleInvoicId;
                                            acd.Type = "Cash";
                                            acd.AccountId = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                                            dbobj.AccountDetails.Add(acd);
                                            dbobj.SaveChanges();

                                            Account ac = new Account();
                                            ac = (from a in dbobj.Accounts where a.AccountId == acId select a).FirstOrDefault();

                                            ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) + tempBal).ToString();
                                            dbobj.SaveChanges();

                                            CashTran ct = new CashTran();
                                            ct.Particular = "Sale inv# " + si.SaleInvoicId;
                                            ct.Amount = tempBal;
                                            ct.AccountDetailId = acd.AccountsDetailId;

                                            dbobj.CashTrans.Add(ct);
                                            dbobj.SaveChanges();

                                            fund = fund - tempBal;
                                        }
                                        else if (fund > 0 && fund < tempBal)
                                        {
                                            int tempremBal = Convert.ToInt32(fund);


                                            si.Paid = si.Paid + Convert.ToInt32(fund);
                                            dbobj.SaveChanges();

                                            //cu.Balance = cu.Balance - Convert.ToInt32(fund);
                                            //dbobj.SaveChanges();

                                            AccountDetail acd = new AccountDetail();
                                            acd.Particular = "Sale inv# " + si.SaleInvoicId;
                                            acd.Amount = tempremBal;
                                            acd.Mode = "Inward";
                                            acd.DateTime = System.DateTime.Now;
                                            acd.UserId = Convert.ToInt32(Session["UserId"]);
                                            acd.SaleInvId = si.SaleInvoicId;
                                            acd.Type = "Cash";
                                            acd.AccountId = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                                            dbobj.AccountDetails.Add(acd);
                                            dbobj.SaveChanges();

                                            Account ac = new Account();
                                            ac = (from a in dbobj.Accounts where a.AccountId == acId select a).FirstOrDefault();

                                            ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) + tempremBal).ToString();
                                            dbobj.SaveChanges();


                                            CashTran ct = new CashTran();
                                            ct.Particular = "Sale inv# " + si.SaleInvoicId;
                                            ct.Amount = tempremBal;
                                            ct.AccountDetailId = acd.AccountsDetailId;

                                            dbobj.CashTrans.Add(ct);
                                            dbobj.SaveChanges();

                                            fund = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                            Response.Redirect(Request.RawUrl);
                       
                    }
                }
                catch (Exception)
                {

                }
                
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   
}

    public class saleProduct
    {
      public  string ProductNm { get; set; }
      public  int ProductQnty { get; set; }
      public  int ProductCost { get; set; }
    }