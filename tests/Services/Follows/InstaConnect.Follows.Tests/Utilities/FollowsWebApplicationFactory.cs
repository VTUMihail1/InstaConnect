using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Follows.Infrastructure.Utilities;
using InstaConnect.Follows.Presentation.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

using Xunit;

namespace InstaConnect.Follows.Tests.Utilities;

public class FollowsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer;
    private readonly RabbitMqContainer _rabbitMqContainer;

    public FollowsWebApplicationFactory()
    {
        _mongoDbContainer = ContainerFactory.GetMongoDbContainer();
        _rabbitMqContainer = ContainerFactory.GetRabbitMqContainer();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddTestJwtAuth();
            serviceCollection.AddTestEventHarness(_rabbitMqContainer.GetConnectionString(), FollowsEventHandlerUtilities.Prefix, FollowsPresentationReference.Assembly);
        });

        builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
        builder.UpdateRabbitMqConfiguration(_rabbitMqContainer.GetConnectionString());
        builder.UpdateAccessTokenConfiguration();
        builder.UpdateOpenTelemetryConfiguration();
        builder.UpdateCorsConfiguration();
    }

    public async Task InitializeAsync()
    {
        await _mongoDbContainer.StartAsync();
        await _rabbitMqContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _mongoDbContainer.DisposeAsync().AsTask();
        await _rabbitMqContainer.DisposeAsync().AsTask();
    }
}
