using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Suppliers : System.Web.UI.Page
    {
        int fund;
        int SupId;
        int PurcInv;
        int AccId;

        public int id;
        public string supNm;
        public string cellNum;
        public string compNm;
        public string address;
        public int balance;
        public DateTime tdt;
        public DateTime fdt;

        AdvInvSystemEntities dbobj = new AdvInvSystemEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            DropDownList2.DataSource = dbobj.sp_Accounts_type("InHand");
            DropDownList2.DataBind();
            if (!IsPostBack)
            {
                ReportDiv.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                Supplier sp = new Supplier();

                sp.Name = NmTxt.Text;
                sp.CellNumber = CellTxt.Text;
                sp.Address = AddTxt.Text;
                sp.Company = CompTxt.Text;
                sp.Balance = Convert.ToInt32(BalTxt.Text);

                dbobj.Suppliers.Add(sp);
                dbobj.SaveChanges();
            }

            NmTxt.Text = "";
            CellTxt.Text = "";
            AddTxt.Text = "";
            CompTxt.Text = "";
            BalTxt.Text = "0";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            NmTxt.Text = "";
            CellTxt.Text = "";
            AddTxt.Text = "";
            CompTxt.Text = "";
            BalTxt.Text = "0";
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDiv.Visible = false;
            
            int tempId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            ViewState["SupId"] = tempId;
            SupId = tempId;
            fundTxt.Enabled = true;

            id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            supNm = GridView1.SelectedRow.Cells[2].Text;
            cellNum = GridView1.SelectedRow.Cells[3].Text;
            compNm = GridView1.SelectedRow.Cells[4].Text;
            address = GridView1.SelectedRow.Cells[5].Text;
            balance = Convert.ToInt32(GridView1.SelectedRow.Cells[6].Text);
            try
            {
                using (dbobj)
                {
                    var pi = (from p in dbobj.PurchaseInvoices where p.SupplierId == tempId && p.Status != "Cleared" select p).ToList();
                    GridView3.DataSource = pi;
                    GridView3.DataBind();

                    ReportDiv.Visible = true; 
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Deposit_btn_Click(object sender, EventArgs e)
        {
            fund = Convert.ToInt32(fundTxt.Text);
            AccId = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            SupId = Convert.ToInt32(ViewState["SupId"]);
            if (fundTxt.Text != "" && fund != 0)
            {
                using (dbobj)
                {
                    Supplier sp = new Supplier();

                    sp = (from s in dbobj.Suppliers where s.SupplierId == SupId select s).FirstOrDefault();
                    sp.Balance += fund;
                    dbobj.SaveChanges();

                    SupplierAccount spa = new SupplierAccount();
                    spa.SupplierId = sp.SupplierId;
                    spa.Particular = "Fund Deposit";
                    spa.Credit = 0;
                    spa.Amount = fund;
                    spa.Debit = fund;
                    spa.Date = System.DateTime.Now;
                    spa.AccountId = AccId;
                    spa.UserId = Convert.ToInt32(Session["UserId"]);

                    dbobj.SupplierAccounts.Add(spa);
                    dbobj.SaveChanges();

                    //fund = sp.Balance;

                    Account ac = new Account();
                    ac = (from a in dbobj.Accounts where a.AccountId == AccId select a).FirstOrDefault();


                    if (GridView3.Rows.Count >= 1)
                    {
                        for (int i = 0; i < GridView3.Rows.Count; i++)
                        {
                            PurcInv = Convert.ToInt32(GridView3.Rows[i].Cells[0].Text);
                            PurchaseInvoice pi = new PurchaseInvoice();

                            pi = (from p in dbobj.PurchaseInvoices where p.PurchaseInvoiceId == PurcInv select p).FirstOrDefault();


                            if (fund > 0)
                            {
                                if (fund >= pi.Balance)
                                {
                                   

                                  /*  SupplierAccount spa1 = new SupplierAccount();
                                    spa1.SupplierId = sp.SupplierId;
                                    spa1.Particular = "Payment for Purchase#" + PurcInv;
                                    spa1.Credit = pi.Balance;
                                    spa1.Debit = 0;
                                    spa1.Date = System.DateTime.Now;
                                    spa1.AccountId = AccId;
                                    spa1.UserId = Convert.ToInt32(Session["UserId"]);

                                    dbobj.SupplierAccounts.Add(spa);
                                    dbobj.SaveChanges();
                                    */
                                    int accb = Convert.ToInt32(ac.CurrentBalance);
                                    int newbal = accb - fund;
                                    ac.CurrentBalance = newbal.ToString();
                                    dbobj.SaveChanges();

                                    AccountDetail acd = new AccountDetail();
                                    acd.Particular = "Purchase Inv# " + PurcInv;
                                    acd.Amount = fund;
                                    acd.Mode = "Outward";
                                    acd.DateTime = System.DateTime.Now;
                                    acd.AccountId = AccId;
                                    acd.UserId = Convert.ToInt32(Session["UserId"]);
                                    acd.Type = "Cash";
                                    acd.PurchInvId = PurcInv;

                                    dbobj.AccountDetails.Add(acd);
                                    dbobj.SaveChanges();

                                    //sp.Balance -= pi.Balance;
                                    //dbobj.SaveChanges();

                                    CashTran ct = new CashTran();
                                    ct.Particular = "Purchase Inv# " + PurcInv;
                                    ct.Amount = pi.Balance;
                                    ct.AccountDetailId = acd.AccountsDetailId;

                                    dbobj.CashTrans.Add(ct);
                                    dbobj.SaveChanges();

                                    fund = fund - pi.Balance;

                                    pi.Paid = pi.Amount;
                                    pi.Balance = 0;
                                    pi.Status = "Cleared";


                                    dbobj.SaveChanges();
                                }

                                else if (fund < pi.Balance)
                                {
                                    pi.Paid = pi.Paid + fund;
                                    pi.Balance = pi.Balance - fund;

                                    dbobj.SaveChanges();

                                   /* SupplierAccount spa1 = new SupplierAccount();
                                    spa1.SupplierId = sp.SupplierId;
                                    spa1.Particular = "Payment for Purchase#" + PurcInv;
                                    spa1.Credit = fund;
                                    spa1.Debit = 0;
                                    spa1.Date = System.DateTime.Now;
                                    spa1.AccountId = AccId;
                                    spa1.UserId = Convert.ToInt32(Session["UserId"]);

                                    dbobj.SupplierAccounts.Add(spa);
                                    dbobj.SaveChanges();
                                    */
                                    int accb = Convert.ToInt32(ac.CurrentBalance);
                                    int newbal = accb - fund;
                                    ac.CurrentBalance = newbal.ToString();
                                    dbobj.SaveChanges();

                                    AccountDetail acd = new AccountDetail();
                                    acd.Particular = "Purchase Inv# " + PurcInv;
                                    acd.Amount = fund;
                                    acd.Mode = "Outward";
                                    acd.DateTime = System.DateTime.Now;
                                    acd.AccountId = AccId;
                                    acd.UserId = Convert.ToInt32(Session["UserId"]);
                                    acd.Type = "Cash";
                                    acd.PurchInvId = PurcInv;

                                    dbobj.AccountDetails.Add(acd);
                                    dbobj.SaveChanges();

                                    //sp.Balance -= fund;
                                    //dbobj.SaveChanges();

                                    CashTran ct = new CashTran();
                                    ct.Particular = "Purchase Inv# " + PurcInv;
                                    ct.Amount = fund;
                                    ct.AccountDetailId = acd.AccountsDetailId;

                                    dbobj.CashTrans.Add(ct);
                                    dbobj.SaveChanges();

                                    fund = 0;
                                    break;
                                }

                            }
                            else
                            {
                                break;
                            }


                        }
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            supNm = GridView1.SelectedRow.Cells[2].Text;
            cellNum = GridView1.SelectedRow.Cells[3].Text;
            compNm = GridView1.SelectedRow.Cells[4].Text;
            address = GridView1.SelectedRow.Cells[5].Text;
            balance = Convert.ToInt32(GridView1.SelectedRow.Cells[6].Text);

           
             int supId = Convert.ToInt32(ViewState["SupId"]);
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
                  fdt = DateTime.Parse(datepicker.Text);

                 try
                 {
                     using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                     {
                         var supRep = dbobj.sp_Supplier_Report(supId, fdt, tdt).ToList();
                         ctlGridView.DataSource = supRep;
                         ctlGridView.DataBind();
                     }
                 }
                 catch (Exception)
                 {
                 }
             } // end of if time selected condition
        }
    }
}