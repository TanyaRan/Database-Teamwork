using System.Collections.Generic;
using ToysShop.Models.SQLModels.Enums;

namespace ToysShop.Models.SQLModels
{
    public class Product
    {
        private ICollection<Vendor> vendors;
        private ICollection<ProductOrder> productOrders;

        public Product()
        {
            this.vendors = new HashSet<Vendor>();
            this.productOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public SuitableFor SuitabaleFor { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }

        public ICollection<Vendor> Vendors
        {
            get
            {
                return this.vendors;
            }
            private set
            {
                this.vendors = value;
            }
        }

        public ICollection<ProductOrder> ProductOrders
        {
            get
            {
                return this.productOrders;
            }
            private set
            {
                this.productOrders = value;
            }
        }
    }
}
