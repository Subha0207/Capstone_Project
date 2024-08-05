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
        private readonly BeverageRepository _beverageRepository;
        private readonly CartItemRepository _cartItemRepository;
        private readonly CartRepository _cartRepository;
        private readonly PizzaRepository _pizzaRepository;
        private readonly CrustRepository _crustRepository;
        private readonly SizeRepository _sizeRepository;
        private readonly ToppingRepository _toppingRepository;

        public CartItemService(CartItemRepository cartItemRepository, CartRepository cartRepository, PizzaRepository pizzaRepository,CrustRepository crustRepository,SizeRepository sizeRepository,ToppingRepository toppingRepository,BeverageRepository beverageRepository
            )
        {
            _beverageRepository = beverageRepository;
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
            cart.TotalPrice += cartItem.PizzaTotalPrice;
            await _cartRepository.Update(cart);

            // Return the CartItemId
            return cartItem.CartItemId;
        }

        public async Task<object> GetCartItemById(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetCartItemByCartItemId(cartItemId);

            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found.");
            }

            if (cartItem.PizzaId.HasValue)
            {
                var cartItemPizzaDTO = new CartItemPizzaDTO
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
                    
                };

                return cartItemPizzaDTO;
            }
            else if (cartItem.BeverageId.HasValue)
            {
                var cartItemBeverageDTO = new CartItemBeverageDTO
                {
                    CartItemId = cartItem.CartItemId,
                    UserId = cartItem.UserId,
                    BeverageId = (int)cartItem.BeverageId,
                    BeverageCost = (decimal)cartItem.BeverageCost,
                    BeverageDiscount = (decimal)cartItem.BeverageDiscount,
                    BeverageFinalPrice = (decimal)cartItem.BeverageFinalPrice,
                    BeverageTotalPrice = (decimal)cartItem.BeverageTotalPrice,
                    BeverageQuantity = (int)cartItem.BeverageQuantity,
                    
                };

                return cartItemBeverageDTO;
            }

            throw new InvalidOperationException("CartItem type is not recognized.");
        }


        public async Task<int> DeleteByCartItemId(int cartItemId)
        {
            // Fetch the existing cart item
            var cartItem = await _cartItemRepository.Get(cartItemId);

            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found.");
            }

            // Fetch the associated cart
            var cart = await _cartRepository.Get(cartItem.CartId);

            if (cart == null)
            {
                throw new KeyNotFoundException("Cart not found.");
            }

            // Determine if the cart item is a pizza or beverage and update the total price accordingly
            if (cartItem.PizzaId.HasValue)
            {
                cart.TotalPrice -= cartItem.PizzaFinalPrice;
            }
            else if (cartItem.BeverageId.HasValue)
            {
                cart.TotalPrice -= cartItem.BeverageFinalPrice;
            }
            else
            {
                throw new InvalidOperationException("CartItem type is not recognized.");
            }

            // Update the cart in the repository
            await _cartRepository.Update(cart);

            // Delete the cart item
            await _cartItemRepository.DeleteByCartItemId(cartItemId);

            // Prepare the appropriate DTO to return based on the item type
            if (cartItem.PizzaId.HasValue)
            {
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
                    PizzaQuantity = cartItem.PizzaQuantity.Value,
                };
                return cartItemDTO.CartItemId;
            }
            else if (cartItem.BeverageId.HasValue)
            {
                var cartItemDTO = new CartItemBeverageDTO
                {
                    CartItemId = cartItem.CartItemId,
                    UserId = cartItem.UserId,
                    BeverageId = (int)cartItem.BeverageId,
                    BeverageCost = (decimal)cartItem.BeverageCost,
                    BeverageDiscount = (decimal)cartItem.BeverageDiscount,
                    BeverageFinalPrice = (decimal)cartItem.BeverageFinalPrice,
                    BeverageTotalPrice = (decimal)cartItem.BeverageTotalPrice,
                    BeverageQuantity = (int)cartItem.BeverageQuantity,
                };
                return cartItemDTO.CartItemId;
            }

            throw new InvalidOperationException("CartItem type is not recognized.");
        }


        public async Task<int> AddBeverageCartItem(CartItemBeverageInputDTO cartItemInputDTO)
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

            // Retrieve the beverage details
            var beverage = await _beverageRepository.GetBeverageByBeverageId(cartItemInputDTO.BeverageId);
            var beverageCost = beverage.Cost;
            var uploadDate = beverage.UploadDate;

            // Calculate discount
            var discount = 0m;
            if (uploadDate >= DateTime.UtcNow.AddDays(-7))
            {
                discount = beverageCost * 0.05m; // 5% discount
            }

            // Calculate the final price for the beverage
            var beverageFinalPrice = beverageCost - discount;
            var beverageTotalPrice = 1 * beverageFinalPrice;

            // Map DTO to Entity
            var cartItem = new CartItem
            {
                UserId = cartItemInputDTO.UserId,
                BeverageId = cartItemInputDTO.BeverageId,
                BeverageCost = beverageCost,
                BeverageQuantity = 1,
                BeverageTotalPrice = beverageTotalPrice,
                CartId = cart.CartId,
                BeverageDiscount = discount,
                BeverageFinalPrice = beverageFinalPrice
            };

            // Add the CartItem to the repository
            await _cartItemRepository.Add(cartItem);

            // Update the cart total price
            cart.TotalPrice += cartItem.BeverageTotalPrice;
            await _cartRepository.Update(cart);

            // Return the CartItemId
            return cartItem.CartItemId;
        }


        public async Task<int> UpdateCartItemQuantity(UpdateQuantityDTO cartItemQuantityUpdateDTO)
        {
            // Fetch the existing cart item
            var cartItem = await _cartItemRepository.Get(cartItemQuantityUpdateDTO.CartItemId);

            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found.");
            }
            var cart = await _cartRepository.Get(cartItem.CartId);

            if (cart == null)
            {
                throw new KeyNotFoundException("Cart not found.");
            }
            // Update the quantity and total price based on the item type
            decimal oldTotalPrice;
            decimal newTotalPrice;

            // Update the quantity and total price based on the item type
            if (cartItem.PizzaId.HasValue)
            {
                oldTotalPrice = (decimal)cartItem.PizzaTotalPrice;
                cartItem.PizzaQuantity = cartItemQuantityUpdateDTO.NewQuantity;
                cartItem.PizzaTotalPrice = cartItem.PizzaQuantity.Value * cartItem.PizzaFinalPrice;
                newTotalPrice = (decimal)cartItem.PizzaTotalPrice;
            }
            else if (cartItem.BeverageId.HasValue)
            {
                oldTotalPrice = (decimal)cartItem.BeverageTotalPrice;
                cartItem.BeverageQuantity = cartItemQuantityUpdateDTO.NewQuantity;
                cartItem.BeverageTotalPrice = cartItem.BeverageQuantity * cartItem.BeverageFinalPrice;
                newTotalPrice = (decimal)cartItem.BeverageTotalPrice;
            }
            else
            {
                throw new InvalidOperationException("CartItem type is not recognized.");
            }

            // Update the cart total price
            cart.TotalPrice += (newTotalPrice - oldTotalPrice);


            // Save changes to repository
            await _cartItemRepository.Update(cartItem);
            await _cartRepository.Update(cart);


            // Return the updated CartItemId
            return cartItem.CartItemId;
        }
    }
}
