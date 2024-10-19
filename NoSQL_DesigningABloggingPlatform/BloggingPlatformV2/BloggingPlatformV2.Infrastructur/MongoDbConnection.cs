using MongoDB.Driver;

namespace BloggingPlatformV2.Infrastructur // Sørg for at namespace matcher
{
    public class MongoDbConnection
    {
        private readonly IMongoDatabase _database;

        public MongoDbConnection(MongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
