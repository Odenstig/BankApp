using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Models;

namespace Bank.Data.Interfaces
{
    public interface IAccountRepo
    {
        Task<Account> Create(Account account);
        Task<Account> Get(int id);
        Task<Account> Update(Account account);
        Task<bool> Delete(Account account);  
    }
}
