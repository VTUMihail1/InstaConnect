using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class ContainerFactory
{
	public static MongoDbContainer GetMongoDbContainer()
	{
		return new MongoDbBuilder("mongo:8.0")
		   .WithReplicaSet()
		   .WithCleanUp(true)
		   .Build();
	}

	public static RabbitMqContainer GetRabbitMqContainer()
	{
		return new RabbitMqBuilder("rabbitmq:4.3")
			.WithCleanUp(true)
			.Build();
	}

	public static RedisContainer GetRedisContainer()
	{
		return new RedisBuilder("redis:7.4")
			.WithCleanUp(true)
			.Build();
	}
}
