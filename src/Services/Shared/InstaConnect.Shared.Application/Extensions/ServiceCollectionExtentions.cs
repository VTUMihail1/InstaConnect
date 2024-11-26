using System.Reflection;
using FluentValidation;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.PipelineBehaviors;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Application.Extensions;
public static class ServiceCollectionExtentions
{
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

        return serviceCollection;
    }
}
