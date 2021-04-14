using System.Linq;
using System.Threading.Tasks;
using Core.Entity.identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "jeeva",
                    Email = "rihivickey7@gmail.com",
                    UserName = "jeeva",
                    Address = new Address
                    {
                        FirstName = "jeeva",
                        LastName = "rishi",
                        Street = "3 cross street",
                        City = "Kanchipuram",
                        State = "Tamilnadu",
                        Zipcode = "631551"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}