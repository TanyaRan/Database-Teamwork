using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ModelsSQL
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int GenreId { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }
    }
}
