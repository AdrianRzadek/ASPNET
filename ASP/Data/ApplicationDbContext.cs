using ASP.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Evaluation;

namespace ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
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




    }
}