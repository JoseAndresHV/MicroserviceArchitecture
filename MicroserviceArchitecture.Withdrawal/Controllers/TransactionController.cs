using MicroserviceArchitecture.Withdrawal.DTOs;
using MicroserviceArchitecture.Withdrawal.Models;
using MicroserviceArchitecture.Withdrawal.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Withdrawal.Controllers
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

        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] TransactionRequest request)
        {
            var transaction = new Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Withdrawal"
            };
            transaction = _transactionService.Withdrawal(transaction);

            return Ok(transaction);
        }
    }
}
