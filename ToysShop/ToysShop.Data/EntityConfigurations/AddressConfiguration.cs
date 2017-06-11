using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(a => a.CityId).IsRequired();

            Property(a => a.FullAddress).IsRequired().HasMaxLength(250);

            HasOptional(a => a.Customer)
                .WithRequired(c => c.Address);

            HasOptional(a => a.Vendor)
                .WithRequired(v => v.Address);
        }
    }
}
