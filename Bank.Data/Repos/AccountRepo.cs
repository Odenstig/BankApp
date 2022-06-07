﻿using Bank.Data.Interfaces;
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
    public class AccountRepo : IAccountRepo
    {
        private readonly BankAppDataContext _db;

        public AccountRepo(BankAppDataContext db)
        {
            _db = db;
        }

        public async Task<Account> Create(Account account)
        {
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();

            return account;
        }

        public async Task<bool> Delete(Account account)
        {
            _db.Accounts.Remove(account);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Account> Get(int id)
        {
            var acc = await _db.Accounts.FindAsync(id);
            return acc;
        }

        public async Task<List<Account>> GetAllSpecific(int id)
        {
            var list = await _db.Accounts
                    .Where(a => a.AccountId == id)
                    .ToListAsync();

            return list;
        }

        public async Task<Account> Update(Account account)
        {
            _db.Accounts.Update(account);
            _db.SaveChangesAsync();

            return account;
        }
    }
}
