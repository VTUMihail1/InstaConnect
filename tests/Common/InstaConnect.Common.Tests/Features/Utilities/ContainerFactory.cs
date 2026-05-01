using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Common.Tests.Features.Utilities;

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

	public static RedisContainer GetRedisContainer()
	{
		return new RedisBuilder("redis:latest")
			.WithCleanUp(true)
			.Build();
	}
}
