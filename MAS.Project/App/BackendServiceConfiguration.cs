using MAS.Project.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.App;

public static class BackendServiceConfiguration
{
    public static IServiceCollection AddBackendServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Database"))
        );
        return services;
    }
}
