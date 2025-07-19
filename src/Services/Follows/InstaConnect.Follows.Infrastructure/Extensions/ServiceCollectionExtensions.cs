using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Follows.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddDatabaseContext<FollowsContext>(configuration);

        serviceCollection
            .AddFollowServices()
            .AddUserServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
            .AddUnitOfWork<FollowsContext>()
            .AddRabbitMQ(configuration, InfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddGuidProvider()
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
