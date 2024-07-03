﻿using FluentValidation;
using InstaConnect.Posts.Write.Business.Consumers;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Write.Business.Extensions;

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
            .AddMessageBroker(configuration, currentAssembly);

        return serviceCollection;
    }
}
