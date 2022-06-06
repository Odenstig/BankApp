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
    public class LoanRepo : ILoanRepo
    {
        private readonly BankAppDataContext _db;

        public LoanRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public Loan Create(Loan loan)
        {
            try
            {
                _db.Loans.Add(loan);
                _db.SaveChanges();

                return loan;
            }
            catch { return null; }
        }

        public bool Delete(Loan loan)
        {
            try
            {
                _db.Loans.Remove(loan);
                _db.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public Loan Get(int id)
        {
            return _db.Loans.SingleOrDefault(l => l.LoanId == id);
        }

        public Loan Update(Loan loan)
        {
            try
            {
                _db.Update(loan);
                _db.SaveChanges();

                return loan;
            }
            catch { return null; }
        }
    }
}
