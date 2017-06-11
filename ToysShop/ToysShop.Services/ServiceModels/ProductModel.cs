using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;
using ToysShop.Models.SQLModels.Enums;

namespace ToysShop.Services.ServiceModels
{
    public class ProductModel
    {
        public ProductModel()
        {
        }

        public ProductModel(Product product)
        {
            if (product != null)
            {
                this.Id = product.Id;
                this.Name = product.Name;
                this.Description = product.Description;
                this.ImageUrl = product.ImageUrl;
                this.SuitabaleFor = product.SuitabaleFor;
                this.Price = product.Price;
                this.UnitsInStock = product.UnitsInStock;
                this.CategoryId = product.CategoryId;
                this.Vendors = product.Vendors
                    .Select(v => new VendorModel(v)).ToList();
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }

        public SuitableFor SuitabaleFor { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }

        public IEnumerable<VendorModel> Vendors { get; set; }

        public static Expression<Func<Product, ProductModel>> Create
        {
            get
            {
                return p => new ProductModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    SuitabaleFor = p.SuitabaleFor,
                    Price = p.Price,
                    UnitsInStock = p.UnitsInStock,
                    Vendors = p.Vendors.AsQueryable()
                        .Select(VendorModel.Create).ToList()
                };
            }
        }
    }
}
