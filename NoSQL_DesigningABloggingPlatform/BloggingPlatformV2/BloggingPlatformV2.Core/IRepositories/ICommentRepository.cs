using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.IRepositories
{
    public interface ICommentRepository
    {
        Task<Comment> AddComment(Comment comment);
        Task<List<Comment>> GetCommentsByPostId(ObjectId postId);
        Task UpdateComments(FilterDefinition<Comment> filter, UpdateDefinition<Comment> update);
    }
}
