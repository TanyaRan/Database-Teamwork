using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ToysShop.Models.SQLModels.Enums;
using ToysShop.Web.Controllers;

namespace ToysShop.Web.Models
{
    public class CityFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Region Region { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<CityController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<CityController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}