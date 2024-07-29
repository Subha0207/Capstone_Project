using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface IToppingService
    {
        Task<IEnumerable<Topping>> GetAllToppings();
    }
}
