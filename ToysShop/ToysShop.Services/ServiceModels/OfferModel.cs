using System;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class OfferModel
    {
        public OfferModel()
        {
        }

        public OfferModel(Offer offer)
        {
            if (offer != null)
            {
                this.Id = offer.Id;
                this.VendorId = offer.VendorId;
                this.ProductId = offer.ProductId;
                this.OfferDate = offer.OfferDate;
                this.TradePrice = offer.TradePrice;
                this.IsOutdated = offer.IsOutdated;
            }
        }

        public int Id { get; set; }

        public int VendorId { get; set; }

        public VendorModel Vendor { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }

        public DateTime OfferDate { get; set; }

        public decimal TradePrice { get; set; }

        public bool IsOutdated { get; set; }

        public static Expression<Func<Offer, OfferModel>> Create
        {
            get
            {
                return o => new OfferModel()
                {
                    Id = o.Id,
                    OfferDate = o.OfferDate,
                    TradePrice = o.TradePrice,
                    IsOutdated = o.IsOutdated
                };
            }
        }
    }
}
