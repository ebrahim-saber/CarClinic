using CarClinic.Application.DTOs.User;
using CarClinic.Domain.Interfaces;
using Microsoft.Extensions.Options;
using CarClinic.Infrastructure.Settings;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CarClinic.Application.UseCases.User
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public LoginUserUseCase(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != HashPassword(request.Password))
            {
                throw new Exception("Invalid email or password.");
            }

            var token = GenerateJwtToken(user.Id, user.Email, user.Role);

            return new LoginResponse
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };
        }

        private string GenerateJwtToken(string userId, string email, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
