using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace HafizG
{
    public partial class ProductStock : System.Web.UI.Page
    {
        int prodId;
        int locId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (Convert.ToInt32(Session["BranchId"]) !=  2 )
            {
                Qnty.Visible = false; 

            }


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

                    ExProdList.SelectedIndex = 0;
                    ExProdList.AppendDataBoundItems = true;
                    ExProdList.Items.Insert(0, new ListItem(String.Empty, String.Empty));

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
                ExProdList.Items.Clear();

                var prod = dbobj.sp_finalStockList(locId).ToList();

                ProductList.DataSource = prod;
                ProductList.DataBind();
                ProductList.Items.Insert(0,new ListItem("Select Product", ""));

               
                ExProdList.DataSource = prod;
                ExProdList.DataBind();
                ExProdList.Items.Insert(0, new ListItem("Select Product", ""));

            }

            
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
                            prodStock.Quantity = Convert.ToInt32(Qnty.Text);

                            dbobj.SaveChanges();
                        }

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
                    }
                }
                catch (Exception)
                {
                }

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ProdId"] = Convert.ToInt32(ProductList.SelectedItem.Value);
        }

        protected void ExProdStock_Click(object sender, EventArgs e)
        {
            if (PMDropdownlist.SelectedIndex != 0 && ExProdList.SelectedIndex != 0)
            {
                prodId = Convert.ToInt32(ViewState["ProdId"]);
                locId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
                if (prodId != 0)
                {

                    try
                    {
                        using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                        {
                            if (exQntyTxt.Text != "")
                            {
                                var prodStock = (from pd in dbobj.Stocks where pd.ProductId == prodId && pd.LocationId == locId select pd).FirstOrDefault();
                                prodStock.Quantity -= Convert.ToInt32(exQntyTxt.Text);

                                dbobj.SaveChanges();
                            }

                            ExcludeProduct ep = new ExcludeProduct();

                            ep.Particular = ParticularTxt.Text;
                            ep.Product = prodId;
                            ep.Quantity = Convert.ToInt32(exQntyTxt.Text);
                            ep.Worth = Convert.ToInt32(worthTxt.Text);
                            ep.Date = System.DateTime.Now;
                            ep.BranchId = locId;
                            ep.userId = Convert.ToInt32(Session["UserId"]);

                            dbobj.ExcludeProducts.Add(ep);
                            dbobj.SaveChanges();

                        }
                    }
                    catch (Exception)
                    {
                    }

                    Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void ExProdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ProdId"] = Convert.ToInt32(ExProdList.SelectedItem.Value);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            /*
            int tempBranchId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
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
                    var excludeStock = dbobj.sp_Search_Exclude(tempBranchId,tdt,fdt).ToList();

                    GridView1.DataSource = excludeStock;
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {
            }
*/

        }

       
    }
}