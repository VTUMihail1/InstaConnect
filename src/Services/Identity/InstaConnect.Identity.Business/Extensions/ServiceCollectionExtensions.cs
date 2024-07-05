﻿using FluentValidation;
using InstaConnect.Identity.Business.Consumers;
using InstaConnect.Identity.Data;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddCachingHandler()
            .AddValidatorsFromAssembly(currentAssembly)
            .AddMediatR(currentAssembly)
            .AddAutoMapper(currentAssembly)
            .AddImageHandler(configuration)
            .AddMessageBroker(configuration, currentAssembly, busConfigurator => 
                busConfigurator.AddTransactionalOutbox<IdentityContext>());

        return serviceCollection;
    }
}
