using MongoDB.Driver;

namespace UnrealDB.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoDbContext()
        {
            var client = new MongoClient("mongodb+srv://Admin:Administrator@unrealdb.n9bru.mongodb.net/UnrealDB?retryWrites=true&w=majority");
            _mongoDb = client.GetDatabase("UnrealDB");
        }
        public IMongoCollection<Enemy> Enemy
        {
            get
            {
                return _mongoDb.GetCollection<Enemy>("Enemy_Template");
            }
        }
    }
}