using MicroserviceArchitecture.Withdrawal.Models;
using MicroserviceArchitecture.Withdrawal.Repositories;

namespace MicroserviceArchitecture.Withdrawal.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ContextDatabase _context;

        public TransactionService(ContextDatabase context)
        {
            _context = context;
        }

        public Transaction Withdrawal(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public Transaction WithdrawalReverse(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }
    }
}
