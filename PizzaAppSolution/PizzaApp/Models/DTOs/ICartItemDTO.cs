namespace PizzaApp.Models.DTOs
{
    public interface ICartItemDTO
    {
        int CartItemId { get; set; }
        int UserId { get; set; }
        decimal TotalPrice { get; }
    }
}
