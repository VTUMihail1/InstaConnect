using DotNet.Testcontainers.Builders;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

namespace InstaConnect.Common.Tests.Utilities;

public static class ContainerFactory
{
    public static MongoDbContainer GetMongoDbContainer()
    {
        return new MongoDbBuilder("mongo:latest")
           .WithReplicaSet()
           .WithCleanUp(true)
           .Build();
    }

    public static RabbitMqContainer GetRabbitMqContainer()
    {
        return new RabbitMqBuilder("rabbitmq:latest")
            .WithCleanUp(true)
            .Build();
    }
}
