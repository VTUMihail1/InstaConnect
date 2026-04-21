using System.Reflection;

using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

using MassTransit;

namespace InstaConnect.Follows.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment,
            Assembly presentationAssembly,
            Action<IRabbitMqBusFactoryConfigurator, IBusRegistrationContext>? configureEndpoints = null)
        {
            serviceCollection
                .AddUserServices()
                .AddFollowServices();

            serviceCollection
                .AddOpenTelemetry(configuration, webHostEnvironment)
                .AddMapper(FollowsInfrastructureReference.Assembly)
                .AddServicesWithMatchingInterfaces(FollowsInfrastructureReference.Assembly)
                .AddMongoDatabase(configuration)
                .AddUnitOfWork()
                .AddRabbitMQ(configuration, presentationAssembly, configureEndpoints)
                .AddJwtBearer(configuration)
                .AddGuidProvider()
                .AddDateTimeProvider()
                .AddSortOrders();

            return serviceCollection;
        }
    }
}
