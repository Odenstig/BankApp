using Bank.Domain.Models;

namespace Bank.Data.Interfaces
{
    public interface ITransactionRepo
    {
        Task<Transaction> Create(Transaction transaction);
        Task<List<Transaction>> GetAllSpecific(int id);
        Task<Transaction> Get(int id);
        Task<bool> Delete(Transaction transaction);
        Task<Transaction> Update(Transaction transaction);
    }
}
