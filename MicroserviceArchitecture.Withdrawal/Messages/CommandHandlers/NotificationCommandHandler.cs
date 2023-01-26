
using Aforo255.Cross.Event.Src.Bus;
using MediatR;
using MicroserviceArchitecture.Withdrawal.Messages.Commands;
using MicroserviceArchitecture.Withdrawal.Messages.Events;

namespace MicroserviceArchitecture.Withdrawal.Messages.CommandHandlers
{
    public class NotificationCommandHandler : IRequestHandler<NotificationCreateCommand, bool>
    {
        private readonly IEventBus _bus;
        public NotificationCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(NotificationCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new NotificationCreatedEvent(
                    request.IdTransaction,
                    request.Amount,
                    request.Type,
                    request.MessageBody,
                    request.Address,
                    request.AccountId
                ));

            return Task.FromResult(true);
        }
    }
}
