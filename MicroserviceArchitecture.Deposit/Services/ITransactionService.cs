using MicroserviceArchitecture.Deposit.Models;

namespace MicroserviceArchitecture.Deposit.Services
{
    public interface ITransactionService
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);

        List<Transaction> All();
    }
}
