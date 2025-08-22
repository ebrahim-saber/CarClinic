using CarClinic.Application.DTOs.User;
using CarClinic.Domain.Interfaces;

namespace CarClinic.Application.UseCases.User
{
    public class GetProfileUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetProfileUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterUserResponse?> ExecuteAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return null;

            return new RegisterUserResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Location = user.Location,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
