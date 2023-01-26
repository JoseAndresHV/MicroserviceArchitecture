using MicroserviceArchitecture.History.DTOs;
using MicroserviceArchitecture.History.Models;
using MicroserviceArchitecture.History.Repositories;
using MongoDB.Driver;

namespace MicroserviceArchitecture.History.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IMongoDBContext _context;
        private IMongoCollection<HistoryTransaction> _dbCollection;

        public HistoryService(IMongoDBContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<HistoryTransaction>(nameof(HistoryTransaction));
        }

        public async Task<bool> Add(HistoryTransaction historyTransaction)
        {
            await _dbCollection.InsertOneAsync(historyTransaction);
            return true;
        }

        public async Task<IEnumerable<HistoryResponse>> GetAll()
        {
            var collection = await _dbCollection.Find(_ => true).ToListAsync();
            var response = new List<HistoryResponse>();

            collection.ForEach(item =>
            {
                response.Add(new HistoryResponse
                {
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    CreationDate = item.CreationDate,
                    IdTransaction = item.IdTransaction,
                    Type = item.Type,
                });
            });

            return response;
        }
    }
}
