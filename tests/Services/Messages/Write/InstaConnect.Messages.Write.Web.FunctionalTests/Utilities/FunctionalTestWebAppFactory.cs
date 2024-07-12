using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Data;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Web.FunctionalTests.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Testcontainers.MsSql;
using WebMotions.Fake.Authentication.JwtBearer;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;

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
            var getUserBySenderIdResponse = new GetUserByIdResponse
            {
                Id = MessageFunctionalTestConfigurations.EXISTING_SENDER_ID,
                UserName = MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME
            };

            var getUserByReceiverIdResponse = new GetUserByIdResponse
            {
                Id = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_ID,
                UserName = MessageFunctionalTestConfigurations.EXISTING_RECEIVER_NAME
            };

            serviceCollection.AddTestDbContext<MessagesContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));
            serviceCollection.AddTestJwtAuth();
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
