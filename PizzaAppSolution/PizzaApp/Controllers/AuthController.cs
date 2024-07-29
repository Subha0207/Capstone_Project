using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs.Auth;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("/api/v1/auth/")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("google")]
        public async Task<IActionResult> AuthenticateWithGoogle([FromBody] GoogleLoginDTO googleLoginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var customErrorResponse = new ErrorModel
                    {
                        ErrorCode = 1001,
                        ErrorMessage = "One or more validation errors occurred.",
           
                    };

                    return BadRequest(customErrorResponse);
                }

                AuthReturnDTO authReturnDTO = await _authService.AuthenticateWithGoogle(googleLoginDTO.Token);

                return Ok(authReturnDTO);
            }
            catch (InvalidJwtException ex)
            {
                var errorObject = new ErrorModel
                {
                    ErrorCode = 1002,
                    ErrorMessage = "Invalid Google Auth Token"
                };
                return BadRequest(errorObject);
            }
            catch (GmailNotVerifiedException ex)
            {
                var errorObject = new ErrorModel
                {
                    ErrorCode = 1003,
                    ErrorMessage = ex.Message
                };
                return BadRequest(errorObject);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }

}
