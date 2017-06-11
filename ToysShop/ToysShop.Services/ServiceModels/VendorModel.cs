using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class VendorModel
    {
        public VendorModel()
        {
        }

        public VendorModel(Vendor vendor)
        {
            if (vendor != null)
            {
                this.Id = vendor.Id;
                this.Name = vendor.Name;
                this.AddressId = vendor.AddressId;
                this.Phone = vendor.Phone;
                this.Email = vendor.Email;
                this.Products = vendor.Products
                    .Select(pr => new ProductModel(pr)).ToList();
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }

        public AddressModel Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }

        public static Expression<Func<Vendor, VendorModel>> Create
        {
            get
            {
                return v => new VendorModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    Phone = v.Phone,
                    Email = v.Email,
                    Products = v.Products.AsQueryable()
                        .Select(ProductModel.Create).ToList()
                };
            }
        }
    }
}
