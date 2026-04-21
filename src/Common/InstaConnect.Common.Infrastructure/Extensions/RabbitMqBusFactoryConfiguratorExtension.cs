using MassTransit;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class RabbitMqBusFactoryConfiguratorExtension
{
    extension(IRabbitMqBusFactoryConfigurator configurator)
    {
        public IRabbitMqBusFactoryConfigurator ReceiveEndpoint<TConsumer>(
             IBusRegistrationContext context, string endpoint)
        where TConsumer : class, IConsumer
        {
            configurator.ReceiveEndpoint(endpoint, e =>
            {
                e.ConfigureConsumer<TConsumer>(context);
            });

            return configurator;
        }
    }
}
