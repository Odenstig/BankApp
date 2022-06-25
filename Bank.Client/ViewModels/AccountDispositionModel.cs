using System.ComponentModel.DataAnnotations;

namespace Bank.Client.ViewModels
{
    public class AccountDispositionModel
    {
        [Required(ErrorMessage = "Required Field")]
        public string Frequency { get; set; } = null!;
        [Required(ErrorMessage = "Required Field")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public int? AccountTypesId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Type { get; set; } = null!;
    }
}
