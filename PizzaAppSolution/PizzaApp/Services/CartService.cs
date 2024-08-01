using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;
        private readonly CartItemRepository _cartItemRepository;

        public CartService(CartRepository cartRepository, CartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;

            _cartItemRepository = cartItemRepository;

        }
        public async Task<CartDTO> GetCartById(int CartId)
        {
            var cart = await _cartRepository.GetCartByCartId(CartId);

            var cartDTO = new CartDTO
            {
              
               
               
                 TotalPrice=cart.TotalPrice
            };

            return cartDTO;
        }
        public async Task<OrderDetailsDTO> UpdateCartCheckoutStatus(int cartId)
        {
            // Retrieve the cart by CartId
            var cart = await _cartRepository.GetCartByCartId(cartId);

            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
            }

            // Update the checkout status
            cart.IsCheckedOut = true;

            // Save the changes to the repository
            await _cartRepository.Update(cart);

            // Fetch the cart items for the cart
            var cartItems = await _cartItemRepository.GetCartItemsByCartId(cartId);

            // Map the cart items to DTOs
            var cartItemDTOs = cartItems.Select(cartItem => new CartItemPizzaDTO
            {
                CartItemId = cartItem.CartItemId,
                UserId = cartItem.UserId,
                PizzaId = (int)cartItem.PizzaId,
                CrustId = (int)cartItem.CrustId,
                SizeId = (int)cartItem.SizeId,
                ToppingId = (int)cartItem.ToppingId,
                PizzaCost = (decimal)cartItem.PizzaCost,
                PizzaDiscount = (decimal)cartItem.PizzaDiscount,
                PizzaFinalPrice = (decimal)cartItem.PizzaFinalPrice,
                PizzaTotalPrice = (decimal)cartItem.PizzaTotalPrice,
                PizzaQuantity = cartItem.PizzaQuantity,
            }).ToList();

            // Create the order details DTO
            var orderDetailsDTO = new OrderDetailsDTO
            {
               
                TotalPrice = (decimal)cart.TotalPrice,
                CartItems = cartItemDTOs
            };

            return orderDetailsDTO;
        }
    }
}
