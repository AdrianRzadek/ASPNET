using ASP.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.Models;
using ASP.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
            //options.
        }

        public DbSet<VehicleViewModel> Vehicles { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<RentalPointViewModel> RentalPoints { get; set; }
        public DbSet<ReservationViewModel> Reservations { get; set; }

        public void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Dodaj role
            builder.Entity<Administrator>().HasData(new Administrator());
            builder.Entity<Operator>().HasData(new Operator());
            builder.Entity<Użytkownik>().HasData(new Użytkownik());

            // Dodaj konto admina
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                UserName = "Admin"

            });

            // Przypisz rolę Administrator do konta admina
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {

                UserId = "admin-id"
            });

        }
    }
}