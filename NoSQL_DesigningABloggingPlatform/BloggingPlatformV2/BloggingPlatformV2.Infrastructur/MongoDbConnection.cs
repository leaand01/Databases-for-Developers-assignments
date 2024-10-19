using MongoDB.Driver;

namespace BloggingPlatformV2.Infrastructur
{
    public class MongoDbConnection
    {
        private readonly IMongoDatabase _database;

        public MongoDbConnection(MongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName); // returner reference til den angivne mongoDB-database
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
            // Returnerer en samling af den angivne dokumenttype fra MongoDB-databasen, f.eks. user dokumenter
        }
    }
}
