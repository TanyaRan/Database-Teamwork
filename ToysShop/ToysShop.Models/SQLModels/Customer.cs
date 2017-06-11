using System.Collections.Generic;

namespace ToysShop.Models.SQLModels
{
    public class Customer
    {
        private ICollection<Order> orders;

        public Customer()
        {
            orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            private set
            {
                this.orders = value;
            }
        }
    }
}
