using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class Accounts : System.Web.UI.Page
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
            using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
            {
                Account ac = new Account();
                ac.Title = titleTxt.Text;
                ac.AccountNumber = AccTxt.Text;
                ac.Bank = BankTxt.Text;
                ac.Type = DropDownList1.SelectedItem.Value;
                ac.CurrentBalance = BalTxt.Text;

                dbobj.Accounts.Add(ac);
                dbobj.SaveChanges();

                titleTxt.Text = "";
                AccTxt.Text = "";
                BankTxt.Text = "";
                DropDownList1.SelectedIndex = 0;
                BalTxt.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            titleTxt.Text = "";
            AccTxt.Text = "";
            BankTxt.Text = "";
            DropDownList1.SelectedIndex = 0;
            BalTxt.Text = "";
        }
    }
}