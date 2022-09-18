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
        private readonly IAccountRepo _accRepo;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepo repo, IMapper mapper, IAccountRepo accRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _accRepo = accRepo;
        }

        public async Task<string> Create(TransactionDTO transactionDTO)
        {
            try
            {
                var sender = await _accRepo.Get(transactionDTO.AccountId);
                var receiver = await _accRepo.Get(transactionDTO.RecieverAccountId);

                TransactionDTO senderTransaction = new()
                {
                    AccountId = transactionDTO.AccountId,
                    Amount = transactionDTO.Amount * -1,
                    Balance = sender.Balance - transactionDTO.Amount,
                        Bank = "NB",
                        Date = DateTime.Now,
                        Operation = "Transfer",
                        Symbol = null,
                        Type = "Debit",
                    Account = receiver.AccountId.ToString(),
                };

                TransactionDTO receiverTransaction = new()
                {
                    AccountId = transactionDTO.RecieverAccountId,
                    Amount = transactionDTO.Amount,
                    Balance = receiver.Balance + transactionDTO.Amount,
                    Bank = "NB",
                    Date = DateTime.Now,
                    Operation = "Transfer",
                    Symbol = transactionDTO.Symbol,
                    Type = "Credit",
                    Account = sender.AccountId.ToString(),
                };

                var mappedSender = _mapper.Map<TransactionDTO, Transaction>(senderTransaction);
                var mappedReceiver = _mapper.Map<TransactionDTO, Transaction>(receiverTransaction);

                await _repo.Create(mappedSender);
                await _repo.Create(mappedReceiver);

                sender.Balance -= transactionDTO.Amount;
                receiver.Balance += transactionDTO.Amount;

                await _accRepo.Update(sender);
                await _accRepo.Update(receiver);


                return "Transaction Successful";
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
