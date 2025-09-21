using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.AspNetCore.Hosting;
using InstaConnect.Messages.Infrastructure;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddDatabaseContext<ChatsContext>(configuration);

        serviceCollection
            .AddUserServices()
            .AddChatServices()
            .AddChatMessageServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddServicesWithMatchingInterfaces(ChatInfrastructureReference.Assembly)
            .AddUnitOfWork<ChatsContext>()
            .AddRabbitMQ(configuration, ChatInfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddGuidProvider()
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
