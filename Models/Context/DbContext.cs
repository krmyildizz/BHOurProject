using BHOurProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BHOurProject.Models.Context
{
    public class DataContext:DbContext
    {
        public DataContext() : base("name=u9172314_alperdb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<DataContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CarrierForm> CarrierForm { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<RequestForm> RequestForm { get; set; }
        public DbSet<ColorPicker> ColorPicker { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}