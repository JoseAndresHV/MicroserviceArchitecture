using MicroserviceArchitecture.Account.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Account.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Models.Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
