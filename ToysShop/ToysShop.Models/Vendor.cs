using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
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

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public int RegionId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
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
            set
            {
                this.offers = value;
            }
        }
    }
}
