using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.IRepositories
{
    public interface IPostRepository
    {
        Task<Post> CreatePost(Post post);
        Task<List<Post>> GetPostsByBlogId(ObjectId blogId);
        Task UpdatePostContent(ObjectId postId, string newContent);


        // tilføjet
        Task UpdatePosts(FilterDefinition<Post> filter, UpdateDefinition<Post> update);

        Task UpdatePost(Post post);
    }
}
