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

        public Disposition Create(Disposition disposition)
        {
            
            _db.Dispositions.Add(disposition);
            _db.SaveChanges();

            return disposition;
            
        }

        public bool Delete(Disposition disposition)
        {
            try
            {
                _db.Dispositions.Remove(disposition);
                _db.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public Disposition Get(int id)
        {
            return _db.Dispositions.SingleOrDefault(c => c.DispositionId == id);
        }

        public Disposition Update(Disposition disposition)
        {
            try
            {
                _db.Dispositions.Update(disposition);
                _db.SaveChanges();

                return disposition;
            }
            catch { return null; }
        }
    }
}
