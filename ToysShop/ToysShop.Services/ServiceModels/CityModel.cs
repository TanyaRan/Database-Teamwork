using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.Models.SQLModels;
using ToysShop.Models.SQLModels.Enums;

namespace ToysShop.Services.ServiceModels
{
    public class CityModel
    {
        public CityModel(City city)
        {
            if (city != null)
            {
                this.Id = city.Id;
                this.Name = city.Name;
                this.Region = city.Region;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public IEnumerable<AddressModel> Addresses { get; set; }
    }
}
