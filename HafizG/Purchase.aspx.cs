using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace HafizG
{
    public partial class Purchase : System.Web.UI.Page
    {
        int supId;
        int bal;
        string AccType;
        int locId;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            if (!IsPostBack)
            {
                bk.Visible = false;
                Asucc.Visible = false;
                Afail.Visible = false;
                DDL.SelectedIndex = -1;

                Div1.Visible = false;
                Div2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DDL.Focus();

            if (qntyTxt.Text != "" && costTxt.Text != "" && rateTxt.Text != "" && ppriceTxt.Text != "")
            {
                
                dt.Columns.Add("Sr#");
                dt.Columns.Add("Id");
                dt.Columns.Add("Item");
                dt.Columns.Add("Qnty");
                dt.Columns.Add("Price");
                dt.Columns.Add("Pp");
                dt.Columns.Add("Sp");
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
                            dr["Sr#"] = dt.Rows.Count+1;
                            dr["Id"] = DDL.SelectedItem.Value;
                            dr["Item"] = DDL.SelectedItem.Text;
                            dr["Qnty"] = qntyTxt.Text;
                            dr["Price"] = costTxt.Text;
                            dr["Pp"] = rateTxt.Text;
                            dr["Sp"] = ppriceTxt.Text;

                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                    }
                }
                else
                {
                    dr = dt.NewRow();
                    dr["Sr#"] = dt.Rows.Count+1;
                    dr["Id"] = DDL.SelectedItem.Value;
                    dr["Item"] = DDL.SelectedItem.Text;
                    dr["Qnty"] = qntyTxt.Text;
                    dr["Price"] = costTxt.Text;
                    dr["Pp"] = rateTxt.Text;
                    dr["Sp"] = ppriceTxt.Text;
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    
                }
                ViewState["emp"] = dt;
                updated_grandTotal();
                //ViewState["gt"] = Convert.ToInt32(ViewState["gt"]) + Convert.ToInt32(costTxt.Text);
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            qntyTxt.Focus();

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                if (GridView1.Rows.Count != 0)
                {
                    if (Convert.ToInt32(paidTxt.Text) <= Convert.ToInt32(amountTxt.Text))
                    {

                        if (spcellTxt.Text != "")
                        {

                            Supplier sp = new Supplier();

                            sp = (from sup in dbobj.Suppliers
                                  where sup.CellNumber == spcellTxt.Text
                                  select sup).FirstOrDefault();


                            if (sp == null)
                            {
                                Supplier spn = new Supplier();

                                spn.Name = spnmTxt.Text;
                                spn.CellNumber = spcellTxt.Text;
                                spn.Company = spcomTxt.Text;
                                spn.Address = spaddTxt.Text;
                                bal = Convert.ToInt32(paidTxt.Text) - Convert.ToInt32(amountTxt.Text);
                                spn.Balance = bal;

                                dbobj.Suppliers.Add(spn);
                                dbobj.SaveChanges();

                                supId = spn.SupplierId;
                            }

                            else
                            {
                                bal = Convert.ToInt32(paidTxt.Text) - Convert.ToInt32(amountTxt.Text);
                                sp.Balance = sp.Balance + bal;
                                dbobj.SaveChanges();
                                supId = sp.SupplierId;
                            }

                        }
                        else
                        {
                            supId = 1;
                        }

                        PurchaseInvoice pi = new PurchaseInvoice();
                        pi.BrandId = Convert.ToInt32(brdDropDown.SelectedItem.Value);
                        pi.Date = System.DateTime.Now;
                        pi.ReferenceId = refTxt.Text;
                        pi.Amount = Convert.ToInt32(amountTxt.Text);
                        pi.Paid = Convert.ToInt32(paidTxt.Text);
                        pi.Balance = Convert.ToInt32(amountTxt.Text) - Convert.ToInt32(paidTxt.Text);
                        if (pi.Balance != 0)
                        {
                            pi.Status = "Pending";
                        }
                        else
                        {
                            pi.Status = "Cleared";
                        }
                        pi.UserId = Convert.ToInt32(Session["UserId"]);
                        pi.AccountCredit = Convert.ToInt32(AccDropDownlist.SelectedItem.Value);
                        pi.StockLocId = Convert.ToInt32(brnchDownList.SelectedItem.Value);
                        locId = pi.StockLocId;
                        pi.SupplierId = supId;
                        if (PMDropdownlist.SelectedIndex != -1)
                        {
                            pi.PaymentMode = PMDropdownlist.SelectedItem.Value;
                        }
                        dbobj.PurchaseInvoices.Add(pi);
                        dbobj.SaveChanges();
                        ViewState["purInvId"] = pi.PurchaseInvoiceId;

                        SupplierAccount spa = new SupplierAccount();
                        spa.SupplierId = supId;
                        spa.Particular = "Purchash inv#" + pi.PurchaseInvoiceId;
                        spa.Amount = Convert.ToInt32(amountTxt.Text);
                        spa.Debit = pi.Paid;
                        spa.Credit = Convert.ToInt32(amountTxt.Text) - pi.Paid;
                        spa.Date = System.DateTime.Now;
                        spa.AccountId = pi.AccountCredit;
                        spa.UserId = 1;

                        dbobj.SupplierAccounts.Add(spa);
                        dbobj.SaveChanges();


                        ChequeList cql = new ChequeList();
                        if (PMDropdownlist.SelectedItem.Value == "Cheque")
                        {

                            cql.Mode = "Outward";
                            cql.ChequeNumber = chqTxt.Text;
                            cql.Bank = bnkTxt.Text;
                            cql.MadeBy = mbTxt.Text;
                            cql.Amount = Convert.ToInt32(ammTxt.Text);
                            cql.Date = System.DateTime.Now;
                            cql.Status = "Pending";
                            cql.AccountId = 1;

                            dbobj.ChequeLists.Add(cql);
                            dbobj.SaveChanges();
                        }

                        ViewState["chequeId"] = cql.ChequeId;

                        PurchaseDetail purD = new PurchaseDetail();

                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            purD.ProductId = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                            purD.Quantity = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                            purD.Price = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                            purD.PurchaseInvoice = Convert.ToInt32(ViewState["purInvId"]);

                            dbobj.PurchaseDetails.Add(purD);
                            dbobj.SaveChanges();

                            Product pd = new Product();
                            pd = (from prod in dbobj.Products
                                  where prod.ProductId == purD.ProductId
                                  select prod).SingleOrDefault();

                            if (pd != null)
                            {
                                pd.PurchasePrice = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
                                pd.SalePrice = Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);
                                dbobj.SaveChanges();
                            }

                            Stock st = new Stock();

                            st = (from sup in dbobj.Stocks
                                  where sup.ProductId == purD.ProductId && sup.LocationId == locId
                                  select sup).FirstOrDefault();
                            if (st != null)
                            {
                                //st.ProductId = purD.ProductId;
                                st.Quantity += purD.Quantity;
                                //st.LocationId = locId;

                                //dbobj.sp_Add_Stock(st.ProductId, st.LocationId, st.Quantity);
                                dbobj.SaveChanges();
                            }
                            else
                            {
                                Stock st1 = new Stock();
                                st1.ProductId = purD.ProductId;
                                st1.Quantity = purD.Quantity;
                                st1.LocationId = locId;

                                dbobj.Stocks.Add(st1);
                                dbobj.SaveChanges();
                            }
                        }
                        if (paidTxt.Text != "" || paidTxt.Text != "0")
                        {
                            int tempAccId = Convert.ToInt32(AccDropDownlist.SelectedItem.Value);

                            Account ac = new Account();
                            ac = (from act in dbobj.Accounts
                                  where act.AccountId == tempAccId
                                  select act).FirstOrDefault();

                            if (ac != null)
                            {
                                ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) - Convert.ToInt32(paidTxt.Text)).ToString();
                                dbobj.SaveChanges();
                            }

                            AccountDetail acd = new AccountDetail();

                            acd.Particular = "Payment inv# " + ViewState["purInvId"];
                            acd.Amount = Convert.ToInt32(paidTxt.Text);
                            acd.Mode = "Outward";
                            acd.DateTime = System.DateTime.Now;
                            acd.AccountId = Convert.ToInt32(AccDropDownlist.SelectedItem.Value);
                            acd.UserId = Convert.ToInt32(Session["UserId"]);
                            acd.Type = PMDropdownlist.SelectedItem.Text;
                            acd.PurchInvId = Convert.ToInt32(ViewState["purInvId"]);

                            dbobj.AccountDetails.Add(acd);
                            dbobj.SaveChanges();

                            //pi.TransactionId = acd.AccountsDetailId;
                            ViewState["transId"] = acd.AccountsDetailId;



                            if (PMDropdownlist.SelectedItem.Text == "Cash")
                            {
                                CashTran ct = new CashTran();
                                ct.Particular = "Purchase inv# " + ViewState["purInvId"];
                                ct.Amount = Convert.ToInt32(paidTxt.Text);
                                ct.AccountDetailId = acd.AccountsDetailId;

                                dbobj.CashTrans.Add(ct);
                                dbobj.SaveChanges();
                            }
                            else if (PMDropdownlist.SelectedItem.Text == "Cheque")
                            {
                                BnkTan bkt = new BnkTan();
                                bkt.Particular = "Purchase inv# " + ViewState["purInvId"];
                                bkt.Amount = Convert.ToInt32(paidTxt.Text);
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
                        Div2.Visible = true;
                        Response.Redirect(Request.RawUrl);
                    } // end of row count condition for checkout

                    else
                    {
                        Div1.Visible = true;
                    }
                }
                else
                {
                    Div1.Visible = true;
                }
            } // end of dbobj 
        }

        protected void PMDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            chqTxt.Text = "";
            bnkTxt.Text = "";
            mbTxt.Text = "";
            ammTxt.Text = "";

            AdvInvSystemEntities dbobj = new AdvInvSystemEntities();
            if (PMDropdownlist.SelectedItem.Value == "Cheque")
            {

                bk.Visible = true;
            }
            else
            {
                bk.Visible = false;
            }

            

            if(PMDropdownlist.SelectedItem.Text == "Cash")
            {
                AccType = "InHand";               
            }
            else if (PMDropdownlist.SelectedItem.Text == "Cheque")
            {
                AccType = "Bank";
            }

            IEnumerable<sp_Accounts_type_Result> AT = dbobj.sp_Accounts_type(AccType).ToList();

            AccDropDownlist.DataSource = AT;
            AccDropDownlist.DataBind();

        }

        protected void spcellTxt_TextChanged(object sender, EventArgs e)
        {
            spnmTxt.Focus();
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                Supplier sp = new Supplier();

                sp = (from sup in dbobj.Suppliers
                      where sup.CellNumber == spcellTxt.Text
                      select sup).FirstOrDefault();

                if (sp != null)
                {

                    spnmTxt.Text = sp.Name;
                    spcomTxt.Text = sp.Company;
                    spaddTxt.Text = sp.Address;
                }

                else
                {
                    spnmTxt.Text = "";
                    spcomTxt.Text = "";
                    spaddTxt.Text = "";
                }
            }
        }

        protected void reset_item_btn()
        {
            DDL.SelectedIndex = 0;
            qntyTxt.Text = "";
            costTxt.Text = "";
            rateTxt.Text = "";
            ppriceTxt.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void costTxt_TextChanged(object sender, EventArgs e)
        {
            int myrate = 0;
            if (costTxt.Text != "")
            {
                myrate =   Convert.ToInt32(costTxt.Text) / Convert.ToInt32(qntyTxt.Text);
                rateTxt.Text = myrate.ToString();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
             dt = ViewState["emp"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["emp"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public void updated_grandTotal()
        {
            int gt=0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
               
                    GridView1.Rows[i].Cells[1].Text = (i+1).ToString();
                
                gt = gt + Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
            }
            ViewState["gt"] = gt;
        }

        protected void ppriceTxt_TextChanged(object sender, EventArgs e)
        {
            Button1.Focus();
        }

       
    }
}