using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public double Price { get;set; }
        public List<Payment>? Payments { get; set;}
    }
}
