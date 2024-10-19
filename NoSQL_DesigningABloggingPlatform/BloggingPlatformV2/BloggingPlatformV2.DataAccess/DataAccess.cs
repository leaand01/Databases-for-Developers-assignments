/*
using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Infrastructur;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IMongoCollection<Blog> _blogsCollection;
        private readonly IMongoCollection<Post> _postsCollection;
        private readonly IMongoCollection<Comment> _commentsCollection;

        public DataAccess(MongoDbConnection dbConnection)
        {
            _usersCollection = dbConnection.GetCollection<User>("users");
            _blogsCollection = dbConnection.GetCollection<Blog>("blogs");
            _postsCollection = dbConnection.GetCollection<Post>("posts");
            _commentsCollection = dbConnection.GetCollection<Comment>("comments");
        }

        public async Task<User> CreateUser(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return user;
        }

        public async Task UpdateUsername(ObjectId userId, string newUsername)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
            var update = Builders<User>.Update.Set(u => u.Username, newUsername);
            await _usersCollection.UpdateOneAsync(filter, update);
        }

        public async Task<User> GetUserById(ObjectId userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }


        //tilføjet
        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _usersCollection.ReplaceOneAsync(filter, user);
        }


        public async Task<Blog> CreateBlog(Blog blog)
        {
            await _blogsCollection.InsertOneAsync(blog);
            return blog;
        }

        public async Task<List<Blog>> GetBlogsByUserId(ObjectId userId)
        {
            return await _blogsCollection.Find(b => b.UserId == userId).ToListAsync();
        }

        public async Task UpdateBlogDescription(ObjectId blogId, string newDescription)
        {
            var filter = Builders<Blog>.Filter.Eq(b => b.Id, blogId);
            var update = Builders<Blog>.Update.Set(b => b.Description, newDescription);
            await _blogsCollection.UpdateOneAsync(filter, update);
        }

        //tilføjet
        public async Task UpdateBlog(Blog blog)
        {
            var filter = Builders<Blog>.Filter.Eq(b => b.Id, blog.Id);
            await _blogsCollection.ReplaceOneAsync(filter, blog);
        }


        public async Task<Post> CreatePost(Post post)
        {
            await _postsCollection.InsertOneAsync(post);
            return post;
        }

        public async Task<List<Post>> GetPostsByBlogId(ObjectId blogId)
        {
            return await _postsCollection.Find(p => p.BlogId == blogId).ToListAsync();
        }

        public async Task UpdatePostContent(ObjectId postId, string newContent)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.Id, postId);
            var update = Builders<Post>.Update.Set(p => p.Content, newContent);
            await _postsCollection.UpdateOneAsync(filter, update);
        }


        // Implementering af UpdatePosts
        public async Task UpdatePosts(FilterDefinition<Post> filter, UpdateDefinition<Post> update)
        {
            await _postsCollection.UpdateManyAsync(filter, update); // Opdaterer alle indlæg der matcher filteret
        }


        //tilføjet
        public async Task UpdatePost(Post post)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.Id, post.Id);
            await _postsCollection.ReplaceOneAsync(filter, post);
        }


        public async Task<Comment> AddComment(Comment comment)
        {
            await _commentsCollection.InsertOneAsync(comment);
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByPostId(ObjectId postId)
        {
            return await _commentsCollection.Find(c => c.PostId == postId).ToListAsync();
        }

        //tilføjet
        public async Task UpdateComments(FilterDefinition<Comment> filter, UpdateDefinition<Comment> update)
        {
            await _commentsCollection.UpdateManyAsync(filter, update);
        }
    }
}
*/
