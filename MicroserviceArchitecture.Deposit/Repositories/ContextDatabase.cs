using MicroserviceArchitecture.Deposit.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Deposit.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
    }
}
