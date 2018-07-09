using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HafizG;

namespace HafizG
{
    public partial class au : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.FileName != "")
            {
                string dgImg = Server.MapPath(@"Images/avatar/" + FileUpload1.FileName);
                FileUpload1.SaveAs(dgImg);

            }

            try
            {
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

                    lu.LocAssigned = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                    dbobj.LoginUsers.Add(lu);
                    dbobj.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}