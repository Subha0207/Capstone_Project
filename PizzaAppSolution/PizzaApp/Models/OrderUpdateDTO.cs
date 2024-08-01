using PizzaApp.Models.Enums;

namespace PizzaApp.Models
{
    public class OrderUpdateDTO
    {
        public OrderStatus Status { get; set; }
        public int OrderId { get; set; }
    }
}
