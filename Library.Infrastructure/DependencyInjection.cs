using Hangfire;
using Library.Core.Repositories;
using Library.Core.ServicesInterfaces;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Repositories;
using Library.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataAccess(configuration)
            .AddRepositories()
            .AddEmailService()
            .AddHangfireService(configuration);

        return services;
    }

    private static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration) 
    {
        var connectionString = configuration.GetConnectionString("librarydb");
        services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(connectionString));
            
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    private static IServiceCollection AddHangfireService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("hangfiredb");
        services.AddHangfire(opt =>
        {
            opt.UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString);
        });

        services.AddHangfireServer(x => x.SchedulePollingInterval = TimeSpan.FromSeconds(10));
        return services;
    }

    private static IServiceCollection AddEmailService(this IServiceCollection services)
    {
        services.AddSingleton<IEmailService, EmailService>();
        return services;
    }
}
