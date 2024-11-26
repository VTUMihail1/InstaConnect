using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
