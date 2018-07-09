using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Branches : System.Web.UI.Page
    {
        int tempId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            Button2.Enabled = false; 
            Page.Title = "Branches";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                StockLocation sl = new StockLocation();

                sl.Name = NmTxt.Text;
                sl.Location = LocTxt.Text;
                sl.Supervisor = SupTxt.Text;
                sl.ContactNumber = NumTxt.Text;

                dbobj.StockLocations.Add(sl);
                dbobj.SaveChanges();

                NmTxt.Text = "";
                LocTxt.Text = "";
                SupTxt.Text = "";
                NumTxt.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tempId = Convert.ToInt32(ViewState["tempId"]);
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                StockLocation sl = new StockLocation();
                sl = (from s in dbobj.StockLocations where s.StockLocId == tempId select s).FirstOrDefault();

                sl.Name = NmTxt.Text;
                sl.Location = LocTxt.Text;
                sl.Supervisor = SupTxt.Text;
                sl.ContactNumber = NumTxt.Text;

                dbobj.SaveChanges();
                NmTxt.Text = "";
                LocTxt.Text = "";
                SupTxt.Text = "";
                NumTxt.Text = "";

                Button1.Enabled = true;
                Button2.Enabled = false;

                Response.Redirect("default.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button2.Enabled = true;
            Button1.Enabled = false;

             ViewState["tempId"] = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
             tempId = Convert.ToInt32(ViewState["tempId"]);
              using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
              {
                  StockLocation sl = new StockLocation();
                  sl = (from s in dbobj.StockLocations where s.StockLocId == tempId select s).FirstOrDefault();

                  NmTxt.Text = sl.Name;
                  LocTxt.Text = sl.Location;
                  SupTxt.Text = sl.Supervisor;
                  NumTxt.Text = sl.ContactNumber;
              }
        }
    }
}