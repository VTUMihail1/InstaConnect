using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddInfrastructure(
			IConfiguration configuration,
			IWebHostEnvironment webHostEnvironment)
		{
			serviceCollection
				.AddUserServices()
				.AddChatServices()
				.AddChatMessageServices();

			serviceCollection
				.AddOpenTelemetry(configuration, webHostEnvironment)
				.AddMapper(ChatsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddServicesWithMatchingInterfaces(ChatsInfrastructureReference.Assembly)
				.AddMongo<IChatsContext>(configuration)
				.AddRabbitMQ(configuration, ChatsEventHandlerUtilities.Prefix, ChatsInfrastructureReference.Assembly)
				.AddJwtBearer(configuration)
				.AddRedis(configuration)
				.AddSignalR(configuration)
				.AddGuidProvider()
				.AddDateTimeProvider()
				.AddSortOrders();

			return serviceCollection;
		}
	}
}
