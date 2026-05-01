using InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication MapChatMessageHub()
		{
			application.MapHub<ChatMessageHub>(ChatMessageRoutes.Hub);

			return application;
		}
	}
}
