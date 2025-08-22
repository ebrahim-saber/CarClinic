using CarClinic.Application.DTOs.User;
using CarClinic.Application.UseCases.User;
using Microsoft.AspNetCore.Mvc;

namespace CarClinic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;

        public UserController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                var response = await _registerUserUseCase.ExecuteAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _loginUserUseCase.ExecuteAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

    }
}
