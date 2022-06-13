using Bank.Domain.DTOs;

namespace Bank.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> Get(int id);
        Task<CustomerDTO> Create(CustomerDTO customer);
        Task<CustomerDTO> Update(CustomerDTO customer);
        Task<bool> Delete(CustomerDTO customer);
    }
}
