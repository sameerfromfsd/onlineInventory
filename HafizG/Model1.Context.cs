﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AdvInvSystemEntities : DbContext
    {
        public AdvInvSystemEntities()
            : base("name=AdvInvSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ChequeList> ChequeLists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomersAccount> CustomersAccounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<LoginUser> LoginUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<RateChangeLog> RateChangeLogs { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<StockLocation> StockLocations { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SupplierAccount> SupplierAccounts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BnkTan> BnkTans { get; set; }
        public DbSet<CashTran> CashTrans { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<ExcludeProduct> ExcludeProducts { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<AddFund> AddFunds { get; set; }
        public DbSet<FundTran> FundTrans { get; set; }
        public DbSet<AddStock> AddStocks { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int sp_Add_Stock(Nullable<int> prodId, Nullable<int> locId, Nullable<int> qnty)
        {
            var prodIdParameter = prodId.HasValue ?
                new ObjectParameter("prodId", prodId) :
                new ObjectParameter("prodId", typeof(int));
    
            var locIdParameter = locId.HasValue ?
                new ObjectParameter("locId", locId) :
                new ObjectParameter("locId", typeof(int));
    
            var qntyParameter = qnty.HasValue ?
                new ObjectParameter("qnty", qnty) :
                new ObjectParameter("qnty", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Add_Stock", prodIdParameter, locIdParameter, qntyParameter);
        }
    
        public virtual ObjectResult<sp_newStockList_Result> sp_newStockList(Nullable<int> locId)
        {
            var locIdParameter = locId.HasValue ?
                new ObjectParameter("locId", locId) :
                new ObjectParameter("locId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_newStockList_Result>("sp_newStockList", locIdParameter);
        }
    
        public virtual ObjectResult<sp_stockList_Result2> sp_stockList(Nullable<int> locId)
        {
            var locIdParameter = locId.HasValue ?
                new ObjectParameter("locId", locId) :
                new ObjectParameter("locId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_stockList_Result2>("sp_stockList", locIdParameter);
        }
    
        public virtual ObjectResult<slist_Result> slist(Nullable<int> locId)
        {
            var locIdParameter = locId.HasValue ?
                new ObjectParameter("locId", locId) :
                new ObjectParameter("locId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<slist_Result>("slist", locIdParameter);
        }
    
        public virtual ObjectResult<sp_finalStockList_Result> sp_finalStockList(Nullable<int> locId)
        {
            var locIdParameter = locId.HasValue ?
                new ObjectParameter("locId", locId) :
                new ObjectParameter("locId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_finalStockList_Result>("sp_finalStockList", locIdParameter);
        }
    
        public virtual ObjectResult<sp_finalStockList_Result> finalStockList(Nullable<int> locId)
        {
            var locIdParameter = locId.HasValue ?
                new ObjectParameter("locId", locId) :
                new ObjectParameter("locId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_finalStockList_Result>("finalStockList", locIdParameter);
        }
    
        public virtual ObjectResult<sp_Accounts_type_Result> sp_Accounts_type(string type)
        {
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Accounts_type_Result>("sp_Accounts_type", typeParameter);
        }
    
        public virtual ObjectResult<sp_Accounts_type_Result> AccTypes(string type)
        {
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Accounts_type_Result>("AccTypes", typeParameter);
        }
    
        public virtual ObjectResult<sp_search_saleInvoices_Result> sp_search_saleInvoices(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_search_saleInvoices_Result>("sp_search_saleInvoices", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_search_saleInvoices_Result> s_s_invoice(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_search_saleInvoices_Result>("s_s_invoice", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_sale_detail_Result> sp_sale_detail(Nullable<int> saleId)
        {
            var saleIdParameter = saleId.HasValue ?
                new ObjectParameter("saleId", saleId) :
                new ObjectParameter("saleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_sale_detail_Result>("sp_sale_detail", saleIdParameter);
        }
    
        public virtual ObjectResult<sp_sale_detail_Result> sale_detail(Nullable<int> saleId)
        {
            var saleIdParameter = saleId.HasValue ?
                new ObjectParameter("saleId", saleId) :
                new ObjectParameter("saleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_sale_detail_Result>("sale_detail", saleIdParameter);
        }
    
        public virtual ObjectResult<sp_search_purchaseInvoices_Result> sp_search_purchaseInvoices(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_search_purchaseInvoices_Result>("sp_search_purchaseInvoices", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_search_purchaseInvoices_Result> s_p_list(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_search_purchaseInvoices_Result>("s_p_list", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_purchase_detail_Result> sp_purchase_detail(Nullable<int> purchaseId)
        {
            var purchaseIdParameter = purchaseId.HasValue ?
                new ObjectParameter("purchaseId", purchaseId) :
                new ObjectParameter("purchaseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_purchase_detail_Result>("sp_purchase_detail", purchaseIdParameter);
        }
    
        public virtual ObjectResult<sp_Search_Expense_Result> sp_Search_Expense(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Search_Expense_Result>("sp_Search_Expense", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_Search_Expense_Result> exp_result(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Search_Expense_Result>("exp_result", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_purchaseInvoice_Depth_Result1> sp_purchaseInvoice_Depth(Nullable<int> purcInvId)
        {
            var purcInvIdParameter = purcInvId.HasValue ?
                new ObjectParameter("purcInvId", purcInvId) :
                new ObjectParameter("purcInvId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_purchaseInvoice_Depth_Result1>("sp_purchaseInvoice_Depth", purcInvIdParameter);
        }
    
        public virtual ObjectResult<sp_invoiceProduct_list_Result> sp_invoiceProduct_list(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_invoiceProduct_list_Result>("sp_invoiceProduct_list", idParameter);
        }
    
        public virtual ObjectResult<sp_Search_Exclude_Result> sp_Search_Exclude(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Search_Exclude_Result>("sp_Search_Exclude", branchIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_saleInvoice_Dept_Result> sp_saleInvoice_Dept(Nullable<int> saleInvId)
        {
            var saleInvIdParameter = saleInvId.HasValue ?
                new ObjectParameter("saleInvId", saleInvId) :
                new ObjectParameter("saleInvId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_saleInvoice_Dept_Result>("sp_saleInvoice_Dept", saleInvIdParameter);
        }
    
        public virtual ObjectResult<sp_Customer_Report_Result> sp_Customer_Report(Nullable<int> cusId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var cusIdParameter = cusId.HasValue ?
                new ObjectParameter("cusId", cusId) :
                new ObjectParameter("cusId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Customer_Report_Result>("sp_Customer_Report", cusIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_Supplier_Report_Result> sp_Supplier_Report(Nullable<int> supId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var supIdParameter = supId.HasValue ?
                new ObjectParameter("supId", supId) :
                new ObjectParameter("supId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Supplier_Report_Result>("sp_Supplier_Report", supIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_withdraw_report_Result1> sp_withdraw_report(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_withdraw_report_Result1>("sp_withdraw_report", startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_Add_fund_Result> sp_Add_fund(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Add_fund_Result>("sp_Add_fund", startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_fund_transfer_Result1> sp_fund_transfer(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_fund_transfer_Result1>("sp_fund_transfer", startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_view_StockAdd_Result> sp_view_StockAdd(Nullable<int> branchId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("branchId", branchId) :
                new ObjectParameter("branchId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_view_StockAdd_Result>("sp_view_StockAdd", branchIdParameter, startDateParameter, endDateParameter);
        }
    }
}
