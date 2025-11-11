using System.Reflection;

using FluentValidation;

using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Application.PipelineBehaviors;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Application.Extensions;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddCQRS(this IServiceCollection serviceCollection, params Assembly[] assemblies)
    {
        serviceCollection.AddMediatR(
            cf =>
            {
                cf.RegisterServicesFromAssemblies(assemblies);

                cf.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
                cf.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                cf.AddOpenBehavior(typeof(CachingPipelineBehavior<,>));
                cf.AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>));
            });

        serviceCollection.AddScoped<IApplicationSender, ApplicationSender>();

        return serviceCollection;
    }

    public static IServiceCollection AddValidators(this IServiceCollection serviceCollection, params Assembly[] assemblies)
    {
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

        serviceCollection.AddValidatorsFromAssemblies(assemblies);

        return serviceCollection;
    }
}
