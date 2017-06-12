using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToysShop.Services.Contracts;
using ToysShop.Services.ServiceModels;
using ToysShop.Web.Models;

namespace ToysShop.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            Guard.WhenArgument(cityService, "cityService").IsNull().Throw();

            this.cityService = cityService;
        }

        [HttpGet]
        public ActionResult All()
        {
            var allCityViewModels = this.cityService.GetAllCitiesSortedById()
                .Select(c => new CityViewModel(c)).ToList();

            return this.View("All", allCityViewModels);
        }

        public ActionResult Details(int? id)
        {
            CityModel city = this.cityService.GetCityById(id);

            CityViewModel viewModel = new CityViewModel(city);

            return this.View("Details", viewModel);
        }
    }
}