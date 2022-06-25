namespace Bank.Client.ViewModels
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string Frequency { get; set; } = null!;
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public int? AccountTypesId { get; set; }
    }
}
