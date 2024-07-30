using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface ICartService
    {
        public Task<CartItem> AddToCart();
    }
}
