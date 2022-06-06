using Bank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDTO> Create(AccountDTO accountDTO);
        Task<AccountDTO> Get(int id);
        Task<AccountDTO> Update(AccountDTO accountDTO);
        Task<bool> Delete(AccountDTO accountDTO);
    }
}
