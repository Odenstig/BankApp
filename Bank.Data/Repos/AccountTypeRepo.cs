using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data.Repos
{
    public class AccountTypeRepo : IAccountTypeRepo
    {
        private readonly BankAppDataContext _db;

        public AccountTypeRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<AccountType> Create(AccountType accountType)
        {
            
            await _db.AccountTypes.AddAsync(accountType);
            await _db.SaveChangesAsync();

            return accountType;
        }

        public async Task<bool> Delete(AccountType accountType)
        {

            _db.AccountTypes.Remove(accountType);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<AccountType> Get(int id)
        {

            var accType = await _db.AccountTypes.FindAsync(id);

            return accType;
        }

        public async Task<List<AccountType>> GetAll()
        {

            var list = await _db.AccountTypes.ToListAsync();

            return list;
        }

        public async Task<AccountType> Update(AccountType accountType)
        {
            _db.Update(accountType);
            await _db.SaveChangesAsync();

            return accountType;
        }
    }
}
