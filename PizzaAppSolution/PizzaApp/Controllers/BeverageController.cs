using Microsoft.AspNetCore.Authorization;
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
    public class BeverageController : ControllerBase
    {
        private IBeverageService _beverageService;

        public BeverageController(IBeverageService beverageService)
        {
            _beverageService = beverageService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetAllBeverages()
        {
            try
            {
                var Beverages = await _beverageService.GetAllBeverages();
                return Ok(Beverages);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the beverages.");
            }
        }

        [HttpGet("newBeverages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetAllNewBeverages()
        {
            try
            {
                var Beverages = await _beverageService.GetAllNewBeverages();
                return Ok(Beverages);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the beverages.");
            }
        }


        [HttpGet("bestsellers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetAllBestSellerBeverages()
        {
            try
            {
                var beverages = await _beverageService.GetAllBestSellingBeverages();
                return Ok(beverages);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the best-seller beverages.");
            }
        }


        [HttpGet("{BeverageId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Beverage>> GetBeverageById(int BeverageId)
        {
            try
            {
                var beverage = await _beverageService.GetBeverageByBeverageId(BeverageId);
                Console.WriteLine(beverage);
                if (beverage == null)
                {
                    return NotFound("Beverage not found");
                }
                return Ok(beverage);
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
    }
    }
