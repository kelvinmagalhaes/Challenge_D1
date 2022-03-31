using Challenge_D1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Challenge_D1.DAL
{
        public class CustomerContext : DbContext
        {

            public CustomerContext() : base("CustomerContext")
            {
            }

            public DbSet<Customer> Customers { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
}
