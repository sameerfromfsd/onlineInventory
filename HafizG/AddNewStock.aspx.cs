using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class AddNewStock : System.Web.UI.Page
    {

        int prodId;
        int locId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

          /*  if (Convert.ToInt32(Session["BranchId"]) != 2)
            {
                Qnty.Visible = false;

            }
            */

            if (!IsPostBack)
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    // IEnumerable<new_st_result> gsl = dbobj.sp_newStockList(1).ToList();
                    //IEnumerable<slist_Result> gsl = dbobj.sp_newStockList(1).ToList();

                    IEnumerable<sp_finalStockList_Result> gsl = dbobj.sp_finalStockList(1).ToList();

                    GridView2.DataSource = gsl;
                    GridView2.DataBind();

                    PMDropdownlist.SelectedIndex = 0;
                    PMDropdownlist.AppendDataBoundItems = true;
                    PMDropdownlist.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    ProductList.SelectedIndex = 0;
                    ProductList.AppendDataBoundItems = true;
                    ProductList.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                }
            }


        }

        protected void PMDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int locId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                IEnumerable<sp_finalStockList_Result> gsl = dbobj.sp_finalStockList(locId).ToList();

                GridView2.DataSource = gsl;
                GridView2.DataBind();

                locId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);

                ProductList.Items.Clear();

                var prod = dbobj.sp_finalStockList(locId).ToList();

                ProductList.DataSource = prod;
                ProductList.DataBind();
                ProductList.Items.Insert(0, new ListItem("Select Product", ""));

            }
        }


        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ProdId"] = Convert.ToInt32(ProductList.SelectedItem.Value);
        }


        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (PMDropdownlist.SelectedIndex != 0 && ProductList.SelectedIndex != 0)
            {

                prodId = Convert.ToInt32(ViewState["ProdId"]);
                locId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);

                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                      if (Qnty.Text != "")
                        {
                            var prodStock = (from pd in dbobj.Stocks where pd.ProductId == prodId && pd.LocationId == locId select pd).FirstOrDefault();
                            prodStock.Quantity += Convert.ToInt32(Qnty.Text);

                            dbobj.SaveChanges();


                            Product pd1 = new Product();
                            pd1 = (from p in dbobj.Products where p.ProductId == prodId select p).FirstOrDefault();
                            if (SPrice.Text != "")
                            {
                                pd1.SalePrice = Convert.ToInt32(SPrice.Text);
                            }
                            if (PPrice.Text != "")
                            {
                                pd1.PurchasePrice = Convert.ToInt32(PPrice.Text);
                            }

                            dbobj.SaveChanges();



                            AddStock addSt = new AddStock();

                            addSt.Quantity = Convert.ToInt32(Qnty.Text);
                            addSt.ProductId = prodId;
                            if (SPrice.Text != "")
                            {
                                addSt.SalePrice = Convert.ToInt32(SPrice.Text);
                            }
                            if (PPrice.Text != "")
                            {
                                addSt.PurcPrice = Convert.ToInt32(PPrice.Text);
                            }
                            addSt.UserId = Convert.ToInt32(Session["UserId"]);

                            TimeZoneInfo tzi;
                            DateTime dtTz;
                            tzi = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                            dtTz = TimeZoneInfo.ConvertTime(DateTime.Now, tzi);

                            addSt.Time = dtTz.ToString("h:mm:ss tt");

                            addSt.Date = System.DateTime.Now;

                            addSt.BranchId = locId;

                            dbobj.AddStocks.Add(addSt);
                            dbobj.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;

            loadgrid();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
            TextBox qn = (TextBox)GridView1.Rows[e.RowIndex].FindControl("qntyTxt");
            TextBox rt = (TextBox)GridView1.Rows[e.RowIndex].FindControl("worthTxt");

            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {

                    var exPro = (from ep in dbobj.AddStocks where ep.AddStockId == id select ep).FirstOrDefault();

                    int proId = Convert.ToInt32(exPro.ProductId);
                    int branchId = Convert.ToInt32(exPro.BranchId);
                    int prvQnty = Convert.ToInt32(exPro.Quantity);
                    int diff;

                    var stl = (from st in dbobj.Stocks where st.ProductId == proId && st.LocationId == branchId select st).FirstOrDefault();


                    if (Convert.ToInt32(qn.Text) > 0)
                    {
                        exPro.Quantity = Convert.ToInt32(qn.Text);
                        
                        dbobj.SaveChanges();

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
                    else if (Convert.ToInt32(qn.Text) <= 0)
                    {
                        var st2 = (from st in dbobj.Stocks where st.ProductId == proId && st.LocationId == branchId select st).FirstOrDefault();


                        dbobj.AddStocks.Remove(exPro);
                        dbobj.SaveChanges();

                        st2.Quantity += prvQnty;
                        dbobj.SaveChanges();
                    }



                    GridView1.EditIndex = -1;

                    loadgrid();

                    DataBind();

                    Response.Redirect(Request.RawUrl);

                }
            }
            catch (Exception)
            {
            }

        }



        protected void loadgrid()
        {
            if (fdpTxt.Text != "")
            {
                int tempBranchId = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                // string fdt = datepicker.Text;
                //string tdt = datepicker1.Text;
                DateTime tdt;
                if (tdpTxt.Text != "")
                {
                    tdt = DateTime.Parse(tdpTxt.Text);
                }
                else
                {
                    tdt = System.DateTime.Now;
                }

                DateTime fdt = DateTime.Parse(fdpTxt.Text);


                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                        var ViewStockAdd = dbobj.sp_view_StockAdd(tempBranchId, fdt, tdt).ToList();
                           

                        GridView1.DataSource = ViewStockAdd;
                       
                        GridView1.DataBind();
                    }
                }
                catch (Exception)
                {
                }
            }
        }



    }
}