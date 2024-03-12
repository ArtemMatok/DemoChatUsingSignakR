using Microsoft.AspNetCore.Identity;

namespace DemoChat.Authentication
{
    public class AppUser :IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
