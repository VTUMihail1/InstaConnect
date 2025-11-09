using InstaConnect.Common.Tests.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;

using Xunit;

namespace InstaConnect.Posts.Tests.Utilities;

public class PostsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer;

    public PostsWebApplicationFactory()
    {
        _mongoDbContainer = ContainerFactory.GetMongoContainer();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddTestJwtAuth();
        });

        builder.UpdateDatabaseConnectionString(_mongoDbContainer.GetConnectionString());
    }

    public Task InitializeAsync()
    {
        return _mongoDbContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _mongoDbContainer.DisposeAsync().AsTask();
    }
}
