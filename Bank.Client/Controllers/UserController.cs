using Microsoft.AspNetCore.Mvc;
using Bank.Client.ViewModels;
using Bank.Client.Services;

namespace Bank.Client.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userSvc;
        private readonly IBankService _bankService;

        public UserController(IUserService userSvc, IBankService bankService)
        {
            _userSvc = userSvc;
            _bankService = bankService;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Customer creation failed!");
                }

                var a = await _userSvc.Create(model);

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> CreateTransaction()
        {

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    throw new Exception("Transaction failed!");
                }

                var a = await _bankService.CreateTransaction(model);

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
