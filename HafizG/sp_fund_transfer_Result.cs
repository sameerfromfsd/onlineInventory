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
    
    public partial class sp_fund_transfer_Result
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string BranchNm { get; set; }
        public int FundTransId { get; set; }
        public string Particular { get; set; }
        public Nullable<int> FromAccount { get; set; }
        public Nullable<int> ToAccount { get; set; }
        public int Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Time { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> BranchId { get; set; }
    }
}