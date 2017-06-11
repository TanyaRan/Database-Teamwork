using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class ProductOrderConfiguration : EntityTypeConfiguration<ProductOrder>
    {
        public ProductOrderConfiguration()
        {
            Property(p => p.OrderId).IsRequired();

            Property(p => p.ProductId).IsRequired();

            Property(p => p.Quantity).IsRequired();
        }
    }
}
