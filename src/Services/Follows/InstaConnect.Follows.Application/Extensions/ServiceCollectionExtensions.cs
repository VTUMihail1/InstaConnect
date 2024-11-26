using InstaConnect.Follows.Application.Features.Follows.Extensions;
using InstaConnect.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddFollowServices();

        serviceCollection
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddValidators(currentAssembly);

        return serviceCollection;
    }
}
