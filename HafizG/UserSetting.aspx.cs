using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class UserSetting : System.Web.UI.Page
    {
        public string imgUrl;
        public string name = "testing";
        public string email;
        public string desig;
        public string cell;
        public string pass;
        public int status;
        int mytempId;

        protected void Page_Load(object sender, EventArgs e)
        {   mytempId = Convert.ToInt32(Session["UserId"]);
            if (!IsPostBack)
            {   

            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            mytempId = Convert.ToInt32(Session["UserId"]);
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    LoginUser lu = new LoginUser();

                    lu = (from us1 in dbobj.LoginUsers
                          where us1.UserId == mytempId
                          select us1).FirstOrDefault();

                    if (lu != null)
                    {
                         imgUrl = lu.Image;
                         name = lu.Name;
                         email = lu.EmailId;
                         desig = lu.Designation;
                         cell = lu.CellNumber;
                         pass = lu.Password;
                         status = lu.Status;

                         NmTxt.Text = lu.Name;
                         EmailTxt.Text = lu.EmailId;
                         PassTxt.Text = lu.Password;
                         CellTxt.Text = lu.CellNumber;

                    }
                }
                
            }
            catch(Exception ex)
            {
                string err = ex.InnerException.Message;
            }
        }
            Page.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                if (FileUpload1.FileName != "")
                {
                    string dgImg = Server.MapPath(@"Images/avatar/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(dgImg);

                }
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    LoginUser lu = new LoginUser();
                    lu = (from us1 in dbobj.LoginUsers
                          where us1.UserId == mytempId
                          select us1).FirstOrDefault();

                    if (lu != null)
                    {
                        lu.Name = NmTxt.Text;
                        lu.Password = PassTxt.Text;
                        lu.EmailId = EmailTxt.Text;
                        lu.CellNumber = CellTxt.Text;

                        if (FileUpload1.FileName != "")
                        {
                            lu.Image = "images/avatar/" + FileUpload1.FileName;
                        }

                        dbobj.SaveChanges();
                        Response.Redirect("Default.aspx");
                    }

                }
            }

        
    }
}