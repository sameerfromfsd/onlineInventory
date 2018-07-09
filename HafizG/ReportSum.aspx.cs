using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class ReportSum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

        }

        protected void Search_Click(object sender, EventArgs e)
        {
           
            int tempBranchId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
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
                   
                    GridView1.DataSource = dbobj.sp_search_saleInvoices(tempBranchId, fdt, tdt).ToList();
                    GridView1.DataBind();

                    GridView2.DataSource = dbobj.sp_search_purchaseInvoices(tempBranchId, fdt, tdt).ToList();
                    GridView2.DataBind();
    
                    GridView3.DataSource = dbobj.sp_Search_Expense(tempBranchId, fdt, tdt).ToList();
                    GridView3.DataBind();
                }

                int tempSaleAm = 0;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    tempSaleAm += Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                }
                saleTxt.Text = tempSaleAm.ToString();


                int tempPurcAm = 0;
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    tempPurcAm += Convert.ToInt32(GridView2.Rows[i].Cells[3].Text);
                }
                purchTxt.Text = tempPurcAm.ToString();

                int tempExpAm = 0;
                for (int i = 0; i < GridView3.Rows.Count; i++)
                {
                    tempExpAm += Convert.ToInt32(GridView3.Rows[i].Cells[4].Text);
                }
                ExpTxt.Text = tempExpAm.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind(); 
        }
    }
}