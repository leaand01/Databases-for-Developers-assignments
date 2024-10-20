﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformV2.Core.Entities
{
    public class Post
    {
        //Definer Post

        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; } // Reference til post ejer
        public ObjectId BlogId { get; set; } // Referencer til blog
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ObjectId> Comments { get; set; } = new List<ObjectId>(); // Referencer til kommentarer


        public string PostAuthor { get; set; } // post ejerens brugernavn
    }
}
