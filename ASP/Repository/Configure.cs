using ASP.App_Start;
using ASP.Controllers;
using ASP.Data;
using ASP.Models;
using Microsoft.EntityFrameworkCore;



namespace ASP.Repository
{
    public class Configure
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "ApplicationDbContextModelSnapshot"));
           
            services.AddScoped(typeof(IRepositoryService<>));
            services.AddScoped(typeof(InMemoryRepository<>)); 
            services.AddScoped(typeof(RepositoryService<>));

           
            services.AddControllersWithViews();
        
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(typeof(Program));

            services.AddMvc();

         

        }


    }
}
