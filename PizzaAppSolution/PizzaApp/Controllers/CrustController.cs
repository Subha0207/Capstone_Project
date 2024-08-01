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
    public class CrustController : ControllerBase
    {
        private ICrustService _crustService;

        public CrustController(ICrustService crustService)
        {
            _crustService = crustService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Crust>>> GetAllCrusts()
        {
            try
            {
                var Crusts = await _crustService.GetAllCrusts();
                return Ok(Crusts);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the crusts.");
            }
        }

        [HttpGet("{CrustId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Crust>> GetId(int CrustId)
        {
            try
            {
                var crust = await _crustService.GetCrustById(CrustId);
                if (crust == null)
                {
                    return NotFound("Crust not found");
                }
                return Ok(crust);
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
        //[HttpGet("cost{PizzaId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<IEnumerable<CrustDTO>>> GetAllCrustCost(int PizzaId)
        //{
        //    try
        //    {
        //        var Crusts = await _crustService.GetAllCrustPriceByPizzaId(PizzaId);
        //        return Ok(Crusts);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the crusts.");
        //    }
        //}
    }
}
