using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformV2.Core.Entities
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<ObjectId> Blogs { get; set; } = new List<ObjectId>(); // Referencer til blogs
    }
}
