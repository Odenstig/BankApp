using Bank.Domain.Models;

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
