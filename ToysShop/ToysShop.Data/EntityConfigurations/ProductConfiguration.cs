using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name).IsRequired()
                .HasMaxLength(70)
                .HasColumnAnnotation(
                "Index",
                new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));

            Property(p => p.CategoryId).IsRequired();

            Property(p => p.SuitabaleFor).IsRequired();

            Property(p => p.ImageUrl).IsRequired();

            Property(p => p.Price).IsRequired();

            Property(p => p.UnitsInStock).IsRequired();

            HasMany(p => p.Vendors)
                .WithMany(v => v.Products);
        }
    }
}
