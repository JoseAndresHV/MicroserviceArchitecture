using MicroserviceArchitecture.Security.Models;

namespace MicroserviceArchitecture.Security.Services
{
    public interface IAccessService
    {
        IEnumerable<Access> GetAll();
        bool Validate(string username, string password);
    }
}
