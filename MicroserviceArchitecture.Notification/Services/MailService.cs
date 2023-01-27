using MicroserviceArchitecture.Notification.Models;
using MicroserviceArchitecture.Notification.Repositories;

namespace MicroserviceArchitecture.Notification.Services
{
    public class MailService : IMailService
    {
        private readonly ContextDatabase _context;

        public MailService(ContextDatabase context)
        {
            _context = context;
        }
        public SendMail Add(SendMail sendMail)
        {
            _context.Add(sendMail);
            _context.SaveChanges();

            return sendMail;
        }
    }
}
