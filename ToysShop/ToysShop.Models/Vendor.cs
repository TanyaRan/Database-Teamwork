using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
