using CarClinic.Application.DTOs;
using CarClinic.Application.UseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : ControllerBase
    {
        private readonly GetUserByIdUseCase _getUserByIdUseCase;
        private readonly GetAllUsersUseCase _getAllUsersUseCase;
        private readonly UpdateUserUseCase _updateUserUseCase;
        private readonly DeleteUserUseCase _deleteUserUseCase;

        public AdminUserController(
            GetUserByIdUseCase getUserByIdUseCase,
            GetAllUsersUseCase getAllUsersUseCase,
            UpdateUserUseCase updateUserUseCase,
            DeleteUserUseCase deleteUserUseCase)
        {
            _getUserByIdUseCase = getUserByIdUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
            _updateUserUseCase = updateUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _getUserByIdUseCase.ExecuteAsync(id);
            if (user == null) return NotFound(new { error = "User not found" });

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _getAllUsersUseCase.ExecuteAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto dto)
        {
            var success = await _updateUserUseCase.ExecuteAsync(id, dto);
            if (!success) return NotFound(new { error = "User not found" });

            return Ok(new { message = "User updated successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var success = await _deleteUserUseCase.ExecuteAsync(id);
            if (!success) return NotFound(new { error = "User not found" });

            return Ok(new { message = "User deleted successfully" });
        }
    }
}
