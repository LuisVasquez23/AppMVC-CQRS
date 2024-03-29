﻿using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;

namespace Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<WebDbContext>( options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("devConnection"));

            });

            services.AddScoped<IDatabaseService, WebDbContext>();

            return services;
        }
    }
}
