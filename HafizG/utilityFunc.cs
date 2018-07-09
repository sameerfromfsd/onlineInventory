using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace HafizG
{
    public class utilityFunc
    {

        public void login(string emTxt , string pasTxt)
        {
           
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    LoginUser lu = new LoginUser();
                    lu = (from us1 in dbobj.LoginUsers
                          where us1.EmailId == emTxt && us1.Password == pasTxt
                          select us1).FirstOrDefault();
                    if (lu != null)
                    {


                        HttpContext.Current.Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        
                    }

                }
            }
            catch (Exception ex)
            {

            }

            
        }

        [WebMethod]
        public static void checkUser()
        {
            if (HttpContext.Current.Session["UserEmail"] == null && HttpContext.Current.Session["UserName"] == null)
            {
                HttpContext.Current.Response.Redirect("Default.aspx", true);
            }
        }


        public static void DepositFund(int invId , int fundAmount , string mode , int acc , string madeby)
        {
            int tempRemAm = 0;
            int tempCusId ;
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {

                    SaleInvoice si = new SaleInvoice();
                    si = (from s in dbobj.SaleInvoices where s.SaleInvoicId == invId select s).FirstOrDefault();
                    tempCusId = si.CustomerId;

                    Customer cu = new Customer();
                    cu = (from c in dbobj.Customers where c.CustomerId == tempCusId select c).FirstOrDefault();
                    cu.Balance += fundAmount;
                    dbobj.SaveChanges();

                    CustomersAccount ca = new CustomersAccount();
                    ca.CustomerId = tempCusId;
                    ca.Date = System.DateTime.Now;
                    ca.Debit = fundAmount;
                    ca.Credit = 0;
                    dbobj.CustomersAccounts.Add(ca);
                    dbobj.SaveChanges(); 



                    if (si.Paid != si.Amount)
                    {
                        tempRemAm = si.Payable - si.Paid;
                        fundAmount = fundAmount - tempRemAm;

                        if(fundAmount == si.Payable)
                        {
                        si.Paid = si.Payable;
                        si.Status = "Cleared";
                       
                        }

                        else
                        {
                            si.Paid = fundAmount;
                            si.Status = "Pending";
                           
                        }
                        si.PaymentMode = mode;
                        si.AccountId = acc; 
                        dbobj.SaveChanges();

                        AccountDetail ac = new AccountDetail();
                        ac.Particular = "Sale inv# " + si.SaleInvoicId;
                        ac.Amount = si.Paid;
                        ac.Mode = "Inward";
                        ac.DateTime = System.DateTime.Now;
                        ac.AccountId = acc;
                        ac.UserId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                        dbobj.AccountDetails.Add(ac);
                        dbobj.SaveChanges();
                       

                        if (si.PaymentMode == "Cash")
                        {
                            CashTran ct = new CashTran();
                            ct.Particular = "Sale inv# " + si.SaleInvoicId;
                            ct.Amount = si.Paid;
                            ct.AccountDetailId = ac.AccountsDetailId;

                            dbobj.CashTrans.Add(ct);
                            dbobj.SaveChanges();
                        }
                        else if (si.PaymentMode == "Bank")
                        {
                            BnkTan bkt = new BnkTan();
                            bkt.Particular = "Sale inv# " + si.SaleInvoicId;
                            bkt.Amount = si.Paid;
                            bkt.AccountDetailId = ac.AccountsDetailId;

                            
                            bkt.MadeBy = madeby;
                            bkt.DueDate = System.DateTime.Now;

                            dbobj.BnkTans.Add(bkt);
                            dbobj.SaveChanges();


                        }
                    }

                }
            }
            catch (Exception)
            {
            }
        }

        public static void chequeTrans(string chq , string bk, string madeby , int am)
        {
            try
            {
                using (AdvInvSystemEntities dbobj = new AdvInvSystemEntities())
                {
                    ChequeList cq = new ChequeList();
                    cq.ChequeNumber = chq;
                    cq.Mode = "Inward";
                    cq.Bank = bk;
                    cq.MadeBy = madeby;
                    cq.Amount = am;
                    cq.Date = System.DateTime.Now;
                    cq.Status = "Pending";


                }
            }
            catch (Exception)
            {
            }
        }



    }

    
}