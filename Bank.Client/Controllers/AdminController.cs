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

        public AdminController(IAccountService accountSvc)
        {
            _accountSvc = accountSvc;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountType(AccountTypeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("AccountType creation failed!");
                }

                var a = await _accountSvc.CreateAccountType(model);

                return View(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("create-account")]
        [HttpGet]
        public async Task<IActionResult> CreateAccount()
        {
            HttpClient client = new();

            var b = await client.GetAsync("https://localhost:7242/api/Account/get-all-account-types");


            var jsonReturn = await b.Content.ReadAsStringAsync();
            List<AccountTypeResponseModel> test = JsonConvert.DeserializeObject<List<AccountTypeResponseModel>>(jsonReturn);

            ViewBag.Accounts = new SelectList(test, "AccountTypesId", "TypeName");


            return View();
        }

        [Route("create-account")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountDispositionModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Account creation failed!");
                }

                var a = await _accountSvc.CreateAccount(model);

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
