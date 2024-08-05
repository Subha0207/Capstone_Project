using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Interfaces;
using System.Threading.Tasks;
using PizzaApp.Models.DTOs;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/Cart/{cartId}
        [HttpGet("{cartId}")]
        public async Task<ActionResult<CartUpdateDTO>> GetCartById(int cartId)
        {
            try
            {
                var cartDTO = await _cartService.GetCartById(cartId);
                if (cartDTO == null)
                {
                    return NotFound();
                }
                return Ok(cartDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("activeCart{userId}")]
        public async Task<ActionResult<int>> GetActiveCartByUserId(int userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var customErrorResponse = new
                    {
                        ErrCode = 1001,
                        Message = "One or more validation errors occurred.",
                        Error = errors
                    };

                    return BadRequest(customErrorResponse);
                }
                var cart = await _cartService.GetActiveCartByUserId(userId);
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart.CartId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // PUT: api/Cart/{cartId}/checkout
        [HttpPut("{cartId}/checkout")]
        public async Task<ActionResult<CartUpdateDTO>> UpdateCartCheckoutStatus(int cartId)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var customErrorResponse = new
                    {
                        ErrCode = 1001,
                        Message = "One or more validation errors occurred.",
                        Error = errors
                    };

                    return BadRequest(customErrorResponse);
                }
                var updatedCartDTO = await _cartService.UpdateCartCheckoutStatus(cartId);
                if (updatedCartDTO == null)
                {  
                    return NotFound();
                }
                return Ok(updatedCartDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Cart/{cartId}/checkout
        [HttpGet("{cartId}/orderDetails")]
        public async Task<ActionResult<OrderDetailsDTO>> GetOrderDetails(int cartId)
        {
            try
            {
                var orderDetailsDTO = await _cartService.GetOrderDetailsByCartId(cartId);
                if (orderDetailsDTO == null)
                {
                    return NotFound();
                }
                return Ok(orderDetailsDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
