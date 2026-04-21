using System.Reflection;

using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;
using InstaConnect.Chats.Infrastructure.Utilities;

namespace InstaConnect.Chats.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment,
            Assembly presentationAssembly)
        {
            serviceCollection
                .AddUserServices()
                .AddChatServices()
                .AddChatMessageServices();

            serviceCollection
                .AddOpenTelemetry(configuration, webHostEnvironment)
                .AddMapper(ChatsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
                .AddServicesWithMatchingInterfaces(ChatsInfrastructureReference.Assembly)
                .AddMongoDatabase(configuration)
                .AddUnitOfWork()
                .AddRabbitMQ(configuration, ChatsEventHandlerUtilities.Prefix, presentationAssembly)
                .AddJwtBearer(configuration)
                .AddGuidProvider()
                .AddDateTimeProvider()
                .AddSortOrders();

            return serviceCollection;
        }
    }
}
