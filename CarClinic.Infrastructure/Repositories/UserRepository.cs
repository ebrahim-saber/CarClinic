using CarClinic.Domain.Entities;
using CarClinic.Domain.Interfaces;
using CarClinic.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarClinic.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDbContext context)
        {
            _users = context.GetCollection<User>("Users");
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }
        public async Task<User> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
                return null; 

            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteAsync(string id)
        {
            await _users.DeleteOneAsync(u => u.Id == id);
        }
        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _users.Find(_ => true).ToListAsync();
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }
    }
}
