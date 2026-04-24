using System.Reflection;

using InstaConnect.Common.Application.Features.Caching.PipelineBehaviors;
using InstaConnect.Common.Application.Features.Data.PipelineBehaviors;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Application.Features.Messaging.Helpers;
using InstaConnect.Common.Application.Features.Validations.Behaviors;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Application.Features.Messaging.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddCQRS(params Assembly[] assemblies)
        {
            serviceCollection.AddMediatR(
                cf =>
                {
                    cf.RegisterServicesFromAssemblies(assemblies);

                    cf.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                    cf.AddOpenBehavior(typeof(CachingPipelineBehavior<,>));
                    cf.AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>));
                });

            serviceCollection.AddScoped<IApplicationSender, ApplicationSender>();

            return serviceCollection;
        }
    }
}
