﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alwi_Laptop_Mart
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbALMContext : DbContext
    {
        public dbALMContext()
            : base("name=dbALMContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Product> tbl_Product { get; set; }
        public virtual DbSet<tbl_Cart> tbl_Cart { get; set; }
        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
        public virtual DbSet<tbl_OrderHistory> tbl_OrderHistory { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
    }
}