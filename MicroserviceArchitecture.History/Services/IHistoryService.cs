using MicroserviceArchitecture.History.DTOs;
using MicroserviceArchitecture.History.Models;

namespace MicroserviceArchitecture.History.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryResponse>> GetAll();
        Task<bool> Add(HistoryTransaction historyTransaction);
    }
}
