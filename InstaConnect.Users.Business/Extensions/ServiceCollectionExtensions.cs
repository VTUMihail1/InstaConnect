using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Consumers;
using InstaConnect.Users.Business.Helpers;
using InstaConnect.Users.Business.Profiles;
using InstaConnect.Users.Business.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InstaConnect.Users.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<ICurrentUserContext, CurrentUserContext>()
                .AddHttpContextAccessor()
                .AddAutoMapper(typeof(UsersBusinessProfile));

            serviceCollection.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumer<GetUserByIdConsumer>();
                busConfigurator.AddConsumer<ValidateUserByIdConsumer>();
                busConfigurator.AddConsumer<GetCurrentUserDetailsConsumer>();

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
