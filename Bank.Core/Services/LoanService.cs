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
        private readonly IMapper _mapper;

        public LoanService(ILoanRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<LoanDTO> Create(LoanDTO loanDTO)
        {
            try
            {
                LoanDTO loan = new()
                {
                    AccountId = loanDTO.AccountId,
                    Amount = loanDTO.Amount,
                    Date = loanDTO.Date,
                    Duration = loanDTO.Duration,
                    Payments = loanDTO.Payments,
                    Status = loanDTO.Status,
                };

                var mapped = _mapper.Map<LoanDTO, Loan>(loan);
                var save = await _repo.Create(mapped);

                var map = _mapper.Map<LoanDTO>(save);

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
