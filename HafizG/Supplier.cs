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
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
            this.SupplierAccounts = new HashSet<SupplierAccount>();
        }
    
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string CellNumber { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public int Balance { get; set; }
    
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual ICollection<SupplierAccount> SupplierAccounts { get; set; }
    }
}
