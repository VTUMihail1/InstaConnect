using InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication MapChatMessageHub()
		{
			var options = application.Services.GetRequiredService<IOptions<ChatMessageOptions>>().Value;

			application.MapHub<ChatMessageHub>(options.HubRoute);

			return application;
		}
	}
}
