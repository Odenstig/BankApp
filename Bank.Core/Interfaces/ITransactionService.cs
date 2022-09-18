using Bank.Domain.DTOs;

namespace Bank.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<string> Create(TransactionDTO transactionDTO);
        Task<List<TransactionDTO>> GetAllSpecific(int id);
        Task<TransactionDTO> Get(int id);
        Task<bool> Delete(TransactionDTO transactionDTO);
        Task<TransactionDTO> Update(TransactionDTO transactionDTO);
    }
}
