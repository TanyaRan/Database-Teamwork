using System.Collections.Generic;

namespace ToysShop.Models.PostgreSQLModels
{
    public class Driver
    {
        private ICollection<Delivery> deliveries;

        public Driver()
        {
            this.deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Delivery> Deliveries
        {
            get
            {
                return this.deliveries;
            }
            set
            {
                this.deliveries = value;
            }
        }
    }
}
