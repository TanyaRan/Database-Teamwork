using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
{
    public class Order
    {
        private ICollection<ProductOrder> productOrders;

        public Order()
        {
            productOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
