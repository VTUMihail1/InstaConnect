using InstaConnect.Common.Extensions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddEmailServices(configuration);

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
            .AddRabbitMQ(configuration, InfrastructureReference.Assembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
