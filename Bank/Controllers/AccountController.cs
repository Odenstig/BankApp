using Bank.Core.Interfaces;
using Bank.Domain.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accSvc;
        private readonly IDispositionService _dispSvc;
        private readonly IAccountTypeService _accTypeSvc;

        public AccountController(IAccountService accSvc, IDispositionService dispSvc, IAccountTypeService accTypeSvc)
        {
            _accSvc = accSvc;
            _dispSvc = dispSvc;
            _accTypeSvc = accTypeSvc;
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Route("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Failed to create account");


                AccountDTO acc = await _accSvc.Create(model);

                return Ok(acc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut]
        [Route("update-balance")]
        public async Task<IActionResult> UpdateBalance(AccountDTO model, decimal money)
        {
            try
            {
                if (model == null)
                    return BadRequest("Failed to create account");

                AccountDTO acc = await _accSvc.Update(model, money);

                return Ok(acc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("get-account/{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get account");

                AccountDTO acc = await _accSvc.Get(id);

                return Ok(acc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Route("create-account-type")]
        public async Task<IActionResult> CreateAccountType([FromBody] AccountTypeDTO model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Failed to create accounttype");


                AccountTypeDTO accType = await _accTypeSvc.Create(model);

                return Ok(accType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = /*"Identity.Application," + */JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("get-account-type/{id}")]
        public async Task<IActionResult> GetAccountType(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get accounttype");

                AccountTypeDTO acc = await _accTypeSvc.Get(id);

                return Ok(acc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-account-types")]
        public async Task<IActionResult> GetAllAccountTypes()
        {
            try
            {
                List<AccountTypeDTO> list = await _accTypeSvc.GetAll();

                if (list == null)
                    return BadRequest("Failed to get accounttypes");


                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Route("create-disposition")]
        public async Task<IActionResult> CreateDisposition([FromBody] DispositionDTO model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Failed to create account");


                DispositionDTO disp = await _dispSvc.Create(model);

                return Ok(disp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("get-disposition/{id}")]
        public async Task<IActionResult> GetDisposition(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get disposition");

                DispositionDTO disp = await _dispSvc.Get(id);

                return Ok(disp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("get-dispositions/{id}")]
        public async Task<IActionResult> GetDispositions(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Failed to get accounts");

                List<DispositionDTO> acc = await _dispSvc.GetAllSpecific(id);

                return Ok(acc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

