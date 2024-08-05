using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CartItemPizzaDTO : ICartItemDTO
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }
        public int ToppingId { get; set; }
        public decimal PizzaCost { get; set; }
        public decimal PizzaDiscount { get; set; }
        public decimal PizzaFinalPrice { get; set; }
        public decimal PizzaTotalPrice { get; set; }
        public int PizzaQuantity { get; set; }
        public decimal TotalPrice => PizzaTotalPrice;
    }
}
