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


        public int? PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int CrustId { get; set; }
        public Crust Crust { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
        public decimal? PizzaDiscount { get; set; }
        public decimal? PizzaFinalPrice { get; set; }
        public decimal? PizzaCost { get; set; }
        public int? BeverageId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice must be a positive value.")]
        public decimal? PizzaTotalPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "PizzaQuantity must be a positive value.")]
        public int? PizzaQuantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "BeverageQuantity must be a positive value.")]
        public int? BeverageQuantity { get; set; }
        public decimal? BeverageCost { get; set; }
        public decimal? BeverageDiscount { get; set; }
        public decimal? BeverageFinalPrice { get; set; }
        public decimal? BeverageTotalPrice { get; set; }
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        public CartItem()
        {
            PizzaDiscount = 0m;
            PizzaQuantity = 1;
   
        }
    }
}
