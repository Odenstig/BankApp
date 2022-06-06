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
        List<AccountType> GetAll();
        AccountType Create(AccountType accountType);
    }
}
