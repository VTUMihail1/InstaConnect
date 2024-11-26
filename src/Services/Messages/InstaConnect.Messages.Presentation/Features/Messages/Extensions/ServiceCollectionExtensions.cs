using InstaConnect.Messages.Business.Features.Messages.Abstractions;
using InstaConnect.Messages.Business.Features.Messages.Helpers;

namespace InstaConnect.Messages.Web.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSignalR();

        serviceCollection
            .AddScoped<IMessageSender, MessageSender>();

        return serviceCollection;
    }
}
