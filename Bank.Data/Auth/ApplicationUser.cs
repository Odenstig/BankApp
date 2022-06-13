using Microsoft.AspNetCore.Identity;

namespace Bank.Data.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public int CustomerId { get; set; }
    }
}
