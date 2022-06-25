namespace Bank.Client.ViewModels
{
    public class DispositionModel
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; } = null!;
    }
}
