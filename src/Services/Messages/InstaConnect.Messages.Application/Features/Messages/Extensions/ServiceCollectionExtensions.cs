using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Application.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
