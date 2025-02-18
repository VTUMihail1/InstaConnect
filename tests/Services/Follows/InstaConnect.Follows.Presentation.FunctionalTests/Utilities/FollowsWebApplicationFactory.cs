using InstaConnect.Follows.Infrastructure;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;

using Testcontainers.MsSql;
using Testcontainers.RabbitMq;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Utilities;

public class FollowsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;
    private readonly RabbitMqContainer _rabbitMqContainer;

    public FollowsWebApplicationFactory()
    {
        _msSqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("Password123!")
            .Build();

        _rabbitMqContainer = new RabbitMqBuilder()
            .WithImage("rabbitmq:management")
            .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddTestDbContext<FollowsContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));
            serviceCollection.AddTestJwtAuth();

            serviceCollection.AddMassTransitTestHarness(busConfigurator =>
            {
                busConfigurator.AddConsumer<UserCreatedEventConsumer>();
                busConfigurator.AddConsumer<UserUpdatedEventConsumer>();
                busConfigurator.AddConsumer<UserDeletedEventConsumer>();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(_rabbitMqContainer.GetConnectionString());

                    configurator.ConfigureEndpoints(context);
                });
            });
        });
    }

    public Task InitializeAsync()
    {
        _rabbitMqContainer.StartAsync();
        return _msSqlContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        _rabbitMqContainer.DisposeAsync().AsTask();
        return _msSqlContainer.DisposeAsync().AsTask();
    }
}
