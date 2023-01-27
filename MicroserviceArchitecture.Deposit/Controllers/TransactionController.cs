﻿using Aforo255.Cross.Event.Src.Bus;
using MicroserviceArchitecture.Deposit.DTOs;
using MicroserviceArchitecture.Deposit.Messages.Commands;
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
        private readonly IAccountService _accountService;
        private readonly IEventBus _bus;

        public TransactionController(
            ITransactionService transactionService,
            IAccountService accountService,
            IEventBus bus)
        {
            _transactionService = transactionService;
            _accountService = accountService;
            _bus = bus;
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

            if (_accountService.Execute(transaction))
            {
                _bus.SendCommand(new TransactionCreateCommand(
                    idTransaction: transaction.Id,
                    amount: transaction.Amount,
                    type: transaction.Type,
                    creationDate: transaction.CreationDate,
                    accountId: transaction.AccountId
                ));

                _bus.SendCommand(new NotificationCreateCommand(
                    idTransaction: transaction.Id,
                    amount: transaction.Amount,
                    type: transaction.Type,
                    messageBody: $"Transaction alert: ${transaction.Amount} {transaction.Type} made to/from your account",
                    address: "alert@bank.com",
                    accountId: transaction.AccountId
                ));
            }

            return Ok(transaction);
        }

        public IActionResult get()
        {
            return Ok(_transactionService.All());
        }
    }
}
