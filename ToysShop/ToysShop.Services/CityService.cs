using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.Data.Contracts;
using ToysShop.Models.SQLModels;
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

        public CityModel GetCityById(int? id)
        {
            return new CityModel(this.cityDbSetWrapper.GetById(id));
        }

        public CityModel GetCityByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
