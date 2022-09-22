using AutoMapper;
using Bank.Core.Interfaces;
using Bank.Data.Interfaces;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Core.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepo _repo;
        private readonly IAccountRepo _accountRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepo repo, IMapper mapper, IAccountRepo accountRepo, ITransactionRepo transactionRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<LoanDTO> Create(LoanDTO loanDTO)
        {
            try
            {
                var account = await _accountRepo.Get(loanDTO.AccountId);

                LoanDTO loan = new()
                {
                    AccountId = loanDTO.AccountId,
                    Amount = loanDTO.Amount,
                    Date = DateTime.Now,
                    Duration = loanDTO.Duration,
                    Payments = 0,
                    Status = "Running",
                };

                var transaction = new TransactionDTO
                {
                    AccountId = loan.AccountId,
                    Date = loan.Date,
                    Type = "Credit",
                    Operation = "Credit in Cash",
                    Amount = loan.Amount,
                    Balance = account.Balance + loan.Amount,
                    Symbol = "loan",
                    Bank = "NB"
                };

                var mappedLoan = _mapper.Map<LoanDTO, Loan>(loan);
                var mappedTransaction = _mapper.Map<TransactionDTO, Transaction>(transaction);

                var saveLoan = await _repo.Create(mappedLoan);
                var saveTransaction = await _transactionRepo.Create(mappedTransaction); 

                account.Balance += loan.Amount;

                await _accountRepo.Update(account);

                var map = _mapper.Map<LoanDTO>(saveLoan);

                return map;
            }
            catch
            {
                throw new Exception("Failed to create loan");
            }
        }
        public async Task<LoanDTO> Get(int id)
        {
            try
            {
                var loan = await _repo.Get(id);

                return _mapper.Map<LoanDTO>(loan);
            }
            catch
            {
                throw new Exception("Failed to get loan");
            }
        }
    }
}
