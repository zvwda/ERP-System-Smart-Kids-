﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class smartkidsdbEntities : DbContext
    {
        public smartkidsdbEntities()
            : base("name=smartkidsdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<supplier> supplier { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<fatora> fatora { get; set; }
        public virtual DbSet<fatora2> fatora2 { get; set; }
        public virtual DbSet<mozaf> mozaf { get; set; }
    }
}
