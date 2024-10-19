using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        //private readonly IDataAccess _dataAccess;
        /*
        public CommentService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        */
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> AddComment(ObjectId userId, ObjectId blogId, ObjectId postId, string content)
        {
            var comment = new Comment { UserId = userId, BlogId = blogId, PostId = postId, Content = content };
            return await _commentRepository.AddComment(comment);
        }

        public async Task<List<Comment>> GetCommentsByPostId(ObjectId postId)
        {
            return await _commentRepository.GetCommentsByPostId(postId);
        }

        //tilføjet
        /*
        public async Task UpdateUsernameInComments(ObjectId userId, string newUsername)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.UserId, userId);
            var update = Builders<Comment>.Update.Set(c => c.Username, newUsername);
            await _commentCollection.UpdateManyAsync(filter, update);
        }
        */
        // Opdaterer brugernavn i alle kommentarer for en bruger
        public async Task UpdateUsernameInComments(ObjectId userId, string newUsername)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.UserId, userId);
            var update = Builders<Comment>.Update.Set(c => c.Content, newUsername); // Opdaterer indholdet med det nye brugernavn

            // Udfør opdatering gennem IDataAccess
            await _commentRepository.UpdateComments(filter, update); // Sørg for at implementere UpdateComments i IDataAccess
        }
    }
}
