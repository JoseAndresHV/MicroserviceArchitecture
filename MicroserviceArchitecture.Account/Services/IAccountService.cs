namespace MicroserviceArchitecture.Account.Services
{
    public interface IAccountService
    {
        IEnumerable<Models.Account> GetAll();
        bool Deposit(Models.Account account);
        bool Withdrawal(Models.Account account);
    }
}
