using InstaConnect.Messages.Infrastructure.Features.Messages.Extensions;
using InstaConnect.Messages.Infrastructure.Features.Users.Extensions;
using InstaConnect.Shared.Common.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

namespace InstaConnect.Messages.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddMessageServices()
            .AddUserServices();

        serviceCollection
            .AddDatabaseContext<MessagesContext>(configuration)
            .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
            .AddUnitOfWork<MessagesContext>()
            .AddRabbitMQ(configuration, InfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
