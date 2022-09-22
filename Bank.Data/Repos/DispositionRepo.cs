using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data.Repos
{
    public class DispositionRepo : IDispositionRepo
    {
        private readonly BankAppDataContext _db;

        public DispositionRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Disposition> Create(Disposition disposition)
        {

            await _db.Dispositions.AddAsync(disposition);
            await _db.SaveChangesAsync();

            return disposition;
        }

        public async Task<bool> Delete(Disposition disposition)
        {

            _db.Dispositions.Remove(disposition);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Disposition> Get(int id)
        {
            return await _db.Dispositions.FindAsync(id);
        }

        public async Task<List<Disposition>> GetAll()
        {
            List<Disposition> list = await _db.Dispositions.ToListAsync();

            return list;
        }

        public async Task<List<Disposition>> GetAllSpecific(int id)
        {
            var list = await _db.Dispositions
                    .Where(d => d.CustomerId == id)
                    .ToListAsync();

            return list;
        }

        public async Task<Disposition> Update(Disposition disposition)
        {

            _db.Dispositions.Update(disposition);
            await _db.SaveChangesAsync();

            return disposition;
        }
    }
}
