using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface ITransactionRepo
    {
        Task<List<Transaction>> GetAllSpecific(int id);
        Task<Transaction> Get(int id);
        Task<bool> Delete(Transaction transaction);
        Task<Transaction> Update(Transaction transaction);
    }
}
