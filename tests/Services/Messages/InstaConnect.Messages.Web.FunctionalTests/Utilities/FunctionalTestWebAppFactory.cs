using InstaConnect.Messages.Business.Consumers.Users;
using InstaConnect.Messages.Data;
using InstaConnect.Shared.Web.FunctionalTests.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace InstaConnect.Messages.Web.FunctionalTests.Utilities;

public class FunctionalTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;

    public FunctionalTestWebAppFactory()
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

            serviceCollection.AddMassTransitTestHarness(cfg =>
            {
                cfg.AddConsumer<UserCreatedEventConsumer>();
                cfg.AddConsumer<UserUpdatedEventConsumer>();
                cfg.AddConsumer<UserDeletedEventConsumer>();
            });
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
