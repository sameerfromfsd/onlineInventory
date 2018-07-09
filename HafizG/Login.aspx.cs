using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();

            validDiv.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (emTxt.Text != "" && pasTxt.Text != "")
            {
                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                        LoginUser lu = new LoginUser();
                        lu = (from us1 in dbobj.LoginUsers
                              where us1.EmailId == emTxt.Text && us1.Password == pasTxt.Text
                              select us1).FirstOrDefault();

                        if (lu != null)
                        {
                            Session["UserId"] = lu.UserId;
                            Session["UserName"] = lu.Name;
                            Session["UserEmail"] = lu.EmailId;
                            Session["UserImg"] = lu.Image;
                            Session["UserDesig"] = lu.Designation;
                            Session["BranchId"] = lu.LocAssigned;

                            Response.Redirect("Default.aspx");
                        }

                        else
                        {
                            validDiv.Visible = true; 
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}