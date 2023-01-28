using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Withdrawal.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok();
    }
}
