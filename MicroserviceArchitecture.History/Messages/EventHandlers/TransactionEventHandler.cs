using Aforo255.Cross.Event.Src.Bus;
using MicroserviceArchitecture.History.Messages.Events;
using MicroserviceArchitecture.History.Models;
using MicroserviceArchitecture.History.Services;

namespace MicroserviceArchitecture.History.Messages.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly IHistoryService _historyService;

        public TransactionEventHandler(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public Task Handle(TransactionCreatedEvent @event)
        {
            _historyService.Add(new HistoryTransaction
            {
                IdTransaction = @event.IdTransaction,
                Amount = @event.Amount,
                Type = @event.Type,
                CreationDate = @event.CreationDate,
                AccountId = @event.AccountId,
            });

            return Task.CompletedTask;
        }
    }
}
