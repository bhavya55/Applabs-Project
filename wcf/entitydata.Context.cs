﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wcf
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Data.Entity.Infrastructure;

    public partial class applabsEntities : DbContext
    {
        public applabsEntities()
            : base("name=applabsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Marketing> Marketings { get; set; }

    }
}