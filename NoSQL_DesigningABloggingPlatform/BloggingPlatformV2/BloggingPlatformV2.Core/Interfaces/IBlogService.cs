/*
using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> CreateBlog(ObjectId userId, string title, string description);
        Task<List<Blog>> GetBlogsByUserId(ObjectId userId);
        Task UpdateBlogDescription(ObjectId blogId, string newDescription);
    }
}
*/