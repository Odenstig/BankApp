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
        Disposition Get(int id);
        Disposition Create(Disposition disposition);
        Disposition Update(Disposition disposition);
        bool Delete(Disposition disposition);

    }
}
