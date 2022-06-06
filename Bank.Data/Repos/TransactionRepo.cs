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
    public class TransactionRepo : ITransactionRepo
    {
        private readonly BankAppDataContext _db;

        public TransactionRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public bool Delete(Transaction transaction)
        {
            try
            {
                _db.Transactions.Remove(transaction);
                _db.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public Transaction Get(int id)
        {
            return _db.Transactions.SingleOrDefault(t => t.TransactionId == id);
        }

        public List<Transaction> GetList(int id)
        {
            List<Transaction> list = new();

            var disp = _db.Dispositions.SingleOrDefault(d => d.CustomerId == id);
            var acc = _db.Accounts.SingleOrDefault(a => a.AccountId == disp.AccountId);

            foreach(var transaction in _db.Transactions.Where(t => t.AccountId == acc.AccountId))
            {
                list.Add(transaction);
            }

            return list;
        }

        public Transaction Update(Transaction transaction)
        {
            try
            {
                _db.Transactions.Update(transaction);
                _db.SaveChanges();

                return transaction;
            }
            catch { return null; }
        }
    }
}
