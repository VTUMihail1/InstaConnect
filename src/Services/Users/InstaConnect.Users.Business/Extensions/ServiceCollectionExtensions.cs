﻿using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Options;
using InstaConnect.Users.Business.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Users.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddOptions<MessageBrokerOptions>()
            .BindConfiguration(nameof(MessageBrokerOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var messageBrokerOptions = configuration.GetSection(nameof(MessageBrokerOptions)).Get<MessageBrokerOptions>()!;

        serviceCollection.AddHttpContextAccessor();

        serviceCollection
            .AddScoped<ICurrentUserContext, CurrentUserContext>();

        serviceCollection.AddAutoMapper(currentAssembly);

        serviceCollection.AddMediatR(cf => cf.RegisterServicesFromAssembly(currentAssembly));

        serviceCollection.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<GetUserByIdConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(messageBrokerOptions.Host), h =>
                {
                    h.Username(messageBrokerOptions.Username);
                    h.Password(messageBrokerOptions.Password);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        return serviceCollection;
    }
}
