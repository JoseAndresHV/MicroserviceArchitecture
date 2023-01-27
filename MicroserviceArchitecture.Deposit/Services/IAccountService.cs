using MicroserviceArchitecture.Deposit.DTOs;
using MicroserviceArchitecture.Deposit.Models;

namespace MicroserviceArchitecture.Deposit.Services
{
    public interface IAccountService
    {
        Task<bool> DepositAccount(AccountRequest request);
        bool DepositReverse(Transaction request);
        bool Execute(Transaction request);
    }
}
