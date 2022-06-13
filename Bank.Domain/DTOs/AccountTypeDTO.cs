namespace Bank.Domain.DTOs
{
    public class AccountTypeDTO
    {
        public int AccountTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Interest { get; set; }

    }
}
