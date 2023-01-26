using MicroserviceArchitecture.Withdrawal.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Withdrawal.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
