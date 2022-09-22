using Bank.Client.Services;
using Bank.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Bank.Client.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAccountService _accountSvc;
        private readonly IBankService _bankSvc;

        public AdminController(IAccountService accountSvc, IBankService bankSvc)
        {
            _accountSvc = accountSvc;
            _bankSvc = bankSvc;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> CreateAccountType()
        {
            if (HttpContext.Session.GetString("is_admin") == null)
                return StatusCode(403);

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateAccountType(AccountTypeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("AccountType creation failed!");
                }

                if (HttpContext.Session.GetString("is_admin") == null)
                    return StatusCode(403);

                var a = await _accountSvc.CreateAccountType(model);

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> CreateAccount()
        {
            if (HttpContext.Session.GetString("is_admin") == null)
                return StatusCode(403);

            HttpClient client = new();

            var b = await client.GetAsync("https://localhost:7242/api/Account/get-all-account-types");


            var jsonReturn = await b.Content.ReadAsStringAsync();
            var test = JsonConvert.DeserializeObject<List<AccountTypeResponseModel>>(jsonReturn);
            ViewBag.AccountTypes = test;

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountDispositionModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("is_admin") == null)
                    return StatusCode(403);

                if (ModelState.IsValid)
                {
                    var a = await _accountSvc.CreateAccount(model);

                    return View();
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                           .Where(y => y.Count > 0)
                                           .ToList();

                    throw new Exception("Account creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Add Loan
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> CreateLoan()
        {
            if (HttpContext.Session.GetString("is_admin") == null)
                return StatusCode(403);

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateLoan(LoanModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("is_admin") == null)
                    return StatusCode(403);

                if (ModelState.IsValid)
                {
                    var a = await _bankSvc.CreateLoan(model);

                    return View();
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                           .Where(y => y.Count > 0)
                                           .ToList();

                    throw new Exception("Loan creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
