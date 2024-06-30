using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Identity.Business.Consumers;
using FluentValidation;

namespace InstaConnect.Identity.Business.Extensions;

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
            busConfigurator.AddConsumer<GetUserByIdConsumer>());

        return serviceCollection;
    }
}
