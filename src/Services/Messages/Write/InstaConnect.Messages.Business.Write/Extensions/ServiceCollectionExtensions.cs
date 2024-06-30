﻿using FluentValidation;
using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Consumers;
using InstaConnect.Messages.Business.Helpers;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.Extensions;

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
             busConfigurator.AddConsumer<UserDeletedEventConsumer>());

        serviceCollection.AddScoped<IMessageSender, MessageSender>();

        return serviceCollection;
    }
}
