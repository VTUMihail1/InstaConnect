using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

namespace InstaConnect.Common.Tests.Utilities;
public static class ContainerFactory
{
    public static MongoDbContainer GetMongoDbContainer()
    {
        return new MongoDbBuilder()
            .WithImage("mongo:latest")
            .WithReplicaSet()
            .WithCleanUp(true)
            .Build();
    }

    public static RabbitMqContainer GetRabbitMqContainer()
    {
        return new RabbitMqBuilder()
            .WithImage("rabbitmq:latest")
            .WithUsername("guest")
            .WithPassword("guest")
            .WithCleanUp(true)
            .Build();
    }
}
