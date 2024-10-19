using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using BloggingPlatformV2.Infrastructur;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BloggingPlatformV2.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDbConnection dbConnection)
        {
            _users = dbConnection.GetCollection<User>("users");
        }

        // Definer logikken for funktionaliteterne i IUserRepository

        public async Task<User> CreateUser(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task UpdateUsername(ObjectId userId, string newUsername)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
            var update = Builders<User>.Update.Set(u => u.Username, newUsername);
            await _users.UpdateOneAsync(filter, update);
        }

        public async Task<User> GetUserById(ObjectId userId)
        {
            return await _users.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _users.Find(_ => true).ToListAsync();
        }


        //tilføjet
        public async Task UpdateUser(User user) // opdater alle ændringer på hele user-objektet
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _users.ReplaceOneAsync(filter, user);
        }
    }
}
