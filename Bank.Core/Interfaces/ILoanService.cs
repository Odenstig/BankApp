using Bank.Domain.DTOs;

namespace Bank.Core.Interfaces
{
    public interface ILoanService
    {
        Task<LoanDTO> Create(LoanDTO loanDTO);
        Task<LoanDTO> Get(int id);
    }
}
