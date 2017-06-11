using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.FirstName).IsRequired().HasMaxLength(30);

            Property(c => c.LastName).IsRequired().HasMaxLength(30);

            Property(c => c.AddressId).IsRequired();

            Property(c => c.Phone).IsRequired();

            HasMany(c => c.Orders)
                .WithRequired(o => o.Customer);
        }
    }
}
