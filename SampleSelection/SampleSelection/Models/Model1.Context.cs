﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleSelection.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NaytevarastoEntities : DbContext
    {
        public NaytevarastoEntities()
            : base("name=NaytevarastoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<Selection> Selection { get; set; }
        public virtual DbSet<SelectionLang> SelectionLang { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
