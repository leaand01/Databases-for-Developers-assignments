using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByPostId(ObjectId postId);
        Task<Comment> AddComment(ObjectId postId, ObjectId userId, string content);
    }
}
