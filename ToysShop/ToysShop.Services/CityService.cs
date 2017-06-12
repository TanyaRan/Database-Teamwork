using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.Data.Contracts;
using ToysShop.Models.SQLModels;
using ToysShop.Models.SQLModels.Enums;
using ToysShop.Services.Contracts;
using ToysShop.Services.ServiceModels;

namespace ToysShop.Services
{
    public class CityService : ICityService
    {
        private readonly IDbSetWrapper<City> cityDbSetWrapper;
        private readonly IDbContextSaveChanges context;

        public CityService(IDbSetWrapper<City> cityDbSetWrapper, IDbContextSaveChanges context)
        {
            Guard.WhenArgument(cityDbSetWrapper, "cityDbSetWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.cityDbSetWrapper = cityDbSetWrapper;
            this.context = context;
        }

        public IEnumerable<CityModel> GetAllCitiesSortedById()
        {
            return this.cityDbSetWrapper.All
                .ToList()
                .OrderBy(c => c.Id)
                .AsQueryable()
                .Select(CityModel.Create).ToList();
        }

        public IEnumerable<CityModel> GetAllCitiesSortedByName()
        {
            return this.cityDbSetWrapper.All
                .ToList()
                .OrderBy(c => c.Name)
                .AsQueryable()
                .Select(CityModel.Create).ToList();
        }

        public CityModel GetCityById(int? id)
        {
            return new CityModel(this.cityDbSetWrapper.GetById(id));
        }

        //public void AddCity(City city)
        public void AddCity(string name, Region region)
        {
            var city = new City
            {
                Name = name,
                Region = region
            };

            this.cityDbSetWrapper.Add(city);
            this.context.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            this.cityDbSetWrapper.Update(city);
            this.context.SaveChanges();
        }
    }
}
