using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Disposition> Update(Disposition disposition)
        {
            
            _db.Dispositions.Update(disposition);
            await _db.SaveChangesAsync();

            return disposition;
        }
    }
}
