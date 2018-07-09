using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Exclude : System.Web.UI.Page
    {
       // int tempBranch;
       // int prodId;
       // int locId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }
          
        }

        protected void PMDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int locId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);

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

                    var exPro = (from ep in dbobj.ExcludeProducts where ep.ExId == id select ep).FirstOrDefault();

                    int proId = Convert.ToInt32(exPro.Product);
                    int branchId = Convert.ToInt32(exPro.BranchId);
                    int prvQnty = Convert.ToInt32(exPro.Quantity);
                    int diff;

                    var stl = (from st in dbobj.Stocks where st.ProductId == proId && st.LocationId == branchId select st).FirstOrDefault();


                    if (Convert.ToInt32(qn.Text) > 0)
                    {
                        exPro.Quantity = Convert.ToInt32(qn.Text);
                        exPro.Worth = Convert.ToInt32(rt.Text);
                        
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


                        dbobj.ExcludeProducts.Remove(exPro);
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
                        var excludeStock = dbobj.sp_Search_Exclude(tempBranchId, fdt, tdt).ToList();

                        GridView1.DataSource = excludeStock;
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