using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class reset : System.Web.UI.Page
    {
        AdvInvSystemEntities dbobj = new AdvInvSystemEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (dbobj)
                {
                  //  dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [ChequeList]");
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [BnkTans]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [CashTrans]");
                    dbobj.SaveChanges();

                    

                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [SaleDetail]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [SaleInvoice]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [PurchaseDetail]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [PurchaseInvoice]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [AccountDetail]");
                    dbobj.SaveChanges();

                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [CustomersAccount]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [SupplierAccount]");
                    dbobj.SaveChanges();
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [Suppliers]");
                    dbobj.SaveChanges();

                    
                    dbobj.Database.ExecuteSqlCommand("TRUNCATE TABLE [Products]");
                   

                    dbobj.SaveChanges();
                }
            }
            catch (Exception ex)
            {
               
            }

        }
    }
}