using PizzaApp.Models.DTOs;

namespace PizzaApp.Models
{
    public class OrderDetailsDTO
    {
        public decimal TotalPrice { get; set; }
        public List<CartItemPizzaDTO> CartItems { get; set; }
    }
}
