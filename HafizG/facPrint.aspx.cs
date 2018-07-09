using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HafizG;

namespace HafizG
{
    public partial class facPrint : System.Web.UI.Page
    {
        public int userId;
        public string shop;
        public string dt;
        public int invId;
        public string cuName;
        public string cuCell;
        public string gt;
        public string dis;
        public string pa;
        public int id;
        public int bal;
        public string cell;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sInvId"] != null)
            {
                id = (Int32)Session["sInvId"];
            }
            else
            {
                id = 1;
            }
            //

            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var si = dbobj.sp_saleInvoice_Dept(id).ToList();

                    userId = si[0].UserId;
                    shop = si[0].Name;
                    dt = si[0].Date.ToShortDateString();

                    gt = (si[0].Amount + " /-").ToString();
                    dis = (si[0].Discount + " /-").ToString();
                    pa = (si[0].Payable + " /-").ToString();

                    invId = si[0].SaleInvoicId;
                    cuName = si[0].CustomerName;

                    var pd = dbobj.sp_invoiceProduct_list(id).ToList();
                    GridView1.DataSource = pd;
                    GridView1.DataBind();

                    var si1 = (from s in dbobj.SaleInvoices where s.SaleInvoicId == id select s).FirstOrDefault();

                    int custId = si1.CustomerId;
                    var cus = (from c in dbobj.Customers where c.CustomerId == custId select c).FirstOrDefault();

                    bal = Convert.ToInt32(cus.Balance);
                    cell = cus.CellNumber;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}