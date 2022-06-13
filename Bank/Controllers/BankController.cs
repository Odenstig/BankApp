using Bank.Core.Interfaces;
using Bank.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ITransactionService _transactionSvc;
        private readonly ILoanService _loanSvc;

        public BankController(ITransactionService transactionSvc, ILoanService loanSvc)
        {
            _transactionSvc = transactionSvc;
            _loanSvc = loanSvc;
        }

        [HttpPost]
        [Route("create-transaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDTO model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Failed to create transaction");


                TransactionDTO transaction = await _transactionSvc.Create(model);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-transaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get transaction");

                TransactionDTO transaction = await _transactionSvc.Get(id);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-transactions/{id}")]
        public async Task<IActionResult> GetTransactions(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get transactions");

                List<TransactionDTO> list = await _transactionSvc.GetAllSpecific(id);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-loan")]
        public async Task<IActionResult> CreateLoan([FromBody] LoanDTO model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Failed to create loan");


                LoanDTO loan = await _loanSvc.Create(model);

                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-loan/{id}")]
        public async Task<IActionResult> GetLoan(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get loan");

                LoanDTO loan = await _loanSvc.Get(id);

                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
