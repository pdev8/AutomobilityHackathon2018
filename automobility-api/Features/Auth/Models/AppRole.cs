using Microsoft.AspNetCore.Identity;

namespace automobility_api.Features.Auth.Models
{
   public class AppRole : IdentityRole<int>
    {
        public AppRole() {}
        public AppRole(string name){
            Name = name;
        }

    }
}