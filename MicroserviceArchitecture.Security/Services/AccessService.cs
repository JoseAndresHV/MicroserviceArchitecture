using MicroserviceArchitecture.Security.Models;
using MicroserviceArchitecture.Security.Repositories;

namespace MicroserviceArchitecture.Security.Services
{
    public class AccessService : IAccessService
    {
        private readonly ContextDatabase _context;

        public AccessService(ContextDatabase context)
        {
            _context = context;
        }

        public IEnumerable<Access> GetAll()
        {
            return _context.Access.ToList();
        }

        public bool Validate(string username, string password)
        {
            return _context.Access.ToList().Find(x => x.Username == username && x.Password == password) != null;
        }
    }
}
