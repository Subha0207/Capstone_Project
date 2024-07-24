using PizzaApp.Models.Enums;

namespace PizzaApp.Models
{
    public class Topping
    {
        public int ToppingId { get; set; }
        public ToppingName Name { get; set; }
        public decimal Cost { get; set; }
    }
}
