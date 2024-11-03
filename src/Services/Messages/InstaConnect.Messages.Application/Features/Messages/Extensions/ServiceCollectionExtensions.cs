using InstaConnect.Messages.Business.Features.Messages.Abstractions;
using InstaConnect.Messages.Business.Features.Messages.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IMessageSender, MessageSender>();

        return serviceCollection;
    }
}
