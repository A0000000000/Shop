using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Models.ORM.Good;
using Shop.Models.ORM.Shop;
using Shop.Models.ORM.User;
using Shop.Models.ORM.Utils;

namespace Shop.DatabaseContext
{
    public class SqlServerDatabaseContext: DbContext
    {
        public SqlServerDatabaseContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerLocation> CustomerLocations { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }

    }
}
