using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.Models.SQLModels;
using ToysShop.Models.SQLModels.Enums;
using ToysShop.Services.ServiceModels;

namespace ToysShop.Services.Contracts
{
    public interface ICityService
    {
        CityModel GetCityById(int? id);

        IEnumerable<CityModel> GetAllCitiesSortedById();

        IEnumerable<CityModel> GetAllCitiesSortedByName();

        void AddCity(string name, Region region);

        void UpdateCity(City city);
    }
}
