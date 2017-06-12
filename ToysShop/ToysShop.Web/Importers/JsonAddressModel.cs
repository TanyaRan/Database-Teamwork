using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToysShop.Web.Importers
{
    public class JsonAddressModel
    {
        public string FullAddress { get; set; }

        public JsonCityModel City { get; set; }
    }
}