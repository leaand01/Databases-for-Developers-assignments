using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using BloggingPlatformV2.Infrastructur;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BloggingPlatformV2.DataAccess.Repositories
{

    public class BlogRepository : IBlogRepository
    {
        private readonly IMongoCollection<Blog> _blogs;

        //public BlogRepository(IMongoDatabase dbConnection)
        public BlogRepository(MongoDbConnection dbConnection)
        {
            _blogs = dbConnection.GetCollection<Blog>("blogs");
        }


        public async Task<Blog> CreateBlog(Blog blog)
        {
            await _blogs.InsertOneAsync(blog);
            return blog;
        }

        public async Task<List<Blog>> GetBlogsByUserId(ObjectId userId)
        {
            return await _blogs.Find(b => b.UserId == userId).ToListAsync();
        }

        public async Task UpdateBlogDescription(ObjectId blogId, string newDescription)
        {
            var filter = Builders<Blog>.Filter.Eq(b => b.Id, blogId);
            var update = Builders<Blog>.Update.Set(b => b.Description, newDescription);
            await _blogs.UpdateOneAsync(filter, update);
        }

        //tilføjet
        public async Task UpdateBlog(Blog blog)
        {
            var filter = Builders<Blog>.Filter.Eq(b => b.Id, blog.Id);
            await _blogs.ReplaceOneAsync(filter, blog);
        }
    }
}
