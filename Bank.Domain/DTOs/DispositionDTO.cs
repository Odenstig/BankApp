namespace Bank.Domain.DTOs
{
    public class DispositionDTO
    {

        public int DispositionId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; } = null!;

    }
}
