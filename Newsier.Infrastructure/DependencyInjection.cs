﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsier.Application.Interfaces;
using Newsier.Infrastructure.Services;

namespace Newsier.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewsierContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("NewsierConnection"),
                    b => b.MigrationsAssembly(typeof(NewsierContext).Assembly.FullName)
               )
            );
            services.AddScoped<INewsierContext>(provider => provider.GetService<NewsierContext>());
            services.AddScoped<IDateTime, DateTimeService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEntitiesSearchService, EntitiesSearchService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
