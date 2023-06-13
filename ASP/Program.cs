using ASP.App_Start;
using ASP.Data;
using ASP.Repository;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ASP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
          var builder = WebApplication.CreateBuilder(args);
          //     builder.Services.AddDbContext<ApplicationDbContext>(options =>
             //     options.UseInMemoryDatabase(databaseName: "ApplicationDbContextModelSnapshot"));



           // builder.Services.AddDbContext<ApplicationDbContext>(options =>
           //   options.UseInMemoryDatabase(databaseName: "ApplicationDbContextModelSnapshot"));

          
       //     builder.Services.AddScoped(typeof(InMemoryRepository<>));





            // Add services to the container.
             var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(connectionString));
             builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddScoped(typeof(RepositoryService<>));


            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddMvc();


            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(Program));

           var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Admin",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Users",
                  pattern: "{area:exists}/{controller=ReservationViewModelsController}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Users",
                  pattern: "{area:exists}/{controller=ReservationViewModelsController}/{action=Create}/{id?}"
                );
            });



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
              name: "Reservation",
              pattern: "{controller=ReservationViews}/{action=Index}/{id?}");



            app.MapRazorPages();

           using(var scope = app.Services.CreateScope())
            {
                var roleManager = 
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Administrator", "Operator", "U¿ytkownik" };

                foreach( var role in roles )
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "admin@gmail.com";
                string password = "Admin123,";
                if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;
                    user.EmailConfirmed = true;
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "operator@gmail.com";
                string password = "Operator123,";
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;
                    user.EmailConfirmed = true;
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Operator");
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "user@gmail.com";
                string password = "User123,";
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;
                    user.EmailConfirmed = true;
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "U¿ytkownik");
                }
            }


            app.Run();
        }
    }
}