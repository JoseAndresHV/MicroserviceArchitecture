using Aforo255.Cross.Event.Src.Bus;
using MicroserviceArchitecture.Notification.Messages.Events;
using MicroserviceArchitecture.Notification.Models;
using MicroserviceArchitecture.Notification.Services;

namespace MicroserviceArchitecture.Notification.Messages.EventHandlers
{
    public class NotificationEventHandler : IEventHandler<NotificationCreatedEvent>
    {
        private readonly IMailService _mailService;

        public NotificationEventHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public Task Handle(NotificationCreatedEvent @event)
        {
            _mailService.Add(new SendMail
            {
                SendDate = DateTime.Now.ToShortDateString(),
                Type = @event.Type,
                Message = @event.MessageBody,
                Address = @event.Address,
                AccountId = @event.AccountId,
            });

            return Task.CompletedTask;
        }
    }
}
