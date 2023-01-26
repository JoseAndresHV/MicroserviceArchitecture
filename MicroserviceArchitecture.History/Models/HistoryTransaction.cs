using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceArchitecture.History.Models
{
    public class HistoryTransaction
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string CreationDate { get; set; } = null!;
        public int AccountId { get; set; }
    }
}
