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
