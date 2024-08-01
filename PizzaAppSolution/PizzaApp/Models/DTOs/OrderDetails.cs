namespace PizzaApp.Models.DTOs
{
    public class OrderDetails
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool IsCheckedOut { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CartItemPizzaDTO> CartItems { get; set; }
    }
}
