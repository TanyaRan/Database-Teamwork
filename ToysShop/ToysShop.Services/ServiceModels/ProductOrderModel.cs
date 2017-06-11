using System;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class ProductOrderModel
    {
        public ProductOrderModel()
        {
        }

        public ProductOrderModel(ProductOrder productOrder)
        {
            if (productOrder != null)
            {
                this.Id = productOrder.Id;
                this.OrderId = productOrder.OrderId;
                this.ProductId = productOrder.ProductId;
                this.Quantity = productOrder.Quantity;
            }
        }

        public int Id { get; set; }

        public int OrderId { get; set; }

        public OrderModel Order { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public static Expression<Func<ProductOrder, ProductOrderModel>> Create
        {
            get
            {
                return pOr => new ProductOrderModel()
                {
                    Id = pOr.Id,
                    Quantity = pOr.Quantity
                };
            }
        }
    }
}
