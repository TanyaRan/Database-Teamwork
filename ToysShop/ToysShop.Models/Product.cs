using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.Models.Enums;

namespace ToysShop.Models
{
    public class Product
    {
        private ICollection<Vendor> vendors;

        public Product()
        {
            this.vendors = new HashSet<Vendor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public SuitableFor SuitabaleFor { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }

        public ICollection<Vendor> Vendors
        {
            get
            {
                return this.vendors;
            }
            set
            {
                this.vendors = value;
            }
        }
    }
}
