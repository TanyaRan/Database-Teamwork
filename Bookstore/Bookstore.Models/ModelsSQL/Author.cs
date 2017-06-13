using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models.ModelsSQL
{
    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IX_Author_Name", IsUnique = true)]
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
