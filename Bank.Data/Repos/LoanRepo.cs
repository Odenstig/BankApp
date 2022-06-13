using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data.Repos
{
    public class LoanRepo : ILoanRepo
    {
        private readonly BankAppDataContext _db;

        public LoanRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Loan> Create(Loan loan)
        {

            await _db.Loans.AddAsync(loan);
            await _db.SaveChangesAsync();

            return loan;
        }

        public async Task<bool> Delete(Loan loan)
        {

            _db.Loans.Remove(loan);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Loan> Get(int id)
        {
            return await _db.Loans.FindAsync(id);
        }

        public Task<List<Loan>> GetAllSpecific(int id)
        {
            var list = _db.Loans
                    .Where(l => l.AccountId == id)
                    .ToListAsync();

            return list;
        }

        public async Task<Loan> Update(Loan loan)
        {

            _db.Update(loan);
            await _db.SaveChangesAsync();

            return loan;
        }
    }
}
