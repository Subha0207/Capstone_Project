using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApp.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? PizzaDetailsId { get; set; }
        public PizzaDetails PizzaDetails { get; set; }
        public int? BeverageId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice must be a positive value.")]
        public decimal TotalPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "PizzaQuantity must be a positive value.")]
        public int? PizzaQuantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "BeverageQuantity must be a positive value.")]
        public int? BeverageQuantity { get; set; }
  
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}
