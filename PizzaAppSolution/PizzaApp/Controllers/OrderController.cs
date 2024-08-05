using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Services;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("AddOrder")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddOrder([FromBody] OrderInputDTO orderInputDTO)
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



            var orderId = await _orderService.AddOrder(orderInputDTO);
            return Ok(new { OrderId = orderId });
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("allOrders{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetOrdersByUserId(int userId)
    {
        try
        {
            var orders = await _orderService.GetOrdersByUserId(userId);

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for the specified user");
            }
            return Ok(orders);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the cart items.");
        }
    }

    [HttpGet("order{OrderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderGetDTO>> GetOrderById(int OrderId)
    {
        try
        {
            var order = await _orderService.GetOrderById(OrderId);

            if (order == null)
            {
                return NotFound("Order not found");
            }
            return Ok(order);
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetAllOrders()
    {
        try
        {

            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        catch (EmptyException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Handle other exceptions as needed
            return StatusCode(500, new { message = "An error occurred while retrieving orders.", details = ex.Message });
        }
    }

    [HttpPatch("Status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> PatchStatus([FromBody] OrderUpdateDTO orderUpdateDTO)
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
            int updatedOrder = await _orderService.UpdateOrderStatus(orderUpdateDTO);
            return Ok(updatedOrder);
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
                ErrorMessage = "An error occurred while updating the order status."
            };
            return StatusCode(StatusCodes.Status500InternalServerError, errorModel);
        }
    }

}
