using Aforo255.Cross.Event.Src.Events;

namespace MicroserviceArchitecture.Deposit.Messages.Events
{
    public class NotificationCreatedEvent : Event
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string MessageBody { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int AccountId { get; set; }

        public NotificationCreatedEvent(int idTransaction, decimal amount,
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
