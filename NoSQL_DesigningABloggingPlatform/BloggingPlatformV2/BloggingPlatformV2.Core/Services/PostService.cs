using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatformV2.Core.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        //private readonly IDataAccess _dataAccess;
        /*
        public PostService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        */
        public PostService(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async Task<Post> CreatePost(ObjectId userId, ObjectId blogId, string title, string content)
        {
            var post = new Post { UserId = userId, BlogId = blogId, Title = title, Content = content };
            return await _postRepository.CreatePost(post);
        }

        public async Task<List<Post>> GetPostsByBlogId(ObjectId blogId)
        {
            return await _postRepository.GetPostsByBlogId(blogId);
        }

        public async Task UpdatePostContent(ObjectId postId, string newContent)
        {
            await _postRepository.UpdatePostContent(postId, newContent);
        }

        //tilføjet
        // Opdaterer brugernavn i alle posts for en bruger
        public async Task UpdateUsernameInPosts(ObjectId userId, string newUsername)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.UserId, userId);
            var update = Builders<Post>.Update.Set(p => p.AuthorUsername, newUsername);
            await _postRepository.UpdatePosts(filter, update);
        }

        //tilføjet
        // Henter alle kommentarer for et givent post
        public async Task<List<Comment>> GetCommentsByPostId(ObjectId postId)
        {
            return await _commentRepository.GetCommentsByPostId(postId);
        }

        // tilføjet
        public async Task UpdatePost(Post post)
        {
            await _postRepository.UpdatePost(post); // Sørg for at denne metode findes i IDataAccess
        }


    }
}
