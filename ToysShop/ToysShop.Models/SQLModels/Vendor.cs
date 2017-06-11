using System.Collections.Generic;

namespace ToysShop.Models.SQLModels
{
    public class Vendor
    {
        private ICollection<Product> products;
        private ICollection<Offer> offers;

        public Vendor()
        {
            this.products = new HashSet<Product>();
            this.offers = new HashSet<Offer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            private set
            {
                this.products = value;
            }
        }

        public virtual ICollection<Offer> Offers
        {
            get
            {
                return this.offers;
            }
            private set
            {
                this.offers = value;
            }
        }
    }
}
