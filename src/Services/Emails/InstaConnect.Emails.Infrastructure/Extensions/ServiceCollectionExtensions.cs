using InstaConnect.Emails.Business.Features.Emails.Extensions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddEmailServices(configuration);

        serviceCollection
            .AddMessageBroker(configuration, currentAssembly)
            .AddJwtBearer(configuration);

        return serviceCollection;
    }
}
