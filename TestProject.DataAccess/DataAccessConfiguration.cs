using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DataAccess
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlite(
                    configuration.GetConnectionString("DatabaseConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
    
}
