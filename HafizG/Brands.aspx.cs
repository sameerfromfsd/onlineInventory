using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HafizG;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace HafizG
{
    public partial class Brands : System.Web.UI.Page
    {

        int bId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            Button2.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            using(AdvInvSystemEntities comp = new AdvInvSystemEntities())
            {

                
                var folder = Server.MapPath("~/Images/company/");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }


                 if (FileUpload1.FileName != "")
                            {
                                string dgImg = Server.MapPath(@"Images/company/" + FileUpload1.FileName);
                                FileUpload1.SaveAs(dgImg);

                            }
                 Brand bd = new Brand();

                 bd.CompanyName = compNm.Text;
                 bd.ContactPerson = compPers.Text;
                 bd.ContactNumber = cellNm.Text;
                 bd.Logo = "images/company/" + FileUpload1.FileName;

                 comp.Brands.Add(bd);
                 comp.SaveChanges();

                 compNm.Text = "";
                 compPers.Text = "";
                 cellNm.Text = "";

            }
            Button2.Enabled = false;

            Response.Redirect(Request.RawUrl);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ImageClick") // check command is cmd_delete
            {
                Button2.Enabled = true;
                Button1.Enabled = false;

                // get you required value
                int brandId = Convert.ToInt32(e.CommandArgument);
                ViewState["bid"] = brandId;
                
                //Write some code for what you need 


                try
                {
                    using (AdvInvSystemEntities comp = new AdvInvSystemEntities())
                    {
                        Brand bd = new Brand();
                        bd = (from b in comp.Brands where b.BrandId == brandId select b).FirstOrDefault();

                        compNm.Text = bd.CompanyName;
                        compPers.Text = bd.ContactPerson;
                        cellNm.Text = bd.ContactNumber;


                    }

                }
                catch (Exception)
                {
                }
            }

        }

        protected void Image_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ImageClick")
            {
                //e.CommandArgument -->  photoid value
                //Do something
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var folder = Server.MapPath("~/Images/company/");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            bId = Convert.ToInt32(ViewState["bid"]);
            string dgImg;
            try
            {
                if (FileUpload1.FileName != "")
                {
                    dgImg = Server.MapPath(@"Images/company/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(dgImg);

                }

                using (AdvInvSystemEntities comp = new AdvInvSystemEntities())
                {
                    Brand bd = new Brand();
                    bd = (from b in comp.Brands where b.BrandId == bId select b).FirstOrDefault();

                    bd.CompanyName = compNm.Text;
                    bd.ContactPerson = compPers.Text;
                    bd.ContactNumber = cellNm.Text;
                    if (FileUpload1.FileName != "")
                    {
                        bd.Logo = "images/company/" + FileUpload1.FileName;
                    }

                    comp.SaveChanges();
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
            }
        }
    }
}