using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(40);

            Property(c => c.ParentCategoryId).IsOptional();

            HasMany(c => c.Products)
                .WithRequired(p => p.Category);
        }
    }
}
