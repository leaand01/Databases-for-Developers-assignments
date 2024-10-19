using BloggingPlatformV2.Core.Entities;
//using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BloggingPlatformV2.Core.Services
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;

        public BlogService(IBlogRepository blogRepository, IPostRepository postRepository)
        {
            _blogRepository = blogRepository;
            _postRepository = postRepository;
        }

        public async Task<Blog> CreateBlog(ObjectId userId, string title, string description)
        {
            var blog = new Blog { UserId = userId, Title = title, Description = description };
            return await _blogRepository.CreateBlog(blog);
        }

        public async Task<List<Blog>> GetBlogsByUserId(ObjectId userId)
        {
            return await _blogRepository.GetBlogsByUserId(userId);
        }

        public async Task<List<Post>> GetPostsByBlogId(ObjectId blogId)
        {
            return await _postRepository.GetPostsByBlogId(blogId);
        }

        public async Task UpdateBlog(Blog blog)
        {
            await _blogRepository.UpdateBlog(blog);
        }
    }
}
