using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly BankAppDataContext _db;

        public TransactionRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<bool> Delete(Transaction transaction)
        {
            
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Transaction> Get(int id)
        {
            return await _db.Transactions.FindAsync(id);
        }

        public async Task<List<Transaction>> GetAllSpecific(int id)
        {
            var list = await _db.Transactions
                    .Where(a => a.AccountId == id)
                    .ToListAsync();

            return list;
        }

        public async Task<Transaction> Update(Transaction transaction)
        {
            
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync();

            return transaction;
        }
    }
}
