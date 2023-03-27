using ASP.Data;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


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
        }
      

    }
}
