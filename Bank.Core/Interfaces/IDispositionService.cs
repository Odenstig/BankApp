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
        Task<DispositionDTO> Get(int id);
        Task<DispositionDTO> Create(DispositionDTO customer);
        Task<DispositionDTO> Update(DispositionDTO customer);
        Task<bool> Delete(DispositionDTO customer);
    }
}
