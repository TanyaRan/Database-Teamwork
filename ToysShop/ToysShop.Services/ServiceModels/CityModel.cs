using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;
using ToysShop.Models.SQLModels.Enums;

namespace ToysShop.Services.ServiceModels
{
    public class CityModel
    {
        public CityModel()
        {
        }

        public CityModel(City city)
        {
            if (city != null)
            {
                this.Id = city.Id;
                this.Name = city.Name;
                this.Region = city.Region;
                this.Addresses = city.Addresses
                    .Select(a => new AddressModel(a)).ToList();
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public IEnumerable<AddressModel> Addresses { get; set; }

        public static Expression<Func<City, CityModel>> Create
        {
            get
            {
                return c => new CityModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Region = c.Region,
                    Addresses = c.Addresses.AsQueryable()
                        .Select(AddressModel.Create).ToList()
                };
            }
        }
    }
}
