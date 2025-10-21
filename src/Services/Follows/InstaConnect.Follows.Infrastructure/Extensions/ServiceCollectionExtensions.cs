using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Extensions;

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
            .AddUserServices()
            .AddFollowServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddMapper(FollowInfrastructureReference.Assembly)
            .AddServicesWithMatchingInterfaces(FollowInfrastructureReference.Assembly)
            .AddMongoDbContext()
            .AddUnitOfWork()
            .AddRabbitMQ(configuration, FollowInfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
