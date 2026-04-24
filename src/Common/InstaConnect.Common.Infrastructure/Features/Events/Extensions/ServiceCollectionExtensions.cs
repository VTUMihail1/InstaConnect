using System.Reflection;

using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Helpers;
using InstaConnect.Common.Infrastructure.Features.Events.Models;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddRabbitMQ(IConfiguration configuration, string prefix, params Assembly[] currentAssemblies)
        {
            serviceCollection.AddValidatedOptions<RabbitMqOptions>(RabbitMqOptions.SectionName);
            var options = configuration.GetOptions<RabbitMqOptions>(RabbitMqOptions.SectionName);

            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatterWithPrefix(prefix);

                busConfigurator.AddConsumers(currentAssemblies);

                busConfigurator.AddMongoDbOutbox(o =>
                {
                    o.ClientFactory(provider => provider.GetRequiredService<IMongoClient>());
                    o.DatabaseFactory(provider => provider.GetRequiredService<IMongoDatabase>());

                    o.UseBusOutbox();
                });

                busConfigurator.AddConfigureEndpointsCallback((context, name, cfg) =>
                {
                    cfg.UseMongoDbOutbox(context);
                });

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(options.ConnectionString);

                    configurator.ConfigureEndpoints(context);
                });
            });

            serviceCollection.AddScoped<IEventPublisher, EventPublisher>();

            return serviceCollection;
        }
    }
}
