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

       
            cart.IsCheckedOut = true;

            // Save the changes to the repository
            await _cartRepository.Update(cart);

            // Fetch the cart items for the cart
            var cartItems = await _cartItemRepository.GetCartItemsByCartId(cartId);

            // Map the cart items to appropriate DTOs
            var cartItemDTOs = cartItems.Select(cartItem =>
            {
                if (cartItem.PizzaId.HasValue)
                {
                    return (ICartItemDTO)new CartItemPizzaDTO
                    {
                        CartItemId = cartItem.CartItemId,
                        UserId = cartItem.UserId,
                        PizzaId = cartItem.PizzaId.Value,
                        CrustId = cartItem.CrustId.Value,
                        SizeId = cartItem.SizeId.Value,
                        ToppingId = cartItem.ToppingId.Value,
                        PizzaCost = cartItem.PizzaCost.Value,
                        PizzaDiscount = cartItem.PizzaDiscount.Value,
                        PizzaFinalPrice = cartItem.PizzaFinalPrice.Value,
                        PizzaTotalPrice = cartItem.PizzaTotalPrice.Value,
                        PizzaQuantity = cartItem.PizzaQuantity.Value,
                    };
                }
                else if (cartItem.BeverageId.HasValue)
                {
                    return (ICartItemDTO)new CartItemBeverageDTO
                    {
                        CartItemId = cartItem.CartItemId,
                        UserId = cartItem.UserId,
                        BeverageId = cartItem.BeverageId.Value,
                        BeverageCost = cartItem.BeverageCost.Value,
                        BeverageDiscount = cartItem.BeverageDiscount.Value,
                        BeverageFinalPrice = cartItem.BeverageFinalPrice.Value,
                        BeverageTotalPrice = cartItem.BeverageTotalPrice.Value,
                        BeverageQuantity = cartItem.BeverageQuantity.Value,
                    };
                }
                else
                {
                    throw new InvalidOperationException("Cart item must have either a PizzaId or a BeverageId.");
                }
            }).ToList();

            // Create the order details DTO
            var orderDetailsDTO = new OrderDetailsDTO
            {
                TotalPrice = cart.TotalPrice.Value,
                CartItems = cartItemDTOs
            };

            return orderDetailsDTO;
        }




        public async Task<OrderDetailsDTO> GetOrderDetailsByCartId(int cartId)
        {
            // Retrieve the cart by CartId
            var cart = await _cartRepository.GetCartByCartId(cartId);

            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
            }

            // Fetch the cart items for the cart
            var cartItems = await _cartItemRepository.GetCartItemsByCartId(cartId);

            // Map the cart items to DTOs
            var cartItemDTOs = cartItems.Select(cartItem =>
            {
                if (cartItem.PizzaId.HasValue)
                {
                    return new CartItemPizzaDTO
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
                        PizzaQuantity = cartItem.PizzaQuantity.Value,
                       
                    } as ICartItemDTO;
                }
                else if (cartItem.BeverageId.HasValue)
                {
                    return new CartItemBeverageDTO
                    {
                        CartItemId = cartItem.CartItemId,
                        UserId = cartItem.UserId,
                        BeverageId = (int)cartItem.BeverageId,
                        BeverageCost = (decimal)cartItem.BeverageCost,
                        BeverageDiscount = (decimal)cartItem.BeverageDiscount,
                        BeverageFinalPrice = (decimal)cartItem.BeverageFinalPrice,
                        BeverageTotalPrice = (decimal)cartItem.BeverageTotalPrice,
                        BeverageQuantity = (int)cartItem.BeverageQuantity,
                     
                    } as ICartItemDTO;
                }
                else
                {
                    throw new InvalidOperationException("CartItem type is not recognized.");
                }
            }).ToList();

            // Create the order details DTO
            var orderDetailsDTO = new OrderDetailsDTO
            {
                TotalPrice = (decimal)cart.TotalPrice,
                CartItems = cartItemDTOs
            };

            return orderDetailsDTO;
        }


        public async Task<Cart> GetActiveCartByUserId(int userId)
        {
            var cart = await _cartRepository.GetActiveCartByUserId(userId);


            return cart;
        }

      
    }
}
