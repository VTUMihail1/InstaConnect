using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatMessageClient CreateChatMessageClient()
		{
			return new ChatMessageClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
