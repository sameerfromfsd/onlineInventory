using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace HafizG
{
    public partial class saleInvoice : System.Web.UI.Page
    {
       
        int payable = 0;
        int bal = 0;
        int cuId;
        //string AccType;
        int CurBalance=0;
        DataTable dt = new DataTable();
        //string pp;
        int accId;
        int prevBal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            bk.Visible = false;
            Asucc.Visible = false;
            Afail.Visible = false;
        }

        protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            qntyTxt.Focus();
           // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Testing" + "');", true);
            qntyTxt.Enabled = true;
            discTxt.Text = "0";
            Label1.Text = "0"; 
            int prodid = Convert.ToInt32(DDL.SelectedItem.Value);
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                Product pd = new Product();

                pd = (from prod in dbobj.Products
                       where prod.ProductId == prodid
                       select prod).FirstOrDefault();
                
                priceTxt.Text = pd.SalePrice.ToString();

               ViewState["pp"] = priceTxt.Text;
                qntyTxt.Text = "";
                //discTxt.Text = "";

                int tempProId = Convert.ToInt32(DDL.SelectedItem.Value);
                int tempBranchId = Convert.ToInt32(Session["BranchId"]);
                Stock st = new Stock();

                st = (from stk in dbobj.Stocks
                      where stk.ProductId == tempProId & stk.LocationId == tempBranchId
                      select stk).FirstOrDefault();
                if (st != null)
                {
                    availTxt.Text = st.Quantity + "";
                    int tempStock = Convert.ToInt32(st.Quantity);
                    ViewState["tempStock"] = tempStock;
                    if (tempStock == 0)
                    {
                       // qntyTxt.Enabled = false;               allow user to make -stock 
                    }
                }
                else
                {
                    qntyTxt.Enabled = false;
                    availTxt.Text = "";
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            DDL.Focus();
            int tempqnty = Convert.ToInt32(qntyTxt.Text);
            int tempStock = Convert.ToInt32(ViewState["tempStock"]);

            if (qntyTxt.Text != "" && tempqnty <= tempStock && availTxt.Text != "" && priceTxt.Text != "" && discTxt.Text != "" && Convert.ToInt32(availTxt.Text) != 0)
            {
                dt.Columns.Add("Sr#");
                dt.Columns.Add("Id");
                dt.Columns.Add("Item");
                dt.Columns.Add("Qnty");
                dt.Columns.Add("Rt");
                
                dt.Columns.Add("Price");
                DataRow dr = null;

                if (GridView1.Rows.Count == 0)
                {
                    ViewState["emp"] = null;
                }

                if (ViewState["emp"] != null)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        dt = (DataTable)ViewState["emp"];
                        if (dt.Rows.Count > 0)
                        {

                            dr = dt.NewRow();
                            dr["Sr#"] = dt.Rows.Count + 1; ;
                            dr["Id"] = DDL.SelectedItem.Value;
                            dr["Item"] = DDL.SelectedItem.Text;
                            dr["Qnty"] = qntyTxt.Text;
                            dr["Rt"] = priceTxt.Text;
                            
                            dr["Price"] = Label1.Text;
                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                    }
                }
                else
                {
                    dr = dt.NewRow();
                    dr["Sr#"] = dt.Rows.Count + 1; ;
                    dr["Id"] = DDL.SelectedItem.Value;
                    dr["Item"] = DDL.SelectedItem.Text;
                    dr["Qnty"] = qntyTxt.Text;
                    dr["Rt"] = priceTxt.Text;
                    dr["Price"] = Label1.Text;
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                ViewState["emp"] = dt;
                updated_grandTotal();
                // ViewState["gt"] = Convert.ToInt32(ViewState["gt"]) + Convert.ToInt32(Label1.Text);
                // grandTotal = grandTotal + Convert.ToInt32(Label1.Text);
                Label2.Text = "G-Total :" + ViewState["gt"].ToString();

                reset_item_btn();

                Asucc.Visible = true;
            }
            else
            {
                Asucc.Visible = false;
                Afail.Visible = true;
            }
    }
        public void reset_item_btn()
        {
            DDL.SelectedIndex = 0;
            qntyTxt.Text = "";
            availTxt.Text = "";
            priceTxt.Text = "";
            discTxt.Text = "0" ;

        }

        protected void qntyTxt_TextChanged(object sender, EventArgs e)
        {

            priceTxt.Focus();
            priceTxt.Text = ViewState["pp"].ToString(); 
            int tempqnty = Convert.ToInt32(qntyTxt.Text);
            int tempStock = Convert.ToInt32(ViewState["tempStock"]);

            if (qntyTxt.Text != "" && tempqnty <= tempStock )
            {
                Label1.Text = (Convert.ToInt32(qntyTxt.Text) * Convert.ToInt32(priceTxt.Text)).ToString();
            }
            else
            {
                Afail.Visible = true;
            }
        }

        protected void discTxt_TextChanged(object sender, EventArgs e)
        {
            
            if (discTxt.Text != "")
            {
                Label1.Text = (Convert.ToInt32(Label1.Text) - Convert.ToInt32(discTxt.Text)).ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count >= 1)
            {
                CurBalance = Convert.ToInt32(paidTxt.Text) + Convert.ToInt32(PreBal.Text);
                prevBal = Convert.ToInt32(PreBal.Text);
                int temppayable = (Convert.ToInt32(ViewState["gt"]) - Convert.ToInt32(TotaldiscTxt.Text));
                if (Convert.ToInt32(paidTxt.Text) <= temppayable)
                {
                    Button2.Enabled = false;
                    try
                    {

                        using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                        {

                            if (cuscellTxt.Text != "")
                            {
                                string cuscell = cuscellTxt.Text;
                                Customer cu = new Customer();
                                cu = (from cust in dbobj.Customers
                                      where cust.CellNumber == cuscell
                                      select cust).FirstOrDefault();

                                if (cu == null)
                                {


                                    Customer cu1 = new Customer();
                                    cu1.CustomerName = cusTxt.Text;
                                    cu1.CellNumber = cuscellTxt.Text;
                                    cu1.Address = addTxt.Text;
                                    cu1.Type = custTypeTxt.Text;
                                    cu1.BadDebt = "Non-Defaulter";
                                    cu1.Balance = CurBalance;
                                    cu1.Cnic = cnicTxt.Text;

                                    dbobj.Customers.Add(cu1);
                                    dbobj.SaveChanges();

                                    ViewState["cusId"] = cu1.CustomerId;
                                }

                                else
                                {
                                    cu.Balance = CurBalance;
                                    dbobj.SaveChanges();
                                    cuId = cu.CustomerId;
                                    ViewState["cusId"] = cu.CustomerId;
                                }
                            }
                            else
                            {
                                Customer cu = new Customer();
                                cu = (from cust in dbobj.Customers
                                      where cust.CustomerId == 1
                                      select cust).FirstOrDefault();

                                cu.Balance = CurBalance;
                                ViewState["cusId"] = 1;
                            }

                            SaleInvoice si = new SaleInvoice();
                            si.CustomerId = Convert.ToInt32(ViewState["cusId"]);
                            si.Date = System.DateTime.Now;
                            si.BranchId = Convert.ToInt32(Session["BranchId"]);
                            si.Amount = Convert.ToInt32(ViewState["gt"]);
                            si.Discount = Convert.ToInt32(TotaldiscTxt.Text);
                            si.Payable = Convert.ToInt32(ViewState["gt"]) - Convert.ToInt32(TotaldiscTxt.Text);
                            ViewState["payable"] = si.Payable;

                            int tempcu2Id = Convert.ToInt32(ViewState["cusId"]);
                            Customer cu2 = new Customer();
                            cu2 = (from cust in dbobj.Customers
                                   where cust.CustomerId == tempcu2Id
                                   select cust).FirstOrDefault();

                          /*  if (Convert.ToInt32(paidTxt.Text) == 0 && prevBal <= 0)
                            {
                                cu2.Balance = cu2.Balance - si.Payable;
                                si.Paid = 0;
                                si.ChangeReturn = si.Paid - si.Payable;
                                dbobj.SaveChanges();
                            }
                            */
                            if (CurBalance != 0)
                            {


                                if (CurBalance >= si.Payable)
                                {

                                    si.Paid = si.Payable;
                                    si.ChangeReturn = Convert.ToInt32(paidTxt.Text) - si.Payable;
                                    si.Status = "Cleared";

                                    cu2.Balance = cu2.Balance - si.Payable;

                                    dbobj.SaveChanges();

                                }
                                else
                                {
                                    si.Paid = Convert.ToInt32(paidTxt.Text);
                                    si.ChangeReturn = Convert.ToInt32(paidTxt.Text) - si.Payable;
                                    si.Status = "Pending";

                                    cu2.Balance = CurBalance - si.Payable;
                                    dbobj.SaveChanges();
                                }

                            }
                            else
                            {
                                si.Paid = 0;
                                si.ChangeReturn = 0;
                                si.Status = "Pending";

                                cu2.Balance = cu2.Balance - si.Payable;
                            }
                           
                            if (Convert.ToInt32(Session["BranchId"]) == 1)
                            {
                                accId = 1;
                            }

                            else
                            {
                                accId = 2;
                            }

                            TimeZoneInfo tzi;
                            DateTime dtTz;
                            tzi = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                            dtTz = TimeZoneInfo.ConvertTime(DateTime.Now, tzi);


                            si.Time = dtTz.ToString("h:mm:ss tt");
                               
                            si.AccountId = accId;
                            si.PaymentMode = "Cash";

                            si.UserId = Convert.ToInt32(Session["UserId"]);
                            dbobj.SaleInvoices.Add(si);
                            dbobj.SaveChanges();

                            ViewState["sInvId"] = si.SaleInvoicId;
                            Session["sInvId"] = ViewState["sInvId"];


                            //   if (PMDropdownlist.SelectedItem.Value == "Cheque")
                            // {
                            //   ChequeList chql = new ChequeList();

                            // chql.Mode = "Inward";
                            // chql.ChequeNumber = chqTxt.Text;
                            // chql.Bank = bnkTxt.Text;
                            // chql.Amount = Convert.ToInt32(ammTxt.Text);
                            // chql.MadeBy = mbTxt.Text;
                            // chql.Date = System.DateTime.Now;
                            // chql.Status = "Pending";
                            // chql.AccountId = Convert.ToInt32(AccDropDownlist.SelectedItem.Value);

                            // dbobj.ChequeLists.Add(chql);
                            // dbobj.SaveChanges();
                            // }


                            CustomersAccount cusA = new CustomersAccount();
                            cusA.CustomerId = Convert.ToInt32(ViewState["cusId"]);
                            cusA.Date = System.DateTime.Now;
                            cusA.Particular = "Sale Invoice# " + si.SaleInvoicId;

                            cusA.Amount = si.Payable;

                            if (Convert.ToInt32(paidTxt.Text) == 0 && prevBal <= 0)
                            {
                                cusA.Credit = cusA.Amount;
                                cusA.Debit = 0;
                            }
                            if (Convert.ToInt32(paidTxt.Text) == 0 && prevBal > 0)
                            {
                                if (prevBal < cusA.Amount)
                                {
                                    cusA.Debit = prevBal;
                                    cusA.Credit = cusA.Amount - prevBal;
                                }
                                if (prevBal >= cusA.Amount)
                                {
                                    cusA.Credit = 0;
                                    cusA.Debit = cusA.Amount;
                                }
                             }

                            if (Convert.ToInt32(paidTxt.Text) < cusA.Amount && prevBal < 0)
                            {
                                cusA.Credit = cusA.Amount - Convert.ToInt32(paidTxt.Text);
                                cusA.Debit = Convert.ToInt32(paidTxt.Text);
                            }
                            if (Convert.ToInt32(paidTxt.Text) < cusA.Amount && prevBal == 0)
                            {
                                cusA.Credit = cusA.Amount - Convert.ToInt32(paidTxt.Text);
                                cusA.Debit = Convert.ToInt32(paidTxt.Text);
                            }
                            if (Convert.ToInt32(paidTxt.Text) < cusA.Amount && prevBal > 0)
                            {
                                if (prevBal + Convert.ToInt32(paidTxt.Text) < cusA.Amount)
                                {
                                    cusA.Debit = prevBal + Convert.ToInt32(paidTxt.Text);
                                    cusA.Credit = cusA.Amount - (prevBal + Convert.ToInt32(paidTxt.Text));
                                }

                                if (prevBal + Convert.ToInt32(paidTxt.Text) >= cusA.Amount)
                                {
                                    cusA.Credit = 0;
                                    cusA.Debit = cusA.Amount;
                                }
                               
                            }

                            if (Convert.ToInt32(paidTxt.Text) == cusA.Amount )
                            {
                                cusA.Credit = 0;
                                cusA.Debit = cusA.Amount;
                            }

                           

                            dbobj.CustomersAccounts.Add(cusA);
                            dbobj.SaveChanges();

                            int tempCuId = Convert.ToInt32(ViewState["cusId"]);


                            SaleDetail sd = new SaleDetail();
                            for (int i = 0; i < GridView1.Rows.Count; i++)
                            {
                                sd.ProductId = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                                sd.Quatity = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                                sd.Rate = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                                sd.DiscountedRate = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
                                sd.SaleInvoiceId = Convert.ToInt32(ViewState["sInvId"]);

                                dbobj.SaleDetails.Add(sd);
                                dbobj.SaveChanges();

                                Stock st = new Stock();
                                int tempbranchId = Convert.ToInt32(Session["BranchId"]);
                                st = (from sup in dbobj.Stocks
                                      where sup.ProductId == sd.ProductId && sup.LocationId == tempbranchId
                                      select sup).FirstOrDefault();
                                if (st != null)
                                {
                                    st.ProductId = sd.ProductId;
                                    st.Quantity -= sd.Quatity;
                                    dbobj.SaveChanges();
                                }

                            }

                            if (CurBalance != 0)
                            {
                                int tempAccId =  accId;

                                Account ac = new Account();
                                ac = (from act in dbobj.Accounts
                                      where act.AccountId == tempAccId
                                      select act).FirstOrDefault();

                                if (ac != null)
                                {
                                    ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) + si.Paid).ToString();
                                    dbobj.SaveChanges();
                                }

                                AccountDetail acd = new AccountDetail();

                                acd.Particular = "Sale inv # " + ViewState["sInvId"];
                                acd.Amount = si.Paid;
                                //acd.Amount = 0;
                                acd.Mode = "Inward";
                                acd.DateTime = System.DateTime.Now;
                                acd.AccountId = accId;
                                acd.UserId = Convert.ToInt32(Session["UserId"]);
                                acd.Type = "Cash";
                                acd.SaleInvId = si.SaleInvoicId;

                                dbobj.AccountDetails.Add(acd);
                                dbobj.SaveChanges();
                                int acdId = acd.AccountsDetailId;



                                if (acd.Type == "Cash")
                                {
                                    CashTran ct = new CashTran();
                                    ct.Particular = "Sale inv# " + ViewState["sInvId"];

                                    ct.Amount = si.Paid;
                                    ct.AccountDetailId = acd.AccountsDetailId;

                                    dbobj.CashTrans.Add(ct);
                                    dbobj.SaveChanges();
                                }
                                else if (acd.Type == "Cheque")
                                {
                                    BnkTan bkt = new BnkTan();
                                    bkt.Particular = "Sale inv# " + ViewState["sInvId"];
                                    bkt.Amount = si.Paid;
                                    bkt.AccountDetailId = acd.AccountsDetailId;
                                    if (chqTxt.Text != "")
                                    {
                                        bkt.ChequeId = Convert.ToInt32(ViewState["chequeId"]);
                                    }
                                    bkt.MadeBy = mbTxt.Text;
                                    bkt.DueDate = System.DateTime.Now;

                                    dbobj.BnkTans.Add(bkt);
                                    dbobj.SaveChanges();

                                }
                            }

                        }
                        Session["sInvId"] = ViewState["sInvId"];
                        string pageurl = "InvoicePrint.aspx";
                        Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");


                      //  Session["sInvId"] = Convert.ToInt32(ViewState["sInvId"]);
                    
                            Response.Redirect("InvoicePrint.aspx");
                    
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    Afail.Visible = true;
                }

                //int sid = Convert.ToInt32(Session["sInvId"]);
                // Response.Redirect(Request.RawUrl);
                // string pageurl1 = "InvoicePrint.aspx";
                //  Response.Write("<script> window.open('" + pageurl1 + "','_blank'); </script>");
            }
            else
            {
                Afail.Visible = true;
            }
         }

     

        protected void TotaldiscTxt_TextChanged(object sender, EventArgs e)
        {
            paidTxt.Focus();
            if (TotaldiscTxt.Text != "")
            {
                Label3.Text = "Payable :" + (Convert.ToInt32(ViewState["gt"]) - Convert.ToInt32(TotaldiscTxt.Text)).ToString();
            }
            else
            {
                Label3.Text = "Payable";
            }

            ViewState["pa"] = Convert.ToInt32(ViewState["gt"]) - Convert.ToInt32(TotaldiscTxt.Text)  ;
            payable = Convert.ToInt32(ViewState["gt"]) - Convert.ToInt32(TotaldiscTxt.Text);
        }

        protected void paidTxt_TextChanged(object sender, EventArgs e)
        {
           
            if (paidTxt.Text != "")
            {
                Label3.Text = "Payable :" + (Convert.ToInt32(ViewState["gt"]) - Convert.ToInt32(TotaldiscTxt.Text)).ToString();
                Label4.Text = "Return" + (Convert.ToInt32(ViewState["pa"]) - Convert.ToInt32(paidTxt.Text));
                bal = payable - Convert.ToInt32(paidTxt.Text);
            }
            else
            {
                Label4.Text = "Return";
            }
        }

        protected void PMDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            chqTxt.Text = "";
            bnkTxt.Text = "";
            mbTxt.Text = "";
            ammTxt.Text = "";

            AdvInvSystemEntities dbobj = new AdvInvSystemEntities();
         /*   if (acd.Type == "Cheque")
            {

                bk.Visible = true;
                paidTxt.Text = "";
                paidTxt.Enabled = false;
            }
            else
            {
                bk.Visible = false;
                paidTxt.Enabled = true;
            }



            if (acd.Type == "Cash")
            {
                AccType = "InHand";
            }
            else if (acd.Type == "Cheque")
            {
                AccType = "Bank";
            }
            */
           

        }

        protected void cuscellTxt_TextChanged(object sender, EventArgs e)
        {
            cusTxt.Focus();

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                Customer cust = new Customer();

                cust = (from cus in dbobj.Customers
                      where cus.CellNumber == cuscellTxt.Text
                      select cus).FirstOrDefault();

                if (cust != null)
                {

                    cusTxt.Text = cust.CustomerName;
                    addTxt.Text = cust.Address;
                    custTypeTxt.Text = cust.Type;
                    cusStatusTxt.Text = cust.BadDebt;
                    cnicTxt.Text = cust.Cnic;
                    PreBal.Text = cust.Balance.ToString();


                    if (cust.BadDebt == "Non-Defaulter")
                    {
                        cusStatusTxt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Green");
                    }
                    else
                    {
                        cusStatusTxt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Red");
                    }
                }
                else
                {
                    cusTxt.Text = "";
                    //cuscellTxt.Text = "";
                    addTxt.Text = "";
                    custTypeTxt.Text = "";
                    cusStatusTxt.Text = "";
                    cnicTxt.Text = "";
                    PreBal.Text = "0";
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeletRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = GridView1.Rows[index];

                dt = ViewState["emp"] as DataTable;
                dt.Rows[index].Delete();
                ViewState["emp"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();

                updated_grandTotal();
                Label2.Text = "G-Total :" + ViewState["gt"].ToString();
            }
        }

        public void updated_grandTotal()
        {
            int gt = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                GridView1.Rows[i].Cells[1].Text = (i + 1).ToString();

                gt = gt + Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
            }
            ViewState["gt"] = gt;
        }

        protected void cnicTxt_TextChanged(object sender, EventArgs e)
        {
            if (cnicTxt.Text != null)
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    Customer cust = new Customer();

                    cust = (from cus in dbobj.Customers
                            where cus.Cnic == cnicTxt.Text
                            select cus).FirstOrDefault();

                    if (cust != null)
                    {
                        cuscellTxt.Text = cust.CellNumber;
                        cusTxt.Text = cust.CustomerName;
                        addTxt.Text = cust.Address;
                        custTypeTxt.Text = cust.Type;
                        cusStatusTxt.Text = cust.BadDebt;
                        PreBal.Text = cust.Balance.ToString();


                        if (cust.BadDebt == "Non-Defaulter")
                        {
                            cusStatusTxt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Green");
                        }
                        else
                        {
                            cusStatusTxt.ForeColor = System.Drawing.ColorTranslator.FromHtml("Red");


                        }
                    }
                    else
                    {
                       
                        PreBal.Text = "0";
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["sInvId"] = ViewState["sInvId"];
            string pageurl = "InvoicePrint.aspx";
            Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
        }

        protected void priceTxt_TextChanged(object sender, EventArgs e)
        {
            if (priceTxt.Text != "")
            {
                discTxt.Focus();
                int tempqnty = Convert.ToInt32(qntyTxt.Text);
                int tempStock = Convert.ToInt32(ViewState["tempStock"]);

                if (qntyTxt.Text != "" && tempqnty <= tempStock)
                {
                    Label1.Text = (Convert.ToInt32(qntyTxt.Text) * Convert.ToInt32(priceTxt.Text)).ToString();
                }
                else
                {
                    Afail.Visible = true;
                }
            }
        }

        protected void priceTxt_Unload(object sender, EventArgs e)
        {
            if (priceTxt.Text != "")
            {
                
                int tempqnty = Convert.ToInt32(qntyTxt.Text);
                int tempStock = Convert.ToInt32(ViewState["tempStock"]);

                if (qntyTxt.Text != "" && tempqnty <= tempStock)
                {
                    Label1.Text = (Convert.ToInt32(qntyTxt.Text) * Convert.ToInt32(priceTxt.Text)).ToString();
                }
                else
                {
                    Afail.Visible = true;
                }
            }
        }
        
   }
 }
