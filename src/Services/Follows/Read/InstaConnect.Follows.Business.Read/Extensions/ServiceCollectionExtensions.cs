using FluentValidation;
using InstaConnect.Follows.Business.Read.Consumers.Follows;
using InstaConnect.Follows.Business.Read.Consumers.Users;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Business.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddMemoryCache()
            .AddValidatorsFromAssembly(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddAutoMapper(currentAssembly)
            .AddCurrentUserContext()
            .AddMessageBroker(configuration, busConfigurator =>
            {
                busConfigurator.AddConsumer<UserCreatedEventConsumer>();
                busConfigurator.AddConsumer<UserUpdatedEventConsumer>();
                busConfigurator.AddConsumer<UserDeletedEventConsumer>();
                busConfigurator.AddConsumer<FollowCreatedEventConsumer>();
                busConfigurator.AddConsumer<FollowDeletedEventConsumer>();
            });

        return serviceCollection;
    }
}
