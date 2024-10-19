using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Services
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;

        //private readonly IDataAccess _dataAccess;

        /*
        public BlogService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        */
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

        //tilføjet
        /*
        public async Task<List<Post>> GetPostsByBlogId(ObjectId blogId)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.BlogId, blogId);
            return await _postCollection.Find(filter).ToListAsync();
        }
        */
        public async Task<List<Post>> GetPostsByBlogId(ObjectId blogId)
        {
            return await _postRepository.GetPostsByBlogId(blogId); // Opdateret til at bruge _dataAccess
        }

        ///tilføjet
        public async Task UpdateBlog(Blog blog)
        {
            await _blogRepository.UpdateBlog(blog); // Sørg for at denne metode findes i IDataAccess
        }

    }
}
