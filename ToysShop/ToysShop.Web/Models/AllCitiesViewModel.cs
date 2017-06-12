using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToysShop.Web.Models
{
    public class AllCitiesViewModel
    {
        public IEnumerable<CityViewModel> AllCities { get; set; }
    }
}