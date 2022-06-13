using AutoMapper;
using Bank.Core.Interfaces;
using Bank.Data.Interfaces;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Core.Services
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepo _repo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AccountDTO> Create(AccountDTO accountDTO)
        {
            try
            {
                AccountDTO acc = new()
                {
                    AccountTypesId = accountDTO.AccountTypesId,
                    Created = accountDTO.Created,
                    Balance = accountDTO.Balance,
                    Frequency = accountDTO.Frequency
                };

                var mapped = _mapper.Map<AccountDTO, Account>(acc);
                var save = await _repo.Create(mapped);

                var map = _mapper.Map<AccountDTO>(save);

                return map;

            }
            catch
            {
                throw new Exception("Failed to create account");
            }
        }

        public async Task<bool> Delete(AccountDTO accountDTO)
        {
            try
            {
                var mapped = _mapper.Map<AccountDTO, Account>(accountDTO);
                await _repo.Delete(mapped);

                return true;
            }
            catch
            {
                throw new Exception("Failed to delete account");
            }
        }

        public async Task<AccountDTO> Get(int id)
        {
            try
            {
                var acc = await _repo.Get(id);

                return _mapper.Map<AccountDTO>(acc);
            }
            catch
            {
                throw new Exception("Failed to get account");
            }
        }

        public async Task<AccountDTO> Update(AccountDTO accountDTO, decimal money)
        {
            try
            {
                accountDTO.Balance += money;

                var mapped = _mapper.Map<AccountDTO, Account>(accountDTO);

                var res = await _repo.Update(mapped);

                return _mapper.Map<AccountDTO>(res);
            }
            catch
            {
                throw new Exception("Failed to update account");
            }

        }
    }
}
