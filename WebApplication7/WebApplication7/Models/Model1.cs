namespace WebApplication7.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Entity Framework context
    /// </summary>
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        /// <summary>
        /// DbSet Adresses
        /// </summary>
        public virtual DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// DbSet Customers
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// DbSet Phones
        /// </summary>
        public virtual DbSet<Phone> Phones { get; set; }

        /// <summary>
        /// Definitions for Database Model
        /// </summary>
        /// <param name="modelBuilder">Builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CPFCustomer)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Phones)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CPFCustomer)
                .WillCascadeOnDelete(true);
        }
    }
}
