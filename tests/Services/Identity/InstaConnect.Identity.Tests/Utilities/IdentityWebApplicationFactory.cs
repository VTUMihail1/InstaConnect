using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Presentation.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

using Xunit;

namespace InstaConnect.Identity.Tests.Utilities;

public class IdentityWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer;
    private readonly RabbitMqContainer _rabbitMqContainer;

    public IdentityWebApplicationFactory()
    {
        _mongoDbContainer = ContainerFactory.GetMongoDbContainer();
        _rabbitMqContainer = ContainerFactory.GetRabbitMqContainer();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddMockImageHandler();
            serviceCollection.AddTestJwtAuth();
            serviceCollection.AddTestEventHarness(_rabbitMqContainer.GetConnectionString(), IdentityPresentationReference.Assembly);
        });

        builder.UpdateDatabaseConnectionString(_mongoDbContainer.GetConnectionString());
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
