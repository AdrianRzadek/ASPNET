using ASP.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.Models;

namespace ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
            //options.
        }

        public DbSet<Vehicle_> Vehicles { get; set; }
       public DbSet<VehicleType> VehicleTypes { get; set; }
       public DbSet<RentalPoint> RentalPoints { get; set; }
       public DbSet<Reservation> Reservations { get; set; }

      

    }
}