using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonMVC.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; }
        public List<Product> Products { get; set;}
    }
}
