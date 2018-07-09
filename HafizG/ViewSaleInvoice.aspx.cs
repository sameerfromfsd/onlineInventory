 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace HafizG
{
    public partial class ViewSaleInvoice : System.Web.UI.Page
    {
        
        int diff;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }
           // fundDeposit.Visible = false;
           // cusDetLbl.Visible = false;
           // bk.Visible = false; 
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (GridView2.Rows.Count >= 1)
            {

                GridView2.Visible = false;
                DetailsView1.Visible = false;
                
            }

            int tempBranchId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
            DateTime tdt;
           // string fdt = datepicker.Text;
            //string tdt = datepicker1.Text;
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
                   // IEnumerable<sp_search_saleInvoices_Result> ssi = dbobj.sp_search_saleInvoices(tempBranchId,fdt,tdt);
                    GridView1.DataSource = dbobj.sp_search_saleInvoices(tempBranchId, fdt, tdt).ToList();
                    GridView1.DataBind(); 
                }

                int tempSaleAm = 0;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    tempSaleAm += Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);

                }

                tSale.Visible = true;
                tSaleTxt.Text = tempSaleAm.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            int tempId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                //saleInvoices si = new saleInvoices();
                SaleInvoice si = new SaleInvoice();
                si = (from sid in dbobj.SaleInvoices
                      where sid.SaleInvoicId == tempId
                      select sid).FirstOrDefault();

                var sil = dbobj.sp_saleInvoice_Dept(tempId);
                
                DetailsView1.DataSource = sil;
                DetailsView1.DataBind();

                loadGrid(tempId);
                GridView2.Visible = true;
                DetailsView1.Visible = true;
            }
        }

        public void loadGrid(int id)
        {
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                IEnumerable<sp_sale_detail_Result> sd = dbobj.sp_sale_detail(id);
                GridView2.DataSource = sd;
                GridView2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (invTxt.Text != "")
            {
           
            int tempSaleInvId = Convert.ToInt32(invTxt.Text);
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    SaleInvoice s = new SaleInvoice();
                    s = (from s1 in dbobj.SaleInvoices where s1.SaleInvoicId == tempSaleInvId select s1).FirstOrDefault();
                    var si = from si1 in dbobj.SaleInvoices where si1.SaleInvoicId == tempSaleInvId  select si1;
                    

                    GridView3.DataSource = si.ToList();
                    GridView3.DataBind();

                    Customer cu = new Customer();

                    cu = (from c in dbobj.Customers where c.CustomerId == s.CustomerId select c).FirstOrDefault();

                    if (cu != null)
                    {
                        cusDetLbl.Text = cu.CustomerName + " / " + cu.CellNumber;

                        cusDetLbl.Visible = true;
                        Button3.Visible = true;
                    }
                }
            }
            catch(Exception)
            {
            }
         }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Delete_btn_Click(object sender, EventArgs e)
        {
            if (GridView3.Rows.Count >= 1)
            {
                int tempSaleInvId = Convert.ToInt32(invTxt.Text);
                using(AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                
                var si = (from s in dbobj.SaleInvoices where s.SaleInvoicId == tempSaleInvId select s).FirstOrDefault();
                var saleD = (from sd in dbobj.SaleDetails where sd.SaleInvoiceId == tempSaleInvId select sd).ToList();
                foreach (var sds in saleD)
                {
                    var stk = (from st in dbobj.Stocks where st.ProductId == sds.ProductId && st.LocationId == si.BranchId select st).FirstOrDefault();
                    stk.Quantity += sds.Quatity;
                    dbobj.SaleDetails.Remove(sds);
                    dbobj.SaveChanges();
                }
                

                if (si.Paid > 0)
                {
                    var cus = (from c in dbobj.Customers where c.CustomerId == si.CustomerId select c).FirstOrDefault();
                   
                        cus.Balance -= si.Paid;
                   
                    
                    CustomersAccount ca = new CustomersAccount();

                    ca.CustomerId = cus.CustomerId;
                    ca.Date = System.DateTime.Now;
                    ca.Credit = si.Paid;
                    ca.Debit = 0;
                    ca.Status = "Cleared";

                    dbobj.CustomersAccounts.Add(ca);
                    dbobj.SaveChanges();

                    Account ac = new Account();
                    ac = (from ac1 in dbobj.Accounts where ac1.AccountId == si.AccountId select ac1).FirstOrDefault(); 
                    ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) - si.Paid).ToString();

                  

                    
                
                }

                var acd = (from ad in dbobj.AccountDetails where ad.SaleInvId == si.SaleInvoicId select ad).ToList();
                foreach (var acd1 in acd)
                {
                    var cashT = (from ct in dbobj.CashTrans where ct.AccountDetailId == acd1.AccountsDetailId select ct).ToList();
                    foreach (var ct1 in cashT)
                    {
                        dbobj.CashTrans.Remove(ct1);
                        dbobj.SaveChanges();
                    }

                    dbobj.AccountDetails.Remove(acd1);
                    dbobj.SaveChanges();
                }

                dbobj.SaleInvoices.Remove(si);
                dbobj.SaveChanges();

                }

                Response.Redirect("Default.aspx");
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //ViewState["tempId"] = Convert.ToInt32(GridView2.edi.Cells[1].Text);

            ViewState["tempId"] = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            GridView2.EditIndex = e.NewEditIndex;
            int tempId =(Int32)ViewState["tempId"];
            loadGrid(tempId);
            DataBind();

            //ViewState["qnty"] = Convert.ToInt32(GridView2.Rows.[e.Row].Cells[3].Text);

        }
        protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int tempId = (Int32)ViewState["tempId"];
            int id = Convert.ToInt32(GridView2.Rows[e.RowIndex].Cells[0].Text);
            TextBox qn = (TextBox)GridView2.Rows[e.RowIndex].FindControl("qntyTxt");
            TextBox rt = (TextBox)GridView2.Rows[e.RowIndex].FindControl("rateTxt");
            TextBox dr = (TextBox)GridView2.Rows[e.RowIndex].FindControl("drTxt");
            
            int prvBal = Convert.ToInt32(dr.Text);
            int prvQnty = 0;
            int proId;
            int stLoc;
            //int qn = Convert.ToInt32(GridView2.Rows[e.RowIndex].Cells[3].Text);
           

                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                        
                        var saleDetail = (from sd in dbobj.SaleDetails where sd.SaleInvoiceDetailId == id select sd).FirstOrDefault();
                        prvQnty = saleDetail.Quatity;
                        proId = saleDetail.ProductId;
                       
                       if (Convert.ToInt32(qn.Text) > 0)
                        {
                        saleDetail.Quatity = Convert.ToInt32(qn.Text);
                        saleDetail.Rate = Convert.ToInt32(rt.Text);
                        saleDetail.DiscountedRate = Convert.ToInt32(qn.Text) * Convert.ToInt32(rt.Text);
                        dbobj.SaveChanges();
                       }
                       else if (Convert.ToInt32(qn.Text) < 0)
                        {
                           dbobj.SaleDetails.Remove(saleDetail);
                           dbobj.SaveChanges();
                        }
                        if (saleDetail.DiscountedRate > prvBal)
                        {
                            diff = saleDetail.DiscountedRate - prvBal;

                        }
                        if (saleDetail.DiscountedRate < prvBal)
                        {
                            diff = saleDetail.DiscountedRate - prvBal;
                        }

                        CustomersAccount ca = new CustomersAccount();


                        SaleInvoice si = new SaleInvoice();
                        si = (from s in dbobj.SaleInvoices where s.SaleInvoicId == tempId select s).FirstOrDefault();

                        stLoc = si.BranchId;

                        si.Payable = si.Payable + diff;
                        si.Amount = si.Amount + diff;

                        if (si.Status == "Cleared")
                        {
                            si.Paid = si.Payable;
                        }



                        dbobj.SaveChanges();

                        var stl = (from st in dbobj.Stocks where st.ProductId == proId && st.LocationId == stLoc select st).FirstOrDefault();


                        if (Convert.ToInt32(qn.Text) > 0)
                        {
                           
                            if (prvQnty > Convert.ToInt32(qn.Text))
                            {
                                diff = prvQnty - Convert.ToInt32(qn.Text);
                                stl.Quantity += diff;
                                dbobj.SaveChanges();
                            }
                            else if (Convert.ToInt32(qn.Text) > prvQnty)
                            {
                                diff = Convert.ToInt32(qn.Text) - prvQnty;
                                stl.Quantity -= diff;
                                dbobj.SaveChanges();
                            }


                        }
                        else if(Convert.ToInt32(qn.Text) <= 0)
                        {
                            var st2 = (from st in dbobj.Stocks where st.ProductId == proId && st.LocationId == stLoc select st).FirstOrDefault();

                           
                            st2.Quantity += prvQnty;
                            dbobj.SaveChanges();
                        }
                      /*  Customer cu = new Customer();
                        cu = (from cust in dbobj.Customers
                              where cust.CustomerId == si.CustomerId
                              select cust).FirstOrDefault();
                        if (cu.Balance != 0)
                        {
                            cu.Balance += diff;
                            dbobj.SaveChanges();
                        }
                        */

                        


                        CustomersAccount cusA = new CustomersAccount();
                        cusA.CustomerId = si.CustomerId;
                        cusA.Date = System.DateTime.Now;
                        cusA.Credit = diff;
                        cusA.Debit = diff;

                        cusA.Status = "Cleared";

                        dbobj.CustomersAccounts.Add(cusA);
                        dbobj.SaveChanges();

                        Account ac = new Account();
                        ac = (from act in dbobj.Accounts
                              where act.AccountId == si.AccountId
                              select act).FirstOrDefault();
                        ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) + diff).ToString() ;
                        dbobj.SaveChanges();

                        AccountDetail acd = new AccountDetail();

                        acd.Particular = "Sale Return inv# " + si.SaleInvoicId;
                        acd.Amount = diff;

                        acd.Mode = "Outward";
                        acd.DateTime = System.DateTime.Now;
                        acd.AccountId = (Int32)si.AccountId;
                        acd.UserId = Convert.ToInt32(Session["UserId"]);
                        acd.Type = "Cash";
                        acd.SaleInvId = si.SaleInvoicId;

                        dbobj.AccountDetails.Add(acd);
                        dbobj.SaveChanges();

                        CashTran ct = new CashTran();
                        ct.Particular = "Sale Return inv# " + si.SaleInvoicId;

                        ct.Amount = diff;
                        ct.AccountDetailId = acd.AccountsDetailId;

                        dbobj.CashTrans.Add(ct);
                        dbobj.SaveChanges();


                      
                        GridView2.EditIndex = -1;

                        loadGrid(tempId);

                        DataBind();

                        Response.Redirect(Request.RawUrl);  
                    }
                }
                catch (Exception)
                {

                }
            }

     

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["sInvId"] = Convert.ToInt32(invTxt.Text);
            string pageurl = "InvoicePrint.aspx";
            Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");

           
            //Response.Redirect("Default.aspx");
        }

        protected void GridView2_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            int tempId = (Int32)ViewState["tempId"];
            GridView2.EditIndex = -1;

            loadGrid(tempId);

            DataBind();
        }
           
           // Response.Redirect("Default.aspx");
        


    }
}