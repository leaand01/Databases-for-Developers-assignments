/*
using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePost(ObjectId blogId, string title, string content, ObjectId userId);
        Task<List<Post>> GetPostsByBlogId(ObjectId blogId);
        Task UpdatePostContent(ObjectId postId, string newContent);
    }
}
*/