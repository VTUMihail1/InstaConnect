using System.Reflection;

using InstaConnect.Common.Infrastructure.Extensions;
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
        public IServiceCollection AddTestEventHarness(string connectionString, string prefix, params Assembly[] currentAssemblies)
        {
            serviceCollection.AddMassTransitTestEventHarness(connectionString, prefix, currentAssemblies);

            serviceCollection.AddScoped<ITestHarnessFactory>(_ => new TestHarnessFactory(connectionString, prefix, currentAssemblies));
            serviceCollection.AddScoped<IEventHarness, EventHarness>();

            return serviceCollection;
        }

        public IServiceCollection AddMockImageHandler()
        {
            serviceCollection.AddScoped(_ => Mocker.Mock<IImageHandler>());

            return serviceCollection;
        }

        internal IServiceCollection AddMassTransitTestEventHarness(string connectionString, string prefix, params Assembly[] currentAssemblies)
        {
            serviceCollection.AddMassTransitTestHarness(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatterWithPrefix(prefix);

                busConfigurator.AddConsumers(currentAssemblies);

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                    configurator.ConfigureEndpoints(context);
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
