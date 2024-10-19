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
        /*
        var connectionString = Environment.GetEnvironmentVariable("mongodb+srv://leaand01:y9VCOHTjgL4CrDYl@cluster0.wjrfw.mongodb.net/");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Environment.Exit(0);
        }
        var client = new MongoClient(connectionString);
        var collection = client.GetDatabase("BloggingPlatformV2").GetCollection<BsonDocument>("user");
        var filter = Builders<BsonDocument>.Filter.Eq("username", "someone");
        var document = collection.Find(filter).First();
        Console.WriteLine(document);
        */

        /*
        var connectionString = "mongodb://localhost:27017";
        var mongoClient = new MongoClient(connectionString);
        var dbConnection = new MongoDbConnection(mongoClient, "BloggingPlatform");
        */

        /*
        IDataAccess dataAccess = new DataAccess(dbConnection);
        */
        //Console.WriteLine("hertil");


        /*var connectionString = "mongodb+srv://leaand01:y9VCOHTjgL4CrDYl@cluster0.wjrfw.mongodb.net/";
        var mongoClient = new MongoClient(connectionString);
        var dbConnection = new MongoDbConnection(mongoClient, "BloggingPlatform");
        IDataAccess dataAccess = new DataAccess(dbConnection);


        var userService = new UserService(dataAccess);
        var blogService = new BlogService(dataAccess);
        var postService = new PostService(dataAccess);
        var commentService = new CommentService(dataAccess);


        // 1. Opret en ny bruger
        var user = await userService.CreateUser("Someone", "someone@gmail.com");
        Console.WriteLine($"User created: {user.Username}");

        // 2. Opret en ny blog og tilføj reference til bruger
        var blog = await blogService.CreateBlog(user.Id, "Blog about Someones life", "This blog is about...");
        Console.WriteLine($"Blog created: {blog.Title}");

        // Tilføj blog-ID til brugerens dokument og opdater det i databasen
        user.Blogs.Add(blog.Id);
        await userService.UpdateUser(user);

        // 3. Opret et indlæg og tilføj reference til blog
        var post = await postService.CreatePost(user.Id, blog.Id, "Typical monday", "bla bla bla");
        Console.WriteLine($"Post created: {post.Title}");

        // Tilføj post-ID til blogens dokument og opdater det i databasen
        blog.Posts.Add(post.Id);
        await blogService.UpdateBlog(blog);

        // 4. Opret en kommentar og tilføj reference til post
        var comment = await commentService.AddComment(user.Id, blog.Id, post.Id, "someone commented on Someones blog post");
        Console.WriteLine($"Comment added: {comment.Content}");

        // Tilføj kommentar-ID til postens dokument og opdater det i databasen
        post.Comments.Add(comment.Id);
        await postService.UpdatePost(post);



        // 5. Opdater indholdet af indlægget
        await postService.UpdatePostContent(post.Id, "Updated content for the first post.");
        Console.WriteLine("Post content updated.");

        // 6. Opdater brugernavn
        await userService.UpdateUsername(user.Id, "john_updated");
        Console.WriteLine("Username updated.");

        Console.WriteLine("Nået hertil...");
        



        /*


        // Opret en ny bruger
        var user = await userService.CreateUser("Someone", "someone@gmail.com");
        Console.WriteLine($"User created: {user.Username}");

        // Opret en ny blog og tilføj reference til bruger
        var blog = await blogService.CreateBlog(user.Id, "Blog about Someones life", "This blog is about...");
        Console.WriteLine($"Blog created: {blog.Title}");

        // Tilføj blog-ID til brugerens dokument og opdater det i databasen
        user.Blogs.Add(blog.Id);
        await userService.UpdateUser(user);


        // Opret et indlæg og tilføje referencer til blog
        var post = await postService.CreatePost(user.Id, blog.Id, "Typical Monday", "bla bla bla.");
        Console.WriteLine($"Post created: {post.Title}");


        // Tilføj post-ID til blogens dokument og opdater det i databasen
        blog.Posts.Add(post.Id);
        await blogService.UpdateBlog(blog);


        // Opret en kommentar
        var comment = await commentService.AddComment(user.Id, blog.Id, post.Id, "Great post!");
        Console.WriteLine($"Comment added: {comment.Content}");

        // Opdater indholdet af indlægget
        await postService.UpdatePostContent(post.Id, "Updated content for the first post.");
        Console.WriteLine("Post content updated.");

        // Opdater brugernavn
        await userService.UpdateUsername(user.Id, "john_updated");
        Console.WriteLine("Username updated.");

        Console.WriteLine("Nået hertil...");        
        */



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
        //var blogService = new BlogService(blogRepository);
        var blogService = new BlogService(blogRepository, postRepository);
        //var postService = new PostService(postRepository);
        var postService = new PostService(postRepository, commentRepository);
        var commentService = new CommentService(commentRepository);



        // 1. Opret en ny bruger
        var user = await userService.CreateUser("john_doe", "john@example.com");
        Console.WriteLine($"User created: {user.Username}");

        // 2. Opret en ny blog og tilføj reference til bruger
        var blog = await blogService.CreateBlog(user.Id, "My First Blog", "This is my first blog description.");
        Console.WriteLine($"Blog created: {blog.Title}");
        user.Blogs.Add(blog.Id);
        await userService.UpdateUser(user);

        // 3. Opret et indlæg og tilføj reference til blog
        var post = await postService.CreatePost(user.Id, blog.Id, "First Post", "This is the content of the first post.");
        Console.WriteLine($"Post created: {post.Title}");
        blog.Posts.Add(post.Id);
        await blogService.UpdateBlog(blog);

        // 4. Opret en kommentar og tilføj reference til post
        var comment = await commentService.AddComment(user.Id, blog.Id, post.Id, "Great post!");
        Console.WriteLine($"Comment added: {comment.Content}");
        post.Comments.Add(comment.Id);
        await postService.UpdatePost(post);




        // 5. Hent alle posts for en blog
        var postsForBlog = await blogService.GetPostsByBlogId(blog.Id);
        Console.WriteLine($"Posts for Blog '{blog.Title}':");
        foreach (var p in postsForBlog) Console.WriteLine($" - {p.Title}");

        // 6. Hent alle kommentarer for et post
        var commentsForPost = await postService.GetCommentsByPostId(post.Id);
        Console.WriteLine($"Comments for Post '{post.Title}':");
        foreach (var c in commentsForPost) Console.WriteLine($" - {c.Content}");

        // 7. Opdater indholdet af et post
        await postService.UpdatePostContent(post.Id, "Updated content for the first post.");
        Console.WriteLine("Post content updated.");

        // 8. Opdater brugernavn og opdater referencer i posts og comments
        string newUsername = "john_updated";
        await userService.UpdateUsername(user.Id, newUsername);
        await postService.UpdateUsernameInPosts(user.Id, newUsername);
        await commentService.UpdateUsernameInComments(user.Id, newUsername);
        Console.WriteLine("Username updated across user, posts, and comments.");

        Console.WriteLine("Nået hertil...");



    }
}
