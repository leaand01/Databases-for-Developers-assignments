using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.IRepositories
{
    public interface IBlogRepository
    {
        Task<Blog> CreateBlog(Blog blog);
        Task<List<Blog>> GetBlogsByUserId(ObjectId userId);
        Task UpdateBlogDescription(ObjectId blogId, string newDescription);

        Task UpdateBlog(Blog blog);
    }
}
