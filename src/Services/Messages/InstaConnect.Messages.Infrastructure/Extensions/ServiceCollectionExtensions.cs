using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Extensions;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Chats.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddUserServices()
            .AddChatServices()
            .AddChatMessageServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddMapper(ChatInfrastructureReference.Assembly)
            .AddServicesWithMatchingInterfaces(ChatInfrastructureReference.Assembly)
            .AddMongoDbContext()
            .AddUnitOfWork()
            .AddRabbitMQ(configuration, ChatInfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
