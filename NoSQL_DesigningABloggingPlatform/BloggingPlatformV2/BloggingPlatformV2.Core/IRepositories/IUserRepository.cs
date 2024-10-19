using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.IRepositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);  // Oprettelse af bruger i MongoDB-databasen
        Task UpdateUsername(ObjectId userId, string newUsername);
        Task<User> GetUserById(ObjectId userId);
        Task<List<User>> GetAllUsers();
        Task UpdateUser(User user); 
    }
}
