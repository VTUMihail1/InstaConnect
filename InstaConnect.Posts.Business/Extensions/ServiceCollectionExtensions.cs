using InstaConnect.Posts.Business.Profiles;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(PostsBusinessProfile));

            serviceCollection.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_HOST")!), h =>
                    {
                        h.Username(Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER")!);
                        h.Password(Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS")!);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });

            return serviceCollection;
        }
    }
}
