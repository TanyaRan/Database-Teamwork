using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ToysShop.Models.SQLModels;

namespace ToysShop.Web.Importers
{
    public class JsonCategoryImporter
    {
        private const string JsonFilePathFormat = "/JSONFiles/categories.{0}.json";
        public void Import()
        {
            var categoriesToAdd = Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/JSONFiles/")
                .Where(f => f.EndsWith(".json"))
                .Select(f => File.ReadAllText(f))
                .Select(str => JsonConvert.DeserializeObject<IEnumerable<JsonCategoryModel>>(str))
                .ToList();

            //var addedCities = new Dictionary<string, City>();

            //foreach (var vendor in vendorsToAdd)
            //{
            //    var cityName = vendor.
            //}
        }
    }
}