using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HafizG
{
    public partial class ViewExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            int tempBranchId = Convert.ToInt32(PMDropdownlist.SelectedItem.Value);
            // string fdt = datepicker.Text;
            //string tdt = datepicker1.Text;
            DateTime tdt;
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
                    IEnumerable<sp_Search_Expense_Result> se = dbobj.sp_Search_Expense(tempBranchId,fdt,tdt);
                    
                    GridView1.DataSource = se;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}