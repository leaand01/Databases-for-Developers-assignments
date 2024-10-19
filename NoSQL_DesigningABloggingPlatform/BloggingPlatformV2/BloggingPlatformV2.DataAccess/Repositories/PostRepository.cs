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
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostRepository(MongoDbConnection dbConnection)
        {
            _posts = dbConnection.GetCollection<Post>("posts");
        }

        public async Task<Post> CreatePost(Post post)
        {
            await _posts.InsertOneAsync(post);
            return post;
        }

        public async Task<List<Post>> GetPostsByBlogId(ObjectId blogId)
        {
            return await _posts.Find(p => p.BlogId == blogId).ToListAsync();
        }

        public async Task UpdatePostContent(ObjectId postId, string newContent)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.Id, postId);
            var update = Builders<Post>.Update.Set(p => p.Content, newContent);
            await _posts.UpdateOneAsync(filter, update);
        }


        // Implementering af UpdatePosts
        public async Task UpdatePosts(FilterDefinition<Post> filter, UpdateDefinition<Post> update)
        {
            await _posts.UpdateManyAsync(filter, update); // Opdaterer alle posts der matcher filteret
        }


        //tilføjet
        public async Task UpdatePost(Post post)  // opdater specifik post
        {
            var filter = Builders<Post>.Filter.Eq(p => p.Id, post.Id);
            await _posts.ReplaceOneAsync(filter, post);
        }
    }
}
