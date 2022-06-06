using Bank.Domain.DTOs;
using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> Get(int id);
        Task<CustomerDTO> Create(CustomerDTO customer);
        Task<CustomerDTO> Update(CustomerDTO customer);
        Task<bool> Delete(CustomerDTO customer);
    }
}
