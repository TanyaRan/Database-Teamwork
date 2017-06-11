using System.Collections.Generic;
using ToysShop.Models.SQLModels.Enums;

namespace ToysShop.Models.SQLModels
{
    public class City
    {
        private ICollection<Address> addresses;

        public City()
        {
            this.addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public ICollection<Address> Addresses
        {
            get
            {
                return this.addresses;
            }
            private set
            {
                this.addresses = value;
            }
        }
    }
}
