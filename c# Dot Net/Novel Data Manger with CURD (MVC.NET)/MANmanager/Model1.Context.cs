﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MANmanager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class manmanagermvcContext : DbContext
    {
        public manmanagermvcContext()
            : base("name=manmanagermvcContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<noveldata> noveldatas { get; set; }
        public DbSet<animedata> animedatas { get; set; }
        public DbSet<manhwadata> manhwadatas { get; set; }
        public DbSet<characterdata> characterdatas { get; set; }
    }
}
