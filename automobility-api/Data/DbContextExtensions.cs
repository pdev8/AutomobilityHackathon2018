using automobility_api.Features.Auth.Models;
using Microsoft.AspNetCore.Identity;

namespace automobility_api.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }

        public static void EnsureSeeded(this DataContext context)
        {
            if (UserManager.FindByEmailAsync("ron@burgundy.com")
                .GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Ron",
                    LastName = "Burgundy",
                    UserName = "ron@burgundy.com",
                    Email = "ron@burgundy.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
            }
        }

    }
}