using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.Services.ServiceModels;

namespace ToysShop.Services.Contracts
{
    public interface ICityService
    {
        CityModel GetById(int? id);

        IEnumerable<CityModel> GetAllCities();
    }
}
