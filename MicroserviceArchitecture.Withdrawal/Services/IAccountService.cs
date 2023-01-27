using MicroserviceArchitecture.Withdrawal.DTOs;
using MicroserviceArchitecture.Withdrawal.Models;

namespace MicroserviceArchitecture.Withdrawal.Services
{
    public interface IAccountService
    {
        Task<bool> WithdrawalAccount(AccountRequest request);
        bool WithdrawalReverse(Transaction request);
        bool Execute(Transaction request);
    }
}
