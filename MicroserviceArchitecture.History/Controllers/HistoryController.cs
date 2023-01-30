using MicroserviceArchitecture.History.DTOs;
using MicroserviceArchitecture.History.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MicroserviceArchitecture.History.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        private readonly IDistributedCache _cache;

        public HistoryController(IHistoryService historyService, IDistributedCache cache)
        {
            _historyService = historyService;
            _cache = cache;
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult> Get(int accountId)
        {
            //var result = await _historyService.GetAll();
            //return Ok(result.Where(x => x.AccountId == accountId).ToList());

            var key = $"historydata-{accountId}";
            var data = _cache.GetString(key);
            IEnumerable<HistoryResponse> histories;

            if (data == null)
            {
                var result = await _historyService.GetAll();
                histories = result.Where(x => x.AccountId == accountId).ToList();

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                _cache.SetString(key, JsonConvert.SerializeObject(histories), options);
            }
            else
            {
                histories = JsonConvert.DeserializeObject<List<HistoryResponse>>(data)
                    ?? new List<HistoryResponse>();
            }

            return Ok(histories);
        }
    }
}
