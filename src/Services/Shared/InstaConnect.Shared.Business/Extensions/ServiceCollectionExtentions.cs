﻿using System.Reflection;
using CloudinaryDotNet;
using FluentValidation;
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

        serviceCollection
            .AddScoped<IEventPublisher, EventPublisher>();

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

        serviceCollection.AddScoped<IInstaConnectSender, InstaConnectSender>();

        return serviceCollection;
    }

    public static IServiceCollection AddMapper(this IServiceCollection serviceCollection, Assembly assembly)
    {
        serviceCollection.AddAutoMapper(assembly);

        serviceCollection.AddScoped<IInstaConnectMapper, InstaConnectMapper>();

        return serviceCollection;
    }

    public static IServiceCollection AddValidators(this IServiceCollection serviceCollection, Assembly assembly)
    {
        serviceCollection.AddValidatorsFromAssembly(assembly);

        serviceCollection.AddScoped<IEntityPropertyValidator, EntityPropertyValidator>();
        serviceCollection.AddScoped<IEnumValidator, EnumValidator>();

        return serviceCollection;
    }

    public static IServiceCollection AddImageHandler(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<ImageUploadOptions>()
            .BindConfiguration(nameof(ImageUploadOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var imageUploadOptions = configuration
            .GetSection(nameof(ImageUploadOptions))
            .Get<ImageUploadOptions>()!;

        serviceCollection.AddScoped(_ => new Cloudinary(new Account(
            imageUploadOptions.CloudName,
            imageUploadOptions.ApiKey,
            imageUploadOptions.ApiSecret)));

        serviceCollection
            .AddScoped<IImageUploadFactory, ImageUploadFactory>()
            .AddScoped<IImageHandler, ImageHandler>();

        return serviceCollection;
    }
}
