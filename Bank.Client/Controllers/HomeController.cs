using Microsoft.AspNetCore.Mvc;
using Bank.Client.ViewModels;
using Bank.Client.Services;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace Bank.Client.Controllers
{
    
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IUserService _userSvc;

        public HomeController(IUserService userSvc)
        {
            _userSvc = userSvc;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("login failed!");
                }

                var a = await _userSvc.Login(model);
                HttpContext.Session.SetString("token", a);

                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Logged in view?

        //Transactions action
    }
}
