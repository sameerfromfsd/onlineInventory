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
    
    public partial class AddFund
    {
        public int AddFundId { get; set; }
        public string Particular { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Time { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual LoginUser LoginUser { get; set; }
        public virtual StockLocation StockLocation { get; set; }
    }
}
