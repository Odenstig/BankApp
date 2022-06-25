using System.ComponentModel.DataAnnotations;

namespace Bank.Client.ViewModels
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Required Field")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string Givenname { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string Streetaddress { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string Zipcode { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public string CountryCode { get; set; } = null!;

        [Required(ErrorMessage = "Required Field")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string? Telephonecountrycode { get; set; }

        [Phone]
        [Required(ErrorMessage = "Required Field")]
        public string? Telephonenumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Required Field")]
        public string? Emailaddress { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string? Password { get; set; }
    }
}
