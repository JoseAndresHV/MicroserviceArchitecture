using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Deposit.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok();
    }
}
