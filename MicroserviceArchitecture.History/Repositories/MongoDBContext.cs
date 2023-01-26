using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroserviceArchitecture.History.Repositories
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _client { get; set; }

        public IClientSessionHandle? Session { get; set; }

        public MongoDBContext(IOptions<MongoSettings> configuration)
        {
            _client = new MongoClient(configuration.Value.Connection);
            _db = _client.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
