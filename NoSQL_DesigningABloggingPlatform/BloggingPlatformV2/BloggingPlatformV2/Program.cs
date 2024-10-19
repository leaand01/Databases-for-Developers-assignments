using BloggingPlatformV2.Core.Entities;
using BloggingPlatformV2.Core.Interfaces;
using BloggingPlatformV2.Core.Services;
using BloggingPlatformV2.Core.IRepositories;
using BloggingPlatformV2.Infrastructur;
using BloggingPlatformV2.DataAccess.Repositories;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // opret forbindelse til MongoDB
        var connectionString = "mongodb+srv://leaand01:y9VCOHTjgL4CrDYl@cluster0.wjrfw.mongodb.net/";
        var mongoClient = new MongoClient(connectionString);
        var dbConnection = new MongoDbConnection(mongoClient, "BloggingPlatform");

        // Initialiser repositories
        var userRepository = new UserRepository(dbConnection);
        var blogRepository = new BlogRepository(dbConnection);
        var postRepository = new PostRepository(dbConnection);
        var commentRepository = new CommentRepository(dbConnection);

        // Initialiser services med de respektive repositories
        var userService = new UserService(userRepository);
        var blogService = new BlogService(blogRepository, postRepository);
        var postService = new PostService(postRepository, commentRepository);
        var commentService = new CommentService(commentRepository);


        /* Bemærk nedenstående kunne være flyttet til et separat script for bedre overskuelighed og læsbarhed */

        // Opret en ny bruger
        var user = await userService.CreateUser("Someone", "someone@gmail.com");
        Console.WriteLine($"User created: {user.Username}");

        // Opret en ny blog og tilføj reference til bruger
        var blog = await blogService.CreateBlog(user.Id, "Blog about Someones life", "This blog is about...");
        Console.WriteLine($"Blog created: {blog.Title}");
        user.Blogs.Add(blog.Id);
        await userService.UpdateUser(user);

        // Opret et indlæg/post og tilføj reference til blog
        var post = await postService.CreatePost(user.Id, blog.Id, "Typical Monday", "bla bla bla");
        Console.WriteLine($"Post created: {post.Title}");
        blog.Posts.Add(post.Id);
        await blogService.UpdateBlog(blog);

        // Opret en kommentar og tilføj reference til post
        var comment = await commentService.AddComment(user.Id, blog.Id, post.Id, "someone commented on Someones blog post");
        Console.WriteLine($"Comment added: {comment.Content}");
        post.Comments.Add(comment.Id);
        await postService.UpdatePost(post);


        // Funktionaliteter skulle implementere:
        // Hent alle posts for en blog
        var postsForBlog = await blogService.GetPostsByBlogId(blog.Id);
        Console.WriteLine($"Posts for Blog '{blog.Title}':");
        foreach (var p in postsForBlog) Console.WriteLine($" - {p.Title}");

        // Hent alle kommentarer for et post
        var commentsForPost = await postService.GetCommentsByPostId(post.Id);
        Console.WriteLine($"Comments for Post '{post.Title}':");
        foreach (var c in commentsForPost) Console.WriteLine($" - {c.Content}");

        // Opdater indholdet af et post
        await postService.UpdatePostContent(post.Id, "opdateret indhold");
        Console.WriteLine("Post content updated.");

        // Opdater brugernavn og opdater referencer i posts og comments
        string newUsername = "Someone_is_Casper";
        await userService.UpdateUsername(user.Id, newUsername);
        await postService.UpdateUsernameInPosts(user.Id, newUsername);
        await commentService.UpdateUsernameInComments(user.Id, newUsername);
        Console.WriteLine("Username updated across user, posts, and comments.");
    }
}
