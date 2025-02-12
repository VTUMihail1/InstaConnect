using InstaConnect.Messages.Application.Features.Messages.Extensions;
using InstaConnect.Shared.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddMessageServices();

        serviceCollection
            .AddValidators(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly);

        return serviceCollection;
    }
}
