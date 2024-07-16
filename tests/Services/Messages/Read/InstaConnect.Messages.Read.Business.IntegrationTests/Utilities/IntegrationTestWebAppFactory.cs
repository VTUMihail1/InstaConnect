using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Business.Consumers.Users;
using InstaConnect.Messages.Read.Data;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.IntegrationTests.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;

    public IntegrationTestWebAppFactory()
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
            var getUserBySenderIdResponse = new GetUserByIdResponse
            {
                Id = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
                UserName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME
            };

            var getUserByReceiverIdResponse = new GetUserByIdResponse
            {
                Id = MessageIntegrationTestConfigurations.EXISTING_RECEIVER_ID,
                UserName = MessageIntegrationTestConfigurations.EXISTING_RECEIVER_NAME
            };

            serviceCollection.AddTestDbContext<MessagesContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));

            serviceCollection.AddTestGetUserByIdRequestClient(getUserBySenderIdResponse, getUserByReceiverIdResponse);

            serviceCollection.AddMassTransitTestHarness(cfg =>
            {
                cfg.AddConsumer<MessageCreatedEventConsumer>();
                cfg.AddConsumer<MessageUpdatedEventConsumer>();
                cfg.AddConsumer<MessageDeletedEventConsumer>();
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
