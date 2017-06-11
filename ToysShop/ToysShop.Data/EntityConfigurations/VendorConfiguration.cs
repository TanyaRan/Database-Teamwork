using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class VendorConfiguration : EntityTypeConfiguration<Vendor>
    {
        public VendorConfiguration()
        {
            Property(v => v.Name).IsRequired()
                .HasMaxLength(70)
                .HasColumnAnnotation(
                "Index",
                new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));

            Property(v => v.AddressId).IsRequired();

            Property(v => v.Phone).IsRequired();

            HasMany(v => v.Offers)
                .WithRequired(o => o.Vendor);
        }
    }
}
