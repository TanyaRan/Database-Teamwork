using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(40);

            Property(c => c.Region).IsRequired();

            HasMany(c => c.Addresses)
                .WithRequired(a => a.City);
        }
    }
}
