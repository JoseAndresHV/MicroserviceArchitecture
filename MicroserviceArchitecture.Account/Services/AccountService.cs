using MicroserviceArchitecture.Account.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceArchitecture.Account.Services
{
    public class AccountService : IAccountService
    {
        private readonly ContextDatabase _context;

        public AccountService(ContextDatabase context)
        {
            _context = context;
        }

        public bool Deposit(Models.Account account)
        {
            _context.Account.Update(account);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Models.Account> GetAll()
        {
            return _context.Account.Include(x => x.Customer)
                .AsNoTracking().ToList();
        }

        public bool Withdrawal(Models.Account account)
        {
            _context.Account.Update(account);
            _context.SaveChanges();
            return true;
        }
    }
}
