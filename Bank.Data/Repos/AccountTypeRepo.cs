using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repos
{
    public class AccountTypeRepo : IAccountTypeRepo
    {
        private readonly BankAppDataContext _db;

        public AccountTypeRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public AccountType Create(AccountType accountType)
        {
            try
            {
                _db.AccountTypes.Add(accountType);
                _db.SaveChanges();

                return accountType;
            }
            catch 
            {
                return null;
            }
        }

        public List<AccountType> GetAll()
        {
            List<AccountType> list = new();

            foreach(AccountType item in _db.AccountTypes)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
