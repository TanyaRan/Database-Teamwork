using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public int ProductId { get; set; }

        public DateTime OfferDate { get; set; }

        public int QuantityInPack { get; set; }

        public decimal TradePrice { get; set; }
    }
}
