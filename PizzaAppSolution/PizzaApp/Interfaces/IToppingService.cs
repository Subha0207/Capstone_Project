using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface IToppingService
    {
        Task<IEnumerable<Topping>> GetAllToppings();
        public Task<Topping> GetToppingById(int ToppingId);
    }
}
