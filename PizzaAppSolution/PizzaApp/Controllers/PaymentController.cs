using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Services;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class PaymentController : ControllerBase
{
  
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("AddPayment")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddPayment([FromBody] PaymentInputDTO paymentInputDTO)
    {
        if (paymentInputDTO == null)
        {
            return BadRequest("Payment input is null");
        }

        try
        {
            var paymentId = await _paymentService.AddPayment(paymentInputDTO);
            return Ok(new { PaymentId = paymentId });
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{PaymentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Payment>> GetId(int PaymentId)
    {
        try
        {
            var payment = await _paymentService.GetAmountByPaymentId(PaymentId);
            if (payment == null)
            {
                return NotFound("Crust not found");
            }
            return Ok(payment);
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

    [HttpGet("PaymentDetails{PaymentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Payment>> GetPaymentDetailsbyId(int PaymentId)
    {
        try
        {
            var payment = await _paymentService.GetDetailsByPaymentId(PaymentId);
            if (payment == null)
            {
                return NotFound("Payment not found");
            }
            return Ok(payment);
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
