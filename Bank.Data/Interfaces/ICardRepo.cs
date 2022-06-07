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
        Task<Card> Get(int id);
        Task<List<Card>> GetAllSpecific(int id);
        Task<Card> Create(Card card);
        Task<Card> Update(Card card);
        Task<bool> Delete(Card card);
    }
}
