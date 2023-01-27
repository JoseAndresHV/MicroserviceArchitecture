using MicroserviceArchitecture.Deposit.Models;
using MicroserviceArchitecture.Deposit.Repositories;

namespace MicroserviceArchitecture.Deposit.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ContextDatabase _context;

        public TransactionService(ContextDatabase context)
        {
            _context = context;
        }

        public Transaction Deposit(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;

        }

        public Transaction DepositReverse(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }
    }
}
