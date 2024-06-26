using InstaConnect.Messages.Business.Read.Consumers.Messages;
using InstaConnect.Messages.Business.Read.Consumers.Users;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddMediatR(currentAssembly)
            .AddAutoMapper(currentAssembly)
            .AddCurrentUserContext()
            .AddMessageBroker(configuration, busConfigurator =>
            {
                busConfigurator.AddConsumer<UserCreatedEventConsumer>();
                busConfigurator.AddConsumer<UserUpdatedEventConsumer>();
                busConfigurator.AddConsumer<UserDeletedEventConsumer>();
                busConfigurator.AddConsumer<MessageCreatedEventConsumer>();
                busConfigurator.AddConsumer<MessageDeletedEventConsumer>();
            });

        return serviceCollection;
    }
}
