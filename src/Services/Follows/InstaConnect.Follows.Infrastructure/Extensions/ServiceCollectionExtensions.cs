using System.Reflection;

using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;
using InstaConnect.Follows.Infrastructure.Utilities;

namespace InstaConnect.Follows.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment,
            Assembly presentationAssembly)
        {
            serviceCollection
                .AddUserServices()
                .AddFollowServices();

            serviceCollection
                .AddOpenTelemetry(configuration, webHostEnvironment)
                .AddMapper(FollowsInfrastructureReference.Assembly)
                .AddServicesWithMatchingInterfaces(FollowsInfrastructureReference.Assembly)
                .AddMongo(configuration)
                .AddUnitOfWork()
                .AddRabbitMQ(configuration, FollowsEventHandlerUtilities.Prefix, presentationAssembly)
                .AddJwtBearer(configuration)
                .AddGuidProvider()
                .AddDateTimeProvider()
                .AddSortOrders();

            return serviceCollection;
        }
    }
}
