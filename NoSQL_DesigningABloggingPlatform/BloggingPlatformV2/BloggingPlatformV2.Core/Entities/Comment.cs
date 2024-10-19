using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformV2.Core.Entities
{
    public class Comment
    {
        // Definer Comment

        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; } // Referencer til ejer
        public ObjectId BlogId { get; set; } // Referencer til blog
        public ObjectId PostId { get; set; } // Referencer til post
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Tidsstempel

        // tilføjet - username på bruger der tilføjer kommentar
        public string Username { get; set; }
    }
}
