using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;

namespace Bank.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly BankAppDataContext _db;

        public CustomerRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> Delete(Customer customer)
        {

            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();

            return true;

        }

        public async Task<Customer> Get(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task<Customer> Update(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();

            return customer;
        }
    }
}
