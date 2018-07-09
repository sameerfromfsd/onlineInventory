using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HafizG;
using System.IO;

namespace HafizG
{
    public partial class Prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            var folder = Server.MapPath("~/Images/products");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            using (AdvInvSystemEntities entity = new AdvInvSystemEntities())
            {
                if (FileUpload1.FileName != "")
                {
                    string dgImg = Server.MapPath(@"Images/products/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(dgImg);

                }
                Product pd = new Product();

                pd.ProductName = proNm.Text;
                pd.Unit = unit.Text;
                pd.SalePrice = Convert.ToInt32(saleP.Text);
                pd.PurchasePrice = Convert.ToInt32(purchP.Text);
                pd.CompanyId = Convert.ToInt32( DropDownList1.SelectedItem.Value);
                pd.img = "images/products/" + FileUpload1.FileName;
                pd.Status = status.Text;

                entity.Products.Add(pd);
                entity.SaveChanges();

               // Stock st = new Stock();
                
                // Enter product stock 0 for all new products Added


                Response.Redirect(Request.RawUrl);

            }

            Response.Redirect(Request.RawUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            proNm.Text = "";
            unit.Text = "";
            saleP.Text = "";
            purchP.Text = "";
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proId = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var pd = (from p in dbobj.Products where p.ProductId == proId select p).FirstOrDefault();
                    if (pd != null)
                    {
                        eProNm.Text = pd.ProductName;
                        eunit.Text = pd.Unit;
                        epurchP.Text = pd.PurchasePrice.ToString();
                        esaleP.Text = pd.SalePrice.ToString();
                        estatus.Text = pd.Status;
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var folder = Server.MapPath("~/Images/company/");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            if (FileUpload2.FileName != "")
            {
                string dgImg = Server.MapPath(@"Images/products/" + FileUpload2.FileName);
                FileUpload2.SaveAs(dgImg);

            }
            int proId = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            try
            {
          
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var pd = (from p in dbobj.Products where p.ProductId == proId select p).FirstOrDefault();
                    if (pd != null)
                    {
                        pd.ProductName = eProNm.Text;
                        pd.Unit = eunit.Text;
                        pd.Status = estatus.Text;
                        pd.CompanyId = Convert.ToInt32(DropDownList3.SelectedItem.Value);

                        if (FileUpload2.HasFile)
                        {
                            pd.img = "images/products/" + FileUpload2.FileName;
                        }

                        dbobj.SaveChanges();

                        eProNm.Text = "";
                        eunit.Text = "";
                        estatus.Text = "";
                        DropDownList3.SelectedIndex = 1;


                    }
                }
            }
            catch (Exception)
            {
            }
             Response.Redirect(Request.RawUrl);
        }
    }
}