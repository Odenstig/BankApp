namespace Bank.Client.ViewModels
{
    public class AccountTypeResponseModel
    {
        public int AccountTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Interest { get; set; }
    }
}
