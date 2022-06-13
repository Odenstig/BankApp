using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;

namespace Bank.Data.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly BankAppDataContext _db;

        public AccountRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Account> Create(Account account)
        {
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();

            return account;
        }

        public async Task<bool> Delete(Account account)
        {
            _db.Accounts.Remove(account);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Account> Get(int id)
        {
            var acc = await _db.Accounts.FindAsync(id);
            return acc;
        }

        public async Task<Account> Update(Account account)
        {
            _db.Accounts.Update(account);
            _db.SaveChangesAsync();

            return account;
        }
    }
}
