using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// Gets all the pizzas from the database.
        /// </summary>
        /// <returns>List of pizzas.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizzas();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the pizzas.");
            }
        }

        [HttpGet("bestsellers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllBestSellerPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllBestSellerPizzas();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the best-seller pizzas.");
            }
        }
        [HttpGet("new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllNewPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllNewPizzas();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the new pizzas.");
            }
        }
        [HttpGet("veg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllVegPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllVegPizzas();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the new pizzas.");
            }
        }
        [HttpGet("nonVeg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllNonVegPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllNonVegPizzas();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the new pizzas.");
            }
        }
    }
}
