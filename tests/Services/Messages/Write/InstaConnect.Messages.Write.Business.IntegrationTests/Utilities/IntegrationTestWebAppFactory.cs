using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Data;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Testcontainers.MsSql;
using InstaConnect.Shared.Business.IntegrationTests;
using InstaConnect.Shared.Business.IntegrationTests.Extensions;
using InstaConnect.Messages.Write.Business.Consumers;

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

            serviceCollection.AddScoped(_ => Substitute.For<IMessageSender>());

            serviceCollection.AddMassTransitTestHarness(cfg => cfg.AddConsumer<UserDeletedEventConsumer>());
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
