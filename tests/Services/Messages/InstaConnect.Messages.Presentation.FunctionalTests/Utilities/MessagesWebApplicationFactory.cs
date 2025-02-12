using InstaConnect.Messages.Infrastructure;
using InstaConnect.Shared.Infrastructure.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Utilities;

public class MessagesWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;

    public MessagesWebApplicationFactory()
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
            serviceCollection.AddTestDbContext<MessagesContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));
            serviceCollection.AddTestJwtAuth();

            serviceCollection.AddMassTransitTestHarness();
        });
    }

    public async Task InitializeAsync()
    {
        await _msSqlContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _msSqlContainer.StopAsync();
        await _msSqlContainer.DisposeAsync();
    }
}
