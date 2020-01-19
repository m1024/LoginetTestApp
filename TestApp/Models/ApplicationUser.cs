using Microsoft.AspNetCore.Identity;

namespace TestApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
    }
}
