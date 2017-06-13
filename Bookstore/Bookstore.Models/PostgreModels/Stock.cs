using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models.PostgreModels
{
    public class StockBook
    {
        public StockBook()
        {
        }

        public StockBook(string bookName, decimal price, int quantity)
        {
            this.BookName = bookName;
            this.Price = price;
            this.Quantity = quantity;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string BookName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
