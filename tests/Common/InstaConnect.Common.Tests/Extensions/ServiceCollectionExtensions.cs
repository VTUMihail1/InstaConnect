using System.Reflection;

using InstaConnect.Common.Tests.Events;
using InstaConnect.Common.Tests.Utilities;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

using WebMotions.Fake.Authentication.JwtBearer;

namespace InstaConnect.Common.Tests.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddTestEventHarness(string connectionString, Assembly currentAssembly, Action<IRabbitMqBusFactoryConfigurator, IBusRegistrationContext>? configureEndpoints = null)
        {
            serviceCollection.AddMassTransitTestEventHarness(connectionString, currentAssembly, configureEndpoints);

            serviceCollection.AddScoped<ITestHarnessFactory>(_ => new TestHarnessFactory(connectionString, currentAssembly, configureEndpoints));
            serviceCollection.AddScoped<IEventHarness, EventHarness>();

            return serviceCollection;
        }

        public IServiceCollection AddMockImageHandler()
        {
            serviceCollection.AddScoped(_ => Mocker.Mock<IImageHandler>());

            return serviceCollection;
        }

        internal IServiceCollection AddMassTransitTestEventHarness(string connectionString, Assembly currentAssembly, Action<IRabbitMqBusFactoryConfigurator, IBusRegistrationContext>? configureEndpoints = null)
        {
            serviceCollection.AddMassTransitTestHarness(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumers(currentAssembly);

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                    configureEndpoints?.Invoke(configurator, context);
                });
            });

            return serviceCollection;
        }

        public IServiceCollection AddTestJwtAuth()
        {
            serviceCollection
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                })
                .AddFakeJwtBearer(opt => opt.BearerValueType = FakeJwtBearerBearerValueType.Jwt);

            return serviceCollection;
        }
    }
}
