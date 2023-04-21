using ASP.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.Areas.Admin.Models
{
    public class AppDbContext : ApplicationDbContext
    {

        public AppDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
            //options.
        }

        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationRole> User { get; set; }


        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            // Tworzenie ról.
            var roles = new[] {
                new ApplicationRole { Name = "Administrator", Description = "Pełna kontrola nad systemem" },
                new ApplicationRole { Name = "Operator", Description = "Obsługa systemu" },
                new ApplicationRole { Name = "Użytkownik", Description = "Zwykły użytkownik systemu" }
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }

            // Tworzenie konta admina.
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin123!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, adminPassword);
            }

            if (!await userManager.IsInRoleAsync(adminUser, "Administrator"))
            {
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }

        }
    }
}
