using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repos
{
    public class CardRepo : ICardRepo
    {
        private readonly BankAppDataContext _db;

        public CardRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Card> Create(Card card)
        {
            
            await _db.Cards.AddAsync(card);
            await _db.SaveChangesAsync();

            return card;
        }

        public async Task<bool> Delete(Card card)
        {
            
            _db.Cards.Remove(card);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Card> Get(int id)
        {
            var card = await _db.Cards.FindAsync(id);

            return card;
        }

        public async Task<List<Card>> GetAllSpecific(int id)
        {
            var list = await _db.Cards
                    .Where(c => c.DispositionId == id)
                    .ToListAsync();

            return list;
        }

        public async Task<Card> Update(Card card)
        {
            _db.Cards.Update(card);
            await _db.SaveChangesAsync();

            return card;
        }
    }
}
