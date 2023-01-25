using MicroserviceArchitecture.Account.DTOs;
using MicroserviceArchitecture.Account.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accountService.GetAll());
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] AccountRequest request)
        {
            var account = _accountService.GetAll()
                .Where(x => x.IdAccount == request.IdAccount).FirstOrDefault();

            if (account is null)
            {
                return BadRequest();
            }

            account.TotalAmount += request.Amount;
            _accountService.Deposit(account);

            return Ok();
        }

        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] AccountRequest request)
        {
            var account = _accountService.GetAll()
                .Where(x => x.IdAccount == request.IdAccount).FirstOrDefault();

            if (account is null)
            {
                return BadRequest();
            }

            account.TotalAmount -= request.Amount;
            _accountService.Withdrawal(account);

            return Ok();
        }
    }
}
