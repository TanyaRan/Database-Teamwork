using System;
using System.Collections.Generic;
using System.Linq;

namespace ToysShop.Models.SQLModels
{
    public class Order
    {
        private ICollection<ProductOrder> productOrders;
        private DateTime? orderDate;

        public Order(DateTime orderDate)
        {
            productOrders = new HashSet<ProductOrder>();
            this.orderDate = orderDate;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime OrderDate
        {
            get
            {
                return this.orderDate.HasValue
                    ? this.orderDate.Value
                    : DateTime.Now;
            }
            set
            {
                this.orderDate = value;
            }
        }

        public virtual ICollection<ProductOrder> ProductOrders
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
