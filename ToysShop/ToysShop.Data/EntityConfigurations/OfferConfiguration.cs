using System.Data.Entity.ModelConfiguration;
using ToysShop.Models.SQLModels;

namespace ToysShop.Data.EntityConfigurations
{
    public class OfferConfiguration : EntityTypeConfiguration<Offer>
    {
        public OfferConfiguration()
        {
            Property(o => o.VendorId).IsRequired();

            Property(o => o.ProductId).IsRequired();

            Property(o => o.OfferDate).IsRequired();

            Property(o => o.TradePrice).IsRequired();
        }
    }
}
