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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                return Ok(cartItemId);
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
        [HttpPost("BeverageCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                return Ok(cartItemId);  // Return OK status with the cart item ID
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
        [HttpPatch("update/Quantity")]
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

     
        [HttpGet("{CartItemId}")]
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

        [HttpDelete("{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> DeleteCartItemById(int cartItemId)
        {
            try
            {
                var cartItemDTO = await _cartItemService.DeleteByCartItemId(cartItemId);

                // Return the DTO directly
                return Ok(cartItemDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the CartItem.");
            }
        }

      

    }
}
