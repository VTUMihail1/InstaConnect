using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;
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
            .AddUserServices()
            .AddFollowServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddServicesWithMatchingInterfaces(FollowInfrastructureReference.Assembly)
            .AddUnitOfWork<FollowsContext>()
            .AddRabbitMQ(configuration, FollowInfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddGuidProvider()
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
