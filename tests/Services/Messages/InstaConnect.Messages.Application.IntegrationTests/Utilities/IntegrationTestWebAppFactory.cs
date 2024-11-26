using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Infrastructure;
using InstaConnect.Shared.Application.IntegrationTests.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Testcontainers.MsSql;

namespace InstaConnect.Messages.Application.IntegrationTests.Utilities;

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
            serviceCollection.AddTestDbContext<MessagesContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));

            serviceCollection.AddMassTransitTestHarness();

            var descriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(IMessageSender));

            if (descriptor != null)
            {
                serviceCollection.Remove(descriptor);
            }

            serviceCollection.AddScoped(_ => Substitute.For<IMessageSender>());
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
