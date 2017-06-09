using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysShop.Models
{
    public class Region
    {
        private ICollection<City> cities;

        public Region()
        {
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}
