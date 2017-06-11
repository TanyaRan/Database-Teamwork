using System;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class OrderModel
    {
        public OrderModel()
        {
        }

        public OrderModel(Order order)
        {

        }

        public static Expression<Func<Order, OrderModel>> Create
        {
            get
            {
                return c => new OrderModel()
                {

                };
            }
        }
    }
}
