using InstaConnect.Chats.Presentation.Extensions;
using InstaConnect.Chats.Presentation.Features.Users.EventHandlers;
using InstaConnect.Chats.Presentation.Utilities;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Tests.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

using Xunit;

namespace InstaConnect.Chats.Tests.Utilities;

public class ChatsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer;
    private readonly RabbitMqContainer _rabbitMqContainer;

    public ChatsWebApplicationFactory()
    {
        _mongoDbContainer = ContainerFactory.GetMongoDbContainer();
        _rabbitMqContainer = ContainerFactory.GetRabbitMqContainer();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddTestJwtAuth();
            serviceCollection.AddTestEventHarness(_rabbitMqContainer.GetConnectionString(), ChatsPresentationReference.Assembly, (configurator, context) => configurator.ReceiveEndpoint<UserAddedEventHandler>(context, ChatsEventHandlerUtilities.UserAdded)
                                                                                                                                                                        .ReceiveEndpoint<UserUpdatedEventHandler>(context, ChatsEventHandlerUtilities.UserUpdated)
                                                                                                                                                                        .ReceiveEndpoint<UserDeletedEventHandler>(context, ChatsEventHandlerUtilities.UserDeleted));
        });

        builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
        builder.UpdateRabbitMqConfiguration(_rabbitMqContainer.GetConnectionString());
        builder.UpdateAccessTokenConfiguration();
        builder.UpdateOpenTelemetryConfiguration();
        builder.UpdateCorsConfiguration();
    }

    public async Task InitializeAsync()
    {
        await _mongoDbContainer.StartAsync();
        await _rabbitMqContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _mongoDbContainer.DisposeAsync().AsTask();
        await _rabbitMqContainer.DisposeAsync().AsTask();
    }
}
