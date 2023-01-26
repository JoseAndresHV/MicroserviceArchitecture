using MongoDB.Driver;

namespace MicroserviceArchitecture.History.Repositories
{
    public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
