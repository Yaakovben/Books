using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string Name { get; set; }

     
        public Shelf Shelf { get; set;}

        [Display(Name = "גובה הספר")]
        public int Height { get; set; }
        [NotMapped]
        public int book_id { get; set; }
    }
}
