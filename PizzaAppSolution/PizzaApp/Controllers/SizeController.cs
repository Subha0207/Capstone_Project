using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SizeController : ControllerBase
    {
        private ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Size>>> GetAllSizes()
        {
            try
            {
                var Sizes = await _sizeService.GetAllSizes();
                return Ok(Sizes);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the crusts.");
            }
        }

        [HttpGet("cost{PizzaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SizeDTO>>> GetAllCrustCost(int PizzaId)
        {
            try
            {
                var Sizes = await _sizeService.GetAllSizePriceBySizeId(PizzaId);
                return Ok(Sizes);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the crusts.");
            }
        }
    }
}
