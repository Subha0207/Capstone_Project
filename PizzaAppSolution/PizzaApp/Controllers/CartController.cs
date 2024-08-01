using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Interfaces;
using System.Threading.Tasks;
using PizzaApp.Models.DTOs;

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

        // PUT: api/Cart/{cartId}/checkout
        [HttpPut("{cartId}/checkout")]
        public async Task<ActionResult<CartUpdateDTO>> UpdateCartCheckoutStatus(int cartId)
        {
            try
            {
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
    }
}
