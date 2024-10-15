using InstaConnect.Follows.Data;
using InstaConnect.Shared.Business.IntegrationTests.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace InstaConnect.Follows.Business.IntegrationTests.Utilities;

public class FollowsIntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;

    public FollowsIntegrationTestWebAppFactory()
    {
        _msSqlContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithPassword("Password123!")
        .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddTestDbContext<FollowsContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));

            serviceCollection.AddMassTransitTestHarness();
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
