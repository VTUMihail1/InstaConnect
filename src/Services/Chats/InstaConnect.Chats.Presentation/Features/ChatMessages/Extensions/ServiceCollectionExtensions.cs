using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatMessageServices()
		{
			serviceCollection.AddSignalR();
			serviceCollection.AddScoped<IChatMessageNotificationService, ChatMessageNotificationService>();

			return serviceCollection;
		}
	}
}
