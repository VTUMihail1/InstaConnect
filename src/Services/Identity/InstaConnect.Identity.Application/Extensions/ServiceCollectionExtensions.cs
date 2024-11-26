using InstaConnect.Identity.Application.Features.Users.Extensions;
using InstaConnect.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddUserServices();

        serviceCollection
            .AddValidators(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly);

        return serviceCollection;
    }
}
