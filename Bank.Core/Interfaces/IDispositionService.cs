using Bank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface IDispositionService
    {
        DispositionDTO Get(int id);
        DispositionDTO Create(DispositionDTO customer);
        DispositionDTO Update(DispositionDTO customer);
        bool Delete(DispositionDTO customer);
    }
}
