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
    
    public partial class SaleDetail
    {
        public int SaleInvoiceDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quatity { get; set; }
        public int Rate { get; set; }
        public int DiscountedRate { get; set; }
        public int SaleInvoiceId { get; set; }
    
        public virtual SaleInvoice SaleInvoice { get; set; }
    }
}