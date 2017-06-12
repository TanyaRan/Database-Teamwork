using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToysShop.Web.Importers
{
    public class JsonVendorModel
    {
        /*"Name": "Ivanov OOD",
  "Phone": "02 334 33 89",
  "Email": "ivanov-toys@gmail.com",
  "Address": {
    "FullAddress": "ул.Слатинска, 12",
    "City": {
      "Name": "София"
    }
  }
         */

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public JsonAddressModel Address { get; set; }
    }
}