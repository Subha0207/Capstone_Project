using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ToppingController : ControllerBase
    {
      
        private IToppingService _toppingService;

        public ToppingController(IToppingService toppingService)
        {
            _toppingService = toppingService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Topping>>> GetAllToppings()
        {
            try
            {
                var Toppings = await _toppingService.GetAllToppings();
                return Ok(Toppings);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the Toppings.");
            }
        }

        [HttpGet("{ToppingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Topping>> GetToppingById(int ToppingId)
        {
            try
            {
                var topping = await _toppingService.GetToppingById(ToppingId);
                if (topping == null)
                {
                    return NotFound("Topping not found");
                }
                return Ok(topping);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the pizza.");
            }
        }
    }
}
