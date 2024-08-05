using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface ICartItemService
    {
        public Task<int> AddCartItem(CartItemPizzaInputDTO cartItemInputDTO);

        public Task<int> AddBeverageCartItem(CartItemBeverageInputDTO cartItemInputDTO);
        public Task<object> GetCartItemById(int CartItemId);

        public Task<int> DeleteByCartItemId(int cartItemId);
       
        public Task<int> UpdateCartItemQuantity(UpdateQuantityDTO cartItemQuantityUpdateDTO);
    }
}
