using System.Reflection;

using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

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
                .AddMongo(configuration)
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
