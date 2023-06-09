using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ASP.Models;
using ASP.Data;
using ASP.Areas.Users.Controllers;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ASP.Areas.Identity.Pages.Account.Manage;
/*
namespace ASP.Test
{
    public class ControllerTests
    {

        public static DbContextOptions<ApplicationDbContext> TestDbContextOptions()
        {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        public async virtual Task Delete(int id)
        {
            var message = await Name.FindAsync(id);

            if (message != null)
            {
                Name.Remove(message);
                await SaveChangesAsync();
            }
        }



    }
    
    
}
*/