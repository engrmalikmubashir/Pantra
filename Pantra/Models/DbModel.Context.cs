﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pantra.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PantraDbContext : DbContext
    {
        public PantraDbContext()
            : base("name=PantraDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<MyCounty> MyCounties { get; set; }
        public virtual DbSet<MyShop> MyShops { get; set; }
    }
}
