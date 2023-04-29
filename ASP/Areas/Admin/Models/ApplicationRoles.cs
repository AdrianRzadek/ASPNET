using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace ASP.Areas.Admin.Models
{
    public class Administrator : IdentityRole
    {
        public Administrator()
        {
            Name = "Administrator";
        }
    }

    public class Operator : IdentityRole
    {
        public Operator()
        {
            Name = "Operator";
        }
    }

    public class Użytkownik : IdentityRole
    {
        public Użytkownik()
        {
            Name = "Użytkownik";
        }
    }

}
