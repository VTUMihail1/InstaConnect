using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;
using InstaConnect.Follows.Infrastructure.Helpers;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddDatabaseContext<FollowsContext>(configuration);

        serviceCollection
            .AddFollowServices()
            .AddUserServices();

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<FollowsContext>()
            .AddRabbitMQ(configuration, currentAssembly)
            .AddJwtBearer(configuration)
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
