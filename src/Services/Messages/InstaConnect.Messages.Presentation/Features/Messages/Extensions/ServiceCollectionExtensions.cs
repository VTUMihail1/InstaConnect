namespace InstaConnect.Messages.Web.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSignalR();

        return serviceCollection;
    }
}
