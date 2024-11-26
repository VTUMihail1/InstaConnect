using InstaConnect.Messages.Infrastructure.Features.Messages.Extensions;
using InstaConnect.Messages.Infrastructure.Features.Users.Extensions;
using InstaConnect.Messages.Infrastructure.Helpers;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddMessageServices()
            .AddUserServices();

        serviceCollection
            .AddDatabaseContext<MessagesContext>(configuration);

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<MessagesContext>()
            .AddRabbitMQ(configuration, currentAssembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
