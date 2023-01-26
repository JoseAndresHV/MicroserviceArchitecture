using MicroserviceArchitecture.History.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.History.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult> Get(int accountId)
        {
            var result = await _historyService.GetAll();

            return Ok(result.Where(x => x.AccountId == accountId).ToList());
        }
    }
}
