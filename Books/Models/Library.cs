using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Library
    {


        [Key]
        public int Id { get; set; }

        [Display(Name ="ז`אנר")]
        public string Genre { get; set; }


    }
}
