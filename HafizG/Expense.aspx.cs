using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Expense1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            myalert.Visible = false;
            myfailalert.Visible = false; 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    Expense ex = new Expense();

                    ex.Particular = prtTxt.Text;
                    ex.Date = System.DateTime.Now;
                    ex.Type = DropDownList1.SelectedItem.Value;
                    ex.Amount = Convert.ToInt32(amTxt.Text);
                    ex.AccountId = Convert.ToInt32(DropDownList2.SelectedItem.Value);
                    ex.UserId = Convert.ToInt32(Session["UserId"]);
                    ex.BranchId = Convert.ToInt32(Session["BranchId"]);

                    dbobj.Expenses.Add(ex);
                    dbobj.SaveChanges();

                    ViewState["expId"] = ex.ExpenseId;

                    int tempAccId = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                        Account ac = new Account();
                        ac = (from act in dbobj.Accounts
                              where act.AccountId == tempAccId
                              select act).FirstOrDefault();

                        if (ac != null)
                        {
                            int tempBal = Convert.ToInt32(ac.CurrentBalance);
                            int updBal = tempBal - Convert.ToInt32(amTxt.Text);
                            ac.CurrentBalance = updBal.ToString(); 
                            dbobj.SaveChanges(); 
                        }

                        AccountDetail acd = new AccountDetail();

                        acd.Particular = "Pay Expense Id# " + ViewState["expId"];
                        acd.Amount = Convert.ToInt32(amTxt.Text);
                        acd.Mode = "Outward";
                        acd.DateTime = System.DateTime.Now;
                        acd.AccountId = tempAccId;
                        acd.UserId = 1;
                        acd.Type = "Cash";

                        dbobj.AccountDetails.Add(acd);
                        dbobj.SaveChanges();


                    myalert.Visible = true;

                    Response.Redirect(Request.RawUrl);
                }
            }
            catch(Exception)
            {
               
                myfailalert.Visible = true;
            }
                
            
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            loadGv();

        }

        public void loadGv()
        {
            int tempBranchId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
            // string fdt = datepicker.Text;
            //string tdt = datepicker1.Text;
            DateTime tdt;
            if (datepicker1.Text != "")
            {
                tdt = DateTime.Parse(datepicker1.Text);
            }
            else
            {
                tdt = System.DateTime.Now;
            }

            DateTime fdt = DateTime.Parse(datepicker.Text);

            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    // IEnumerable<sp_search_purchaseInvoices_Result> spi = dbobj.sp_search_purchaseInvoices(tempBranchId, fdt, tdt);

                    var spi = dbobj.sp_Search_Expense(tempBranchId, fdt, tdt).ToList();
                    GridView1.DataSource = spi;
                    GridView1.DataBind();

                    int tempPurcAm = 0;
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        tempPurcAm += Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);

                    }

                    tSale.Visible = true;
                    tSaleTxt.Text = tempPurcAm.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            loadGv();
            GridView1.DataBind();

            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int expId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                var ex = (from ex1 in dbobj.Expenses where ex1.ExpenseId == expId select ex1).SingleOrDefault();

                DropDownList dp1 = (row.Cells[4].FindControl("DropDownList3") as DropDownList);
                ex.Particular = (row.Cells[3].Controls[0] as TextBox).Text;
                ex.Type = dp1.SelectedValue;
                ex.Amount = Convert.ToInt32((row.Cells[5].Controls[0] as TextBox).Text);

                dbobj.SaveChanges();
            }

            loadGv();
            GridView1.DataBind();
            Response.Redirect(Request.RawUrl);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }
    }
}