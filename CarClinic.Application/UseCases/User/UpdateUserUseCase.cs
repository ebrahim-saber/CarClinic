using CarClinic.Application.DTOs;
using CarClinic.Domain.Interfaces;

namespace CarClinic.Application.UseCases.User
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ExecuteAsync(string id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            user.FullName = dto.FullName ?? user.FullName;
            user.Email = dto.Email ?? user.Email;
            user.Role = dto.Role ?? user.Role;

            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
