using MicroserviceArchitecture.Withdrawal.Models;

namespace MicroserviceArchitecture.Withdrawal.Services
{
    public interface ITransactionService
    {
        Transaction Withdrawal(Transaction transaction);
        Transaction WithdrawalReverse(Transaction transaction);
    }
}
