using CarClinic.Application.DTOs.User;
using CarClinic.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CarClinic.Application.UseCases.User
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest request)
        {
            // check if email already exists
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already registered.");
            }

            // hash password
            var passwordHash = HashPassword(request.Password);

            var user = new CarClinic.Domain.Entities.User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Location = request.Location,
                PhoneNumber = request.PhoneNumber,
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            var createdUser = await _userRepository.CreateUserAsync(user);

            return new RegisterUserResponse
            {
                Id = createdUser.Id,
                FullName = createdUser.FullName,
                Email = createdUser.Email,
                Location = createdUser.Location,
                PhoneNumber = createdUser.PhoneNumber,
                Role = createdUser.Role,
                CreatedAt = createdUser.CreatedAt
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
