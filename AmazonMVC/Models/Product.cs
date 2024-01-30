using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonMVC.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [Required, MaxLength(40)]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre;
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
        [NotMapped]
        public string GenreName { get; set; }
    }
}
