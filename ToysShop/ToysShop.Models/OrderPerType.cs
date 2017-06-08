using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
{
    public class OrderPerType
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}
