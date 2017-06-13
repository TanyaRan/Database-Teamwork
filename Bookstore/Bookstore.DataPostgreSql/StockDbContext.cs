using Bookstore.Models.PostgreModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataPostgreSql
{
    public class StockDbContext : DbContext
    {
        public StockDbContext()
            : base("StockDb")
        {
        }

        public DbSet<StockBook> StockBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Properties<decimal>()
            .Configure(prop => prop.HasPrecision(7, 2));

            this.OnModelCreatingStock(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnModelCreatingStock(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockBook>()
                .Property(s => s.BookName)
                .HasColumnName("stockbook");

            modelBuilder.Entity<StockBook>()
                .Property(s => s.Price)
                .HasColumnName("price");

            modelBuilder.Entity<StockBook>()
                .Property(s => s.Quantity)
                .HasColumnName("quantity");
        }
    }
}
