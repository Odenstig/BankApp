using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface IDispositionRepo
    {
        Task<Disposition> Get(int id);
        Task<Disposition> Create(Disposition disposition);
        Task<Disposition> Update(Disposition disposition);
        Task<bool> Delete(Disposition disposition);

    }
}
