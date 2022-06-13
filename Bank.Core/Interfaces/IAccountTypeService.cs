using Bank.Domain.DTOs;

namespace Bank.Core.Interfaces
{
    public interface IAccountTypeService
    {
        Task<AccountTypeDTO> Create(AccountTypeDTO accountType);
        Task<AccountTypeDTO> Get(int id);
        Task<List<AccountTypeDTO>> GetAll();
    }
}
