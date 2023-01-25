using MicroserviceArchitecture.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Security.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Access> Access { get; set; }
    }
}
