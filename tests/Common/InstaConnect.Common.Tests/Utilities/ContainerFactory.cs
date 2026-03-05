using DotNet.Testcontainers.Builders;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

namespace InstaConnect.Common.Tests.Utilities;

public static class ContainerFactory
{
    public static MongoDbContainer GetMongoDbContainer()
    {
        return new MongoDbBuilder()
           .WithImage("mongo:7.0")
           .WithReplicaSet()
           .WithCleanUp(true)
           .Build();
    }

    public static RabbitMqContainer GetRabbitMqContainer()
    {
        return new RabbitMqBuilder()
            .WithImage("rabbitmq:3.13-management")
            .WithCleanUp(true)
            .Build();
    }
}
