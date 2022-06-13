using Bank.Domain.Models;

namespace Bank.Data.Interfaces
{
    public interface ICustomerRepo
    {
        Task<Customer> Get(int id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<bool> Delete(Customer customer);
    }
}
