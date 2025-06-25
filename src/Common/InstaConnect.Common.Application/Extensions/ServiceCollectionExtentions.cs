using System.Reflection;

using FluentValidation;

using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Application.PipelineBehaviors;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Application.Extensions;
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
                cf.AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>));
            });

        serviceCollection.AddScoped<IApplicationSender, ApplicationSender>();

        return serviceCollection;
    }

    public static IServiceCollection AddValidators(this IServiceCollection serviceCollection, Assembly assembly)
    {
        serviceCollection.AddValidatorsFromAssembly(assembly);

        serviceCollection.AddScoped<IEntityPropertyValidator, EntityPropertyValidator>();

        return serviceCollection;
    }
}
