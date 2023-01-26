using MicroserviceArchitecture.Notification.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Notification.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<SendMail> SendMail { get; set; }
    }
}
