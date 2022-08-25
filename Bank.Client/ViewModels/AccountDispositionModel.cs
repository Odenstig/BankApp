using System.ComponentModel.DataAnnotations;

namespace Bank.Client.ViewModels
{
    public class AccountDispositionModel
    {
        public string? Frequency { get; set; }
        public DateTime Created { get; set; }

        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public int? AccountTypesId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string? Type { get; set; }
    }
}
