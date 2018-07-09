using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class ab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var cus = (from c in dbobj.Customers where c.CustomerId == 1 select c).FirstOrDefault();

                    if (cus != null && cus.CustomerName == "Anomynous")
                    {
                        cus.Balance = 0;
                        dbobj.SaveChanges();

                        Label1.Text = "Anomynous balance modified successfully ";
                        Label1.Visible = true;
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var acc = (from a in dbobj.Accounts where a.AccountId == 1 select a).FirstOrDefault();

                    if (acc != null )
                    {
                        acc.CurrentBalance = TextBox1.Text;
                        dbobj.SaveChanges();

                        Label2.Text = "Shop Account Updated ";
                        Label2.Visible = true;
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var acc = (from a in dbobj.Accounts where a.AccountId == 2 select a).FirstOrDefault();

                    if (acc != null)
                    {
                        acc.CurrentBalance = TextBox2.Text;
                        dbobj.SaveChanges();

                        Label2.Text = "Factory Account Updated ";
                        Label2.Visible = true;
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
            }
        }
    }
}