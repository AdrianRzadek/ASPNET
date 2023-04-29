using Microsoft.AspNetCore.Identity;

namespace ASP.Data
{
    public class ApplicationUser: IdentityUser
   { 
        public string CustomTag { get; set; } 
    }
    
}
