using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
