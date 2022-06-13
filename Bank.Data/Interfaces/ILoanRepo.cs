using Bank.Domain.Models;

namespace Bank.Data.Interfaces
{
    public interface ILoanRepo
    {
        Task<Loan> Create(Loan loan);
        Task<Loan> Update(Loan loan);
        Task<Loan> Get(int id);
        Task<List<Loan>> GetAllSpecific(int id);
        Task<bool> Delete(Loan loan);

    }
}
