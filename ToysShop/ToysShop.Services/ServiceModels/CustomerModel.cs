using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class CustomerModel
    {
        public CustomerModel()
        {
        }

        public CustomerModel(Customer customer)
        {
            if (customer != null)
            {
                this.Id = customer.Id;
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Phone = customer.Phone;
                this.AddressId = customer.AddressId;
                this.Orders = customer.Orders
                    .Select(o => new OrderModel(o)).ToList();
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AddressId { get; set; }

        public AddressModel Address { get; set; }

        public string Phone { get; set; }

        public IEnumerable<OrderModel> Orders { get; set; }

        public static Expression<Func<Customer, CustomerModel>> Create
        {
            get
            {
                return c => new CustomerModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Phone = c.Phone,
                    Orders = c.Orders.AsQueryable()
                        .Select(OrderModel.Create).ToList()
                };
            }
        }
    }
}
