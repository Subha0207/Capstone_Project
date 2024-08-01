using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Repositories;
using System.Runtime.InteropServices;

namespace PizzaApp.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly CartItemRepository _cartItemRepository;
        private readonly CartRepository _cartRepository;
        private readonly PizzaRepository _pizzaRepository;
        private readonly CrustRepository _crustRepository;
        private readonly SizeRepository _sizeRepository;
        private readonly ToppingRepository _toppingRepository;

        public CartItemService(CartItemRepository cartItemRepository, CartRepository cartRepository, PizzaRepository pizzaRepository,CrustRepository crustRepository,SizeRepository sizeRepository,ToppingRepository toppingRepository
            )
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _pizzaRepository = pizzaRepository;
            _crustRepository = crustRepository;
            _sizeRepository = sizeRepository;
            _toppingRepository = toppingRepository;
        }
        public async Task<int> AddCartItem(CartItemPizzaInputDTO cartItemInputDTO)
        {
            // Find an existing cart for the user or create a new one
            var cart = await _cartRepository.GetActiveCartByUserId(cartItemInputDTO.UserId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = cartItemInputDTO.UserId,
                    TotalPrice = 0m,
                    IsCheckedOut = false
                };
                await _cartRepository.Add(cart);
            }

            var pizza = await _pizzaRepository.GetPizzaByPizzaId(cartItemInputDTO.PizzaId);
            var crust = await _crustRepository.GetCrustByCrustId(cartItemInputDTO.CrustId);
            var size = await _sizeRepository.GetSizeBySizeId(cartItemInputDTO.SizeId);
            var topping = await _toppingRepository.GetToppingByToppingId(cartItemInputDTO.ToppingId);

            var baseCost = pizza.Cost;
            var crustMultiplier = crust.Cost;
            var sizeMultiplier = size.Cost;
            var toppingCost = topping.Cost;

            var pizzaCost = (baseCost * crustMultiplier * sizeMultiplier )+ toppingCost;
            pizzaCost = (decimal)Math.Ceiling(pizzaCost);
            var uploadDate = pizza.UploadDate;

            // Check if the pizza was uploaded within the last week
            var discount = 0m;
            if (uploadDate >= DateTime.UtcNow.AddDays(-7))
            {
                discount = pizzaCost * 0.05m; // 5% discount
            }

            var finalPizzaCost = pizzaCost - discount;
            
            // Map DTO to Entity
            var cartItem = new CartItem
            {
                UserId = cartItemInputDTO.UserId,
                PizzaId = cartItemInputDTO.PizzaId,
                CrustId = (int)cartItemInputDTO.CrustId,
                SizeId = (int)cartItemInputDTO.SizeId,
                ToppingId = (int)cartItemInputDTO.ToppingId,
                PizzaFinalPrice = finalPizzaCost,
              PizzaCost=pizzaCost,
              PizzaDiscount=discount,
              PizzaQuantity=1,
                PizzaTotalPrice = (decimal)(1 * finalPizzaCost),
                CartId = cart.CartId
            };

            // Add the CartItem to the repository
            await _cartItemRepository.Add(cartItem);

            // Update the cart total price
            cart.TotalPrice += cartItem.PizzaFinalPrice;
            await _cartRepository.Update(cart);

            // Return the CartItemId
            return cartItem.CartItemId;
        }



        public async Task<IEnumerable<CartItemPizzaDTO>> GetAllCartItems()
        {
            var cartItems = await _cartItemRepository.Get();
            if (!cartItems.Any())
            {
                throw new EmptyException("No cart items found");
            }
            var cartItemDTOs = cartItems.Select(cartItem => new CartItemPizzaDTO
            {
                CartItemId = cartItem.CartItemId,
                UserId = cartItem.UserId,
                PizzaId = (int)cartItem.PizzaId,
                SizeId = (int)cartItem.SizeId,
                CrustId = (int)cartItem.CrustId,
                ToppingId = (int)cartItem.ToppingId,
                PizzaCost = (decimal)cartItem.PizzaCost,
                PizzaDiscount = (decimal)cartItem.PizzaDiscount,
                PizzaFinalPrice= (decimal)cartItem.PizzaFinalPrice,
                PizzaTotalPrice = (decimal)cartItem.PizzaTotalPrice,
                PizzaQuantity = cartItem.PizzaQuantity,
           
            });

            return cartItemDTOs;

        }

        public async Task<CartItemPizzaDTO> GetCartItemById(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetCartItemByCartItemId(cartItemId);

            var cartItemDTO = new CartItemPizzaDTO
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
               
            };

            return cartItemDTO;

        }

        public async Task<CartItemPizzaDTO> DeleteByCartItemId(int cartItemId)
        {
            var cartItem = await _cartItemRepository.DeleteByCartItemId(cartItemId);

            var cartItemDTO = new CartItemPizzaDTO
            {
                CartItemId = cartItem.CartItemId,
                UserId = cartItem.UserId,
                PizzaId = (int)cartItem.PizzaId,
                CrustId = (int)cartItem.CrustId,
                ToppingId = (int)cartItem.ToppingId,
                SizeId = (int)cartItem.SizeId,
                PizzaCost = (decimal)cartItem.PizzaCost,
                PizzaDiscount = (decimal)cartItem.PizzaDiscount,
                PizzaFinalPrice = (decimal)cartItem.PizzaFinalPrice,
                PizzaTotalPrice = (decimal)cartItem.PizzaTotalPrice,
                PizzaQuantity = cartItem.PizzaQuantity,
               
            };

            return cartItemDTO;

        }

        public async Task<IEnumerable<CartItemPizzaDTO>> GetCartItemsByUserId(int userId)
        {
            var allCartItems = await GetAllCartItems();
            var filteredCartItems = allCartItems.Where(cartItem => cartItem.UserId == userId);

            if (!filteredCartItems.Any())
            {
                throw new EmptyException("No cart items found for the specified user");
            }

            return filteredCartItems;
        }

        public async Task<IEnumerable<CartItemBeverageDTO>> GetAllBeverageCartItems()
        {
            var cartItems = await _cartItemRepository.Get();
            if (!cartItems.Any())
            {
                throw new EmptyException("No cart items found");
            }
            var cartItemDTOs = cartItems.Select(cartItem => new CartItemBeverageDTO
            {
                CartItemId = cartItem.CartItemId,
                UserId = cartItem.UserId,
                BeverageId = (int)cartItem.BeverageId,
                BeverageCost = (decimal)cartItem.BeverageCost,
                BeverageTotalPrice = (decimal)cartItem.BeverageTotalPrice,
                BeverageQuantity = (int)cartItem.BeverageQuantity,

            });

            return cartItemDTOs;
        }

        public Task<CartItemBeverageDTO> GetBeverageCartItemById(int CartItemId)
        {
            throw new NotImplementedException();
        }

        public Task<CartItemBeverageDTO> DeleteBeverageByCartItemId(int cartItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddBeverageCartItem(CartItemBeverageInputDTO cartItemInputDTO)
        {
            // Map DTO to Entity
            var cartItem = new CartItem
            {
                UserId = cartItemInputDTO.UserId,
                BeverageId = cartItemInputDTO.BeverageId,

                BeverageCost = cartItemInputDTO.BeverageCost,


                BeverageQuantity = (int)cartItemInputDTO.BeverageQuantity,
                BeverageTotalPrice = (decimal)(cartItemInputDTO.BeverageQuantity * (int)cartItemInputDTO.BeverageCost),

            };

            // Add to repository
            await _cartItemRepository.Add(cartItem);

            // Return the CartItemId
            return cartItem.CartItemId;

        }

        public async Task<IEnumerable<CartItemBeverageDTO>> GetBeverageCartItemsByUserId(int userId)
        {
            var allCartItems = await GetAllBeverageCartItems();
            var filteredCartItems = allCartItems.Where(cartItem => cartItem.UserId == userId);

            if (!filteredCartItems.Any())
            {
                throw new EmptyException("No cart items found for the specified user");
            }

            return filteredCartItems;
        }

        public async Task<int> UpdateCartItemQuantity(UpdateQuantityDTO cartItemQuantityUpdateDTO)
        {
            // Fetch the existing cart item
            var cartItem = await _cartItemRepository.Get(cartItemQuantityUpdateDTO.CartItemId);

            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found.");
            }

            // Update the quantity and total price
            cartItem.PizzaQuantity = cartItemQuantityUpdateDTO.NewQuantity;
            cartItem.PizzaTotalPrice = cartItem.PizzaQuantity * cartItem.PizzaFinalPrice;

            // Save changes to repository
            await _cartItemRepository.Update(cartItem);

            // Return the updated CartItemId
            return cartItem.CartItemId;
        }
    }
}
