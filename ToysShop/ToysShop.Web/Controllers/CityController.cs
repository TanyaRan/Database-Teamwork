using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToysShop.Models.SQLModels;
using ToysShop.Models.SQLModels.Enums;
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

            return this.View(allCityViewModels);
        }

        [HttpGet]
        public ActionResult AllByName()
        {
            var allCityViewModels = this.cityService.GetAllCitiesSortedByName()
                .Select(c => new CityViewModel(c)).ToList();

            return this.View(allCityViewModels);
        }

        public ActionResult Details(int? id)
        {
            CityModel city = this.cityService.GetCityById(id);

            CityViewModel viewModel = new CityViewModel(city);

            return this.View("Details", viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CityFormViewModel
            {
                Heading = "Add a City"
            };

            return View("CityForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CityForm", viewModel);
            }

            //var city = new City
            //{
            //    Name = viewModel.Name,
            //    Region = viewModel.Region
            //};

            string name = viewModel.Name;
            Region region = viewModel.Region;

            this.cityService.AddCity(name, region);

            return RedirectToAction("All", "City");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var city = this.cityService.GetCityById(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CityFormViewModel
            {
                Heading = "Edit a City",
                Id = city.Id,
                Name = city.Name,
                Region = city.Region
            };

            return View("CityForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CityFormViewModel viewModel)
        {
            // TODO
            if (!ModelState.IsValid)
            {
                return View("CityForm", viewModel);
            }

            var city = this.cityService.GetCityById(viewModel.Id);

            if (city == null)
            {
                return HttpNotFound();
            }

            var newCity = new City
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Region = viewModel.Region
            };

            this.cityService.UpdateCity(newCity);

            return RedirectToAction("All", "City");
        }
    }
}