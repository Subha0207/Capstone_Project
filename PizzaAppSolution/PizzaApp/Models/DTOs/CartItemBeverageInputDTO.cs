using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CartItemBeverageInputDTO
    {
        public int UserId { get; set; }
        public int BeverageId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "BeverageQuantity must be a positive value.")]
        public int BeverageQuantity { get; set; }
        public decimal BeverageCost { get; set; }
       
    }
}
