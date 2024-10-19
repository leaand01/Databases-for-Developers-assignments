using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IDataAccess _dataAccess;

        /*
        public UserService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        */
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(string username, string email)
        {
            var user = new User { Username = username, Email = email };
            return await _userRepository.CreateUser(user);  // erstatet _dataAccess med _userRepository
        }

        public async Task UpdateUsername(ObjectId userId, string newUsername)
        {
            await _userRepository.UpdateUsername(userId, newUsername);
        }

        public async Task<User> GetUserById(ObjectId userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        // tilføjet
        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user); // Sørg for at denne metode findes i IDataAccess
        }

    }
}
