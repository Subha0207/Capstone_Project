using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class CartService : ICartService
    {

        private readonly CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public Task<CartItem> AddToCart()
        {
            throw new NotImplementedException();
        }
    }
}
