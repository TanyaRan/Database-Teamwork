using System;

namespace ToysShop.Models.SQLModels
{
    public class Offer
    {
        private DateTime? offerDate;

        public Offer(DateTime offerDate)
        {
            this.offerDate = offerDate;
        }

        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime OfferDate
        {
            get
            {
                return this.offerDate.HasValue 
                    ? this.offerDate.Value 
                    : DateTime.Now;
            }
            set
            {
                this.offerDate = value;
            }
        }

        public decimal TradePrice { get; set; }
    
        public bool IsOutdated { get; set; }
    }
}
