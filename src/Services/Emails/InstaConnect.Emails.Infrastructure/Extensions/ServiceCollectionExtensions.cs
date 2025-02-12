using InstaConnect.Emails.Infrastructure.Features.Emails.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddEmailServices(configuration);

        serviceCollection
            .AddRabbitMQ(configuration, currentAssembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
