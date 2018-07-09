using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HafizG
{
    public partial class Users : System.Web.UI.Page
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


            var folder = Server.MapPath("~/Images/avatar");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }



            if (FileUpload1.FileName != "")
            {
                string dgImg = Server.MapPath(@"Images/avatar/" + FileUpload1.FileName);
                FileUpload1.SaveAs(dgImg);

            }

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                LoginUser lu = new LoginUser();

                lu.Name = NmTxt.Text;
                lu.Password = PassTxt.Text;
                lu.EmailId = EmailTxt.Text;
                lu.Designation = DesTxt.Text;
                if (DropDownList1.SelectedItem.Value == "Active")
                {
                    lu.Status = 1;
                }
                else if (DropDownList1.SelectedItem.Value == "Deactive")
                {
                    lu.Status = 0;
                }
                lu.CellNumber = CellTxt.Text;
                if (FileUpload1.FileName != "")
                {
                    lu.Image = "images/avatar/" + FileUpload1.FileName;
                }

                lu.LocAssigned = Convert.ToInt32( DropDownList2.SelectedItem.Value);

                dbobj.LoginUsers.Add(lu);
                dbobj.SaveChanges();

               
            }


            Response.Redirect(Request.RawUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            NmTxt.Text = "";
            PassTxt.Text = "";
            EmailTxt.Text = "";
            DesTxt.Text = "";
            DropDownList1.SelectedIndex = 0;
            CellTxt.Text = "";
            DropDownList2.SelectedIndex = 0;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                var us = (from u in dbobj.LoginUsers where u.UserId == id select u).First();

                dbobj.LoginUsers.Remove(us);
                dbobj.SaveChanges();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}