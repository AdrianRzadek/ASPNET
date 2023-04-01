using ASP.Data;
using Microsoft.EntityFrameworkCore;



namespace ASP.Repository
{
    public class Configure
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "ApplicationDbContextModelSnapshot"));

            services.AddScoped(typeof(IRepositoryService<>),
          typeof(InMemoryRepository<>));


           
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
      

    }
}
