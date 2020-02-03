using Microsoft.Extensions.DependencyInjection;
using Newsier.Application.Interfaces;
using Newsier.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Newsier.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<INewsierDbContext, NewsierDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("NewsierConnection"),
                    b => b.MigrationsAssembly(typeof(NewsierDbContext).Assembly.FullName)
               )
            );
            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
