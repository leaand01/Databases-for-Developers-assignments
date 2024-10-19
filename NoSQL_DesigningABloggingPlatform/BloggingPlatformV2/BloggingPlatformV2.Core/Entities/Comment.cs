using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformV2.Core.Entities
{
    public class Comment
    {
        // Definer Comment

        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; } // Reference til comment ejeren
        public ObjectId BlogId { get; set; } // Reference til blogid
        public ObjectId PostId { get; set; } // Reference til postid
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string PostAuthor { get; set; } // username på post ejeren/author
    }
}
