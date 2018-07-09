using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class FundTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null && Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            fundTransError.Visible = false; 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (AmTxt.Text != "")
            {
                Button1.Enabled = false;
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    AddFund af = new AddFund();
                    af.Particular = PartTxt.Text;
                    af.Amount = Convert.ToInt32(AmTxt.Text);
                    af.AccountId = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                    af.UserId = Convert.ToInt32(Session["UserId"]);
                    af.BranchId = Convert.ToInt32(Session["BranchId"]);
                    af.Date = System.DateTime.Now;
                    af.Time = DateTime.Now.ToString("h:mm:ss tt");

                    dbobj.AddFunds.Add(af);
                    dbobj.SaveChanges();

                    AccountDetail ad = new AccountDetail();
                    ad.Particular = PartTxt.Text;
                    ad.Amount = Convert.ToInt32(AmTxt.Text);
                    ad.Mode = "Inward";
                    ad.DateTime = System.DateTime.Now;
                    ad.UserId = Convert.ToInt32(Session["UserId"]);
                    ad.Type = "Cash";
                    ad.AccountId = Convert.ToInt32(DropDownList1.SelectedItem.Value);

                    dbobj.AccountDetails.Add(ad);
                    dbobj.SaveChanges();

                    var acc = (from a in dbobj.Accounts where a.AccountId == ad.AccountId select a).FirstOrDefault();

                    acc.CurrentBalance = (Convert.ToInt32(acc.CurrentBalance) + Convert.ToInt32(AmTxt.Text)).ToString();
                    dbobj.SaveChanges();
                }
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                addFundError.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PartTxt.Text = "";
            AmTxt.Text = "";
            DropDownList1.SelectedIndex = 0;


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.Text != DropDownList3.SelectedItem.Text && TpartTxt.Text != "")
            {
                Button3.Enabled = false;
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    FundTran ft = new FundTran();
                    ft.Particular = TpartTxt.Text;
                    ft.FromAccount = DropDownList2.SelectedItem.Text;
                    ft.ToAccount = DropDownList3.SelectedItem.Text;
                    ft.Amount = Convert.ToInt32(TAmTxt.Text);
                    ft.Date = System.DateTime.Now;
                    ft.Time = DateTime.Now.ToString("h:mm:ss tt");
                    ft.UserId = Convert.ToInt32(Session["UserId"]);
                    ft.BranchId = Convert.ToInt32(Session["BranchId"]);

                    dbobj.FundTrans.Add(ft);
                    dbobj.SaveChanges();

                    AccountDetail ad = new AccountDetail();
                    ad.Particular = TpartTxt.Text;
                    ad.Amount = Convert.ToInt32(TAmTxt.Text);
                    ad.Mode = "Outward";
                    ad.DateTime = System.DateTime.Now;
                    ad.UserId = Convert.ToInt32(Session["UserId"]);
                    ad.Type = "Cash";

                    ad.AccountId = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                    dbobj.AccountDetails.Add(ad);
                    dbobj.SaveChanges();

                    AccountDetail ad1 = new AccountDetail();
                    ad1.Particular = TpartTxt.Text;
                    ad1.Amount = Convert.ToInt32(TAmTxt.Text);
                    ad1.Mode = "Inward";
                    ad1.DateTime = System.DateTime.Now;
                    ad1.UserId = Convert.ToInt32(Session["UserId"]);
                    ad1.Type = "Cash";
                    ad1.AccountId = Convert.ToInt32(DropDownList3.SelectedItem.Value);

                    dbobj.AccountDetails.Add(ad1);
                    dbobj.SaveChanges();

                    int facc = Convert.ToInt32(DropDownList2.SelectedItem.Value);
                    var acc = (from a in dbobj.Accounts where a.AccountId == facc select a).FirstOrDefault();

                    acc.CurrentBalance = (Convert.ToInt32(acc.CurrentBalance) - Convert.ToInt32(TAmTxt.Text)).ToString();
                    dbobj.SaveChanges();

                    int tacc = Convert.ToInt32(DropDownList3.SelectedItem.Value);
                    var acc1 = (from a in dbobj.Accounts where a.AccountId == tacc select a).FirstOrDefault();

                    acc1.CurrentBalance = (Convert.ToInt32(acc1.CurrentBalance) + Convert.ToInt32(TAmTxt.Text)).ToString();
                    dbobj.SaveChanges();

                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                fundTransError.Visible = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TpartTxt.Text = "";
            AmTxt.Text = "";
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int tempAccId = Convert.ToInt32(WDAccDropDownList.SelectedItem.Value);
            Button5.Enabled = false;
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    var ac = (from a in dbobj.Accounts where a.AccountId == tempAccId select a).FirstOrDefault();

                    ac.CurrentBalance = (Convert.ToInt32(ac.CurrentBalance) - Convert.ToInt32(wAmTxt.Text)).ToString();
                    dbobj.SaveChanges();

                    Withdraw wd = new Withdraw();
                    wd.Particular = wPartTxt.Text;
                    wd.Amount = Convert.ToInt32(wAmTxt.Text);
                    wd.BranchId = Convert.ToInt32(Session["BranchId"]);
                    wd.Date = System.DateTime.Now;

                    TimeZoneInfo tzi;
                    DateTime dtTz;
                    tzi = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                    dtTz = TimeZoneInfo.ConvertTime(DateTime.Now, tzi);

                    wd.Time = dtTz.ToString("h:mm:ss tt");

                    wd.AccountId = tempAccId;
                    wd.UserId = Convert.ToInt32(Session["UserId"]);
                   
                    dbobj.Withdraws.Add(wd);
                    dbobj.SaveChanges();


                    AccountDetail ad = new AccountDetail();
                    ad.Particular = wPartTxt.Text + "Owner Withdraw";
                    ad.Amount = Convert.ToInt32(wAmTxt.Text);
                    ad.Mode = "Outward";
                    ad.DateTime = System.DateTime.Now;
                    ad.AccountId = tempAccId;
                    ad.UserId = Convert.ToInt32(Session["UserId"]);
                    ad.Type = "Cash";

                    dbobj.AccountDetails.Add(ad);
                    dbobj.SaveChanges();

                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            DateTime tdt;
            if (datepicker.Text != "")
            {

                if (datepicker1.Text != "")
                {
                    tdt = DateTime.Parse(datepicker1.Text);
                }
                else
                {
                    tdt = System.DateTime.Now;
                }
                DateTime fdt = DateTime.Parse(datepicker.Text);

                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities()) 
                    {
                        var wdReport = dbobj.sp_withdraw_report(fdt, tdt).ToList();

                        GridView2.DataSource = wdReport;
                        GridView2.DataBind();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            DateTime tdt;
            if (dp1.Text != "")
            {

                if (dp2.Text != "")
                {
                    tdt = DateTime.Parse(dp2.Text);
                }
                else
                {
                    tdt = System.DateTime.Now;
                }
                DateTime fdt = DateTime.Parse(dp1.Text);

                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                        var fundTrns = dbobj.sp_fund_transfer(fdt, tdt).ToList();

                        GridView3.DataSource = fundTrns;
                        GridView3.DataBind();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            DateTime tdt;
            if (dp3.Text != "")
            {

                if (dp4.Text != "")
                {
                    tdt = DateTime.Parse(dp4.Text);
                }
                else
                {
                    tdt = System.DateTime.Now;
                }
                DateTime fdt = DateTime.Parse(dp3.Text);

                try
                {
                    using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                    {
                        var fundTrns = dbobj.sp_Add_fund(fdt, tdt).ToList();

                        GridView4.DataSource = fundTrns;
                        GridView4.DataBind();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}