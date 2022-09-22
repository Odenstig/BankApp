using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using Bank.Client.ViewModels;

namespace Bank.Client.Services
{
    public interface IUserService
    {
        Task<ResponseModel> Login(LoginModel model);
        Task<string> Create(CustomerModel model);
    }
    public class UserService : IUserService
    {
        private readonly string _loginUrl;
        private readonly string _createCustUrl;

        public UserService()
        {
            _loginUrl = "https://localhost:7242/api/User/login";
            _createCustUrl = "https://localhost:7242/api/User/register";
        }

        public async Task<ResponseModel> Login(LoginModel model)
        {
            try
            {
                using HttpClient client = new();

                string json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(_loginUrl, data);
                response.EnsureSuccessStatusCode();

                string jsonReturn = await response.Content.ReadAsStringAsync();


                var modelTest = JsonConvert.DeserializeObject<ResponseModel>(jsonReturn);
                return modelTest;
            }
            catch
            {
                throw new Exception("Failed to do stuff blah blah");
            }
        }

        public async Task<string> Create(CustomerModel model)
        {
            try
            {
                using HttpClient client = new();

                string json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpContextAccessor a = new();
                var b = a.HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + b);

                HttpResponseMessage response = await client.PostAsync(_createCustUrl, data);
                if (!response.IsSuccessStatusCode)
                    return "Failed!";

                return "Success!";
            }
            catch
            {
                throw new Exception("Failed to do stuff blah blah");
            }
        }
    }
}
