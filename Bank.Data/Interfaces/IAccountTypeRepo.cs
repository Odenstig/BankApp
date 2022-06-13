using Bank.Domain.Models;

namespace Bank.Data.Interfaces
{
    public interface IAccountTypeRepo
    {
        Task<List<AccountType>> GetAll();
        Task<AccountType> Get(int id);
        Task<AccountType> Create(AccountType accountType);
        Task<AccountType> Update(AccountType accountType);
        Task<bool> Delete(AccountType accountType);
    }
}
