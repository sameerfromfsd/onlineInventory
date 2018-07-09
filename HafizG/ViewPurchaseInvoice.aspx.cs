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
    public partial class ViewPurchaseInvoice : System.Web.UI.Page
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
            if (GridView2.Rows.Count >= 1)
            {

                GridView2.Visible = false;
                DetailsView1.Visible = false;

            }
            GridView1.Visible = true;

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
                    IEnumerable<sp_search_purchaseInvoices_Result> spi = dbobj.sp_search_purchaseInvoices(tempBranchId, fdt, tdt);
                    
                    GridView1.DataSource = spi;
                    GridView1.DataBind();

                    int tempPurcAm = 0;
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        tempPurcAm += Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);

                    }

                    tSale.Visible = true;
                    tSaleTxt.Text = tempPurcAm.ToString();
                }
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
               // IEnumerable<sp_purchaseInvoice_Depth_Result> pid = dbobj.sp_purchaseInvoice_Depth(tempId);

                DetailsView1.DataSource = dbobj.sp_purchaseInvoice_Depth(tempId).ToList();
                DetailsView1.DataBind();

               // IEnumerable<sp_purchase_detail_Result> pd = dbobj.sp_purchase_detail(tempId);
                loadGrid(tempId);
                GridView2.Visible = true;
                DetailsView1.Visible = true;
            }

            GridView1.Visible = false;
        }

        public void loadGrid(int id)
        {
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                GridView2.DataSource = dbobj.sp_purchase_detail(id).ToList();
                GridView2.DataBind();
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (ViewState["tempId"] == null)
            {
            ViewState["tempId"] = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            }
            GridView2.EditIndex = e.NewEditIndex;
            int sd = GridView2.EditIndex;
            int tempId = (Int32)ViewState["tempId"];
            loadGrid(tempId);
            
            DataBind();


        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int tempId = (Int32)ViewState["tempId"];
            Label lpid = (Label)GridView2.Rows[e.RowIndex].FindControl("pdId");
            int id = Convert.ToInt32(lpid.Text);
            TextBox qn = (TextBox)GridView2.Rows[e.RowIndex].FindControl("qnty");
            TextBox rt = (TextBox)GridView2.Rows[e.RowIndex].FindControl("pTxt");
            int qnt = Convert.ToInt32(qn.Text);

            qn.ReadOnly = false;
            rt.ReadOnly = false; 
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var pDetail = (from pd in dbobj.PurchaseDetails where pd.PurchaseDetailId == id select pd).FirstOrDefault();
                    var pInvoic = (from pi in dbobj.PurchaseInvoices where pi.PurchaseInvoiceId == tempId select pi).FirstOrDefault();
                    if (qnt == 0)
                    {
                        dbobj.PurchaseDetails.Remove(pDetail);
                        dbobj.SaveChanges();

                        pInvoic.Paid -= pDetail.Price;
                        dbobj.SaveChanges(); 
                    }
                    else if (qnt > 0)
                    {
                        pDetail.Quantity = qnt;
                        pDetail.Price = Convert.ToInt32(rt.Text);

                        dbobj.SaveChanges();
                    }
                    GridView2.EditIndex = -1;

                    loadGrid(tempId);

                    DataBind();
                }

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
            }

        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            int tempId = (Int32)ViewState["tempId"];
            GridView2.EditIndex = -1;

            loadGrid(tempId);

            DataBind();

           
        }


    }
}