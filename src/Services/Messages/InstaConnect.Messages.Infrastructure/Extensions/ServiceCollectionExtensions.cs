using InstaConnect.Common.Extensions;
using InstaConnect.Messages.Infrastructure.Features.Messages.Extensions;
using InstaConnect.Messages.Infrastructure.Features.Users.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Messages.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddMessageServices()
            .AddUserServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddDatabaseContext<MessagesContext>(configuration)
            .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
            .AddUnitOfWork<MessagesContext>()
            .AddRabbitMQ(configuration, InfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddGuidProvider()
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
