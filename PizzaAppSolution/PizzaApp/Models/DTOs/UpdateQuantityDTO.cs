namespace PizzaApp.Models.DTOs
{
    public class UpdateQuantityDTO
    {
        public int CartItemId { get; set; }
        public int NewQuantity { get; set; }
    }
}
