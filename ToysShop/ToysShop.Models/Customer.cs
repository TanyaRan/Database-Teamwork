using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string RegionId { get; set; }

        public string CityId { get; set; }

        public string Phone { get; set; }
    }
}
