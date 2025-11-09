using Testcontainers.MongoDb;

namespace InstaConnect.Common.Tests.Utilities;
public static class ContainerFactory
{
    public static MongoDbContainer GetMongoContainer()
    {
        return new MongoDbBuilder()
            .WithImage("mongo:7.0")
            .Build();
    }
}
