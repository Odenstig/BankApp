using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]

        public int AccountTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Interest { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
