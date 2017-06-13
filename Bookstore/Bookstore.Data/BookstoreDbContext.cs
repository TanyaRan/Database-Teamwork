using Bookstore.Models.ModelsSQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
            : base("BookstoreDb")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
