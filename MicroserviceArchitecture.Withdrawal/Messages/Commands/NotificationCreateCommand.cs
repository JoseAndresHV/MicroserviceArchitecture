using Aforo255.Cross.Event.Src.Commands;

namespace MicroserviceArchitecture.Withdrawal.Messages.Commands
{
    public class NotificationCreateCommand : Command
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string MessageBody { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int AccountId { get; set; }

        public NotificationCreateCommand(int idTransaction, decimal amount,
            string type, string messageBody, string address, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            MessageBody = messageBody;
            Address = address;
            AccountId = accountId;
        }
    }
}
