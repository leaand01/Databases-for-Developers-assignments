using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(string username, string email); // Opret user med angivne username og email
        Task UpdateUsername(ObjectId userId, string newUsername);
        Task<User> GetUserById(ObjectId userId);
        Task<List<User>> GetAllUsers();
    }
}
