using System.Collections.Generic;

namespace ToysShop.Models.SQLModels
{
    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            private set
            {
                this.products = value;
            }
        }
    }
}
