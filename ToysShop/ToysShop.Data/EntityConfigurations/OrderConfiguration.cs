using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(o => o.CustomerId).IsRequired();

            Property(o => o.OrderDate).IsRequired();

            HasMany(o => o.ProductOrders)
                .WithRequired(prO => prO.Order);
        }
    }
}
