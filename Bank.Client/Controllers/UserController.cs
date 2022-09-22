using Microsoft.AspNetCore.Mvc;
using Bank.Client.ViewModels;
using Bank.Client.Services;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

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
            if (HttpContext.Session.GetString("is_admin") == null)
                return StatusCode(403);

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("is_admin") == null)
                    return StatusCode(403);

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
            if (HttpContext.Session.GetString("is_user") == null)
                return StatusCode(403);

            var token = HttpContext.Session.GetString("token");
            var a = HttpContext.Session.GetString("user");

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            
            var b = await client.GetAsync($"https://localhost:7242/api/Account/get-dispositions/{a}");

            var jsonReturn = await b.Content.ReadAsStringAsync();
            var test = JsonConvert.DeserializeObject<List<DispositionModel>>(jsonReturn);

            ViewBag.UAccounts = test;

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("is_user") == null)
                    return StatusCode(403);

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

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Accounts()
        {
            try
            {
                if (HttpContext.Session.GetString("is_user") == null)
                    return StatusCode(403);

                var a = HttpContext.Session.GetString("user");
                var token = HttpContext.Session.GetString("token");
                if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(token))
                    return BadRequest();

                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var b = await client.GetAsync($"https://localhost:7242/api/Account/get-dispositions/{a}");

                var jsonReturn = await b.Content.ReadAsStringAsync();
                var test = JsonConvert.DeserializeObject<List<DispositionModel>>(jsonReturn);

                List<AccountModel> accounts = new();

                foreach (var item in test)
                {
                    var acc = await client.GetAsync($"https://localhost:7242/api/Account/get-account/{item.AccountId}");
                    var jsonRetAcc = await acc.Content.ReadAsStringAsync();
                    AccountModel desAcc = JsonConvert.DeserializeObject<AccountModel>(jsonRetAcc);

                    accounts.Add(desAcc);

                }

                var types = await client.GetAsync("https://localhost:7242/api/Account/get-all-account-types");
                var jsonReturnTypes = await types.Content.ReadAsStringAsync();
                var DesTypes = JsonConvert.DeserializeObject<List<AccountTypeResponseModel>>(jsonReturnTypes);

                ViewBag.AccountTypes = DesTypes;

                ViewBag.Accounts = accounts;

                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> AccountDetails(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("is_user") == null)
                    return StatusCode(403);

                var token = HttpContext.Session.GetString("token");

                HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var b = await client.GetAsync($"https://localhost:7242/api/Bank/get-transactions/{id}");
                var jsonRet = await b.Content.ReadAsStringAsync();
                var desTransactions = JsonConvert.DeserializeObject<List<TransactionModel>>(jsonRet);

                var acc = await client.GetAsync($"https://localhost:7242/api/Account/get-account/{id}");
                var jasonRetAcc = await acc.Content.ReadAsStringAsync();
                var desAcc = JsonConvert.DeserializeObject<AccountModel>(jasonRetAcc);

                ViewBag.AccountDetails = desAcc;
                ViewBag.Transactions = desTransactions;


                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
