using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformV2.Core.Entities
{
    public class Blog
    {
        // Definer Blog

        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; } // Referencer til ejer
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ObjectId> Posts { get; set; } = new List<ObjectId>(); // Referencer til posts
    }
}
