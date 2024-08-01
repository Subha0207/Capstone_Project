using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CartItemBeverageDTO
    {
        public int CartItemId { get; set; }


        public int UserId { get; set; }
        public int BeverageId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "BeverageQuantity must be a positive value.")]
        public int BeverageQuantity { get; set; }
        public decimal BeverageCost { get; set; }
        public decimal BeverageDiscount { get; set; }
        public decimal BeverageFinalPrice { get; set; }
        public decimal BeverageTotalPrice { get; set; }
    }
}
