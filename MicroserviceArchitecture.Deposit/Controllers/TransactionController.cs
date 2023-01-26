using MicroserviceArchitecture.Deposit.DTOs;
using MicroserviceArchitecture.Deposit.Models;
using MicroserviceArchitecture.Deposit.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            var transaction = new Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Deposit"
            };
            transaction = _transactionService.Deposit(transaction);

            return Ok(transaction);
        }

        public IActionResult get()
        {
            return Ok(_transactionService.All());
        }
    }
}
