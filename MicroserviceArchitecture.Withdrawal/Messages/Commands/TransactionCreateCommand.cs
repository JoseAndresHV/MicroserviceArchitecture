using Aforo255.Cross.Event.Src.Commands;

namespace MicroserviceArchitecture.Withdrawal.Messages.Commands
{
    public class TransactionCreateCommand : Command
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string CreationDate { get; set; } = null!;
        public int AccountId { get; set; }

        public TransactionCreateCommand(int idTransaction, decimal amount,
            string type, string creationDate, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }
    }
}
