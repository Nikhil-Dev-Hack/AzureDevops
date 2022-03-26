using ADONETEntityFramework.SQL_MODELS;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ADONETEntityFramework
{
    class CompanyContext : DbContext
    {
        static string _ConnStr = string.Empty;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADONET;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            optionsBuilder.UseSqlServer(_ConnStr);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
