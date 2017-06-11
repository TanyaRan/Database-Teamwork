using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ToysShop.Data.Contracts;
using ToysShop.Data.EntityConfigurations;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data
{
    public class ToysShopDbContext : DbContext, IDbContextSaveChanges
    {
        public ToysShopDbContext()
            : base("ToysShopSQL")
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductOrder> ProductOrders { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<decimal>()
            .Configure(prop => prop.HasPrecision(7, 2));

            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductOrderConfiguration());
            modelBuilder.Configurations.Add(new VendorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
