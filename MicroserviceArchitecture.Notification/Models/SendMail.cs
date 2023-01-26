using System.ComponentModel.DataAnnotations;

namespace MicroserviceArchitecture.Notification.Models
{
    public class SendMail
    {
        [Key]
        public int SendMailId { get; set; }
        public string SendDate { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int AccountId { get; set; }
    }
}
