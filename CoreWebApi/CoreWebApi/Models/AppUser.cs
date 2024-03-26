using Microsoft.AspNetCore.Identity;

namespace CoreWebApi.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}
