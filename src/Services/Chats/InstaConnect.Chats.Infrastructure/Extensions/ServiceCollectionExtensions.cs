using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Chats.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection
                .AddUserServices()
                .AddChatServices()
                .AddChatMessageServices();

            serviceCollection
                .AddObservability(configuration, webHostEnvironment)
                .AddMapper(ChatInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
                .AddServicesWithMatchingInterfaces(ChatInfrastructureReference.Assembly)
                .AddMongoDbContext()
                .AddUnitOfWork()
                .AddRabbitMQ(configuration, ChatInfrastructureReference.Assembly)
                .AddJwtBearer(configuration)
                .AddGuidProvider()
                .AddDateTimeProvider()
                .AddSortOrders();

            return serviceCollection;
        }
    }
}
