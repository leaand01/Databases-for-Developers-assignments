using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformV2.Core.Entities
{
    public class Post
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; } // Referencer til ejer
        public ObjectId BlogId { get; set; } // Referencer til blog
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ObjectId> Comments { get; set; } = new List<ObjectId>(); // Referencer til kommentarer


        // Tilføjet felt til at gemme brugernavnet
        public string AuthorUsername { get; set; } // Brugernavn tilknyttet til post
    }
}
