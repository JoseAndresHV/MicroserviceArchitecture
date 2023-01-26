using MicroserviceArchitecture.Notification.Models;

namespace MicroserviceArchitecture.Notification.Services
{
    public interface IMailService
    {
        SendMail Add(SendMail sendMail);
    }
}
