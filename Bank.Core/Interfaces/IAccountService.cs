using Bank.Domain.DTOs;

namespace Bank.Core.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDTO> Create(AccountDTO accountDTO);
        Task<AccountDTO> Get(int id);
        Task<AccountDTO> Update(AccountDTO accountDTO, decimal money);
        Task<bool> Delete(AccountDTO accountDTO);
    }
}
