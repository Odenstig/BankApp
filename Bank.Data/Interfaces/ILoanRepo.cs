using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface ILoanRepo
    {
        Loan Create(Loan loan);
        Loan Update(Loan loan);
        Loan Get(int id);
        bool Delete(Loan loan);
        
    }
}
