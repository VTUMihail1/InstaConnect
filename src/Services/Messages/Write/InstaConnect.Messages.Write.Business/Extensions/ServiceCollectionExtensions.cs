using FluentValidation;
using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Business.Helpers;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddValidators(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddMapper(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly, busConfigurator => 
                busConfigurator.AddTransactionalOutbox<MessagesContext>());

        serviceCollection
            .AddScoped<IMessageSender, MessageSender>();

        return serviceCollection;
    }
}
