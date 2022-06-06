using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Domain.Models;
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

        public Card Create(Card card)
        {
            try
            {
                _db.Cards.Add(card);
                _db.SaveChanges();

                return card;
            }
            catch { return null; }
        }

        public bool Delete(Card card)
        {
            try
            {
                _db.Cards.Remove(card);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Card Get(int id)
        {
            var disp = _db.Dispositions.SingleOrDefault(c => c.CustomerId == id);
            var card = _db.Cards.SingleOrDefault(c => c.DispositionId == disp.DispositionId);

            return card;
        }

        public Card Update(Card card)
        {
            _db.Cards.Update(card);
            _db.SaveChanges();

            return card;
        }
    }
}
