using Bank.Domain.Models;

namespace Bank.Data.Interfaces
{
    public interface IDispositionRepo
    {
        Task<Disposition> Get(int id);
        Task<List<Disposition>> GetAll();
        Task<List<Disposition>> GetAllSpecific(int id);
        Task<Disposition> Create(Disposition disposition);
        Task<Disposition> Update(Disposition disposition);
        Task<bool> Delete(Disposition disposition);

    }
}
