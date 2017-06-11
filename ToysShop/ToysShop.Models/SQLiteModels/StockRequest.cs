using System;

namespace ToysShop.Models.SQLiteModels
{
    public class StockRequest
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
