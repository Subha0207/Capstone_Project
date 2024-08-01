using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemPizzaDTO>> GetAllCartItems();
        public Task<CartItemPizzaDTO> GetCartItemById(int CartItemId);


        public Task<CartItemPizzaDTO> DeleteByCartItemId(int cartItemId);
        public Task<int> AddCartItem(CartItemPizzaInputDTO cartItemInputDTO);
        Task<IEnumerable<CartItemPizzaDTO>> GetCartItemsByUserId(int userId);


        Task<IEnumerable<CartItemBeverageDTO>> GetAllBeverageCartItems();
        public Task<CartItemBeverageDTO> GetBeverageCartItemById(int CartItemId);


        public Task<CartItemBeverageDTO> DeleteBeverageByCartItemId(int cartItemId);

        Task<IEnumerable<CartItemBeverageDTO>> GetBeverageCartItemsByUserId(int userId);

        public Task<int> AddBeverageCartItem(CartItemBeverageInputDTO cartItemInputDTO);
        public Task<int> UpdateCartItemQuantity(UpdateQuantityDTO cartItemQuantityUpdateDTO);
    }
}
