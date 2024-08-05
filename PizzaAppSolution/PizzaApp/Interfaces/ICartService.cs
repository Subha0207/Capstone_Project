using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface ICartService
    {
        public Task<CartDTO> GetCartById(int CartId);

        public Task<OrderDetailsDTO> UpdateCartCheckoutStatus(int CartId);
        public Task<OrderDetailsDTO> GetOrderDetailsByCartId(int cartId);

        public  Task<Cart> GetActiveCartByUserId(int userId);



    }
}
