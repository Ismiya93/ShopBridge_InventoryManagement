using Microsoft.EntityFrameworkCore;
using ShopBridge_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Core
{
    /**
    * Application Database Context
    */
    public class AppDbContext : DbContext
    {
        /**
         * Data Sets
         */
        public DbSet<Products> Product { get; set; }
        /**
         * AppDbContext constructor.
         * @param options Context options
         */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products() { ID = 1, Name = "John", Description = "Developer",  Price = 30000 },
                new Products() { ID = 2, Name = "Chris", Description = "Manager", Price = 50000 },
                new Products() { ID = 3, Name = "Mukesh", Description = "Consultant", Price = 20000 });
        }
    }
}
