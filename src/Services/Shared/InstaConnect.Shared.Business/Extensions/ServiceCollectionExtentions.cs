using System.Reflection;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Options;
using InstaConnect.Shared.Business.PipelineBehaviors;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Business.Extensions;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Assembly currentAssembly,
        Action<IBusRegistrationConfigurator>? configure = null
        )
    {
        serviceCollection
            .AddOptions<MessageBrokerOptions>()
            .BindConfiguration(nameof(MessageBrokerOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var messageBrokerOptions = configuration
            .GetSection(nameof(MessageBrokerOptions))
            .Get<MessageBrokerOptions>()!;

        serviceCollection.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumers(currentAssembly);

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(messageBrokerOptions.Host), h =>
                {
                    h.Username(messageBrokerOptions.Username);
                    h.Password(messageBrokerOptions.Password);
                });

                configurator.ConfigureEndpoints(context);
            });

            configure?.Invoke(busConfigurator);
        });

        return serviceCollection;
    }

    public static IServiceCollection AddMediatR(this IServiceCollection serviceCollection, Assembly assembly)
    {
        serviceCollection.AddMediatR(
            cf =>
            {
                cf.RegisterServicesFromAssembly(assembly);

                cf.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
                cf.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                cf.AddOpenBehavior(typeof(CachingPipelineBehavior<,>));
            });

        return serviceCollection;
    }

    public static IServiceCollection AddCachingHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IJsonConverter, JsonConverter>()
            .AddScoped<ICacheHandler, CacheHandler>();

        return serviceCollection;
    }
}
