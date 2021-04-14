using Microsoft.AspNetCore.Identity;

namespace Core.Entity.identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public Address Address { get; set; }

    }

}

    