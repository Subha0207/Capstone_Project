using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        [Required]
   
        public decimal TotalCost { get; set; }
    }
}
