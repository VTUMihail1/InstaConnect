using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Shared.Infrastructure.Extensions;

using MassTransit;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;

using Testcontainers.MsSql;

using Xunit;

namespace InstaConnect.Posts.Common.Tests.Features.Utilities;

public class PostsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;

    public PostsWebApplicationFactory()
    {
        _msSqlContainer = ContainerFactory.GetMsSqlContainer();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection
                 .AddTestDbContext<PostsContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()))
                 .AddTestEventHarness()
                 .AddTestJwtAuth();
        });
    }

    public Task InitializeAsync()
    {
        return _msSqlContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _msSqlContainer.DisposeAsync().AsTask();
    }
}
