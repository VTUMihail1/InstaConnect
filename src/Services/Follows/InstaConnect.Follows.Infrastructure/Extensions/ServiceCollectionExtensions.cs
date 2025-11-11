using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

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
            .AddGuidProvider()
            .AddDateTimeProvider()
            .AddSortOrders();

        return serviceCollection;
    }
}
