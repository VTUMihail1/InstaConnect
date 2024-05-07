using InstaConnect.Shared.Business.Models.Options;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Consumers;
using InstaConnect.Users.Business.Helpers;
using InstaConnect.Users.Business.Profiles;
using InstaConnect.Users.Business.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        serviceCollection
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<ICurrentUserContext, CurrentUserContext>();

        serviceCollection.AddHttpContextAccessor();

        serviceCollection.AddAutoMapper(currentAssembly);

        serviceCollection.AddMediatR(cf => cf.RegisterServicesFromAssembly(currentAssembly));

        serviceCollection.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<GetCurrentUserByIdConsumer>();
            busConfigurator.AddConsumer<ValidateUserByIdConsumer>();
            busConfigurator.AddConsumer<ValidateUserIdConsumer>();

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
