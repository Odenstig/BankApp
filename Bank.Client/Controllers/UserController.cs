using Microsoft.AspNetCore.Mvc;
using Bank.Client.ViewModels;
using Bank.Client.Services;

namespace Bank.Client.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userSvc;

        public UserController(IUserService userSvc)
        {
            _userSvc = userSvc;
        }

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
    }
}
