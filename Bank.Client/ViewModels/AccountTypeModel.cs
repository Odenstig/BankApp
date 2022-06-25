using System.ComponentModel.DataAnnotations;

namespace Bank.Client.ViewModels
{
    public class AccountTypeModel
    {
        [Required(ErrorMessage = "Required Field")]
        public string TypeName { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public decimal? Interest { get; set; }
    }
}
