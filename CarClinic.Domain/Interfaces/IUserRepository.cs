using CarClinic.Domain.Entities;

namespace CarClinic.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(string id);
        Task<User> GetByIdAsync(string id);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
