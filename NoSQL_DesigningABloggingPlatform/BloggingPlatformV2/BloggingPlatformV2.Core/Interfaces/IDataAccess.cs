/*
using BloggingPlatformV2.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Interfaces
{
    public interface IDataAccess
    {
        Task<User> CreateUser(User user);
        Task UpdateUsername(ObjectId userId, string newUsername);
        Task<User> GetUserById(ObjectId userId);
        Task<List<User>> GetAllUsers();
        //tilføjet
        Task UpdateUser(User user); // Tilføj denne metode

        Task<Blog> CreateBlog(Blog blog);
        Task<List<Blog>> GetBlogsByUserId(ObjectId userId);
        Task UpdateBlogDescription(ObjectId blogId, string newDescription);
        //tilføjet
        Task UpdateBlog(Blog blog); // Tilføj denne metode

        
        //Task<Post> CreatePost(Post post);
        //Task<List<Post>> GetPostsByBlogId(ObjectId blogId);
        //Task UpdatePostContent(ObjectId postId, string newContent);
        

        Task<Post> CreatePost(Post post);
        Task<List<Post>> GetPostsByBlogId(ObjectId blogId);
        Task UpdatePostContent(ObjectId postId, string newContent);
        //Task UpdatePosts(FilterDefinition<Post> filter, UpdateDefinition<Post> update);
        //Task<List<Comment>> GetCommentsByPostId(ObjectId postId);
        Task UpdatePosts(FilterDefinition<Post> filter, UpdateDefinition<Post> update); // Tilføjet
        
        //tilføjet
        Task UpdatePost(Post post); // Tilføj denne metode


        Task<Comment> AddComment(Comment comment);
        Task<List<Comment>> GetCommentsByPostId(ObjectId postId);

        //tilføjet
        Task UpdateComments(FilterDefinition<Comment> filter, UpdateDefinition<Comment> update);
    }
}
*/