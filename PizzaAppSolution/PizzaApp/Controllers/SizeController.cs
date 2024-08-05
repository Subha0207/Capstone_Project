using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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




        [HttpGet("{SizeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Size>> GetId(int SizeId)
        {
            try
            {
                var size = await _sizeService.GetSizeById(SizeId);
                if (size == null)
                {
                    return NotFound("Size not found");
                }
                return Ok(size);
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
        [HttpGet("cost/{pizzaId}/{sizeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetCostBySizeIdAndPizzaId(int pizzaId, int sizeId)
        {
            try
            {
                var sizeDTO = await _sizeService.GetCostBySizeIdAndPizzaId(pizzaId,sizeId);
                if (sizeDTO == null)
                {
                    return NotFound("Size or Pizza not found.");
                }
                return Ok(sizeDTO);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the size cost.");
            }
        }


    }
}
