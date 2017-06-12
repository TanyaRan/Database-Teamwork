using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToysShop.Web.Importers
{
    public class JsonCategoryModel
    {
        public string Name { get; set; }

        public JsonParentCategoryModel ParentCategory { get; set; }
    }
}