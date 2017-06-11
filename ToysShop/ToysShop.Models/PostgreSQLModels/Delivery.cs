using System;

namespace ToysShop.Models.PostgreSQLModels
{
    public class Delivery
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public DateTime Date { get; set; }

        public string CustomerFullName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
