using Bank.Domain.DTOs;

namespace Bank.Core.Interfaces
{
    public interface IDispositionService
    {
        Task<DispositionDTO> Get(int id);
        Task<List<DispositionDTO>> GetAllSpecific(int id);
        Task<DispositionDTO> Create(DispositionDTO customer);
        Task<DispositionDTO> Update(DispositionDTO customer);
        Task<bool> Delete(DispositionDTO customer);
    }
}
