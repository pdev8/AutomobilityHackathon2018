using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace automobility_api.Features.Auth.Models
{
     public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName {
            get {return $"{FirstName} {LastName}"; }
         }
        
    }
}