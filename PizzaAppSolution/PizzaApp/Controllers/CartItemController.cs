using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CartItemController : ControllerBase
    {

        private ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpPost("PizzaCartItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> PostCartItem([FromBody] CartItemPizzaInputDTO cartItemInputDTO)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid model state."
                };
                return BadRequest(errorModel);
            }

            try
            {

                int cartItemId = await _cartItemService.AddCartItem(cartItemInputDTO);


                return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItemId }, cartItemId);
            }
            catch (Exception ex)
            {


                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = "An error occurred while adding the cart item."
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorModel);
            }
        }
        [HttpPatch("PizzaCartItem/Quantity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> PatchCartItemQuantity([FromBody] UpdateQuantityDTO cartItemQuantityUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid model state."
                };
                return BadRequest(errorModel);
            }

            try
            {
                int updatedCartItemId = await _cartItemService.UpdateCartItemQuantity(cartItemQuantityUpdateDTO);
                return Ok(updatedCartItemId);
            }
            catch (KeyNotFoundException ex)
            {
                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message
                };
                return BadRequest(errorModel);
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = "An error occurred while updating the cart item quantity."
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorModel);
            }
        }

        [HttpPost("BeverageCartItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> PostBeverageCartItem([FromBody] CartItemBeverageInputDTO cartItemInputDTO)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid model state."
                };
                return BadRequest(errorModel);
            }

            try
            {

                int cartItemId = await _cartItemService.AddBeverageCartItem(cartItemInputDTO);


                return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItemId }, cartItemId);
            }
            catch (Exception ex)
            {


                var errorModel = new ErrorModel
                {
                    ErrorCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = "An error occurred while adding the cart item."
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorModel);
            }
        }

        [HttpGet("allPizzas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CartItemPizzaDTO>>> GetAllCartItems()
        {
            try
            {
                var cartItems = await _cartItemService.GetAllCartItems();
                return Ok(cartItems);
            }
            catch (EmptyException ex)
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cart items.");
            }
        }
        [HttpGet("pizza{CartItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartItem>> GetCartItemById(int CartItemId)
        {
            try
            {
                var cartItem = await _cartItemService.GetCartItemById(CartItemId);
           
                if (cartItem == null)
                {
                    return NotFound("CartItem not found");
                }
                return Ok(cartItem);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the Beverage.");
            }
        }

        [HttpDelete("pizza{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartItemPizzaDTO>> DeleteCartItemById(int cartItemId)
        {
            try
            {
                var cartItemDTO = await _cartItemService.DeleteByCartItemId(cartItemId);
                return Ok(cartItemDTO);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the CartItem.");
            }
        }

        [HttpGet("allPizzas{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CartItemPizzaDTO>>> GetCartItemsByUserId(int userId)
        {
            try
            {
                var cartItems = await _cartItemService.GetCartItemsByUserId(userId);

                if (cartItems == null || !cartItems.Any())
                {
                    return NotFound("No cart items found for the specified user");
                }
                return Ok(cartItems);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cart items.");
            }
        }

        [HttpGet("allBeverages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CartItemBeverageDTO>>> GetAllBeverageCartItems()
        {
            try
            {
                var cartItems = await _cartItemService.GetAllBeverageCartItems();
                return Ok(cartItems);
            }
            catch (EmptyException ex)
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cart items.");
            }
        }
        [HttpGet("allBeverages{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CartItemBeverageDTO>>> GetBeverageCartItemsByUserId(int userId)
        {
            try
            {
                var cartItems = await _cartItemService.GetBeverageCartItemsByUserId(userId);

                if (cartItems == null || !cartItems.Any())
                {
                    return NotFound("No cart items found for the specified user");
                }
                return Ok(cartItems);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cart items.");
            }
        }


    }
}
