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
        List<Transaction> GetList(int id);
        Transaction Get(int id);
        bool Delete(Transaction transaction);
        Transaction Update(Transaction transaction);
    }
}
