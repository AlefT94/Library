using Library.Application.Books.Commands.CreateBook;
using Library.Application.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<CreateBookCommand>();
        });

        return services;
    }
}
