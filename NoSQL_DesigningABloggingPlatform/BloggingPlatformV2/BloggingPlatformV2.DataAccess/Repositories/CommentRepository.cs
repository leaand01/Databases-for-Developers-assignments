using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.IRepositories;
using BloggingPlatformV2.Infrastructur;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BloggingPlatformV2.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IMongoCollection<Comment> _comments;

        public CommentRepository(MongoDbConnection dbConnection)
        {
            _comments = dbConnection.GetCollection<Comment>("comments");
        }


        public async Task<Comment> AddComment(Comment comment)
        {
            await _comments.InsertOneAsync(comment);
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByPostId(ObjectId postId)
        {
            return await _comments.Find(c => c.PostId == postId).ToListAsync();
        }

        //tilføjet
        public async Task UpdateComments(FilterDefinition<Comment> filter, UpdateDefinition<Comment> update)
        {
            await _comments.UpdateManyAsync(filter, update); // opdater alle comments-objekter som matcher filteret
        }
    }
}
