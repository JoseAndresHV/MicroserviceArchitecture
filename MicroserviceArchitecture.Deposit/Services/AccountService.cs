using Aforo255.Cross.Http.Src;
using MicroserviceArchitecture.Deposit.DTOs;
using MicroserviceArchitecture.Deposit.Models;
using Polly;
using Polly.CircuitBreaker;

namespace MicroserviceArchitecture.Deposit.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly ITransactionService _transactionService;
        private readonly IHttpClient _http;

        public AccountService(IConfiguration configuration,
            ITransactionService transactionService,
            IHttpClient http)
        {
            _configuration = configuration;
            _transactionService = transactionService;
            _http = http;
        }

        public async Task<bool> DepositAccount(AccountRequest request)
        {
            string? uri = _configuration["proxy:urlAccountDeposit"];
            var response = await _http.PostAsync(uri!, request);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public bool DepositReverse(Transaction request)
        {
            _transactionService.DepositReverse(request);

            return true;
        }

        public bool Execute(Transaction request)
        {
            bool response = false;

            var policy = Policy.Handle<Exception>()
               .CircuitBreaker(3, TimeSpan.FromSeconds(15));

            var retry = Policy.Handle<Exception>()
                .WaitAndRetryForever(attempt => TimeSpan.FromSeconds(15))
                .Wrap(policy);

            retry.Execute(() =>
            {
                if (policy.CircuitState == CircuitState.Closed)
                {
                    var account = new AccountRequest
                    {
                        Amount = request.Amount,
                        IdAccount = request.AccountId
                    };

                    response = DepositAccount(account).Result;
                }
                else
                {
                    DepositReverse(new Transaction
                    {
                        AccountId = request.AccountId,
                        Amount = request.Amount,
                        CreationDate = DateTime.Now.ToShortDateString(),
                        Type = "Deposit Reverse"
                    });

                    response = false;
                }
            });

            return response;
        }
    }
}
