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
    
    public partial class ChequeList
    {
        public ChequeList()
        {
            this.BnkTans = new HashSet<BnkTan>();
        }
    
        public int ChequeId { get; set; }
        public string Mode { get; set; }
        public string ChequeNumber { get; set; }
        public string Bank { get; set; }
        public string MadeBy { get; set; }
        public int Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
        public int AccountId { get; set; }
    
        public virtual ICollection<BnkTan> BnkTans { get; set; }
    }
}
