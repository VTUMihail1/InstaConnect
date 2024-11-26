using InstaConnect.Follows.Data.Features.Follows.Extensions;
using InstaConnect.Follows.Data.Features.Users.Extensions;
using InstaConnect.Follows.Data.Helpers;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Data.Extensions;

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
            .AddMessageBroker(configuration, currentAssembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
