using AutoMapper;
using Bank.Core.Interfaces;
using Bank.Data.Interfaces;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _repo;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TransactionDTO> Create(TransactionDTO transactionDTO)
        {
            try
            {
                TransactionDTO transaction = new()
                {
                    AccountId = transactionDTO.AccountId,
                    Amount = transactionDTO.Amount,
                    Balance = transactionDTO.Balance,
                    Bank = transactionDTO.Bank,
                    Date = transactionDTO.Date,
                    Operation = transactionDTO.Operation,
                    Symbol = transactionDTO.Symbol,
                    Type = transactionDTO.Type,
                    Account = transactionDTO.Account,
                };

                var mapped = _mapper.Map<TransactionDTO, Transaction>(transaction);
                var save = await _repo.Create(mapped);

                var map = _mapper.Map<TransactionDTO>(save);

                return map;
            }
            catch
            {
                throw new Exception("Failed to create transaction");
            }
        }

        public async Task<bool> Delete(TransactionDTO transactionDTO)
        {
            try
            {
                var mapped = _mapper.Map<TransactionDTO, Transaction>(transactionDTO);
                await _repo.Delete(mapped);

                return true;
            }
            catch
            {
                throw new Exception("Failed to delete transaction");
            }
        }

        public async Task<TransactionDTO> Get(int id)
        {
            try
            {
                var loan = await _repo.Get(id);

                return _mapper.Map<TransactionDTO>(loan);
            }
            catch
            {
                throw new Exception("Failed to get transaction");
            }
        }

        public async Task<List<TransactionDTO>> GetAllSpecific(int id)
        {
            try
            {
                var list = await _repo.GetAllSpecific(id);

                return _mapper.Map<List<TransactionDTO>>(list);
            }
            catch
            {
                throw new Exception("Failed to get transactions");
            }
        }

        public async Task<TransactionDTO> Update(TransactionDTO transactionDTO)
        {
            try
            {
                var acc = _mapper.Map<TransactionDTO, Transaction>(transactionDTO);

                var res = await _repo.Update(acc);

                return _mapper.Map<TransactionDTO>(res);
            }
            catch
            {
                throw new Exception("Failed to update transaction");
            }
        }
    }
}
