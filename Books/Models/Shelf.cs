using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "מס' ספריה")]
        public Library? Library{ get; set; }

        [NotMapped]
        public int l_id { get; set; }

        [Display(Name = "גובה המדף")]
        public int Height { get; set; }
    }
}
