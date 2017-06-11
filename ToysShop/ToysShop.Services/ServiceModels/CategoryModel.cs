using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class CategoryModel
    {
        public CategoryModel()
        {
        }

        public CategoryModel(Category category)
        {
            if (category != null)
            {
                this.Id = category.Id;
                this.Name = category.Name;
                if (category.ParentCategory != null)
                {
                    this.ParentCategoryId = category.ParentCategoryId;
                }
                this.Products = category.Products
                    .Select(pr => new ProductModel(pr)).ToList();
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public CategoryModel ParentCategory { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }

        public static Expression<Func<Category, CategoryModel>> Create
        {
            get
            {
                return c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = c.Products.AsQueryable()
                        .Select(ProductModel.Create).ToList()
                };
            }
        }
    }
}
