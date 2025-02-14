using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Presentation.Features.Messages.Helpers;

namespace InstaConnect.Messages.Presentation.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSignalR();

        return serviceCollection;
    }
}
