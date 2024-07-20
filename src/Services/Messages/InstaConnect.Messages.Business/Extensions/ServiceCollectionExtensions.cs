using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Helpers;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddValidators(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly);

        serviceCollection
            .AddScoped<IMessageSender, MessageSender>();

        return serviceCollection;
    }
}
