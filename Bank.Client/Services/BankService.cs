using Bank.Client.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Bank.Client.Services
{
    public interface IBankService
    {
        Task<string> CreateTransaction(TransactionModel model);
    }
    public class BankService : IBankService
    {
        private readonly string _createTransactionUrl;
        
        public BankService()
        {
            _createTransactionUrl = "https://localhost:7242/api/Bank/create-transaction";
        }

        public async Task<string> CreateTransaction(TransactionModel model)
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

                HttpResponseMessage response = await client.PostAsync(_createTransactionUrl, data);
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
