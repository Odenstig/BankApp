using Bank.Client.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Bank.Client.Services
{
    public interface IAccountService
    {
        Task<string> CreateAccountType(AccountTypeModel model);
        Task<string> CreateAccount(AccountDispositionModel model);
    }
    public class AccountService : IAccountService
    {
        private readonly string _createAccTypeUrl;
        private readonly string _createAccUrl;
        private readonly string _createDispUrl;

        public AccountService()
        {
            _createAccTypeUrl = "https://localhost:7242/api/Account/create-account-type";
            _createAccUrl = "https://localhost:7242/api/Account/create-account";
            _createDispUrl = "https://localhost:7242/api/Account/create-disposition";
        }
        public async Task<string> CreateAccountType(AccountTypeModel model)
        {
            try
            {
                using HttpClient client = new();

                string json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpContextAccessor a = new();

                if (a.HttpContext.Session.GetString("token") != null)
                {
                    var b = a.HttpContext.Session.GetString("token");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + b);
                }

                HttpResponseMessage response = await client.PostAsync(_createAccUrl, data);
                if (!response.IsSuccessStatusCode)
                    return "Failed!";

                return "Success!";
            }
            catch
            {
                throw new Exception("Failed to do stuff blah blah");
            }
        }

        public async Task<string> CreateAccount(AccountDispositionModel model)
        {
            try
            {
                using HttpClient client = new();

                var acc = new AccountModel()
                {
                    AccountTypesId = model.AccountTypesId,
                    Balance = model.Balance,
                    Created = model.Created,
                    Frequency = model.Frequency
                };

                string json = JsonConvert.SerializeObject(acc);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpContextAccessor a = new();
                if (a.HttpContext.Session.GetString("token") != null)
                {
                    var b = a.HttpContext.Session.GetString("token");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + b);
                };

                HttpResponseMessage response = await client.PostAsync(_createAccTypeUrl, data);
                if (!response.IsSuccessStatusCode)
                    return "Failed!";

                string jsonReturn = await response.Content.ReadAsStringAsync();

                AccountModel modelTest = JsonConvert.DeserializeObject<AccountModel>(jsonReturn);

                DispositionModel dispModel = new()
                {
                    AccountId = modelTest.AccountId,
                    CustomerId = model.CustomerId,
                    Type = "OWNER"
                };

                string dispJson = JsonConvert.SerializeObject(dispModel);
                var dispData = new StringContent(dispJson, Encoding.UTF8, "application/json");

                HttpResponseMessage dispResponse = await client.PostAsync(_createDispUrl, dispData);
                if (!dispResponse.IsSuccessStatusCode)
                    return "Failed!"; ;

                return "Success!";
            }
            catch
            {
                throw new Exception("Failed to do stuff blah blah");
            }
        }
    }
}
