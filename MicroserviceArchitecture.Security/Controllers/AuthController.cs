using Aforo255.Cross.Token.Src;
using MicroserviceArchitecture.Security.DTOs;
using MicroserviceArchitecture.Security.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MicroserviceArchitecture.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _accessService;
        private readonly JwtOptions _jwt;

        public AuthController(IAccessService accessService, IOptionsSnapshot<JwtOptions> jwt)
        {
            _accessService = accessService;
            _jwt = jwt.Value;
        }

        public IActionResult Get()
        {
            return Ok(_accessService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            if (!_accessService.Validate(request.Username, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwt));

            return Ok();
        }
    }
}
