﻿using MAS.Project.Persistence;
using MAS.Project.Repositories;
using MAS.Project.Services;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.Configuration;

public static class BackendServiceConfiguration
{
    public static IServiceCollection AddBackendServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Database"))
        );
        services.AddTransient<SampleDataService>();
        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
        return services;
    }
}