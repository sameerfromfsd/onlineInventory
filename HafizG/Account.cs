//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HafizG
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            this.Expenses = new HashSet<Expense>();
            this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
            this.SaleInvoices = new HashSet<SaleInvoice>();
            this.AccountDetails = new HashSet<AccountDetail>();
            this.Withdraws = new HashSet<Withdraw>();
            this.AddFunds = new HashSet<AddFund>();
        }
    
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string ContactPerson { get; set; }
        public string Type { get; set; }
        public string CurrentBalance { get; set; }
    
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual ICollection<SaleInvoice> SaleInvoices { get; set; }
        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual ICollection<Withdraw> Withdraws { get; set; }
        public virtual ICollection<AddFund> AddFunds { get; set; }
    }
}
