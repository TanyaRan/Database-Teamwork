using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models.ModelsSQL
{
    public class Genre
    {
        private ICollection<Book> books;

        public Genre()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }
    }
}
