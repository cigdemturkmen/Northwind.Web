using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class NorthwindDbContext: DbContext
    {

        public NorthwindDbContext()
        {
            this.Database.Connection.ConnectionString = "Server=.;Database=NorthwindDemo;User Id=sa;Password=Password1;";

            //this.Database.Connection.ConnectionString = "Server=.;Database=NorthwindDev;User Id=sa;Password=123;";
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //         .HasRequired<Category>(s => s.Category)
        //         .WithMany(g => g.Products)
        //         .HasForeignKey<int>(s => s.Id)
        //         .WillCascadeOnDelete(false);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderDetail>()
                .HasOptional(a => a.Product)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>() // bu cascade true olsa daha doğru olurdu gibi?
                .HasOptional(a => a.Order)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
