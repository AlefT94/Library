using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataAccess(configuration);
        return services;
    }

    private static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration) 
    {
        var connectionString = configuration.GetConnectionString("librarydb");
        services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(connectionString));
            
        return services;
    }
}
