using Bank.Core.Interfaces;
using Bank.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAccountService _accountSvc;
        private readonly IDispositionService _dispSvc;
        private readonly ICustomerService _customerSvc;

        public AdminController(IAccountService accountSvc, IDispositionService dispSvc, ICustomerService customerSvc)
        {
            _accountSvc = accountSvc;
            _dispSvc = dispSvc;
            _customerSvc = customerSvc;
        }

        [HttpPost]
        [Route("add-account")]
        public async Task<IActionResult> Register([FromBody] AccountDTO accountDTO)
        {
            AccountDTO acc = new()
            {
            };

            var result = await _accountSvc.Create(acc);

            return Ok();
        }
    }
}
