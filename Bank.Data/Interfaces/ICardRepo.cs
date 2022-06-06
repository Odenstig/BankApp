using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface ICardRepo
    {
        Card Get(int id);
        Card Create(Card card);
        Card Update(Card card);
        bool Delete(Card card);
    }
}
