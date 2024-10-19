using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.IRepositories
{
    public interface IUserRepository
    {
        /*
        Task<User> CreateUser(User user);
        Task<User> GetUserById(ObjectId userId);
        Task<List<User>> GetAllUsers();
        Task UpdateUser(User user);
        Task UpdateUsername(ObjectId userId, string newUsername);
        Task DeleteUser(ObjectId userId);

        */

        Task<User> CreateUser(User user);
        Task UpdateUsername(ObjectId userId, string newUsername);
        Task<User> GetUserById(ObjectId userId);
        Task<List<User>> GetAllUsers();
        //tilføjet
        Task UpdateUser(User user); // Tilføj denne metode
    }
}
