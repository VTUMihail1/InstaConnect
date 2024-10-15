using InstaConnect.Follows.Business.Features.Follows.Extensions;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddFollowServices();

        serviceCollection
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddValidators(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly);

        return serviceCollection;
    }
}
