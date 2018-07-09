using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class _Default : Page
    {
        public int CustomerCount;
        public int SupplierCount { get; set; }
        public int SaleInvoiceCount { get; set; }
        public int PurchInvoiceCount { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
               var CustomerCount1 = dbobj.Customers.SqlQuery("Select * from Customers").ToList();
               CustomerCount = CustomerCount1.Count();

               var sup = dbobj.Suppliers.SqlQuery("Select * from Suppliers").ToList();
               SupplierCount = sup.Count();

               var saleInv = dbobj.SaleInvoices.SqlQuery("Select * from SaleInvoice").ToList();
               SaleInvoiceCount = saleInv.Count();

               var purchInv = dbobj.PurchaseInvoices.SqlQuery("select * from PurchaseInvoice").ToList();
               PurchInvoiceCount = purchInv.Count(); 
            }
        }
    }
}